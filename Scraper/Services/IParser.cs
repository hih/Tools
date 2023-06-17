using Scraper.Models;

namespace Scraper.Services
{
	public interface IParser
	{
		JobPosting ParseJobPosting(string htmlContent);
	}
}
