using System;
using Xamarin.Forms;

namespace MobileKahrds
{
	public class HangmanPage : ContentPage
	{
		HangmanModel hangman;
		int length;
		string[,] dictionary;

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
				dictionary [0, length] = kv.Question;
				dictionary [1, length] = kv.Answer;
				length++;
			}

			onCreate ();
		}
		public void onCreate(){
			Random rand = new Random ();
			int id = rand.Next (1, length);
			hangman = new HangmanModel (dictionary [0, id], dictionary [1, id]);
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

