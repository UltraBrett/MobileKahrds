using System;
using Xamarin.Forms;

namespace MobileKahrds 
{
	public class MyKahrdSetsPage : ContentPage
	{
		Picker picker;
		public MyKahrdSetsPage ()
		{
			Title = "My Kahrd Sets";

			this.SetBinding (ContentPage.TitleProperty, "Name");

			NavigationPage.SetHasNavigationBar (this, true);

			picker = new Picker
			{
				Title = "Kahrd sets",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};



			var newSetButton = new Button { Text = "Create a new set" };
			newSetButton.Clicked += (sender, e) => {
				var setItem = new SetItem();
				var setPage = new CreateSetPage();
				setPage.BindingContext = setItem;
				Navigation.PushAsync(setPage);
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
					picker,
					newSetButton, newQuestionButton, 
					editQuestionButton, deleteQuestionButton
				}
			};
		}
		protected override void OnAppearing ()
		{
			picker.Items.Clear();
			var sets = App.Database.GetSetNames();
			foreach (var s in sets) {
				picker.Items.Add (s.Set);
			}
		}
	}
}

