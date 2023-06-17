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

			var delay = TimeSpan.FromMilliseconds(300);

			IThrottler throttler = new Throttler(delay);
			IDownloader downloader = new Downloader(throttler);
			IParser parser = new Parser();
			IKeywordExtractor keywordExtractor = new KeywordExtractor();
			IAnalyser analyser = new Analyser();
			IDataStore dataStore = new DataStore();
			IScheduler scheduler = new Scheduler(urls);

			// TODO: Save to DB instead of to JSONs (or save to cloud storage)
			string dir = "D:\\Programs\\Scraper\\Data";

			var jobPostings = new List<JobPosting>();

			var pattern = ".*job(\\d+)";
			var rg = new Regex(pattern);

			string url;
			while ((url = scheduler.GetNextUrl()) != null)
			{
				string content = await downloader.DownloadPageAsync(url);
				var jobPosting = parser.ParseJobPosting(content);

				var id = rg.Matches(url)[0].Groups[1].Value;
				dataStore.SaveToFile($"{dir}/raw/{id}.json", content);

				if (jobPosting != null)
				{
					var keywords = keywordExtractor.ExtractKeywords(jobPosting.Body);

					jobPosting.Keywords = keywords;
					jobPostings.Add(jobPosting);

					Console.WriteLine($"Position: {jobPosting.Position}");
					Console.WriteLine($"Body: {jobPosting.Body}");
					Console.WriteLine($"Location: {jobPosting.Location}");
					Console.WriteLine($"Company: {jobPosting.Company}");
					Console.WriteLine($"SalaryFrom: {jobPosting.SalaryFrom}");
					Console.WriteLine($"SalaryTo: {jobPosting.SalaryTo}");
					Console.WriteLine($"JobType: {jobPosting.JobType}");
					Console.WriteLine($"Keywords: {keywords}");
				}
			}

			var keywordCounts = analyser.CountKeywordOccurrences(jobPostings);

			foreach (var keywordCount in keywordCounts)
			{
				Console.WriteLine($"Keyword {keywordCount.Key}: {keywordCount.Value}");
			}

			var currentTime = DateTime.UtcNow;
			var unixTime = ((DateTimeOffset)currentTime).ToUnixTimeSeconds();

			dataStore.SaveToFile($"{dir}/Processed/{unixTime}.json", jobPostings);
		}
	}
}