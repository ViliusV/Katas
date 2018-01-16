using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleSandbox
{
    public class DuplicateEncoderUtility
    {
        public static string DuplicateEncode(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return string.Empty;
            }
            
            var lowercaseWord = word.ToLowerInvariant();
            var counters = GetCounters(lowercaseWord);
            var encodedText = Encode(lowercaseWord, counters);

            return encodedText;
        }

        private static IDictionary<char, int> GetCounters(string word)
        {
            var counters = new Dictionary<char, int>();
            var distinctSymbols = word.Distinct();
            foreach (var symbol in distinctSymbols)
            {
                counters.Add(symbol, word.Count(s => s.Equals(symbol)));
            }

            return counters;
        }

        private static string Encode(string word, IDictionary<char, int> counters)
        {
            var encodedString = string.Empty;
            foreach (var symbol in word)
            {
                var newSymbol = counters[symbol] == 1 ? "(" : ")";
                encodedString += newSymbol;
            }

            return encodedString;
        }
    }
}
