using Swarojgaar.Models;
using Swarojgaar.ViewModel.JobVM;

namespace Swarojgaar.Services.Interface;

public interface IJobService
{
    List<GetAllJobsVM> GetAllJobs();
    public List<GetAllJobsVM> GetJobsByUserId(string userId);
    DetailsJobVM GetJobDetails(string id);
    public bool CreateJob(CreateJobVM createViewModel, string userId);
    bool EditJob(EditJobVM  editViewModel);
    bool DeleteJob(int id);
    EditJobVM EditJob(int id);
    public Task<List<JobApplicantVM>> GetJobApplicants(int jobId);
}