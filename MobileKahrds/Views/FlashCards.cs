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

			var showDefinition = new Button { Text = "Show Definition" };
			showDefinition.Clicked += (sender, e) => {
				answer.Text = dictionary[1, id];
			};

			var hideDefinition = new Button { Text = "Hide Definition" };
			hideDefinition.Clicked += (sender, e) => {
				answer.Text = "";
			};

			var nextCard = new Button { Text = "Next Card" };
			nextCard.Clicked += (sender, e) => {
				newCard();
			};

			var quitGame = new Button { Text = "Quit Game" };
			quitGame.Clicked += (sender, e) => {
				Navigation.PopAsync();
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					question,
					answer,
					showDefinition,
					hideDefinition,
					nextCard,
					quitGame
					}

			};
		}
	}
}

