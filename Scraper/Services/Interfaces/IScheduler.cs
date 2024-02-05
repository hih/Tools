namespace Scraper.Services.Interfaces
{
    public interface IScheduler
    {
        public void AddUrl(string url);
        public string? GetNextUrl();
    }
}
