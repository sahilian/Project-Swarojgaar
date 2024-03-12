using Microsoft.AspNetCore.Mvc;
using Swarojgaar.Models;
using Swarojgaar.Services.Interface;
using System.Diagnostics;
using Microsoft.AspNetCore.DataProtection;
using Swarojgaar.Security;
using Swarojgaar.ViewModel.JobVM;

namespace Swarojgaar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobService _jobService;
        private readonly IDataProtector protector;

        public HomeController(ILogger<HomeController> logger, 
            IJobService jobService, 
            IDataProtectionProvider dataProtectionProvider, 
            DataProtectionPurposeStrings dataProtectionPurposeStrings
            )
        {
            _logger = logger;
            _jobService = jobService;
            protector = dataProtectionProvider
                .CreateProtector(dataProtectionPurposeStrings.JobIdRouteValue);
        }

        [HttpGet]

        public IActionResult SearchJobs(string search_item)
        {
            var allJobs = _jobService.GetAllJobs();

            if (string.IsNullOrEmpty(search_item))
                return PartialView("_JobListPartial", allJobs);

            var searchTermLower = search_item.ToLower();

            var results = allJobs.Where(j =>
                j.Title.ToLower().Contains(searchTermLower)).ToList();

            if (results.Count == 0)
            {
                ViewBag.Message = "No Jobs Found!";
            }
            return PartialView("_JobListPartial", results);
        }

        public IActionResult Index()
        {
            var allJobs = _jobService.GetAllJobs();
            return View(allJobs);
        }
        public IActionResult Detail(string id)
        {
            return View(_jobService.GetJobDetails(id));
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
