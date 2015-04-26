using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MobileKahrds
{
	public class DownloadSet
	{
		[JsonProperty("kahrd_sets")]
		public List<Attributes> sets { set; get; }
	}

	public class Attributes{
		[JsonProperty("id")]
		public string id { set; get; }
		[JsonProperty("name")]
		public string name { set; get; }
		[JsonProperty("parent_category_name")]
		public string parent_category_name { set; get; }
		[JsonProperty("category_name")]
		public string category_name { set; get; }
		[JsonProperty("kahrds_count")]
		public int kahrds_count { set; get; }
	}
}

