namespace Tools.Models
{
	public class LocationsIndexModel
	{
        public IEnumerable<Locations> Locations { get; set; }
        public int PageNumber { get; set; }
		public int ShowingY { get; set; }
		public int ShowingX { get; set; }
        public int PagesToShow { get; set; }
        public int TotalResults { get; set; }
		public int TotalPages { get; set; }

		public int PaginationMin { get; set; }
		public int PaginationMax { get; set; }
	}
}
