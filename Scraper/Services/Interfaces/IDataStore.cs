namespace Scraper.Services.Interfaces
{
    public interface IDataStore
    {
        public void SaveToFile<T>(string filePath, T data);
    }
}
