namespace Scraper.Services.Interfaces
{
    public interface IThrottler
    {
        public Task ThrottleRequests();
    }
}
