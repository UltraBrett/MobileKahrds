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

		/// <summary>
		/// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		public SetItemDatabase()
		{
			database = DependencyService.Get<ISQLite> ().GetConnection ();
			// create the tables
			database.CreateTable<SetItem>();
		}

		public IEnumerable<SetItem> GetItems ()
		{
			lock (locker) {
				return (from i in database.Table<SetItem>() select i).ToList();
			}
		}

		public IEnumerable<SetItem> GetItemsNotDone ()
		{
			lock (locker) {
				return database.Query<SetItem>("SELECT * FROM [SetItem] WHERE [Done] = 0");
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

		public int DeleteItem(int id)
		{
			lock (locker) {
				return database.Delete<SetItem>(id);
			}
		}
	}
}

