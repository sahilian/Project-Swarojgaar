﻿using AutoMapper;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.JobApplicationVM;

namespace Swarojgaar.Services.Implementation
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IGenericRepository<JobApplication> _jobApplicationRepository;
        private readonly IMapper _mapper;

        public JobApplicationService(IGenericRepository<JobApplication> jobApplicationRepository, IMapper mapper)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _mapper = mapper;
        }
        public List<GetAllJobApplicationsVM> GetAllJobApplications()
        {
            try
            {
                List<JobApplication> jobApplications = _jobApplicationRepository.GetAll();
                List<GetAllJobApplicationsVM> getAllJobApplications = _mapper.Map<List<GetAllJobApplicationsVM>>(jobApplications);
                return getAllJobApplications;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void CreateJobApplication(CreateJobApplicationVM createJobApplication)
        {
            try
            {
                var jobApplication = _mapper.Map<JobApplication>(createJobApplication);
                //jobApplication.UserId = userId;
                _jobApplicationRepository.Create(jobApplication);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
