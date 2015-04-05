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
		static HashSet<char> hiddenChars;
		static HashSet<char> guessedChars;	
		private int penaltyCount;


		String getTermKey() {
			return termKey;
		}

		String getDefinitionValue() {
			return definitionValue;
		}

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

