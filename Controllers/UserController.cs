using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swarojgaar.Data;
using System.Linq;
using System.Threading.Tasks;
using Swarojgaar.Models;

namespace Swarojgaar.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public UserController(UserManager<User> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            //var users = await _userManager.Users.ToListAsync();
            var users = _userManager.Users
                .AsEnumerable() // Switch to in-memory processing
                .OrderBy(u =>_userManager.GetRolesAsync(u).Result.FirstOrDefault())
                .ToList();

            return View(users);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var user = await _userManager.FindByIdAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    // Delete saved jobs and job applications associated with the user
        //    var savedJobs = await _context.SavedJobs.Where(sj => sj.UserId == id).ToListAsync();
        //    var jobApplications = await _context.JobApplications.Where(ja => ja.UserId == id).ToListAsync();

        //    var result = await _userManager.DeleteAsync(user);

        //    if (result.Succeeded)
        //    {
        //        _context.SavedJobs.RemoveRange(savedJobs);
        //        _context.JobApplications.RemoveRange(jobApplications);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction("Index");
        //    }

        //    // Handle errors, if any
        //    return View(user);
        //}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            // Find the user by id
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                // Delete saved jobs associated with the user
                var savedJobs = await _context.SavedJobs.Where(sj => sj.UserId == id).ToListAsync();
                _context.SavedJobs.RemoveRange(savedJobs);

                // Delete job applications associated with the user
                var jobApplications = await _context.JobApplications.Where(ja => ja.UserId == id).ToListAsync();
                _context.JobApplications.RemoveRange(jobApplications);

                // Remove the user from the database context
                _context.Users.Remove(user);

                // Save changes to the database
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log or handle any errors that occur during deletion
                return RedirectToAction("Error", "Home");
            }
        }
        public IActionResult DownloadDocument(string docFileName)
        {
            // Get the file path based on the file name
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", docFileName);

            // Check if the file exists
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(); // Return a 404 Not Found if the file does not exist
            }

            // Read the file contents
            var fileContents = System.IO.File.ReadAllBytes(filePath);

            // Determine the MIME type based on the file extension
            var mimeType = GetMimeType(docFileName);

            // Return the file as a stream
            return File(fileContents, mimeType, docFileName);
        }

        private string GetMimeType(string fileName)
        {
            var fileExtension = Path.GetExtension(fileName).ToLowerInvariant();
            switch (fileExtension)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".pdf":
                    return "application/pdf";
                default:
                    return "application/octet-stream";
            }
        }
    }
}
