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
		public GamePage()
		{
			this.SetBinding(ContentPage.TitleProperty, "Name");
		}

		protected override void OnAppearing ()
		{
			Game game = (Game)BindingContext;

			var gamesButton = new Button { 
				Text = "Play!",
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Start
			};

			Picker picker = new Picker
			{
				Title = "Kahrd sets",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.End
			};

			picker.Items.Clear();
			var sets = App.Database.GetSetNames();
			foreach (var s in sets) {
				picker.Items.Add (s.Set);
			}

			//Play! button for each game page is set here
			gamesButton.Clicked += (sender, e) => {
				switch(game.Name){
				case "Hangman":
					if(picker.SelectedIndex >= 0){
						var setItem = new SetItem();
						setItem.Set = picker.Items[picker.SelectedIndex];
						var setPage = new HangmanPage();
						setPage.BindingContext = setItem;
						Navigation.PushAsync(setPage);
					}
					break;
				case "Quiz":
					if(picker.SelectedIndex >= 0){
						var setItem = new SetItem();
						setItem.Set = picker.Items[picker.SelectedIndex];
						var setPage = new QuizPage();
						setPage.BindingContext = setItem;
						Navigation.PushAsync(setPage);
					}
					break;
				case "Flash Kahrds":
					if(picker.SelectedIndex >= 0){
						var setItem = new SetItem();
						setItem.Set = picker.Items[picker.SelectedIndex];
						var setPage = new FlashCards();
						setPage.BindingContext = setItem;
						Navigation.PushAsync(setPage);
					}
					break;
				};
			};

			Image image = new Image
			{
				Source = ImageSource.FromFile(game.Source),
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			Label bigLabel = new Label
			{
				FontSize = 50,
				HorizontalOptions = LayoutOptions.Center
			};
			bigLabel.SetBinding(Label.TextProperty, "Name");

			// Build the page
			this.Content = new StackLayout
			{
				Children = 
				{
					bigLabel,
					image,
					new StackLayout
					{
						Spacing = 0,
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.Center,
						Children = 
						{
							gamesButton, picker
						}
					}
				}
			};
		}
	}
}
