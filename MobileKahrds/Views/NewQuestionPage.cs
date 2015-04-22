using System;
using Xamarin.Forms;

namespace MobileKahrds 
{
	public class NewQuestionPage : ContentPage
	{
		public NewQuestionPage ()
		{
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

				int questionFlag = (setItem.Question.Length > 0) ? 0 : 1;
				int answerFlag = (setItem.Answer.Length > 0) ? 0 : 1;

				for(int i = 0; i < setItem.Question.Length; i++){
					if(setItem.Question[i] == ' ' && questionFlag != 2)
						questionFlag = 1;
					if(setItem.Question[i] != ' ')
						questionFlag = 2;
				}

				for(int i = 0; i < setItem.Answer.Length; i++){
					if(setItem.Answer[i] == ' ' && answerFlag != 2)
						answerFlag = 1;
					if(setItem.Answer[i] != ' ')
						answerFlag = 2;
				}

				if(questionFlag == 1 || answerFlag == 1){
					DisplayAlert("You goofed!", "None of the fields can be empty.", "Ok");
				} else {
					App.Database.NewItem(setItem);
					Navigation.PopAsync();
				}
			};

			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.Clicked += (sender, e) => {
				Navigation.PopAsync();
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

