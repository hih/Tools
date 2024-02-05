using Scraper.Models;

namespace Scraper.Services.Interfaces
{
    public interface IAnalyser
    {
        Dictionary<string, int> CountKeywordOccurrences(List<JobPosting> jobPostings);
    }
}
