using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.JobApplicationVM;
using Swarojgaar.ViewModel.SavedJobVM;

namespace Swarojgaar.Services.Implementation
{
    public class SaveJobService : ISaveJobService
    {
        private readonly IGenericRepository<SavedJob> _savedJobRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public SaveJobService(IGenericRepository<SavedJob> savedJobRepository, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _savedJobRepository = savedJobRepository;
            _mapper = mapper;
            _userManager = userManager;
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
    }
}
