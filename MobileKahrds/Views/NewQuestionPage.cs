﻿using System;
using Xamarin.Forms;

namespace MobileKahrds 
{
	public class NewQuestionPage : ContentPage
	{
		public NewQuestionPage ()
		{
			this.SetBinding (ContentPage.TitleProperty, "Name");

			NavigationPage.SetHasNavigationBar (this, false);

			var questionLabel = new Label { Text = "Question" };
			var questionEntry = new Entry ();
			questionEntry.SetBinding (Entry.TextProperty, "Question");

			var answerLabel = new Label { Text = "Answer" };
			var answerEntry = new Entry ();
			answerEntry.SetBinding (Entry.TextProperty, "Answer");

			var saveButton = new Button { Text = "Save Question" };
			saveButton.Clicked += (sender, e) => {
				var setItem = (SetItem)BindingContext;
				App.Database.SaveItem(setItem);
				this.Navigation.PopAsync();
			};

			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.Clicked += (sender, e) => {
				var set = (SetItem)BindingContext;
				this.Navigation.PopAsync();
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					questionLabel, questionEntry,
					answerLabel, answerEntry,
					saveButton, cancelButton
				}
			};
		}
	}
}
