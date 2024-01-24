using Swarojgaar.ViewModel.JobVM;
using Swarojgaar.ViewModel.SavedJobVM;

namespace Swarojgaar.Services.Interface;

public interface ISaveJobService
{
    List<GetAllSavedJobsVM> GetAllSavedJobs();
    bool SaveJob(SaveJobVM saveJob, string userId);
    public bool ApplyAndRemove(string savedJobId, string userId);
    public SavedJobDetailVM GetSavedJobDetail(string id);
    public bool DeleteSavedJob(int savedJobId);

}