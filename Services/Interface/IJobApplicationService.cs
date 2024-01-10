using Swarojgaar.ViewModel.JobApplicationVM;
using Swarojgaar.ViewModel.JobVM;

namespace Swarojgaar.Services.Interface;

public interface IJobApplicationService
{
    List<GetAllJobApplicationsVM> GetAllJobApplications();
    bool CreateJobApplication(CreateJobApplicationVM createJobApplication, string userId);
}