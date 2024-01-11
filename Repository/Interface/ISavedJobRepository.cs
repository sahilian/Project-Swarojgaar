using Swarojgaar.Models;

namespace Swarojgaar.Repository.Interface;

public interface ISavedJobRepository
{
    SavedJob GetBySavedJobId(int savedJobId);
    List<SavedJob> GetAll();
    bool Save(SavedJob savedJob);
    bool Delete(int savedJobId);
}