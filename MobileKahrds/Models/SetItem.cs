using SQLite.Net.Attributes;

namespace MobileKahrds
{
	public class SetItem
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Set { get; set; }
		public string Question { get; set; }
		public string Answer { get; set; }
	}
}

