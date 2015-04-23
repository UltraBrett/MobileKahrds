using Xamarin.Forms;

namespace MobileKahrds
{
	public class SetPage : ContentPage
	{
		ListView listView;
		SetItem setItem;

		public SetPage ()
		{
			this.SetBinding(ContentPage.TitleProperty, "Set");

			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate 
				(typeof (ItemCell));
			listView.ItemSelected += (sender, e) => {
				var item = (SetItem)e.SelectedItem;
				item.Set = setItem.Set;
				var page = new EditQuestionPage();
				page.BindingContext = item;
				Navigation.PushAsync(page);
			};

			var layout = new StackLayout();
			layout.Children.Add(listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;

			ToolbarItem tbi = new ToolbarItem ("play", "play", () => {
				var kvSets = App.Database.GetSetItems(setItem.Set);
				var length = 0;
				foreach (var kv in kvSets) {
					length++;
				}
				if(length <= 4){
					DisplayAlert("You've made a huge mistake!", "Games require at least five items in a set to play.", "Ok");
				} else {				
					var page = new GameSelectPage(setItem.Set);
					Navigation.PushAsync(page);
				}
			}, 0, 0);
			ToolbarItems.Add (tbi);

			tbi = new ToolbarItem ("+", "plus", () => {
				var item = new SetItem();
				item.Set = setItem.Set;
				var page = new NewQuestionPage();
				page.BindingContext = item;
				Navigation.PushAsync(page);
			}, 0, 1);
			ToolbarItems.Add (tbi);

			tbi = new ToolbarItem ("delete", "delete", () => {
				deleteSet();
			}, 0, 2);
			ToolbarItems.Add (tbi);
		}

		protected override void OnAppearing ()
		{
			setItem = (SetItem)BindingContext;
			base.OnAppearing ();
			listView.ItemsSource = App.Database.GetSetItems(setItem.Set);
		}

		public async void deleteSet(){
			bool delete = await DisplayAlert ("Delete a set", "Are you sure you want to delete this set?", "Yes", "No");
			if(delete){
				App.Database.DeleteSet(setItem.Set);
				Navigation.PopAsync();
			} 
		}
	}
}

