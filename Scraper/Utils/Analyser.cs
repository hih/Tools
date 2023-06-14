using Scraper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Utils
{
	public class Analyser
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
