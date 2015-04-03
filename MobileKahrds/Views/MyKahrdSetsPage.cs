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
				if(picker.SelectedIndex >= 0){
					var setItem = new SetItem();
					setItem.Set = picker.Items[picker.SelectedIndex];
					var setPage = new NewQuestionPage();
					setPage.BindingContext = setItem;
					Navigation.PushAsync(setPage);
				}
			};

			var editQuestionButton = new Button { Text = "Edit an existing question" };
			editQuestionButton.Clicked += (sender, e) => {
				if(picker.SelectedIndex >= 0){
					var setItem = new SetItem();
					setItem.Set = picker.Items[picker.SelectedIndex];
					var setPage = new SelectQuestionPage();
					setPage.BindingContext = setItem;
					Navigation.PushAsync(setPage);
				}
			};

			var deleteSetButton = new Button { Text = "Delete selected set" };
			deleteSetButton.Clicked += (sender, e) => {
				if(picker.SelectedIndex >= 0){
					App.Database.DeleteSet(picker.Items[picker.SelectedIndex]);
					picker.Items.Clear();
					var sets = App.Database.GetSetNames();
					foreach (var s in sets) {
						picker.Items.Add (s.Set);
					}
				}
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					picker,
					newSetButton, newQuestionButton, 
					editQuestionButton, deleteSetButton
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

