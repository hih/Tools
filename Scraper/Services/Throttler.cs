namespace Scraper.Services
{
	public class Throttler : IThrottler
	{
		private readonly TimeSpan _delay;

        public Throttler(TimeSpan delay)
        {
            _delay = delay;
        }

        public async Task ThrottleRequests()
        {
            await Task.Delay(_delay);
        }
    }
}
