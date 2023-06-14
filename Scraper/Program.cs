using HtmlAgilityPack;
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

			string content = await downloader.DownloadPageAsync(url);

			if (content != null)
			{
				Console.WriteLine(content.Substring(0, 100));
			}
		}
	}
}