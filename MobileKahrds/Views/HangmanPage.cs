using System;
using Xamarin.Forms;

namespace MobileKahrds
{
	public class HangmanPage : ContentPage
	{
		HangmanModel hangman;
		int length;
		string[,] dictionary;
		Image image;
		string hiddenAnswer;

		public HangmanPage ()
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

			onCreate ();
		}
		public void onCreate(){
			Random rand = new Random ();
			int id = rand.Next (0, length);
			hangman = new HangmanModel (dictionary [0, id], dictionary [1, id]);

			Label label = new Label
			{
				Text = hangman.definitionValue,
				FontSize = 15,
				HorizontalOptions = LayoutOptions.Center
			};

			image = new Image
			{
				Source = ImageSource.FromFile("game_start.jpg"),
			};

			hiddenAnswer = "__ ";
			for (int i = 0; i < hangman.termKey.Length; i++) {
				hiddenAnswer = hiddenAnswer + "__ ";
			}

			Label hiddenAnswerLabel = new Label
			{
				Text = hiddenAnswer,
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center
			};

			var btnA = new Button { Text = "A", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnB = new Button { Text = "B", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnC = new Button { Text = "C", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnD = new Button { Text = "D", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnE = new Button { Text = "E", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnF = new Button { Text = "F", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnG = new Button { Text = "G", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnH = new Button { Text = "H", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnI = new Button { Text = "I", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnJ = new Button { Text = "J", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnK = new Button { Text = "K", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnL = new Button { Text = "L", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnM = new Button { Text = "M", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnN = new Button { Text = "N", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnO = new Button { Text = "O", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnP = new Button { Text = "P", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnQ = new Button { Text = "Q", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnR = new Button { Text = "R", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnS = new Button { Text = "S", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnT = new Button { Text = "T", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnU = new Button { Text = "U", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnV = new Button { Text = "V", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnW = new Button { Text = "W", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnX = new Button { Text = "X", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnY = new Button { Text = "Y", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			var btnZ = new Button { Text = "Z", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };

			this.Content = new StackLayout {
				Children = {
					label,
					image,
					hiddenAnswerLabel,
					new StackLayout
					{
						Spacing = 0,
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.Center,
						Children = 
						{
							btnA, btnB, btnC, btnD, btnE, btnF, btnG, btnH, btnI
						}
					},
					new StackLayout
					{
						Spacing = 0,
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.Center,
						Children = 
						{
							btnJ, btnK, btnL, btnM, btnN, btnO, btnP, btnQ, btnR
						}
					},
					new StackLayout
					{
						Spacing = 0,
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.Center,
						Children = 
						{
							btnS, btnT, btnU, btnV, btnW, btnX, btnY, btnZ
						}
					}
					
				}
			};
		}

		public bool checkForMatch(char input){
			return (hangman.hiddenChars.Contains(input)) ? true : false;
		}

		public bool checkForVictory(HangmanModel hangman){
			char[] answer = hangman.termKey.ToCharArray();
			for(int i = 0; i < answer.Length; i++){
				if(!hangman.guessedChars.Contains(answer[i])){
					return false;
				}
			}
			return true;
		}
	}
}

