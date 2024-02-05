using Scraper.Services.Interfaces;

namespace Scraper.Services
{
    public class KeywordExtractor : IKeywordExtractor
	{
		// TODO: NLP
		private List<string> _keywords = new List<string>()
		{
			".NET 7", ".NET Core", ".NET Developer", "Agile", "Scrum", "Kanban", "Ajax", "Angular",
			"API", "Web Api", "MVC", "VB", "VB.NET", "AWS", "AWS Lambda", "Azure", "Azure SQL", "Azure Devops",
			"Bash", "BDD", "TDD", "Blazor", "CI", "CD", "Clean code", "HTML", "HTML5", "CSS", "JS", "JavaScript",
			"C#", ".NET", "ASP.NET", "JavaScript", "React", "Angular", "SQL", "Python", "Java",
			"Degree", "Devops", "Docker", "DRY", "SOLID", "Dynamo DB", "EF Core", "EntityFramework",
			"Entity Framework", "GCP", "AWS", "Git", "Github", "Gitlab", "GO", "Golang", "Jira", "JSON",
			"JQuery", "Kubernetes", "LINQ", "Linux", "Shell", "Bash", "Microservices", "MongoDB", "MS Office",
			"MVC", "Next.Js", "Prism", "Problem solving", "TSQL", "T-SQL", "Visual Studio", "VueJS", "Vue.Js",
			"Vue Js", "WPF", "Webforms"
		};

		public List<string> ExtractKeywords(string text)
		{
			text = text.ToLower();
			return _keywords.Where(keyword => text.Contains(keyword.ToLower())).ToList();
		}
	}
}
