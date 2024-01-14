using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.JobVM;
using X.PagedList;


namespace Swarojgaar.Controllers
{
    //[Authorize(Roles = "Admin, Job_Provider")]
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        // GET: Jobs
        public IActionResult Index(int? page)
        {
            return View(_jobService.GetAllJobs().ToPagedList(page ?? 1, 6));
        }


        // GET: Jobs/Details/5
        public IActionResult Details(int id)
        {
            return View(_jobService.GetJobDetails(id));
        }
        // GET: Jobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create

        [HttpPost]
        public IActionResult Create(CreateJobVM createViewModel)
        {
            try
            {
                _jobService.CreateJob(createViewModel);
                TempData["ResultOk"] = "Data Created Successfully !";
                return RedirectToAction("Index", "Jobs");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        // GET: Jobs/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            return View(_jobService.EditJob(id));
        }

        // POST: Jobs/Edit/5

        [HttpPost]
        public IActionResult Edit(EditJobVM editViewModel)
        {
            _jobService.EditJob(editViewModel);
            TempData["ResultOk"] = "Data Updated Successfully !";
            return RedirectToAction("Index", "Jobs");
        }

        // GET: Jobs/Delete/5
        public IActionResult Delete(int id)
        {
            return View(_jobService.GetJobDetails(id));
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteJob(int id)
        {
            _jobService.DeleteJob(id);
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index", "Jobs");
        }
    }
}
