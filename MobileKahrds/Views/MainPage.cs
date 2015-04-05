using System;
using Xamarin.Forms;

namespace MobileKahrds
{
	public class MainPage : ContentPage
	{
		public MainPage ()
		{
			Title = "Mobile Kahrds";

			this.SetBinding (ContentPage.TitleProperty, "Name");

			NavigationPage.SetHasNavigationBar (this, true);

			var gamesButton = new Button { Text = "Games" };
			gamesButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new GameSelectPage());
			};

			var kahrdsButton = new Button { Text = "My Kahrd Sets" };
			kahrdsButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new MyKahrdSetsPage());
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					gamesButton, kahrdsButton
				}
			};
		}
	}
}

