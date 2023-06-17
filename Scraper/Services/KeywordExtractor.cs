namespace Scraper.Utils
{
	public class KeywordExtractor
	{
		// TODO: NLP
		private List<string> _keywords = new List<string>()
		{
			"C#", ".NET", "ASP.NET", "JavaScript", "React", "Angular", "SQL", "Python", "Java"
		};

		public List<string> ExtractKeywords(string text)
		{
			text = text.ToLower();
			return _keywords.Where(keyword => text.Contains(keyword.ToLower())).ToList();
		}
	}
}
