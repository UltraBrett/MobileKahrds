using System;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace MobileKahrds
{
	public class CreateSetPage : ContentPage
	{
		public CreateSetPage ()
		{
			NavigationPage.SetHasNavigationBar (this, false);

			var setNameLabel = new Label { Text = "Set Name" };
			var setNameEntry = new Entry ();
			setNameEntry.SetBinding (Entry.TextProperty, "Set");

			var saveButton = new Button { Text = "Save Set" };
			saveButton.Clicked += (sender, e) => {
				var setItem = (SetItem)BindingContext;

				int flag = (setItem.Set.Length > 0) ? 0 : 1;

				for(int i = 0; i < setItem.Set.Length; i++){
					if(setItem.Set[i] == ' ' && flag != 2)
						flag = 1;
					if(setItem.Set[i] != ' ')
						flag = 2;
				}

				if(flag == 1){
					DisplayAlert("You goofed!", "The field cannot be empty.", "Ok");
				} else {
					App.Database.NewItem(setItem);
					Navigation.PopAsync();
				}
			};

			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.Clicked += (sender, e) => {
				Navigation.PopAsync();
			};

			var download = new Button { VerticalOptions = LayoutOptions.EndAndExpand,
				Text = "Download a Personal Set" };
			download.Clicked += async (sender, e) => {
				var sv = new KahrdsWebService();
				var es = await sv.GetMyList();
				es = es.Substring(28, es.Length - 30);
				var jsonObject = JsonConvert.DeserializeObject<DownloadSet> (es);
				var page = new ImportSetPage();
				page.BindingContext = jsonObject;
				await Navigation.PushAsync(page);
			};
				
			Content = new StackLayout {
				Padding = new Thickness(20),
				Children = {
					setNameLabel, setNameEntry, 
					saveButton, cancelButton,
					download
				}
			};
		}
	}
}

