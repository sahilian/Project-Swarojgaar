using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.JobVM;

namespace Swarojgaar.Services.Implementation;

public class JobService : IJobService
{
    private readonly IGenericRepository<Job> _jobRepository;
    private readonly IGenericRepository<JobApplication> _jobApplicationRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser> _userManager;

    public JobService(IGenericRepository<Job> jobRepository, IMapper mapper, UserManager<IdentityUser> userManager, IGenericRepository<JobApplication> jobApplicationRepository)
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
        _userManager = userManager;
        _jobApplicationRepository = jobApplicationRepository;
    }
    public List<GetAllJobsVM> GetAllJobs()
    {
        try
        {
            IOrderedEnumerable<Job> jobs = _jobRepository.GetAll().OrderByDescending(job => job.JobId);
            List<GetAllJobsVM> getAllJobs = _mapper.Map<List<GetAllJobsVM>>(jobs);
            return getAllJobs;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public List<GetAllJobsVM> GetJobsByUserId(string userId)
    {
        try
        {
            // Filter jobs based on the provided user ID
            IOrderedEnumerable<Job> jobs = _jobRepository.GetAll().Where(job => job.UserId == userId).OrderByDescending(job => job.JobId);

            List<GetAllJobsVM> getAllJobs = _mapper.Map<List<GetAllJobsVM>>(jobs);
            return getAllJobs;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<JobApplicantVM>> GetJobApplicants(int jobId)
    {
        try
        {
            // Retrieve the job applications for the specified job ID
            var jobApplications = _jobApplicationRepository
                .GetAll()
                .Where(application => application.JobId == jobId)
                .ToList();

            // Retrieve user details for each job application
            var jobApplicants = new List<JobApplicantVM>();

            foreach (var application in jobApplications)
            {
                var user = await _userManager.FindByIdAsync(application.UserId);
                if (user is User applicationUser)
                {
                    var applicantViewModel = new JobApplicantVM()
                    {
                        JobApplicationId = application.JobApplicationId,
                        UserId = application.UserId,
                        FirstName = applicationUser.FirstName,
                        LastName = applicationUser.LastName,
                        Location = applicationUser.Location
                        // Add other user details as needed
                    };

                    jobApplicants.Add(applicantViewModel);
                }
            }

            return jobApplicants;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public DetailsJobVM GetJobDetails(int id)
    {
        try
        {
            Job job = _jobRepository.GetDetails(id);
            DetailsJobVM details = _mapper.Map<DetailsJobVM>(job);
            return details;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool CreateJob(CreateJobVM createViewModel, string userId)
    {

        try
        {
            Job job = _mapper.Map<Job>(createViewModel);
            return _jobRepository.Create(job);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public EditJobVM EditJob(int id)
    {
        try
        {
            Job job = _jobRepository.GetDetails(id);
            EditJobVM editViewModel = _mapper.Map<EditJobVM>(job);
            return editViewModel;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool EditJob(EditJobVM editViewModel)
    {
        try
        {
            Job job = _mapper.Map<Job>(editViewModel);
            return _jobRepository.Edit(job);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public bool DeleteJob(int id)
    {
        try
        {
            return _jobRepository.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}