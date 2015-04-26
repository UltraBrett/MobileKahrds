using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MobileKahrds
{
	public class KahrdList{
		[JsonProperty("kahrd_set")]
		public KahrdListData data { get; set; }
	}

	public class KahrdListData{
		[JsonProperty("id")]
		public string id { get; set; } 
		[JsonProperty("name")]
		public string name { get; set; }
		[JsonProperty("public")]
		public bool isPublic { get; set; }
		[JsonProperty("parent_category_name")]
		public string parent_category_name { get; set; } 
		[JsonProperty("category_name")]
		public string category_name { get; set; }
		[JsonProperty("kahrds_count")]
		public int kahrds_count { get; set; } 
		[JsonProperty("kahrds")]
		public List<Kahrds> list { get; set; } 
	}

	public class Kahrds{
		[JsonProperty("word")]
		public string word { get; set; }
		[JsonProperty("definition")]
		public string definition{ get; set; } 
	}
}

