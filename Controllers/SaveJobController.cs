using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swarojgaar.Data;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.JobApplicationVM;
using Swarojgaar.ViewModel.SavedJobVM;

namespace Swarojgaar.Controllers
{
    [Authorize(Roles = "Job_Seeker")]
    public class SaveJobController : Controller
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly ISaveJobService _saveJobService;
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IGenericRepository<Job> _genericRepository;
        private readonly ApplicationDbContext _context;
        private readonly ISavedJobRepository _savedJobRepository;

        public SaveJobController(
            IJobApplicationService jobApplicationService,
            ISaveJobService saveJobService,
            IJobService jobService,
            IMapper mapper,
            ApplicationDbContext context,
            IGenericRepository<Job> genericRepository,
            UserManager<User> userManager,
            ISavedJobRepository savedJobRepository)
        {
            _jobApplicationService = jobApplicationService;
            _genericRepository = genericRepository;
            _jobService = jobService;
            _saveJobService = saveJobService;
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _savedJobRepository = savedJobRepository;
        }

        [Authorize(Roles = "Job_Seeker")]
        public IActionResult Index()
        {
            return View(_saveJobService.GetAllSavedJobs());
        }

        [Authorize(Roles = "Job_Seeker")]
        [HttpGet]
        public IActionResult SaveJob(string id)
        {
            return View(_jobService.GetJobDetails(id));
        }

        [Authorize(Roles = "Job_Seeker")]
        [HttpPost]
        public IActionResult SaveJob(SaveJobVM saveJobVm)
        {
            try
            {
                var userId = _userManager.GetUserId(User);

                var jobDetails = _genericRepository.GetDetails(saveJobVm.JobId);

                SaveJobVM saveJob = new SaveJobVM()
                {
                    UserId = userId,
                    Title = jobDetails.Title,
                    Description = jobDetails.Description,
                    Salary = jobDetails.Salary,
                    ExpiryDate = jobDetails.ExpiryDate,
                    JobId = jobDetails.JobId
                };

                var existingSaved = _context.SavedJobs
                    .FirstOrDefault(j => j.JobId == jobDetails.JobId && j.UserId == userId);

                if (existingSaved != null)
                {
                    // User has already applied, you can redirect or show a message
                    TempData["ResultNotOk"] = "You have already saved this job.";
                    return RedirectToAction("Index", "SaveJob");
                }
                else
                {
                    _saveJobService.SaveJob(saveJob, userId);
                    TempData["ResultOk"] = "Job Saved Successfully !";
                    return RedirectToAction("Index", "SaveJob");
                }

            }
            catch (Exception e)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine(e);
                TempData["ResultError"] = "An error occurred while saving the job.";
                return RedirectToAction("Index", "JobApplication");
            }
        }
        [Authorize(Roles = "Job_Seeker")]
        [HttpGet]
        public IActionResult ApplyAndRemove(int savedJobId)
        {
            return View(_saveJobService.GetSavedJobDetail(savedJobId));
        }
        [Authorize(Roles = "Job_Seeker")]
        [HttpPost]
        public IActionResult ApplyAndRemove(CreateJobApplicationVM createJobApplication, int savedJobId)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var userId = _userManager.GetUserId(User);

                var jobDetails = _savedJobRepository.GetBySavedJobId(savedJobId);


                CreateJobApplicationVM createjob = new CreateJobApplicationVM()
                {
                    UserId = userId,
                    Title = jobDetails.Title,
                    Description = jobDetails.Description,
                    Salary = jobDetails.Salary,
                    ExpiryDate = jobDetails.ExpiryDate,
                    JobId = jobDetails.JobId
                };
                _jobApplicationService.CreateJobApplication(createjob);
                _saveJobService.ApplyAndRemove(savedJobId, userId);
                transaction.Commit();
                TempData["ResultOk"] = "Job Applied Successfully !";
                return RedirectToAction("Index", "JobApplication");
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e);
                TempData["ResultError"] = "An error occurred while applying for the job.";
                return RedirectToAction("Index", "JobApplication");
            }
        }
        [Authorize(Roles = "Job_Seeker")]
        [HttpGet]
        public IActionResult DeleteSavedJob(int savedJobId)
        {
            return View(_saveJobService.GetSavedJobDetail(savedJobId));
        }
        [Authorize(Roles = "Job_Seeker")]
        [HttpPost, ActionName("DeleteSavedJob")]
        public IActionResult DeleteSaved(int savedJobId)
        {
            _saveJobService.DeleteSavedJob(savedJobId);
            TempData["ResultOk"] = "Saved Job Deleted Successfully !";
            return RedirectToAction("Index", "SaveJob");
        }
    }
}
