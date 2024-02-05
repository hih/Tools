using Scraper.Models;
using Scraper.Services.Interfaces;

namespace Scraper.Services
{
    public class Analyser : IAnalyser
	{
		public Dictionary<string, int> CountKeywordOccurrences(List<JobPosting> jobPostings)
		{
			var keywordCounts = new Dictionary<string, int>();

			foreach (var jobPosting in jobPostings)
			{
				foreach (var keyword in jobPosting.Keywords)
				{
					if (keywordCounts.ContainsKey(keyword))
					{
						keywordCounts[keyword]++;
					}
					else
					{
						keywordCounts[keyword] = 1;
					}
				}
			}

			return keywordCounts;
		}
	}
}
