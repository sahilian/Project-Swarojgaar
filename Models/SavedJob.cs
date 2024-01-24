using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Swarojgaar.Models
{
    public class SavedJob
    {
        [Key]
        public int SavedJobId { get; set; }
        [NotMapped]
        public string EncryptedSavedJobId { get; set; }


        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Salary { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}