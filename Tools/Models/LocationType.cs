using System.ComponentModel.DataAnnotations;

namespace Tools.Models
{
	public class LocationType
	{
		[Key]
		public int LocationTypeID { get; set; }
        public required string Name { get; set; }
    }
}
