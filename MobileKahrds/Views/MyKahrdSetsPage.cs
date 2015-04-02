using System;
using Xamarin.Forms;

namespace MobileKahrds 
{
	public class MyKahrdSetsPage : ContentPage
	{
		public MyKahrdSetsPage ()
		{
			Title = "My Kahrd Sets";

			this.SetBinding (ContentPage.TitleProperty, "Name");

			NavigationPage.SetHasNavigationBar (this, true);

			var newSetButton = new Button { Text = "Create a new set" };
			newSetButton.Clicked += (sender, e) => {

			};

			var newQuestionButton = new Button { Text = "Add a new question" };
			newQuestionButton.Clicked += (sender, e) => {

			};

			var editQuestionButton = new Button { Text = "Edit an existing question" };
			editQuestionButton.Clicked += (sender, e) => {

			};

			var deleteQuestionButton = new Button { Text = "Edit an existing question" };
			deleteQuestionButton.Clicked += (sender, e) => {

			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					newSetButton, newQuestionButton, 
					editQuestionButton, deleteQuestionButton
				}
			};
		}
	}
}

