namespace Scraper.Services
{
	public interface IDownloader
	{
		Task<string> DownloadPageAsync(string url);
	}
}
