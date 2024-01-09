using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swarojgaar.Data;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.SavedJobVM;

namespace Swarojgaar.Controllers
{
    public class SaveJobController : Controller
    {
        private readonly ISaveJobService _saveJobService;
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IGenericRepository<Job> _genericRepository;
        private readonly ApplicationDbContext _context;

        public SaveJobController(
            ISaveJobService saveJobService,
            IJobService jobService,
            IMapper mapper,
            ApplicationDbContext context,
            IGenericRepository<Job> genericRepository,
            UserManager<IdentityUser> userManager)
        {
            _genericRepository = genericRepository;
            _jobService = jobService;
            _saveJobService = saveJobService;
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
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
    }
}
