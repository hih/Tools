using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tools.Models
{
	public class Locations
	{
		[Key]
		public int ID { get; set; }
        public required string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [ForeignKey("LocationType")]
        public required int LocationTypeID { get; set; }
    }
}
