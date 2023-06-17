namespace Scraper.Services
{
	public interface IThrottler
	{
		public Task ThrottleRequests();
	}
}
