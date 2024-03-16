using Swarojgaar.Models;

namespace Swarojgaar.Services.Interface;

public interface IRecommendationService
{
    IEnumerable<Job> GetRecommendedJobs(string userId);
}