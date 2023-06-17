using Scraper.Models;

namespace Scraper.Services
{
	public interface IAnalyser
	{
		Dictionary<string, int> CountKeywordOccurrences(List<JobPosting> jobPostings);
	}
}
