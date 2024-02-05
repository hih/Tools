using Newtonsoft.Json;
using Scraper.Services.Interfaces;

namespace Scraper.Services
{
    public class DataStore : IDataStore
	{
		private readonly JsonSerializerSettings _settings;

        public DataStore()
        {
            _settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            };
        }

        public void SaveToFile<T>(string filePath, T data)
        {
            string jsonData = JsonConvert.SerializeObject(data, _settings);
            File.WriteAllText(filePath, jsonData);
        }
    }
}
