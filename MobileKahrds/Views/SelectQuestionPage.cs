using System;
using Xamarin.Forms;

namespace MobileKahrds
{
	public class SelectQuestionPage : ContentPage
	{
		Picker picker;
		SetItem setItem;
		public SelectQuestionPage ()
		{
			

			this.SetBinding (ContentPage.TitleProperty, "Name");

			NavigationPage.SetHasNavigationBar (this, true);

			picker = new Picker
			{
				Title = "Set questions",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			var editQuestionButton = new Button { Text = "Edit Question" };
			editQuestionButton.Clicked += (sender, e) => {
				if(picker.SelectedIndex >= 0){
					var editSetItem = new SetItem();
					editSetItem.Set = setItem.Set;
					editSetItem.Question = picker.Items[picker.SelectedIndex];
					var answer = App.Database.GetAnswer(editSetItem.Set, editSetItem.Question);

					foreach (var a in answer) {
						editSetItem.Answer = a.Answer;
					}

					var setPage = new EditQuestionPage();
					setPage.BindingContext = editSetItem;
					Navigation.PushAsync(setPage);
				}
			};	

			var deleteQuestionButton = new Button { Text = "Delete Question" };
			deleteQuestionButton.Clicked += (sender, e) => {
				if(picker.SelectedIndex >= 0){
					App.Database.DeleteItem(picker.Items[picker.SelectedIndex], setItem.Set);
					picker.Items.Clear();
					var questions = App.Database.GetSetItems(setItem.Set);
					foreach (var q in questions) {
						picker.Items.Add (q.Question);
					}
				}
			};	

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					picker,
					editQuestionButton,
					deleteQuestionButton
				}
			};
		}
		protected override void OnAppearing ()
		{
			setItem = (SetItem)BindingContext;
			Title = "Question Editor";
			picker.Items.Clear();
			var questions = App.Database.GetSetItems(setItem.Set);
			foreach (var q in questions) {
				picker.Items.Add (q.Question);
			}
		}
	}
}

