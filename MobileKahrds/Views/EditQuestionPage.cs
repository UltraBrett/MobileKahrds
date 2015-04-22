using System;
using Xamarin.Forms;

namespace MobileKahrds 
{
	public class EditQuestionPage : ContentPage
	{
		protected override void OnAppearing ()
		{
			var setItem = (SetItem)BindingContext;
			var	question = setItem.Question;
			var setName = setItem.Set;

			NavigationPage.SetHasNavigationBar (this, false);

			var questionLabel = new Label { Text = "Question" };
			var questionEntry = new Entry ();
			questionEntry.SetBinding (Entry.TextProperty, "Question");

			var answerLabel = new Label { Text = "Answer" };
			var answerEntry = new Entry ();
			answerEntry.SetBinding (Entry.TextProperty, "Answer");

			var saveButton = new Button { Text = "Save Question" };
			saveButton.Clicked += (sender, e) => {
				var editSetItem = (SetItem)BindingContext;
				App.Database.SaveItem(editSetItem);
				this.Navigation.PopAsync();
			};

			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.Clicked += (sender, e) => {
				this.Navigation.PopAsync();
			};

			var deleteButton = new Button { VerticalOptions = LayoutOptions.EndAndExpand,
				Text = "Delete" };
			deleteButton.Clicked += (sender, e) => {
				App.Database.DeleteItem(question, setName);
				this.Navigation.PopAsync();
			};


			var apiButton = new Button { VerticalOptions = LayoutOptions.EndAndExpand,
				Text = "API" };
			apiButton.Clicked += (sender, e) => {
				this.Navigation.PopAsync();
				this.Navigation.PushAsync(new KahrdsAPIPage() );
			};

			Content = new StackLayout {
				Padding = new Thickness(20),
				Children = {
					questionLabel, questionEntry,
					answerLabel, answerEntry,
					saveButton,
					cancelButton,
					deleteButton,
					apiButton
				}
			};
		}
	}
}

