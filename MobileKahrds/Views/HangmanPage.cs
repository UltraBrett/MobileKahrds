using System;
using Xamarin.Forms;

namespace MobileKahrds
{
	public class HangmanPage : ContentPage
	{
		HangmanModel hangman;
		int length;
		int penalties;
		string[,] dictionary;
		string hiddenAnswer;
		Image image1, image2, image3, image4, image5, image6, image7;
		Label hiddenAnswerLabel;

		public HangmanPage ()
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
			Random rand = new Random ();
			int id = rand.Next (0, length);
			hangman = new HangmanModel (dictionary [0, id], dictionary [1, id]);

			Label label = new Label
			{
				Text = hangman.definitionValue,
				FontSize = 15,
				HorizontalOptions = LayoutOptions.Center
			};

			image1 = new Image
			{
				Source = ImageSource.FromFile("game_start.jpg"),
			};
			image2 = new Image
			{
				Source = ImageSource.FromFile("one_penalty.jpg"),
				IsVisible = false
			};
			image3 = new Image
			{
				Source = ImageSource.FromFile("two_penalties.jpg"),
				IsVisible = false
			};
			image4 = new Image
			{
				Source = ImageSource.FromFile("three_penalties.jpg"),
				IsVisible = false
			};
			image5 = new Image
			{
				Source = ImageSource.FromFile("four_penalties.jpg"),
				IsVisible = false
			};
			image6 = new Image
			{
				Source = ImageSource.FromFile("five_penalties.jpg"),
				IsVisible = false
			};
			image7 = new Image
			{
				Source = ImageSource.FromFile("defeat.jpg"),
				IsVisible = false
			};


			hiddenAnswer = "";
			for (int i = 0; i < hangman.termKey.Length; i++) {
				// XD the best variable name
				if (hangman.alphabet.Contains (hangman.termKey [i])) {
					hiddenAnswer = hiddenAnswer + "__ ";
				} else {
					string lineOrNah = (hangman.termKey [i] == ' ') ? "__ " : hangman.termKey [i] + "  ";
					hiddenAnswer = hiddenAnswer + lineOrNah;
				}


			}

			hiddenAnswerLabel = new Label
			{
				Text = hiddenAnswer,
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center
			};

