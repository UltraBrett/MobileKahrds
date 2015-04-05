using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileKahrds
{
	class GamePage : ContentPage
	{
		Game game;
		string thisGame;
		public GamePage(bool includeBigLabel)
		{
			// This binding is necessary to label the tabs in 
			//      the TabbedPage.
			this.SetBinding(ContentPage.TitleProperty, "Name");


			// Function to create six Labels.
			Func<string, string, Label> CreateLabel = (string source, string fmt) =>
			{
				Label label = new Label {
					FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
					XAlign = TextAlignment.End
				};
				label.SetBinding(Label.TextProperty,
					new Binding(source, BindingMode.OneWay, null, null, fmt));

				return label;
			};

			// BoxView to show the color.
			Image image = new Image
			{
				Source = ImageSource.FromFile("defeatV2.jpg"),
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			var gamesButton = new Button { Text = "Play!" };
				gamesButton.Clicked += (sender, e) => {
					switch(thisGame){
					case "Hangman":
						Navigation.PushAsync(new GameSelectPage());
						break;
					case "?????":
						Navigation.PushAsync(new MainPage());
						break;
					case "Flash Cards":
						Navigation.PushAsync(new MyKahrdSetsPage());
						break;
				};
			};

			// Build the page
			this.Content = new StackLayout
			{
				Children = 
				{
					new StackLayout
					{   
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand,

					},
					image,
					gamesButton

				}
			};

			// Add in the big Label at top for CarouselPage.
			if (includeBigLabel)
			{
				Label bigLabel = new Label
				{
					FontSize = 50,
					HorizontalOptions = LayoutOptions.Center
				};
				bigLabel.SetBinding(Label.TextProperty, "Name");

				(this.Content as StackLayout).Children.Insert(0, bigLabel);
			}
		}
		protected override void OnAppearing ()
		{
			game = (Game)BindingContext;
			thisGame = game.Name;
		}
	}
}
