using Swarojgaar.ViewModel.JobVM;

namespace Swarojgaar.Services.Interface;

public interface IJobService
{
    List<GetAllJobsVM> GetAllJobs();
    DetailsJobVM GetJobDetails(int id);
    bool CreateJob(CreateJobVM createViewModel);
    bool EditJob(EditJobVM  editViewModel);
    bool DeleteJob(int id);
    EditJobVM EditJob(int id);

}