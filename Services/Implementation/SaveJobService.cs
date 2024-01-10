using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.JobApplicationVM;
using Swarojgaar.ViewModel.JobVM;
using Swarojgaar.ViewModel.SavedJobVM;

namespace Swarojgaar.Services.Implementation
{
    public class SaveJobService : ISaveJobService
    {
        private readonly IGenericRepository<SavedJob> _savedJobRepository;
        private readonly IJobApplicationService _jobApplicationService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public SaveJobService(
            IGenericRepository<SavedJob> savedJobRepository,
            IMapper mapper,
            UserManager<IdentityUser> userManager,
            IJobApplicationService jobApplicationService)
        {
            _savedJobRepository = savedJobRepository;
            _mapper = mapper;
            _userManager = userManager;
            _jobApplicationService = jobApplicationService;
        }

        public List<GetAllSavedJobsVM> GetAllSavedJobs()
        {
            try
            {
                List<SavedJob> savedJobs = _savedJobRepository.GetAll();
                List<GetAllSavedJobsVM> getAllSavedJobs = _mapper.Map<List<GetAllSavedJobsVM>>(savedJobs);
                return getAllSavedJobs;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public SavedJobDetailVM GetSavedJobDetail(int id)
        {
            try
            {
                SavedJob savedjobdetail = _savedJobRepository.GetDetails(id);
                SavedJobDetailVM savedJobDetail = _mapper.Map<SavedJobDetailVM>(savedjobdetail);
                return savedJobDetail;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool SaveJob(SaveJobVM saveJob, string userId)
        {
            try
            {
                SavedJob savedJob = _mapper.Map<SavedJob>(saveJob);
                return _savedJobRepository.Create(savedJob);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public bool ApplyAndRemove(int savedJobId, string userId)
        {
            try
            {
                var savedJob = _savedJobRepository.GetDetails(savedJobId);

                if (savedJob != null)
                {
                    //// Create a new JobApplication entry
                    //CreateJobApplicationVM jobApplication = new CreateJobApplicationVM()
                    //{
                    //    // Set other properties
                    //    UserId = savedJob.UserId,
                    //    JobId = savedJob.JobId,
                    //    Title = savedJob.Title,
                    //    Description = savedJob.Description,
                    //    Salary = savedJob.Salary,
                    //    ExpiryDate = savedJob.ExpiryDate
                    //};
                    //_jobApplicationService.CreateJobApplication(jobApplication, userId);

                    // Add the JobApplication entry (you may need to inject and use the JobApplication repository)
                    // Remove the SavedJob entry
                    _savedJobRepository.Delete(savedJobId);
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
