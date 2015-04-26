using Xamarin.Forms;
using Newtonsoft.Json;

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
			listView.ItemSelected += async (sender, e) => {
				var item = (Attributes) e.SelectedItem;
				var sv = new KahrdsWebService();
				var es = await sv.GetOneSetofKahrds(item.id);
				es = es.Substring(28, es.Length - 30);
				var jsonObject = JsonConvert.DeserializeObject<KahrdsList> (es);
				App.Database.ImportDataSets(jsonObject);
				await DisplayAlert("Success!", "Set available to play.", "Ok");
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

