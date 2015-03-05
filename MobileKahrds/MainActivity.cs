using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MobileKahrds
{
	[Activity (Label = "My Mobile Kahrds", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		public static Button myKahrds; 
		public static Button mainMenu;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);
			buttonInitializer ("mainMenu");
					
		}

		public void buttonInitializer(string page){
			switch (page) {
			case "mainMenu":
				myKahrds = FindViewById<Button> (Resource.Id.myKahrds);

				myKahrds.Click += delegate {
					SetContentView (Resource.Layout.MyKahrds);
					buttonInitializer ("myKahrds");
				};

				break;
			case "myKahrds":
				mainMenu = FindViewById<Button> (Resource.Id.mainMenu);
				mainMenu.Click += delegate {
					SetContentView (Resource.Layout.Main);
					buttonInitializer("mainMenu");
				};
				break;
			default:
				break;
			}
		}
	}
}


