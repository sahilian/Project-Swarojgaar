using Microsoft.AspNetCore.Mvc.Rendering;
using Swarojgaar.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Swarojgaar.ViewModel.JobVM
{
    public class CreateJobVM
    {
        [Key]
        public int JobId { get; set; }
        public string EncryptedJobId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Job Summary")]
        [MaxLength(60, ErrorMessage = "The {0} must be at most {1} characters long.")]
        [Required(ErrorMessage = "Job Summary is required.")]
        public string JobSummary { get; set; }

        public string Description { get; set; }
        public double Salary { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
