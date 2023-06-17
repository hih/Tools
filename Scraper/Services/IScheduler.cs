namespace Scraper.Services
{
	public interface IScheduler
	{
		public void AddUrl(string url);
		public string? GetNextUrl();
	}
}
