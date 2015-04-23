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
			database.CreateTable<LoginInfo>();
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

		public IEnumerable<LoginInfo> GetAccount ()
		{
			lock (locker) {
				return database.Query<LoginInfo> ("SELECT * FROM [LoginInfo]").ToList ();
			}
		}

		public SetItem GetItem (int id) 
		{
			lock (locker) {
				return database.Table<SetItem>().FirstOrDefault(x => x.ID == id);
			}
		}

		public int NewItem (SetItem item) 
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

		public void SaveItem (SetItem item) 
		{
			lock (locker) {
				database.Update(item);
			}
		}

		public int NewAccount (LoginInfo info) 
		{
			lock (locker) {
				return database.Insert(info);
			}
		}

		public void UpdateAccount (LoginInfo info, string username) 
		{
			lock (locker) {
				database.Query<LoginInfo> ("DELETE FROM [LoginInfo] WHERE [Username] = '" + username + "'");
				database.Insert(info);
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

