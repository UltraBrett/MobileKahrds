using System;
using Xamarin.Forms;

namespace MobileKahrds
{
	public class FlashCards : ContentPage
	{
		int length;
		string[,] dictionary;

		public FlashCards ()
		{
			NavigationPage.SetHasNavigationBar (this, false);
		}

		protected override void OnAppearing ()
		{
			var setItem = (SetItem)BindingContext;
			var kvSets = App.Database.GetSetItems(setItem.Set);

			foreach (var kv in kvSets) {
				length++;
			}
			dictionary = new string[2, length];
			length = 0;
			foreach (var kv in kvSets) {
				dictionary [0, length] = kv.Answer;
				dictionary [1, length] = kv.Question;
				length++;
			}

			newCard();
		}

		public void newCard() {
			Random rand = new Random ();
			int id = rand.Next (0, length);

			Label question = new Label {
				Text = dictionary [0, id],
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center
			};

			Label answer = new Label {
				Text = "",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center
			};

			var showDefinition = new Button { Text = "Show Definition", HeightRequest = 70, WidthRequest = 100, FontSize = 14 };
			showDefinition.Clicked += (sender, e) => {
				answer.Text = dictionary[1, id];
			};

			var hideDefinition = new Button { Text = "Hide Definition", HeightRequest = 70, WidthRequest = 100, FontSize = 14 };
			hideDefinition.Clicked += (sender, e) => {
				answer.Text = "";
			};

			var nextCard = new Button { Text = "Next Card", HeightRequest = 70, WidthRequest = 100, FontSize = 14 };
			nextCard.Clicked += (sender, e) => {
				newCard();
			};

			var quitGame = new Button { Text = "Quit Game", HeightRequest = 70, WidthRequest = 100, FontSize = 14 };
			quitGame.Clicked += (sender, e) => {
				Navigation.PopAsync();
			};

			Content = new StackLayout {
				Children = {
					question,
					answer,
					new StackLayout
					{
						Spacing = 0,
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.Center,
						Children = 
						{
							showDefinition, hideDefinition, nextCard, quitGame
						}
					}
				}
			};
		}
	}
}

