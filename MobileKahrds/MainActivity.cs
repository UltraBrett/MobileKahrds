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

		public static Button myKahrds, mainMenu, createSet, manageSet, newSet, 
			newQuestion, editQuestion, deleteQuestion, saveQuestion,
			editSelectedQuestion, deleteSelectedQuestion; 

		public static Spinner spinner;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);
			buttonInitializer ("mainMenu");
					
		}

		//controls everything forever
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
				createSet = FindViewById<Button> (Resource.Id.createSet);
				manageSet = FindViewById<Button> (Resource.Id.manageSet);

				mainMenu.Click += delegate {
					SetContentView (Resource.Layout.Main);
					buttonInitializer("mainMenu");
				};
				createSet.Click += delegate {
					SetContentView (Resource.Layout.CreateSet);
					buttonInitializer("createSet");
				};
				manageSet.Click += delegate {
					SetContentView (Resource.Layout.ManageSet);
					buttonInitializer("manageSet");
				};
				break;
			case "createSet":
				break;
			case "manageSet":
				spinner = FindViewById<Spinner> (Resource.Id.spinner);
				newQuestion = FindViewById<Button> (Resource.Id.newQuestion);
				editQuestion = FindViewById<Button> (Resource.Id.editQuestion);
				deleteQuestion = FindViewById<Button> (Resource.Id.deleteQuestion);
				myKahrds = FindViewById<Button> (Resource.Id.myKahrds);

				newQuestion.Click += delegate {
					SetContentView (Resource.Layout.NewQuestion);
					buttonInitializer ("newQuestion");
				};
				editQuestion.Click += delegate {
					SetContentView (Resource.Layout.EditQuestion);
					buttonInitializer ("editQuestion");
				};
				deleteQuestion.Click += delegate {
					SetContentView (Resource.Layout.DeleteQuestion);
					buttonInitializer ("deleteQuestion");
				};
				myKahrds.Click += delegate {
					SetContentView (Resource.Layout.MyKahrds);
					buttonInitializer ("myKahrds");
				};
				break;
			case "newSet":
				break;
			case "newQuestion":
				break;
			case "editQuestion":
				break;
			case "deleteQuestion":
				break;
			case "saveQuestion":
				break;
			case "editSelectedQuestion":
				break;
			case "deleteSelectedQuestion":
				break;
			}
		}
	}
}


