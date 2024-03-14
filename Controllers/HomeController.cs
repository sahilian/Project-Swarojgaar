using Microsoft.AspNetCore.Mvc;
using Swarojgaar.Models;
using Swarojgaar.Services.Interface;
using System.Diagnostics;
using Microsoft.AspNetCore.DataProtection;
using Swarojgaar.Security;
using Swarojgaar.ViewModel.JobVM;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swarojgaar.Data;

namespace Swarojgaar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobService _jobService;
        private readonly IDataProtector protector;
        private readonly ApplicationDbContext _dbContext;
        public HomeController(ILogger<HomeController> logger, 
            IJobService jobService, 
            IDataProtectionProvider dataProtectionProvider, 
            DataProtectionPurposeStrings dataProtectionPurposeStrings, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _jobService = jobService;
            _dbContext = dbContext;
            protector = dataProtectionProvider
                .CreateProtector(dataProtectionPurposeStrings.JobIdRouteValue);
        }

        [HttpGet]

        public IActionResult SearchJobs(string search_item, int? categoryId)
        {
            var allJobs = _jobService.GetAllJobs();

            // Filter by search term
            if (!string.IsNullOrEmpty(search_item))
            {
                var searchTermLower = search_item.ToLower();
                allJobs = allJobs.Where(j => j.Title.ToLower().Contains(searchTermLower)).ToList();
            }

            // Filter by category
            if (categoryId.HasValue && categoryId.Value != 0)
            {
                allJobs = allJobs.Where(j => j.CategoryId == categoryId.Value).ToList();
            }

            if (allJobs.Count == 0)
            {
                ViewBag.Message = "No Jobs Found!";
            }

            return PartialView("_JobListPartial", allJobs);
        }

        public IActionResult Index()
        {
            var allJobs = _jobService.GetAllJobs();
            ViewBag.Categories = _dbContext.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();

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
