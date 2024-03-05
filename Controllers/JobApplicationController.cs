//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Swarojgaar.Services.Implementation;
//using Swarojgaar.Services.Interface;
//using Swarojgaar.ViewModel.JobApplicationVM;
//using Swarojgaar.ViewModel.JobVM;
//using System.Security.Claims;
//using AutoMapper;

//namespace Swarojgaar.Controllers
//{
//    public class JobApplicationController : Controller
//    {
//        private readonly IJobApplicationService _jobApplicationService;
//        private readonly IJobService _jobService;
//        private readonly IMapper _mapper;

//        public JobApplicationController(IJobApplicationService jobApplicationService, IJobService jobService, IMapper mapper)
//        {
//            _jobService = jobService;
//            _jobApplicationService = jobApplicationService;
//            _mapper = mapper;
//        }
//        public IActionResult Index()
//        {
//            return View(_jobApplicationService.GetAllJobApplications());
//        }
//        [Authorize(Roles = "Job_Seeker")]
//        [HttpGet]
//        public IActionResult CreateJobApplication(int id)
//        {
//            return View(_jobService.GetJobDetails(id));
//        }

//        [Authorize]
//        [HttpPost]
//        public IActionResult CreateJobApplication(CreateJobApplicationVM createJobApplication)
//        {
//            try
//            {
//                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

//                //var username = User.Identity.Name;

//                var jobDetails = _jobService.GetJobDetails(createJobApplication.JobId);
//                _mapper.Map(jobDetails, createJobApplication);
//                _jobApplicationService.CreateJobApplication(createJobApplication, userId);
//                TempData["ResultOk"] = "Job Applied Successfully !";
//                return RedirectToAction("Index", "JobApplication");
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }

//    }
//}

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swarojgaar.Data;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.JobApplicationVM;

namespace Swarojgaar.Controllers
{
    [Authorize(Roles = "Job_Seeker")]
    public class JobApplicationController : Controller
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IGenericRepository<Job> _genericRepository;
        private readonly ApplicationDbContext _context;

        public JobApplicationController(
            IJobApplicationService jobApplicationService,
            IJobService jobService,
            IMapper mapper,
            ApplicationDbContext context,
            IGenericRepository<Job> genericRepository,
            UserManager<IdentityUser> userManager)
        {
            _genericRepository = genericRepository;
            _jobService = jobService;
            _jobApplicationService = jobApplicationService;
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Job_Seeker")]
        public IActionResult Index()
        {
            return View(_jobApplicationService.GetAllJobApplications());
        }

        [Authorize(Roles = "Job_Seeker")]
        [HttpGet]
        public IActionResult CreateJobApplication(string id)
        {
            return View(_jobService.GetJobDetails(id));
        }

        [Authorize(Roles = "Job_Seeker")]
        [HttpPost]
        public IActionResult CreateJobApplication(CreateJobApplicationVM createJobApplication)
        {
            
            try
            {
                // Get the current user's ID
                var userId = _userManager.GetUserId(User);
                var jobDetails = _genericRepository.GetDetails(createJobApplication.JobId);

                CreateJobApplicationVM createjob = new CreateJobApplicationVM()
                {
                    UserId = userId,
                    Title = jobDetails.Title,
                    Description = jobDetails.Description,
                    Salary = jobDetails.Salary,
                    ExpiryDate = jobDetails.ExpiryDate,
                    JobId = jobDetails.JobId
                };
                // Check if the user has already applied for the job
                var existingApplication = _context.JobApplications
                    .FirstOrDefault(j => j.JobId == jobDetails.JobId && j.UserId == userId);

                if (existingApplication != null)
                {
                    // User has already applied, you can redirect or show a message
                    TempData["ResultNotOk"] = "You have already applied for this job.";
                    return RedirectToAction("Index", "JobApplication");
                }
                else
                {
                    _jobApplicationService.CreateJobApplication(createjob);
                    TempData["ResultOk"] = "Job Applied Successfully !";
                    return RedirectToAction("Index", "JobApplication");
                }

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
