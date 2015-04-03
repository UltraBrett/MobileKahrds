using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace MobileKahrds
{
	public class App : Application
	{
		static SetItemDatabase database;

		public App ()
		{
			var mainNav = new NavigationPage (new MainPage ());

			MainPage = mainNav;
		}

		public static SetItemDatabase Database {
			get { 
				if (database == null) {
					database = new SetItemDatabase ();
				}
				return database; 
			}
		}
	}
}

