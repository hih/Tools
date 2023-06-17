namespace Scraper.Services
{
	public interface IKeywordExtractor
	{
		List<string> ExtractKeywords(string text);
	}
}
