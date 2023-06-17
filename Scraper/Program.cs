using Newtonsoft.Json;
using Scraper.Models;
using System.Text.RegularExpressions;
using Scraper.Services;

namespace Scraper
{
	class Program
	{
		static async Task Main(string[] args)
		{
			List<string> urls = new List<string>()
			{
				"https://www.totaljobs.com/job/net-developer/adria-solutions-job100571702?TemplateType=Standard",
				"https://www.totaljobs.com/job/net-developer/reed-technology-job100612153",
				//"https://www.totaljobs.com/job/c-developer/exposed-solutions-job100610086",
				//"https://www.totaljobs.com/job/senior-c-net-developer/exposed-solutions-job100610068",
				//"https://www.totaljobs.com/job/remote-developer/exposed-solutions-job100610019"
			};

			var pattern = ".*job(\\d+)";
			var rg = new Regex(pattern);

			var downloader = new Downloader();
			var parser = new Parser();
			var keywordExtractor = new KeywordExtractor();
			var analyser = new Analyser();
			var dataStore = new DataStore();

			// TODO: Save to DB instead of to JSONs (or save to cloud storage)
			string dir = "D:\\Programs\\Scraper\\Data";

			List<JobPosting> jobPostings = new List<JobPosting>();

			foreach (string url in urls)
			{
				string content = await downloader.DownloadPageAsync(url);
				var id = rg.Matches(url)[0].Groups[1].Value;

				if (content != null)
				{
					dataStore.SaveToFile($"{dir}/raw/{id}.json", jobPostings);

					var jobPosting = parser.ParseJobPosting(content);
					var keywords = keywordExtractor.ExtractKeywords(content);
					var keywordString = string.Join(", ", keywords);

					var finalJob = jobPosting;
					finalJob.Keywords = keywords;

					if (jobPosting != null)
					{
						Console.WriteLine($"Position: {jobPosting.Position}");
						Console.WriteLine($"Body: {jobPosting.Body}");
						Console.WriteLine($"Location: {jobPosting.Location}");
						Console.WriteLine($"Company: {jobPosting.Company}");
						Console.WriteLine($"SalaryFrom: {jobPosting.SalaryFrom}");
						Console.WriteLine($"SalaryTo: {jobPosting.SalaryTo}");
						Console.WriteLine($"JobType: {jobPosting.JobType}");
						Console.WriteLine($"Keywords: {keywordString}");
					}

					jobPostings.Add(finalJob);
				}
			}

			var keywordCounts = analyser.CountKeywordOccurrences(jobPostings);
			foreach (var keywordCount in keywordCounts)
			{
				Console.WriteLine($"Keyword {keywordCount.Key}: {keywordCount.Value}");
			}

			DateTime currentTime = DateTime.UtcNow;
			long unixTime = ((DateTimeOffset)currentTime).ToUnixTimeSeconds();

			dataStore.SaveToFile($"{dir}/Processed/{unixTime}.json", jobPostings);
		}
	}
}