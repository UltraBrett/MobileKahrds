using System;
using System.Collections.Generic;

namespace MobileKahrds
{
	public class HangmanModel
	{
		public HangmanModel(String k, String v ){
			termKey = k;
			definitionValue = v;
			penaltyCount = 0;
			hiddenChars = tokenizeCharSet(termKey);
			guessedChars = new HashSet<char>();
		}	

		public string termKey { private set; get; }
		public string definitionValue { private set; get; }
		public HashSet<char> hiddenChars { private set; get; }
		public HashSet<char> guessedChars { private set; get; }
		private int penaltyCount;

		int incrementPenaltyCount(){
			return ++penaltyCount;
		}

		HashSet<char> tokenizeCharSet(String sourcestring){
			var characterSet = new HashSet<char>();
			char[] chars = sourcestring.ToCharArray();
			for (int i=0; i<chars.Length; i++){
				characterSet.Add(chars[i]);
			}
			return characterSet;
		}
	}
}

