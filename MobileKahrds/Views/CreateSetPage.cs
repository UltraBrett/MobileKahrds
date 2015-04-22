using System;
using Xamarin.Forms;

namespace MobileKahrds
{
	public class CreateSetPage : ContentPage
	{
		public CreateSetPage ()
		{
			this.SetBinding (ContentPage.TitleProperty, "Name");

			NavigationPage.SetHasNavigationBar (this, false);

			var setNameLabel = new Label { Text = "Set Name" };
			var setNameEntry = new Entry ();
			setNameEntry.SetBinding (Entry.TextProperty, "Set");

			var saveButton = new Button { Text = "Save Set" };
			saveButton.Clicked += (sender, e) => {
				var setItem = (SetItem)BindingContext;
				App.Database.NewItem(setItem);
				this.Navigation.PopAsync();
			};

			var cancelButton = new Button { Text = "Cancel" };
			cancelButton.Clicked += (sender, e) => {
				var set = (SetItem)BindingContext;
				this.Navigation.PopAsync();
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

