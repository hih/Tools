using Scraper.Services.Interfaces;

namespace Scraper.Services
{
    public class Scheduler : IScheduler
	{
		private readonly Queue<string> _queue;

		public Scheduler()
		{
			_queue = new Queue<string>();
		}

		public Scheduler(IEnumerable<string> initialList)
        {
            _queue = new Queue<string>(initialList);
        }

        public void AddUrl(string url)
        {
            _queue.Enqueue(url);
        }

        public string? GetNextUrl()
        {
            // TODO: Double check if this can be done better
            if (_queue.Any())
                return _queue.Dequeue();
            return null;
        }
	}
}
