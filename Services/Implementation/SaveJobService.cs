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
        private readonly IJobApplicationService _jobApplicationService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ISavedJobRepository _savedJobRepository;

        public SaveJobService(
            IMapper mapper,
            UserManager<IdentityUser> userManager,
            IJobApplicationService jobApplicationService,
            ISavedJobRepository savedJobRepository)
        {
            _savedJobRepository = savedJobRepository;
            _mapper = mapper;
            _userManager = userManager;
            _jobApplicationService = jobApplicationService;
            _savedJobRepository = savedJobRepository;
        }

        public List<GetAllSavedJobsVM> GetAllSavedJobs()
        {
            try
            {
                IOrderedEnumerable<SavedJob> savedJobs = _savedJobRepository.GetAll().OrderByDescending(sj => sj.SavedJobId);
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
                SavedJob savedjobdetail = _savedJobRepository.GetBySavedJobId(id);
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
                return _savedJobRepository.Save(savedJob);
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
                var savedJob = _savedJobRepository.GetBySavedJobId(savedJobId);

                if (savedJob != null)
                {
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

        public bool DeleteSavedJob(int savedJobId)
        {
            try
            {
                return _savedJobRepository.Delete(savedJobId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
