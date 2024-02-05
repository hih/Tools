namespace Scraper.Services.Interfaces
{
    public interface IKeywordExtractor
    {
        List<string> ExtractKeywords(string text);
    }
}
