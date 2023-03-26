using System;
using System.Collections.Generic;

namespace OppgaveOrdgaater
{
	public class WordList
	{
		private string[] _words;

		public WordList(string[] words)
		{
			_words = FilterWords(words);
		}
		private string[] FilterWords(string[] words)
		{
		/*
		 * Method prefilters words when the class is instantiated for faster processing
		 */
			var filteredWord = words
				.Distinct()
				.Where(word =>
				{
						return word.Length > 2 && word.Length < 11 && word.Length < 11 && !word.Contains('-') && !word.Contains(" ");
				}).ToArray();

			return filteredWord;
		}
		public string GetRandomWord()
		{
			var random = new Random();
			while (true)
			{
				var randomIndex = random.Next(_words.Length);
				var word = _words[randomIndex];

				if (word.Length > 6)
				{
					return word;
				}
			}
		}
		private bool MatchesSearchCriteria(string searchWord, string word)
		{
			if (word != searchWord && searchWord.Length > 2 && word.Length > 6)
			{
				return true;
			}
			return false;
		}
		private string[] GetEndsWithWords(string searchWord)
		{
			var list = new List<string>();
			foreach (var word in _words)
			{
				if (word.EndsWith(searchWord) && MatchesSearchCriteria(searchWord, word))
				{
					list.Add(word);
				}
			}
			return list.ToArray();
		}
		private string GetStartsWithWord(string searchWord)
		{
			foreach (var word in _words)
			{
				if (word.StartsWith(searchWord) && MatchesSearchCriteria(searchWord, word))
				{
					return word;
				}
			}
			return null;
		}
		public string GetStartsWithWordBySubstringLength(string endsWithWord)
		{
			for (int substringLength = 3; substringLength < 6 ; substringLength++)
			{
				var substring = endsWithWord.Substring(endsWithWord.Length - substringLength);
				var word = GetStartsWithWord(substring);

				if (word != null)
				{
					return word;
				}
			}
			return null;
		}
		public string[][] GetWordPuzzles(int amountOfPuzzles)
		{
			Console.Write("Searching for words");
			var random = new Random();
			var wordPuzzles = new List<string[]>();

			for (int i = 0; i < amountOfPuzzles; i++)
			{
				while (true)
				{
					var commonWord = GetRandomWord();
					var startsWithWord = GetStartsWithWord(commonWord);
					var endsWithWords = GetEndsWithWords(commonWord);

					if (endsWithWords.Length > 0 && startsWithWord != null)
					{
						var randomEndsWithWord = endsWithWords[random.Next(endsWithWords.Length)];
						var wordPuzzle = new string[] { commonWord, startsWithWord, randomEndsWithWord };
						wordPuzzles.Add(wordPuzzle);
						Console.Write('.');

						if (wordPuzzles.Count == amountOfPuzzles)
						{
							Console.WriteLine();
							return wordPuzzles.ToArray();
						}
						break;                     
					}
				}
			}
			return wordPuzzles.ToArray();
		}
	}
}