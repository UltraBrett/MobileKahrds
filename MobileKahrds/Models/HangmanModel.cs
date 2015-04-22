using System;
using System.Collections.Generic;

namespace MobileKahrds
{
	public class HangmanModel
	{
		public HangmanModel(String k, String v ){
			termKey = k.ToUpper();
			definitionValue = v;
			penaltyCount = 0;
			hiddenChars = tokenizeCharSet(termKey);
			guessedChars = new HashSet<char>();
			alphabet = getAlphabet();
		}	

		public string termKey { private set; get; }
		public string definitionValue { private set; get; }
		public HashSet<char> hiddenChars { private set; get; }
		public HashSet<char> guessedChars { private set; get; }
		public HashSet<char> alphabet { private set; get; }
		private int penaltyCount;

		public int incrementPenaltyCount(){
			return ++penaltyCount;
		}

		HashSet<char> tokenizeCharSet(String sourcestring){
			var characterSet = new HashSet<char>();
			sourcestring = sourcestring.ToUpper ();
			char[] chars = sourcestring.ToCharArray();
			for (int i=0; i<chars.Length; i++){
				if(chars[i] != ' ')
					characterSet.Add(chars[i]);
			}
			return characterSet;
		}

		HashSet<char> getAlphabet(){
			var characterSet = new HashSet<char>();
			characterSet.Add ('A');
			characterSet.Add ('B');
			characterSet.Add ('C');
			characterSet.Add ('D');
			characterSet.Add ('E');
			characterSet.Add ('F');
			characterSet.Add ('G');
			characterSet.Add ('H');
			characterSet.Add ('I');
			characterSet.Add ('J');
			characterSet.Add ('K');
			characterSet.Add ('L');
			characterSet.Add ('M');
			characterSet.Add ('N');
			characterSet.Add ('O');
			characterSet.Add ('P');
			characterSet.Add ('Q');
			characterSet.Add ('R');
			characterSet.Add ('S');
			characterSet.Add ('T');
			characterSet.Add ('U');
			characterSet.Add ('V');
			characterSet.Add ('W');
			characterSet.Add ('X');
			characterSet.Add ('Y');
			characterSet.Add ('Z');
			return characterSet;
		}
	}
}

