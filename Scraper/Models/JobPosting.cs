using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scraper.Models
{
    public class JobPosting
	{
        public string Position { get; set; }
        public string Body { get; set; }
        public string Location { get; set; }
        public string Company { get; set; }

        public decimal SalaryFrom { get; set; }
        public decimal SalaryTo { get; set; }

        public JobType JobType { get; set; }

        public List<string> Keywords { get; set; }
    }

	public enum JobType
    {
        Contract = 0,
        PartTime = 1,
        FullTime = 2,
    }
}
