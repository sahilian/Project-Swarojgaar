using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.JobApplicationVM;
using Swarojgaar.ViewModel.JobVM;
using System.Net.NetworkInformation;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;


namespace Swarojgaar.Controllers
{
    //[Authorize(Roles = "Admin, Job_Provider")]
    public class JobsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJobService _jobService;
        private readonly IGenericRepository<Job> _genericRepository;


        public JobsController(
            IJobService jobService, 
            UserManager<IdentityUser> userManager, 
            IGenericRepository<Job> genericRepository
            )
        {

            _jobService = jobService;
            _userManager = userManager;
            _genericRepository = genericRepository;
        }
        /*
        //GET: Jobs
        public IActionResult Index(int? page)
        {
            try
            {
                var jobs = _jobService.GetAllJobs().ToPagedList(page ?? 1, 6);

                return View("Index", jobs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }*/
        public IActionResult Index(int? page)
        {
            try
            {
                bool isAdmin = User.IsInRole("Admin");
                if (isAdmin)
                {
                    var jobs = _jobService.GetAllJobs().ToPagedList(page ?? 1, 6);
                    return View("Index", jobs);

                }
                else
                {
                    string currentUserId = _userManager.GetUserId(User);
                    var jobs = _jobService.GetJobsByUserId(currentUserId).ToPagedList(page ?? 1, 6);
                    return View("Index", jobs);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        public async Task<IActionResult> JobApplicants(int jobId)
        {
            try
            {
                var jobApplicants = await _jobService.GetJobApplicants(jobId);

                // Pass the list of job applicants to the view
                return View("JobApplicants", jobApplicants);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
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
                var userId = _userManager.GetUserId(User);
                createViewModel.UserId = userId;
                _jobService.CreateJob(createViewModel, userId);
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
