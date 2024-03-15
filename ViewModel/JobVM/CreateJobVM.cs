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
        [NotMapped]
        public string EncryptedJobId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Display(Name = "Job Summary")]
        [MaxLength(60, ErrorMessage = "The {0} must be at most {1} characters long.")]
        [Required(ErrorMessage = "Job Summary is required.")]
        public string JobSummary { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a non-negative value")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "Expiry Date is required.")]
        public DateTime ExpiryDate { get; set; }
    }
}
