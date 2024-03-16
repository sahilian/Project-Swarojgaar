using Swarojgaar.Models;
using Swarojgaar.ViewModel.JobVM;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Swarojgaar.ViewModel.HomeIndexVM
{
    public class HomeIndexVM
    {
        public List<GetAllJobsVM> ActiveJobs { get; set; }
        public IEnumerable<Job> RecommendedJobs { get; set; }
    }

}
