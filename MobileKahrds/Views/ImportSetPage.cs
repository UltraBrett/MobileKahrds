using Xamarin.Forms;

namespace MobileKahrds
{
	public class ImportSetPage : ContentPage
	{
		ListView listView;
		DownloadSet sets;

		public ImportSetPage ()
		{
			listView = new ListView ();
			listView.ItemTemplate = new DataTemplate 
				(typeof (DownloadSetCell));
			listView.ItemSelected += (sender, e) => {
				
			};

			var layout = new StackLayout();
			layout.Children.Add(listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;
		}

		protected override void OnAppearing ()
		{
			sets = (DownloadSet)BindingContext;
			base.OnAppearing ();
			listView.ItemsSource = sets.sets;
		}
	}
}

