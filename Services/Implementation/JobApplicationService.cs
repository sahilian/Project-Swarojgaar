using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.JobApplicationVM;
using Swarojgaar.ViewModel.JobVM;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Swarojgaar.Services.Implementation
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IGenericRepository<JobApplication> _jobApplicationRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public JobApplicationService(IGenericRepository<JobApplication> jobApplicationRepository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public List<GetAllJobApplicationsVM> GetAllJobApplications()
        {
            try
            {
                List<JobApplication> jobApplications = _jobApplicationRepository.GetAll();
                List<GetAllJobApplicationsVM> getAllJobApplications =_mapper.Map<List<GetAllJobApplicationsVM>>(jobApplications);
                return getAllJobApplications;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool CreateJobApplication(CreateJobApplicationVM createJobApplication, string userId)
        {
            try
            {
                JobApplication jobApplication = _mapper.Map<JobApplication>(createJobApplication);
                //jobApplication.UserId = userId;
                return _jobApplicationRepository.Create(jobApplication);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
