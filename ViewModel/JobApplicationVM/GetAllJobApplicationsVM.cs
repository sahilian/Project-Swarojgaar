using System.ComponentModel.DataAnnotations;
using Swarojgaar.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Swarojgaar.ViewModel.JobApplicationVM
{
    public class GetAllJobApplicationsVM
    {
        [Key]
        public int JobApplicationId { get; set; }
        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; }
        public string Title { get; set; }
        public string JobSummary { get; set; }

        public string Description { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public double Salary { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int ApplicationStatus { get; set; }

    }
}
