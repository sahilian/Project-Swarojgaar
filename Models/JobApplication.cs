using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Swarojgaar.Models
{
    public class JobApplication
    {
        [Key]
        public int JobApplicationId { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public string JobSummary { get; set; }


        [Required(ErrorMessage = "Salary is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a non-negative value")]
        public double Salary { get; set; }

        [Required(ErrorMessage = "ExpiryDate is required")]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

        public int ApplicationStatus { get; set; }
    }
}