using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swarojgaar.Data;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;
using Swarojgaar.Services.Implementation;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.JobApplicationVM;
using Swarojgaar.ViewModel.SavedJobVM;

namespace Swarojgaar.Controllers
{
    public class SaveJobController : Controller
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly ISaveJobService _saveJobService;
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
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
            UserManager<IdentityUser> userManager,
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

        public IActionResult Index()
        {
            return View(_saveJobService.GetAllSavedJobs());
        }

        [Authorize(Roles = "Job_Seeker")]
        [HttpGet]
        public IActionResult SaveJob(int id)
        {
            return View(_jobService.GetJobDetails(id));
        }

        [Authorize]
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
                _saveJobService.SaveJob(saveJob, userId);
                TempData["ResultOk"] = "Job Saved Successfully !";
                return RedirectToAction("Index", "SaveJob");
            }
            catch (Exception e)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine(e);
                TempData["ResultError"] = "An error occurred while saving the job.";
                return RedirectToAction("Index", "JobApplication");
            }
        }
        [HttpGet]
        public IActionResult ApplyAndRemove(int savedJobId)
        {
            return View(_saveJobService.GetSavedJobDetail(savedJobId));
        }

        [HttpPost]
        public IActionResult ApplyAndRemove(CreateJobApplicationVM createJobApplication, int savedJobId)
        {
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
                _jobApplicationService.CreateJobApplication(createjob, userId);
                _saveJobService.ApplyAndRemove(savedJobId, userId);
                TempData["ResultOk"] = "Job Applied Successfully !";
                return RedirectToAction("Index", "JobApplication");
            }
            catch (Exception e)
            {
                // Log the exception or handle it appropriately
                Console.WriteLine(e);
                TempData["ResultError"] = "An error occurred while applying for the job.";
                return RedirectToAction("Index", "JobApplication");
            }
        }
    }
}
