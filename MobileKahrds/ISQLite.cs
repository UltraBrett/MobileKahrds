using System;
using SQLite.Net;

namespace MobileKahrds
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

