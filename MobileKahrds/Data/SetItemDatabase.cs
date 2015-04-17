using System;
using SQLite.Net;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MobileKahrds
{
	public class SetItemDatabase 
	{
		static object locker = new object ();

		SQLiteConnection database;
		public SetItemDatabase()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			// create the tables
			database.CreateTable<SetItem>();
		}
			
		public IEnumerable<SetItem> GetSetNames ()
		{
			lock (locker) {
				return database.Query<SetItem>("SELECT DISTINCT [Set] FROM [SetItem] WHERE [Set] IS NOT NULL").ToList();
			}
		}

		public IEnumerable<SetItem> GetSetItems (string setName)
		{
			lock (locker) {
				return database.Query<SetItem>("SELECT * FROM [SetItem] WHERE [Set] = '" + setName + "' AND [Question] IS NOT NULL").ToList();
			}
		}

		public IEnumerable<SetItem> GetAnswer (string setName, string question)
		{
			lock (locker) {
				return database.Query<SetItem>("SELECT [Answer] FROM [SetItem] WHERE [Set] = '" + setName
					+ "' AND [Question] = '" + question + "'").ToArray();
			}
		}

		public SetItem GetItem (int id) 
		{
			lock (locker) {
				return database.Table<SetItem>().FirstOrDefault(x => x.ID == id);
			}
		}

		public int SaveItem (SetItem item) 
		{
			lock (locker) {
				if (item.ID != 0) {
					database.Update(item);
					return item.ID;
				} else {
					return database.Insert(item);
				}
			}
		}

		public void DeleteItem(string question, string setName)
		{
			lock (locker) {
				database.Query<SetItem> ("DELETE FROM [SetItem] WHERE [Set] = '" + setName
				+ "' AND [Question] = '" + question + "'");
			}
		}

		public void DeleteSet(string setName)
		{
			lock (locker) {
				database.Query<SetItem> ("DELETE FROM [SetItem] WHERE [Set] = '" + setName + "'");
			}
		}
	}
}

