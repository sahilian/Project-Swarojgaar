using Swarojgaar.Data;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;

namespace Swarojgaar.Repository.Implementation
{
    public class SavedJobRepository : ISavedJobRepository
    {
        private readonly ApplicationDbContext _context;

        public SavedJobRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public SavedJob GetBySavedJobId(int savedJobId)
        {
            return _context.SavedJobs
                .FirstOrDefault(j => j.SavedJobId == savedJobId);
        }

        public List<SavedJob> GetAll()
        {
            return _context.SavedJobs.ToList();
        }

        public bool Save(SavedJob savedJob)
        {
            _context.SavedJobs.Add(savedJob);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int savedJobId)
        {
            var savedJob = GetBySavedJobId(savedJobId);
            if (savedJob == null)
                return false;

            _context.SavedJobs.Remove(savedJob);
            return _context.SaveChanges() > 0;
        }
    }
}
