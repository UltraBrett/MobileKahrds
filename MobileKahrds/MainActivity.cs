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

		public static EditText newSetField, newQuestionField, newAnswerField,
		editQuestionField, editAnswerField;


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
				newSetField = FindViewById<EditText> (Resource.Id.newSetField);
				//basically going to be manage set with an actual set variable
				//during the save
				manageSet = FindViewById<Button> (Resource.Id.manageSet);
				myKahrds = FindViewById<Button> (Resource.Id.myKahrds);

				manageSet.Click += delegate {
					SetContentView (Resource.Layout.ManageSet);
					buttonInitializer("manageSet");
				};
				myKahrds.Click += delegate {
					SetContentView (Resource.Layout.MyKahrds);
					buttonInitializer ("myKahrds");
				};
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

			case "newQuestion":
				newQuestionField = FindViewById<EditText> (Resource.Id.newQuestionField);
				newAnswerField = FindViewById<EditText> (Resource.Id.newAnswerField);
				saveQuestion = FindViewById<Button> (Resource.Id.saveQuestion);
				manageSet = FindViewById<Button> (Resource.Id.manageSet);

				saveQuestion.Click += delegate {
					//todo save question and answer field
					SetContentView (Resource.Layout.ManageSet);
					buttonInitializer("manageSet");
				};
				manageSet.Click += delegate {
					SetContentView (Resource.Layout.ManageSet);
					buttonInitializer ("manageSet");
				};
				break;

			case "editQuestion":
				spinner = FindViewById<Spinner> (Resource.Id.spinner);
				editQuestion = FindViewById<Button> (Resource.Id.editQuestion);
				manageSet = FindViewById<Button> (Resource.Id.manageSet);

				editQuestion.Click += delegate {
					SetContentView (Resource.Layout.EditSelectedQuestion);
					buttonInitializer("editSelectedQuestion");
				};
				manageSet.Click += delegate {
					SetContentView (Resource.Layout.ManageSet);
					buttonInitializer ("manageSet");
				};
				break;

			case "deleteQuestion":
				spinner = FindViewById<Spinner> (Resource.Id.spinner);
				deleteQuestion = FindViewById<Button> (Resource.Id.deleteQuestion);
				manageSet = FindViewById<Button> (Resource.Id.manageSet);

				manageSet.Click += delegate {
					SetContentView (Resource.Layout.ManageSet);
					buttonInitializer ("manageSet");
				};
				break;

			case "editSelectedQuestion":
				editQuestionField = FindViewById<EditText> (Resource.Id.editQuestionField);
				editAnswerField = FindViewById<EditText> (Resource.Id.editAnswerField);
				saveQuestion = FindViewById<Button> (Resource.Id.saveQuestion);
				editQuestion = FindViewById<Button> (Resource.Id.editQuestion);

				saveQuestion.Click += delegate {
					SetContentView (Resource.Layout.EditQuestion);
					buttonInitializer("editQuestion");
				};
				editQuestion.Click += delegate {
					SetContentView (Resource.Layout.EditQuestion);
					buttonInitializer ("editQuestion");
				};
				break;
			}
		}
	}
}


