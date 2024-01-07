using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swarojgaar.Services.Implementation;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.JobApplicationVM;
using Swarojgaar.ViewModel.JobVM;

namespace Swarojgaar.Controllers
{
    public class JobApplicationController : Controller
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly IJobService _jobService;

        public JobApplicationController(IJobApplicationService jobApplicationService, IJobService jobService)
        {
            _jobService = jobService;
            _jobApplicationService = jobApplicationService;
        }
        public IActionResult Index()
        {
            return View(_jobApplicationService.GetAllJobApplications());
        }
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
                var username = User.Identity.Name;
                _jobApplicationService.CreateJobApplication(createJobApplication);
                TempData["ResultOk"] = "Job Applied Successfully !";
                return RedirectToAction("Index", "JobApplication");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
       
    }
}
