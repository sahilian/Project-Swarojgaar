using Swarojgaar.ViewModel.JobVM;

namespace Swarojgaar.Services.Interface;

public interface IJobService
{
    List<GetAllJobsVM> GetAllJobs();
    DetailsJobVM GetJobDetails(int id);
    void CreateJob(CreateJobVM createViewModel);
    void EditJob(EditJobVM  editViewModel);
    void DeleteJob(int id);
    EditJobVM EditJob(int id);

}