using HtmlAgilityPack;
using Scraper.Models;
using Scraper.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Scraper
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var url = "https://www.totaljobs.com/job/net-developer/adria-solutions-job100571702?TemplateType=Standard";

			var downloader = new Downloader();
			var parser = new Parser();

			string content = await downloader.DownloadPageAsync(url);

			if (content != null)
			{
				//Console.WriteLine(content.Substring(0, 100));

				var jobPosting = parser.ParseJobPosting(content);

				if (jobPosting != null)
				{
					Console.WriteLine($"Position: {jobPosting.Position}");
					Console.WriteLine($"Body: {jobPosting.Body}");
					Console.WriteLine($"Location: {jobPosting.Location}");
					Console.WriteLine($"Company: {jobPosting.Company}");
					Console.WriteLine($"SalaryFrom: {jobPosting.SalaryFrom}");
					Console.WriteLine($"SalaryTo: {jobPosting.SalaryTo}");
					Console.WriteLine($"JobType: {jobPosting.JobType}");
				}
			}
		}
	}
}