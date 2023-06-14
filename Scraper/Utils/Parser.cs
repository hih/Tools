using HtmlAgilityPack;
using Scraper.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Utils
{
	public class Parser
	{
		public JobPosting ParseJobPosting(string htmlContent)
		{
			var htmlDoc = new HtmlDocument();
			htmlDoc.LoadHtml(htmlContent);

			// TODO: Move config out to allow for multiple job boards
			var positionXPath = "/html/body/div[2]/div[5]/div[1]/div[1]/div/div/div[1]/div/div/div[1]/div/h1";
			var bodyXPath = "/html/body/div[2]/div[5]/div[1]/div[1]/div/div/div[3]/div/div";
			var locationXPath = "/html/body/div[2]/div[5]/div[1]/div[1]/div/div/div[1]/div/div/div[1]/section/ul[1]/li[1]/div/a";
			var salaryXPath = "/html/body/div[2]/div[5]/div[1]/div[1]/div/div/div[1]/div/div/div[1]/section/ul[1]/li[2]/div";
			var jobTypeXPath = "/html/body/div[2]/div[5]/div[1]/div[1]/div/div/div[1]/div/div/div[1]/section/ul[2]/li[2]/div";
			var companyXPath = "//*[@id=\"companyJobsLink\"]";

			var positionNode = htmlDoc.DocumentNode.SelectSingleNode(positionXPath);
			var bodyNode = htmlDoc.DocumentNode.SelectSingleNode(bodyXPath);
			var locationNode = htmlDoc.DocumentNode.SelectSingleNode(locationXPath);
			var salaryNode = htmlDoc.DocumentNode.SelectSingleNode(salaryXPath);
			var jobTypeNode = htmlDoc.DocumentNode.SelectSingleNode(jobTypeXPath);
			var companyNode = htmlDoc.DocumentNode.SelectSingleNode(companyXPath);

			decimal salaryTo = 0;
			decimal salaryFrom = 0;

			if (salaryNode  != null)
			{
				// TODO: Upgrade to regex
				var salaryText = salaryNode.InnerText.Trim().Split(" - ");
				salaryFrom = Decimal.Parse(salaryText[0].Replace("&#163;", ""));
				salaryTo = Decimal.Parse(salaryText[1]
					.Replace("&#163;", "")
					.Replace("per annum", "")
					.Replace("Benefits 100% Remote (UK)", "")
					.Replace(",", "").Trim());
			}

			var location = "";
			if (locationNode != null)
				location = locationNode.InnerText.Trim();

			JobType jobType;

			switch (jobTypeNode.InnerText.Trim())
			{
				case "Contract":
					jobType = JobType.Contract;
					break;
				case "PartTime":
					jobType = JobType.PartTime;
					break;
				case "Permanent":
				case "Fulltime":
					jobType = JobType.FullTime;
					break;
				default:
					jobType = JobType.FullTime;
					break;
			}

			return new JobPosting
			{
				Position = positionNode.InnerText.Trim(),
				Body = bodyNode.InnerText.Trim(),
				Location = location,
				Company = companyNode.InnerText.Trim(),
				SalaryTo = salaryTo,
				SalaryFrom = salaryFrom,
				JobType = jobType,
			};
		}
	}
}
