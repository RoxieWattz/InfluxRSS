using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluxRSS.Feed
{
	public class FeedItem
	{
		public string? Title { get; set; }
		public string? Description { get; set; }
		public int? Date { get; set; }
		public string? Author { get; set; }
		public string? Source { get; set; }
		public string? URL { get; set; }

	}
}
