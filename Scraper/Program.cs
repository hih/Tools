using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace Scraper
{
	class Program
	{
		static void Main(string[] args)
		{
			String url = "https://www.totaljobs.com/job/net-developer/adria-solutions-job100571702?TemplateType=Standard";

			var httpClient = new HttpClient();
			var html = httpClient.GetStringAsync(url).Result;
			var htmlDocument = new HtmlDocument();

			htmlDocument.LoadHtml(html);

			var xPath = "/html/body/div[2]/div[5]/div[1]/div[1]/div/div/div[1]/div/div/div[1]/div/h1";
			var title = GetTextFromElem(htmlDocument, xPath);

			Console.WriteLine("Job Title: " + title);
		}

		public static string GetTextFromElem(HtmlDocument html, string xPath)
		{
			var elem = html.DocumentNode.SelectSingleNode(xPath);
			var elemText = elem.InnerText.Trim();
			return elemText;
		}
	}
}