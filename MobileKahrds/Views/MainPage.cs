using Xamarin.Forms;

namespace MobileKahrds
{
	public class MainPage : ContentPage
	{
		ListView listView;
		public MainPage ()
		{
			Title = "Mobile Kahrds";

			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate 
				(typeof (SetCell));
			listView.ItemSelected += (sender, e) => {
				var item = (SetItem)e.SelectedItem;
				var page = new SetPage();
				page.BindingContext = item;
				Navigation.PushAsync(page);
			};

			var layout = new StackLayout();
			layout.Children.Add(listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;

			ToolbarItem tbi = new ToolbarItem ("dots", "dots", () => {
				var info = new LoginInfo();
				var page = new LoginPage();
				var account = App.Database.GetAccount();
				foreach (var kv in account){
					info.Username = kv.Username;
					info.Password = kv.Password;
				}
				page.BindingContext = info;
				Navigation.PushAsync(page);
			}, 0, 1);
			ToolbarItems.Add (tbi);

			tbi = new ToolbarItem ("+", "plus", () => {
				var item = new SetItem();
				var page = new CreateSetPage();
				page.BindingContext = item;
				Navigation.PushAsync(page);
			}, 0, 0);
			ToolbarItems.Add (tbi);
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			listView.ItemsSource = App.Database.GetSetNames ();
		}
	}
}

