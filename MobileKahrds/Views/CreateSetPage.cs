using System;
using Xamarin.Forms;

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
				
			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					setNameLabel, setNameEntry, 
					saveButton, cancelButton
				}
			};
		}
	}
}

