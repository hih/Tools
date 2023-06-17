namespace Scraper.Services
{
	public interface IDataStore
	{
		public void SaveToFile<T>(string filePath, T data);
	}
}
