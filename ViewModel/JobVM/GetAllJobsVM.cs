using System.ComponentModel.DataAnnotations;

namespace Swarojgaar.ViewModel.JobVM
{
    public class GetAllJobsVM
    {
        [Key]
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string FormattedExpiryDate => ExpiryDate.ToShortDateString();

    }
}
