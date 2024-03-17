using System;
using System.Collections.Generic;
using System.Linq;
using Swarojgaar.Data;
using Swarojgaar.Models;
using Swarojgaar.Services.Interface;

namespace Swarojgaar.Services.Implementation
{
    public class RecommendationService : IRecommendationService
    {
        private readonly ApplicationDbContext _dbContext;
        private const double Threshold = 0.5; // Adjust as needed
        private const int MaxRecommendations = 6;

        public RecommendationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Job> GetRecommendedJobs(string userId)
        {
            var userAppliedJobs = _dbContext.JobApplications
                .Where(ja => ja.UserId == userId)
                .Select(ja => ja.Job.Title)
                .ToList();

            var recommendedJobs = _dbContext.Jobs
                .Where(job => !userAppliedJobs.Contains(job.Title)) // Exclude user's applied jobs
                .ToList() // Materialize the query before further filtering
                .Where(job => CalculateCosineSimilarity(userAppliedJobs, job.Title) >= Threshold)
                .Take(MaxRecommendations)
                .ToList();

            return recommendedJobs;
        }

        private double CalculateCosineSimilarity(List<string> userJobTitles, string jobTitle)
        {
            // Tokenize and vectorize job titles
            var userVector = VectorizeText(userJobTitles);
            var jobVector = VectorizeText(new List<string> { jobTitle });

            // Calculate dot product and magnitudes
            double dotProduct = DotProduct(userVector, jobVector);
            double magnitude1 = Magnitude(userVector);
            double magnitude2 = Magnitude(jobVector);

            // Calculate cosine similarity
            double cosineSimilarity = dotProduct / (magnitude1 * magnitude2);

            return cosineSimilarity;
        }

        private Dictionary<string, int> VectorizeText(List<string> texts)
        {
            var vector = new Dictionary<string, int>();

            foreach (var text in texts)
            {
                var lowerText = text.ToLower(); // Convert text to lowercase
                for (int start = 0; start < lowerText.Length; start++)
                {
                    for (int length = 1; length <= Math.Min(3, lowerText.Length - start); length++) // Adjust the maximum substring length as needed
                    {
                        var substring = lowerText.Substring(start, length);
                        if (vector.ContainsKey(substring))
                        {
                            vector[substring]++;
                        }
                        else
                        {
                            vector[substring] = 1;
                        }
                    }
                }
            }

            return vector;
        }


        private Dictionary<string, int> VectorizeText(string text)
        {
            text = text.ToLower(); // Convert text to lowercase

            var vector = new Dictionary<string, int>();

            for (int start = 0; start < text.Length; start++)
            {
                for (int length = 1; length <= Math.Min(3, text.Length - start); length++) // Adjust the maximum substring length as needed
                {
                    var substring = text.Substring(start, length);
                    if (vector.ContainsKey(substring))
                    {
                        vector[substring]++;
                    }
                    else
                    {
                        vector[substring] = 1;
                    }
                }
            }

            return vector;
        }


        private double DotProduct(Dictionary<string, int> vector1, Dictionary<string, int> vector2)
        {
            double dotProduct = 0;

            foreach (var key in vector1.Keys)
            {
                if (vector2.ContainsKey(key))
                {
                    dotProduct += vector1[key] * vector2[key];
                }
            }

            return dotProduct;
        }

        private double Magnitude(Dictionary<string, int> vector)
        {
            return Math.Sqrt(vector.Values.Sum(v => v * v));
        }
    }
}





//-------> This works on the basis of whole string matching instead of substring

//using Swarojgaar.Data;
//using Swarojgaar.Models;
//using Swarojgaar.Services.Interface;

//namespace Swarojgaar.Services.Implementation
//{
//    public class RecommendationService : IRecommendationService
//    {
//        private readonly ApplicationDbContext _dbContext;
//        private const double Threshold = 0.2; // Adjust as needed
//        private const int MaxRecommendations = 6;
//        public RecommendationService(ApplicationDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public IEnumerable<Job> GetRecommendedJobs(string userId)
//        {
//            var jobApplications = _dbContext.JobApplications
//                .Where(ja => ja.UserId != userId) // Exclude the current user
//                .ToList();

//            var recommendedJobs = new List<Job>();

//            foreach (var job in _dbContext.Jobs)
//            {
//                // Calculate cosine similarity between the current user's job applications and other users' job applications
//                double similarity = CalculateCosineSimilarity(userId, job.JobId, jobApplications);

//                // If similarity is above a threshold, consider recommending the job
//                if (similarity >= Threshold)
//                {
//                    recommendedJobs.Add(job);
//                }

//                if (recommendedJobs.Count >= MaxRecommendations)
//                {
//                    break; // Limit the number of recommendations
//                }
//            }

//            return recommendedJobs;
//        }

//        private double CalculateCosineSimilarity(string userId, int jobId, List<JobApplication> jobApplications)
//        {
//            // Get job applications by the current user
//            var userApplications = jobApplications
//                .Where(ja => ja.UserId == userId && ja.JobId == jobId)
//                .ToList();

//            // Get job applications by all users except the current user
//            var allApplications = jobApplications
//                .Where(ja => ja.UserId != userId)
//                .ToList();

//            // Calculate dot product and magnitudes
//            double dotProduct = userApplications
//                .Count(ja => allApplications
//                    .Any(a => a.JobId == ja.JobId));
//            double magnitude1 = Math.Sqrt(userApplications.Count);
//            double magnitude2 = Math.Sqrt(allApplications.Count);

//            // Calculate cosine similarity
//            double cosineSimilarity = dotProduct / (magnitude1 * magnitude2);

//            return cosineSimilarity;
//        }
//    }
//}
