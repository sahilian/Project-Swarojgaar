using Swarojgaar.ViewModel.JobVM;

namespace Swarojgaar.Services.Interface;

public interface IJobService
{
    List<GetAllJobsVM> GetAllJobs();
    DetailsJobVM GetJobDetails(int id);
    public bool CreateJob(CreateJobVM createViewModel, string userId);
    bool EditJob(EditJobVM  editViewModel);
    bool DeleteJob(int id);
    EditJobVM EditJob(int id);

}