using System;
using Xamarin.Forms;
using System.Linq;

namespace MobileKahrds
{
	public class QuizPage : ContentPage
	{

		int length;
		string[,] dictionary;

		public QuizPage ()
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

			startQuiz ();
		}

		public void startQuiz() {
			Random rand = new Random ();
			int[] values = Enumerable.Range(0, length).OrderBy(x => rand.Next()).ToArray();
			int first = values[0];
			int second = values[1];
			int third = values[2];

			int[] answers = Enumerable.Range(0, 3).OrderBy(x => rand.Next()).ToArray();
			int a = answers [0];
			int b = answers [1];
			int c = answers [2];

			Label question = new Label {
				Text = dictionary [0, first],
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center
			};

			var answerA = new Button { Text = dictionary[1, values[a]] };
			answerA.Clicked += (sender, e) => {
				if (dictionary[1, values[a]] == dictionary[1, first]) {
					gameOver("right", dictionary[1, first]);
				}
				else {
					gameOver("wrong", dictionary[1, first]);
				}
			};

			var answerB = new Button { Text = dictionary[1, values[b]] };
			answerB.Clicked += (sender, e) => {
				if (dictionary[1, values[b]] == dictionary[1, first]) {
					gameOver("right", dictionary[1, first]);
				}
				else {
					gameOver("wrong", dictionary[1, first]);
				}
			};

			var answerC = new Button { Text = dictionary[1, values[c]] };
			answerC.Clicked += (sender, e) => {
				if (dictionary[1, values[c]] == dictionary[1, first]) {
					gameOver("right", dictionary[1, first]);
				}
				else {
					gameOver("wrong", dictionary[1, first]);
				}
			};

			var quitGame = new Button { Text = "Quit" };
			quitGame.Clicked += (sender, e) => {
				Navigation.PopAsync();
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness (20),
				Children = {
					question,
					answerA,
					answerB,
					answerC,
					quitGame
				}
			};
		}

		public async void gameOver(string outcome, string answer) {
			string titleMessage = (outcome == "right") ? "Correct!" : "You got that wrong!";
			string displayMessage = (outcome == "right") ? "Good job! " : "The answer was " + answer + ". ";
			bool replay = await DisplayAlert (titleMessage, displayMessage + "Next Question?", "Yes", "No");
			if(replay){
				startQuiz ();
			} else {
				await Navigation.PopAsync();
			}
		}
	}
}

