using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic.CompilerServices;

namespace Swarojgaar.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [NotMapped]
        public string EncryptedJobId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
