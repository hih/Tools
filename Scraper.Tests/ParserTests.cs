using Scraper.Models;
using Scraper.Services;
using System;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace Scraper.Tests
{
	public class ParserTests
	{
		private IParser _parser;
		private JobPosting _jobPosting;
		private string _content;

		public ParserTests()
        {
			string dir = Directory.GetCurrentDirectory();
			using StreamReader reader = new($"{dir}/TestData/test.txt");

			_content = reader.ReadToEnd();
			_parser = new Parser();
			_jobPosting = _parser.ParseJobPosting(_content);
		}

        [Fact]
		public void ParseJobPosting_ReturnsExpectedTitle()
		{
			Assert.Equal(".NET Developer", _jobPosting.Position);
		}

		[Fact]
		public void ParseJobPosting_ReturnsExpectedBody()
		{
			Assert.Equal(".NET CORE | C# | SQL | BLAZOR | SPA | CSS | TDD | REDUX | ORM | ENTITY FRAMEWORK | GIT | " +
				"AZURE | LOGIC APPS | CI/CD | DEVOPS | REMOTE | UK.NET Developer - £65k A global project management " +
				"consultancy is looking for a .NET Developer to build multiple internal web applications using C#, .NET " +
				"CORE and Blazor, fully remote in the UK paying up to £65k.Key aspects of the .NET Developer role: Work " +
				"with cross-functional teams - Product, BA, PM. Design, develop and test document code. Take an active " +
				"approach to agile development principles. Communicate deep, complex technical ideas to non-technical " +
				"stakeholders.Experience required for the .NET Developer: Expert with C#.NET. Strong SQL experience. " +
				"Excellent knowledge of .NET CORE. Commercial background using Blazor. Exposure to cloud technologies - " +
				"preferably Azure.Offering an excellent starting salary coupled with flexi-benefits tailored to you, " +
				"this is an excellent opportunity for a .NET Developer looking to add true value to a global business " +
				"working on exciting projects in multiple countries.If this is applicable to you or you know of a " +
				"colleague/friend that this may be of interest to, please get in touch and send an email .NET CORE | C# " +
				"| SQL | BLAZOR | SPA | CSS | TDD | REDUX | ORM | ENTITY FRAMEWORK | GIT | AZURE | LOGIC APPS | CI/CD | " +
				"DEVOPS | REMOTE | UK \r\n    \r\n    \r\n        \r\n            Contact: Jason Rees\r\n        " +
				"\r\n        \r\n            Reference: Totaljobs/X3-907675\r\n        \r\n        \r\n         " +
				"   Job ID: 100612153", _jobPosting.Body);
		}

		[Fact]
		public void ParseJobPosting_ReturnsExpectedLocation()
		{
			Assert.Equal("South East", _jobPosting.Location);
		}

		[Fact]
		public void ParseJobPosting_ReturnsExpectedCompany()
		{
			Assert.Equal("Reed Technology", _jobPosting.Company);
		}

		[Fact]
		public void ParseJobPosting_ReturnsExpectedSalaryFrom()
		{
			Assert.Equal(50000.0m, _jobPosting.SalaryFrom);
		}

		[Fact]
		public void ParseJobPosting_ReturnsExpectedSalaryTo()
		{
			Assert.Equal(65000.0m, _jobPosting.SalaryTo);
		}

		[Fact]
		public void ParseJobPosting_ReturnsExpectedJobType()
		{
			Assert.Equal(JobType.FullTime, _jobPosting.JobType);
		}
	}
}