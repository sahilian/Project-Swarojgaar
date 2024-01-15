using Microsoft.AspNetCore.Mvc;
using Swarojgaar.Models;
using Swarojgaar.Services.Interface;
using System.Diagnostics;
using Swarojgaar.ViewModel.JobVM;

namespace Swarojgaar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobService _jobService;


        public HomeController(ILogger<HomeController> logger, IJobService jobService)
        {
            _logger = logger;
            _jobService = jobService;
        }

        [HttpGet]

        public IActionResult SearchJobs(string search_item)
        {
            var allJobs = _jobService.GetAllJobs();

            if (string.IsNullOrEmpty(search_item))
                return PartialView("_JobListPartial", allJobs);

            var results = allJobs.Where(j =>
                j.Title.ToLower().Contains(search_item)).ToList();

            return PartialView("_JobListPartial", results);
        }

        public IActionResult Index()
        {
            var allJobs = _jobService.GetAllJobs();
            return View(allJobs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
