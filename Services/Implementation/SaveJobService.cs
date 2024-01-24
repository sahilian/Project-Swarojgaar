using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;
using Swarojgaar.Security;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.SavedJobVM;

namespace Swarojgaar.Services.Implementation
{
    public class SaveJobService : ISaveJobService
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ISavedJobRepository _savedJobRepository;
        private readonly IDataProtector protector;


        public SaveJobService(
            IMapper mapper,
            UserManager<IdentityUser> userManager,
            IJobApplicationService jobApplicationService,
            ISavedJobRepository savedJobRepository,
            IDataProtectionProvider dataProtectionProvider,
            DataProtectionPurposeStrings dataProtectionPurposeStrings
            )
        {
            _savedJobRepository = savedJobRepository;
            _mapper = mapper;
            _userManager = userManager;
            _jobApplicationService = jobApplicationService;
            _savedJobRepository = savedJobRepository;
            protector = dataProtectionProvider
                .CreateProtector(dataProtectionPurposeStrings.SavedJobIdRouteValue);
        }

        public List<GetAllSavedJobsVM> GetAllSavedJobs()
        {
            try
            {
                IEnumerable<SavedJob> savedJobs = _savedJobRepository.GetAll().OrderByDescending(SavedJob => SavedJob.SavedJobId)
                    .Select(
                        sj =>
                            {
                                sj.EncryptedSavedJobId = protector.Protect(sj.SavedJobId.ToString());
                                return sj;
                            }
                        );
                List<GetAllSavedJobsVM> getAllSavedJobs = _mapper.Map<List<GetAllSavedJobsVM>>(savedJobs);
                return getAllSavedJobs;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public SavedJobDetailVM GetSavedJobDetail(string id)
        {
            try
            {
                string decryptedSavedJobId = protector.Unprotect(id);
                int decryptedIntSavedJobId = Convert.ToInt32(decryptedSavedJobId);
                SavedJob savedjobdetail = _savedJobRepository.GetBySavedJobId(decryptedIntSavedJobId);
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
        public bool ApplyAndRemove(string savedJobId, string userId)
        {
            try
            {
                string decryptedSavedJobId = protector.Unprotect(savedJobId);
                int decryptedIntSavedJobId = Convert.ToInt32(decryptedSavedJobId);
                var savedJob = _savedJobRepository.GetBySavedJobId(decryptedIntSavedJobId);

                if (savedJob != null)
                {
                    _savedJobRepository.Delete(decryptedIntSavedJobId);
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
