
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.JobVM;
using Microsoft.AspNetCore.DataProtection;
using Swarojgaar.Security;

namespace Swarojgaar.Services.Implementation;

public class JobService : IJobService
{
    private readonly IGenericRepository<Job> _jobRepository;
    private readonly IGenericRepository<JobApplication> _jobApplicationRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IDataProtector protector;


    public JobService(IGenericRepository<Job> jobRepository, 
        IMapper mapper, 
        UserManager<User> userManager, 
        IGenericRepository<JobApplication> jobApplicationRepository, 
        IDataProtectionProvider dataProtectionProvider,
        DataProtectionPurposeStrings dataProtectionPurposeStrings)
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
        _userManager = userManager;
        _jobApplicationRepository = jobApplicationRepository;
        protector = dataProtectionProvider
            .CreateProtector(dataProtectionPurposeStrings.JobIdRouteValue);
    }
    public List<GetAllJobsVM> GetAllJobs()
    {
        try
        {
            IEnumerable<Job> jobs = _jobRepository.GetAll().OrderByDescending(job => job.JobId)
                .Select(
                    j =>
                    {
                        j.EncryptedJobId = protector.Protect(j.JobId.ToString());
                        return j;
                    }
                );
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
            IEnumerable<Job> jobs = _jobRepository.GetAll().Where(job => job.UserId == userId).OrderByDescending(job => job.JobId)
                .Select(
                    j =>
                    {
                        j.EncryptedJobId = protector.Protect(j.JobId.ToString());
                        return j;
                    }
                    );

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
                        Location = applicationUser.Location,
                        DocFile = applicationUser.DocFile,
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

    public DetailsJobVM GetJobDetails(string id)
    {
        try
        {
            string decryptedJobId = protector.Unprotect(id);
            int decryptedIntJobId = Convert.ToInt32(decryptedJobId);
            Job job = _jobRepository.GetDetails(decryptedIntJobId);
            DetailsJobVM details = _mapper.Map<DetailsJobVM>(job);
            // Ensure EncryptedJobId is not null, home page ra bhitra bata get details ma farak bhako bhayera
            if (details != null)
            {
                details.EncryptedJobId = protector.Protect(job.JobId.ToString());
            }
            return details;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool CreateJob(CreateJobVM createViewModel)
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

    public EditJobVM EditJob(string id)
    {
        try
        {
            string decryptedJobId = protector.Unprotect(id);
            int decryptedIntJobId = Convert.ToInt32(decryptedJobId);
            Job job = _jobRepository.GetDetails(decryptedIntJobId);
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


    public bool DeleteJob(string id)
    {
        try
        {
            string decryptedJobId = protector.Unprotect(id);
            int decryptedIntJobId = Convert.ToInt32(decryptedJobId);
            return _jobRepository.Delete(decryptedIntJobId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}