			var btnA = new Button { Text = "A", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnA.Clicked += (sender, e) => {
				btnA.IsEnabled = false;
				btnA.BackgroundColor = Color.Blue;
				btnA.TextColor = Color.White;
				inputChar('A');
			};
			var btnB = new Button { Text = "B", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnB.Clicked += (sender, e) => {
				btnB.IsEnabled = false;
				btnB.BackgroundColor = Color.Blue;
				btnB.TextColor = Color.White;
				inputChar('B');
			};
			var btnC = new Button { Text = "C", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnC.Clicked += (sender, e) => {
				btnC.IsEnabled = false;
				btnC.BackgroundColor = Color.Blue;
				btnC.TextColor = Color.White;
				inputChar('C');
			};
			var btnD = new Button { Text = "D", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnD.Clicked += (sender, e) => {
				btnD.IsEnabled = false;
				btnD.BackgroundColor = Color.Blue;
				btnD.TextColor = Color.White;
				inputChar('D');
			};
			var btnE = new Button { Text = "E", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnE.Clicked += (sender, e) => {
				btnE.IsEnabled = false;
				btnE.BackgroundColor = Color.Blue;
				btnE.TextColor = Color.White;
				inputChar('E');
			};
			var btnF = new Button { Text = "F", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnF.Clicked += (sender, e) => {
				btnF.IsEnabled = false;
				btnF.BackgroundColor = Color.Blue;
				btnF.TextColor = Color.White;
				inputChar('F');
			};
			var btnG = new Button { Text = "G", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnG.Clicked += (sender, e) => {
				btnG.IsEnabled = false;
				btnG.BackgroundColor = Color.Blue;
				btnG.TextColor = Color.White;
				inputChar('G');
			};
			var btnH = new Button { Text = "H", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnH.Clicked += (sender, e) => {
				btnH.IsEnabled = false;
				btnH.BackgroundColor = Color.Blue;
				btnH.TextColor = Color.White;
				inputChar('H');
			};
			var btnI = new Button { Text = "I", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnI.Clicked += (sender, e) => {
				btnI.IsEnabled = false;
				btnI.BackgroundColor = Color.Blue;
				btnI.TextColor = Color.White;
				inputChar('I');
			};
			var btnJ = new Button { Text = "J", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnJ.Clicked += (sender, e) => {
				btnJ.IsEnabled = false;
				btnJ.BackgroundColor = Color.Blue;
				btnJ.TextColor = Color.White;
				inputChar('J');
			};
			var btnK = new Button { Text = "K", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnK.Clicked += (sender, e) => {
				btnK.IsEnabled = false;
				btnK.BackgroundColor = Color.Blue;
				btnK.TextColor = Color.White;
				inputChar('K');
			};
			var btnL = new Button { Text = "L", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnL.Clicked += (sender, e) => {
				btnL.IsEnabled = false;
				btnL.BackgroundColor = Color.Blue;
				btnL.TextColor = Color.White;
				inputChar('L');
			};
			var btnM = new Button { Text = "M", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnM.Clicked += (sender, e) => {
				btnM.IsEnabled = false;
				btnM.BackgroundColor = Color.Blue;
				btnM.TextColor = Color.White;
				inputChar('M');
			};
			var btnN = new Button { Text = "N", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnN.Clicked += (sender, e) => {
				btnN.IsEnabled = false;
				btnN.BackgroundColor = Color.Blue;
				btnN.TextColor = Color.White;
				inputChar('N');
			};
			var btnO = new Button { Text = "O", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnO.Clicked += (sender, e) => {
				btnO.IsEnabled = false;
				btnO.BackgroundColor = Color.Blue;
				btnO.TextColor = Color.White;
				inputChar('O');
			};
			var btnP = new Button { Text = "P", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnP.Clicked += (sender, e) => {
				btnP.IsEnabled = false;
				btnP.BackgroundColor = Color.Blue;
				btnP.TextColor = Color.White;
				inputChar('P');
			};
			var btnQ = new Button { Text = "Q", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnQ.Clicked += (sender, e) => {
				btnQ.IsEnabled = false;
				btnQ.BackgroundColor = Color.Blue;
				btnQ.TextColor = Color.White;
				inputChar('Q');
			};
			var btnR = new Button { Text = "R", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnR.Clicked += (sender, e) => {
				btnR.IsEnabled = false;
				btnR.BackgroundColor = Color.Blue;
				btnR.TextColor = Color.White;
				inputChar('R');
			};
			var btnS = new Button { Text = "S", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnS.Clicked += (sender, e) => {
				btnS.IsEnabled = false;
				btnS.BackgroundColor = Color.Blue;
				btnS.TextColor = Color.White;
				inputChar('S');
			};
			var btnT = new Button { Text = "T", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnT.Clicked += (sender, e) => {
				btnT.IsEnabled = false;
				btnT.BackgroundColor = Color.Blue;
				btnT.TextColor = Color.White;
				inputChar('T');
			};
			var btnU = new Button { Text = "U", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnU.Clicked += (sender, e) => {
				btnU.IsEnabled = false;
				btnU.BackgroundColor = Color.Blue;
				btnU.TextColor = Color.White;
				inputChar('U');
			};
			var btnV = new Button { Text = "V", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnV.Clicked += (sender, e) => {
				btnV.IsEnabled = false;
				btnV.BackgroundColor = Color.Blue;
				btnV.TextColor = Color.White;
				inputChar('V');
			};
			var btnW = new Button { Text = "W", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnW.Clicked += (sender, e) => {
				btnW.IsEnabled = false;
				btnW.BackgroundColor = Color.Blue;
				btnW.TextColor = Color.White;
				inputChar('W');
			};
			var btnX = new Button { Text = "X", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnX.Clicked += (sender, e) => {
				btnX.IsEnabled = false;
				btnX.BackgroundColor = Color.Blue;
				btnX.TextColor = Color.White;
				inputChar('X');
			};
			var btnY = new Button { Text = "Y", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnY.Clicked += (sender, e) => {
				btnY.IsEnabled = false;
				btnY.BackgroundColor = Color.Blue;
				btnY.TextColor = Color.White;
				inputChar('Y');
			};
			var btnZ = new Button { Text = "Z", HeightRequest = 35, WidthRequest = 35, FontSize = 14 };
			btnZ.Clicked += (sender, e) => {
				btnZ.IsEnabled = false;
				btnZ.BackgroundColor = Color.Blue;
				btnZ.TextColor = Color.White;
				inputChar('Z');
			};

			Content = new StackLayout {
				Children = {
					label,
					image1, image2, image3, image4, image5, image6, image7,
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

		public void inputChar(char input){
			hangman.guessedChars.Add(input);
			if (checkForMatch (input)) {

				char[] progress = hiddenAnswerLabel.Text.ToCharArray ();

				for (int i = 0; i < hangman.termKey.Length; i++) {
					if (hangman.termKey [i] == input) {
						progress [3 * i] = ' ';
						progress [3 * i + 1] = input;
					}
				}

				string newProgress = new string (progress);

				hiddenAnswerLabel.Text = newProgress;

				if (checkForVictory (hangman)) {
					gameOver ("win");
				}
			} else {
				penalties = hangman.incrementPenaltyCount ();
				if (penalties == 1) {
					image1.IsVisible = false;
					image2.IsVisible = true;
				}
				if (penalties == 2) {
					image2.IsVisible = false;
					image3.IsVisible = true;
				}
				if (penalties == 3) {
					image3.IsVisible = false;
					image4.IsVisible = true;
				}
				if (penalties == 4) {
					image4.IsVisible = false;
					image5.IsVisible = true;
				}
				if (penalties == 5) {
					image5.IsVisible = false;
					image6.IsVisible = true;
				}
				if (penalties == 6) {
					image6.IsVisible = false;
					image7.IsVisible = true;
					gameOver ("lose");
				}
			}
		}

		public async void gameOver(string scenario){
			string titleMessage = (scenario == "win") ? "You win!" : "He's dead, Jim";
			string displayMessage = (scenario == "win") ? "" : "The answer was " + hangman.termKey + ". ";
			bool replay = await DisplayAlert (titleMessage, displayMessage + "Would you like to play again?", "Yes", "No");
			if(replay){
				onCreate ();
			} else {
				await Navigation.PopAsync();
			}
		}

		public bool checkForMatch(char input){
			return hangman.hiddenChars.Contains(input);
		}

		public bool checkForVictory(HangmanModel hangman){
			char[] answer = hangman.termKey.ToCharArray();
			for(int i = 0; i < answer.Length; i++){
				if(!hangman.guessedChars.Contains(answer[i]) && hangman.alphabet.Contains(answer[i])){
					return false;
				}
			}
			return true;
		}
	}
}

