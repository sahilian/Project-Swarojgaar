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
        private readonly UserManager<User> _userManager;

        public JobApplicationService(IGenericRepository<JobApplication> jobApplicationRepository, IMapper mapper, UserManager<User> userManager)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public List<GetAllJobApplicationsVM> GetAllJobApplications()
        {
            try
            {
                IOrderedEnumerable<JobApplication> jobApplications = _jobApplicationRepository.GetAll().OrderByDescending(j => j.JobApplicationId);
                List<GetAllJobApplicationsVM> getAllJobApplications =_mapper.Map<List<GetAllJobApplicationsVM>>(jobApplications);
                return getAllJobApplications;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool CreateJobApplication(CreateJobApplicationVM createJobApplication)
        {
            try
            {
                JobApplication jobApplication = _mapper.Map<JobApplication>(createJobApplication);
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
