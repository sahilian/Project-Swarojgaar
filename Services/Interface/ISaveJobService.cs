using Swarojgaar.ViewModel.JobVM;
using Swarojgaar.ViewModel.SavedJobVM;

namespace Swarojgaar.Services.Interface;

public interface ISaveJobService
{
    List<GetAllSavedJobsVM> GetAllSavedJobs();


    bool SaveJob(SaveJobVM saveJob, string userId);
}