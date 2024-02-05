using Scraper.Models;

namespace Scraper.Services.Interfaces
{
    public interface IParser
    {
        JobPosting ParseJobPosting(string htmlContent);
    }
}
