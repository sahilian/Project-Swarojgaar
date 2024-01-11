using Swarojgaar.ViewModel.JobVM;
using Swarojgaar.ViewModel.SavedJobVM;

namespace Swarojgaar.Services.Interface;

public interface ISaveJobService
{
    List<GetAllSavedJobsVM> GetAllSavedJobs();
    bool SaveJob(SaveJobVM saveJob, string userId);
    public bool ApplyAndRemove(int savedJobId, string userId);
    public SavedJobDetailVM GetSavedJobDetail(int id);
    public bool DeleteSavedJob(int savedJobId);

}