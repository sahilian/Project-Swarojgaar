using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swarojgaar.Services.Interface;

namespace Swarojgaar.Controllers
{
    [Authorize(Roles = "Job_Seeker")]
    public class SaveJobController : Controller
    {
        private readonly IJobService _jobService;

        public SaveJobController(IJobService jobService)
        {
            _jobService = jobService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SaveJob(int id)
        {
            return View(_jobService.GetJobDetails(id));
        }

    }
}
