using System;
using System.Collections.Generic;

namespace OppgaveOrdgaater
{
		public class WordList
		{
				private string[] _words;

				public WordList(string[] words)
				{
						_words = words.Distinct().Where(word =>
						{
								return word.Length > 2 && word.Length < 11 && word.Length < 11 && !word.Contains('_') && !word.Contains(" ");
						}).ToArray();
				}
				private bool MatchesSearchCriteria(string searchWord, string word, string prevWord)
				{
						if (word != prevWord && word != searchWord && searchWord.Length > 2 && word.Length > 6)
						{
								return true;
						}
						return false;
				}
				public void ShowEndsWithWords(string searchWord)
				{
						var prevWord = "";
						foreach (var word in _words)
						{
								if (word.EndsWith(searchWord) && MatchesSearchCriteria(searchWord, word, prevWord))
								{
										Console.WriteLine(word);
										prevWord = word;
								}
						}            
				}
				public string[] GetEndsWithWords(string searchWord)
				{
						var list = new List<string>();
						var prevWord = "";
						foreach (var word in _words)
						{
								if (word.EndsWith(searchWord) && MatchesSearchCriteria(searchWord, word, prevWord))
								{
										list.Add(word);
								}
								prevWord = word;
						}
						return list.ToArray();
				}
				public string GetStartsWithWord(string searchWord)
				{
						var prevWord = "";
						foreach (var word in _words)
						{
								if (word.StartsWith(searchWord) && MatchesSearchCriteria(searchWord, word, prevWord))
								{
										return word;
								}
								prevWord = word;
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
				public string[] GetWordsThatCanGoAtStartAndEnd(int amountOfWordsRequested)
				{
						var list = new List<string>();

						foreach (var word in _words)
						{
								var endsWithWords = GetEndsWithWords(word);

								if (endsWithWords.Length > 0)
								{
										foreach (var endsWithWord in endsWithWords)
										{
												var startsWithWord = GetStartsWithWord(word);

												if (startsWithWord != null && !list.Contains(word))
												{
														Console.Write(".");
														list.Add(word);
														if (list.Count == amountOfWordsRequested) return list.ToArray();
												}
										}
								}
						}
						return null;
				}
				public void ShowWordPuzzles(int amountOfPuzzles)
				{
						var random = new Random();
						Console.Write("loading..");
						Console.WriteLine();

						foreach (var word in GetWordsThatCanGoAtStartAndEnd(amountOfPuzzles))
						{
								var endsWithWords = GetEndsWithWords(word);
								var randomIndex = random.Next(0, endsWithWords.Length);
								var endsWithWord = endsWithWords[randomIndex];
								var startsWithWord = GetStartsWithWord(word);

								Console.WriteLine();
								Console.WriteLine($"{word}: {endsWithWord} og {startsWithWord}");
						}
				}
		}
}