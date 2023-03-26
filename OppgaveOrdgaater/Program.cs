using System;

namespace OppgaveOrdgaater;

class Program
{
    /*
     * Searching the wordlist file on my computer was slow so I extracted the words
     * when loading the file into the program and also filtered out some words in
     * the constructor of the WordList class to reduce the processing speed during
     * word searches
     */
    static void Main(string[] args)
    {
        Run();
    }
    static void Run()
    {
        var words = FileLoader.Load(@"../../../ordliste.txt");
        var wordList = new WordList(words);

        /*
         * Console out all words in the file
         */
        ShowAllWords(words);

        /*
         * Check if there is a word that starts the last 3,4,5 characters of a randomly choosen word
         */
        Console.WriteLine("Check if there is a word that starts the last 3,4,5 characters of a randomly choosen word:");
        var randomWord = wordList.GetRandomWord();
        var startWithWord= wordList.GetStartsWithWordBySubstringLength(randomWord);

        if (startWithWord != null)
        {
            Console.WriteLine($"{startWithWord} starts with the same letters as {randomWord} ends with" + "\n");
        }
        else
        {
            Console.WriteLine($"There are no words that start with the same letters as {randomWord} ends with" + "\n");
        }

        /*
         * Show 20 word puzzle pairs
         */
        Console.WriteLine("Show 20 word puzzle pairs");
        var wordPuzzles = wordList.GetWordPuzzles(20);
        ShowAllWordPuzzles(wordPuzzles);

    }
    static void ShowAllWords(string[] words)
    {
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
        Console.WriteLine();
    }
    static void ShowAllWordPuzzles(string[][] wordPuzzles)
    {
        foreach (var wordPuzzle in wordPuzzles)
        {
            Console.WriteLine($"{wordPuzzle[0]}: {wordPuzzle[1]} og {wordPuzzle[2]}");
        }
    }
}