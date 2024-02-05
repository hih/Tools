namespace Scraper.Services.Interfaces
{
    public interface IDownloader
    {
        Task<string> DownloadPageAsync(string url);
    }
}
