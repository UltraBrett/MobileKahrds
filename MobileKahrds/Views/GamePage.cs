using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileKahrds
{
	// Used in:
	//      MasterDetailPageDemoPage (as a page)
	//      TabbedPageDemoPage (as a page template)
	//      CarouselPageDemoPage (as a page template)
	//
	//  Expects BindingContext to be of type NamedColor!
	class GamePage : ContentPage
	{
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
			BoxView boxView = new BoxView
			{
				WidthRequest = 100,
				HeightRequest = 100,
				HorizontalOptions = LayoutOptions.Center
			};
			boxView.SetBinding(BoxView.ColorProperty, "Color");

			var gamesButton = new Button { Text = "Play!" };
			gamesButton.Clicked += (sender, e) => {
				Navigation.PushAsync(new GameSelectPage());
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
					boxView,
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
	}
}
