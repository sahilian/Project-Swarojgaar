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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.JobApplicationVM;
using Swarojgaar.ViewModel.JobVM;
using System;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Swarojgaar.Controllers
{
    public class JobApplicationController : Controller
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly IJobService _jobService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public JobApplicationController(
            IJobApplicationService jobApplicationService,
            IJobService jobService,
            IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            _jobService = jobService;
            _jobApplicationService = jobApplicationService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_jobApplicationService.GetAllJobApplications());
        }

        [Authorize(Roles = "Job_Seeker")]
        [HttpGet]
        public IActionResult CreateJobApplication(int id)
        {
            return View(_jobService.GetJobDetails(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateJobApplication(CreateJobApplicationVM createJobApplication)
        {
            try
            {
                var userId = _userManager.GetUserId(User);

                var jobDetails = _jobService.GetJobDetails(createJobApplication.JobId);
                _mapper.Map(jobDetails, createJobApplication);

                _jobApplicationService.CreateJobApplication(createJobApplication, userId);
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
