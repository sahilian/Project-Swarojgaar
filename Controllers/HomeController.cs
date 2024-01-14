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

        public IActionResult Index(string search_item = "")
        {
            List<GetAllJobsVM> jobs = _jobService.GetAllJobs();
            if (string.IsNullOrEmpty(search_item))
            {
                return View(jobs);
            }
            else
            {
                search_item = search_item.ToLower();
                List<GetAllJobsVM> getAllJobs = jobs.Where(x => x.Title.ToLower().Contains(search_item) || search_item == null).ToList()!;
                return View(getAllJobs);
            }
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
