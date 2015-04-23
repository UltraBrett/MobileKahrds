using SQLite.Net.Attributes;

namespace MobileKahrds
{
	public class LoginInfo
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
	}
}

