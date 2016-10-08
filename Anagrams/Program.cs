using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            var anagrams = File.ReadAllLines(args[0])
                .ToLookup(w => w.Signature());

            foreach (var word in args.Skip(1))
            {
                WriteLine($"Anagrams for \"{word}\":");
                foreach (var anagram in anagrams[word.Signature()])
                    WriteLine(anagram);

                WriteLine();
            }
        }
    }

    static class Anagram
    {
        public static string Signature(this string word) =>
            new string(word.ToLowerInvariant().OrderBy(c => c).ToArray());
    }
}
