using System.ComponentModel.DataAnnotations;
using Swarojgaar.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Swarojgaar.ViewModel.SavedJobVM
{
    public class GetAllSavedJobsVM
    {
        [Key]
        public int SavedJobId { get; set; }
        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; }
        public string Title { get; set; }
        public string JobSummary { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }
        public double Salary { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string FormattedExpiryDate => ExpiryDate.ToShortDateString();

    }
}