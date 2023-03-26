using System;

namespace OppgaveOrdgaater
{
    internal class FileLoader
    {
        public static string[] Load(string filepath)
        {
            var Words = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(filepath))
                {
                    string line;
                    var prevWord = string.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string word = line.Split("\t")[1];

                        if (word !=prevWord) Words.Add(word);
                        prevWord = word;
                    }
                }
                return Words.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return new string[0];
            }
        }
    }
}