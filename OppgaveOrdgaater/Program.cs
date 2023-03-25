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
        Console.WriteLine("Welcome to the word puzzle generator");
        Console.WriteLine();

        var words = FileLoader.Load(@"../../../ordliste.txt");
        var wordList = new WordList(words);

        Console.WriteLine("Words that end with ost: \n");
        wordList.ShowEndsWithWords("ost");

        Console.WriteLine("\n20 word puzzle pairs:");
        wordList.ShowWordPuzzles(20);
    }
}