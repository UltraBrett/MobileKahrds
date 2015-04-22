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

				int questionFlag = (editSetItem.Question.Length > 0) ? 0 : 1;
				int answerFlag = (editSetItem.Answer.Length > 0) ? 0 : 1;

				for(int i = 0; i < editSetItem.Question.Length; i++){
					if(editSetItem.Question[i] == ' ' && questionFlag != 2)
						questionFlag = 1;
					if(editSetItem.Question[i] != ' ')
						questionFlag = 2;
				}

				for(int i = 0; i < editSetItem.Answer.Length; i++){
					if(editSetItem.Answer[i] == ' ' && answerFlag != 2)
						answerFlag = 1;
					if(editSetItem.Answer[i] != ' ')
						answerFlag = 2;
				}

				if(questionFlag == 1 || answerFlag == 1){
					DisplayAlert("You goofed!", "None of the fields can be empty.", "Ok");
				} else {
					App.Database.SaveItem(editSetItem);
					Navigation.PopAsync();
				}
			};

			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.Clicked += (sender, e) => {
				Navigation.PopAsync();
			};

			var deleteButton = new Button { VerticalOptions = LayoutOptions.EndAndExpand,
				Text = "Delete" };
			deleteButton.Clicked += (sender, e) => {
				App.Database.DeleteItem(question, setName);
				Navigation.PopAsync();
			};

			Content = new StackLayout {
				Padding = new Thickness(20),
				Children = {
					questionLabel, questionEntry,
					answerLabel, answerEntry,
					saveButton,
					cancelButton,
					deleteButton
				}
			};
		}
	}
}

