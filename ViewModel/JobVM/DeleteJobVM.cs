using Swarojgaar.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Swarojgaar.ViewModel.JobVM
{
    public class DeleteJobVM
    {
        [Key]
        public int JobId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
