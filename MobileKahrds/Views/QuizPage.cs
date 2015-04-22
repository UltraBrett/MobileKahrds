using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace MobileKahrds
{
	public class QuizPage : ContentPage
	{
		int length;
		string[,] dictionary;
		int correct;
		Label question;
		Button answer1, answer2, answer3, answer4;

		public QuizPage ()
		{
			NavigationPage.SetHasNavigationBar (this, false);
		}

		protected override void OnAppearing ()
		{
			var setItem = (Game)BindingContext;
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

			onCreate ();
		}

		public void onCreate(){

			question = new Label {
				HorizontalOptions = LayoutOptions.Center
			};

			answer1 = new Button {
				HorizontalOptions = LayoutOptions.Center
			};
			answer1.Clicked += (sender, e) => {
				checkForCorrect(1);
			};

			answer2 = new Button {
				HorizontalOptions = LayoutOptions.Center
			};
			answer2.Clicked += (sender, e) => {
				checkForCorrect(2);
			};

			answer3 = new Button {
				HorizontalOptions = LayoutOptions.Center
			};
			answer3.Clicked += (sender, e) => {
				checkForCorrect(3);
			};

			answer4 = new Button {
				HorizontalOptions = LayoutOptions.Center
			};
			answer4.Clicked += (sender, e) => {
				checkForCorrect(4);
			};

			Content = new StackLayout {
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(20),
				Children = {
					question,
					answer1,
					answer2,
					answer3,
					answer4
				}
			};

			newQAs ();
		}

		public async void checkForCorrect(int answer){
			if (correct == answer) {
				if (answer == 1)
					answer1.BackgroundColor = Color.Green;
				if (answer == 2)
					answer2.BackgroundColor = Color.Green;
				if (answer == 3)
					answer3.BackgroundColor = Color.Green;
				if (answer == 4)
					answer4.BackgroundColor = Color.Green;
				bool replay = await DisplayAlert ("Correct!", "Would you like to play again?", "Yes", "No");
				if(replay){
					onCreate ();
				} else {
					await Navigation.PopAsync();
				}
			} else {
				if (answer == 1)
					answer1.BackgroundColor = Color.Red;
				if (answer == 2)
					answer2.BackgroundColor = Color.Red;
				if (answer == 3)
					answer3.BackgroundColor = Color.Red;
				if (answer == 4)
					answer4.BackgroundColor = Color.Red;
			}
		}

		public void newQAs (){

			Random rand = new Random ();
			int dictionaryID = rand.Next (0, length);
			correct = rand.Next (1, 5);
			HashSet<int> usedAnswers = new HashSet<int> ();

			string[] possibleAnswers = new string[4];

			for (int i = 0; i < 4; i++) {
				if (i+1 == correct) {
					possibleAnswers [i] = dictionary [0, dictionaryID];
				} else {
					int flag = 0;
					while (flag == 0) {
						int randDictionaryID = rand.Next (0, length);
						if (randDictionaryID != dictionaryID) {
							if (length >= 4) {
								if(!usedAnswers.Contains(randDictionaryID)){
									flag = 1;
									usedAnswers.Add (randDictionaryID);
									possibleAnswers [i] = dictionary [0, randDictionaryID];
								}
							} else {
								flag = 1;
								possibleAnswers [i] = dictionary [0, randDictionaryID];
							}
						}
					}
				}
			}

			question.Text = dictionary [1, dictionaryID];
			answer1.Text = possibleAnswers [0];
			answer2.Text = possibleAnswers [1];
			answer3.Text = possibleAnswers [2];
			answer4.Text = possibleAnswers [3];
		}
	}
}

