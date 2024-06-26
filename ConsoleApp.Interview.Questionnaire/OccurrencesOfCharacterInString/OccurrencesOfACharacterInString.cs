using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Interview.Questionnaire.OccurrencesOfCharacterInString
{
    public static class OccurrencesOfACharacterInString
    {
        public static Dictionary<char, int> GetOccurrencesOfACharacterInString(string input)
        {
            var result = new Dictionary<char, int>();

            if (string.IsNullOrEmpty(input))
            {
                result = new Dictionary<char, int>();
            }
            else
            {
                var charcount = input.ToLowerInvariant().Replace(" ", string.Empty).ToCharArray();
                for (int i = 0; i <= charcount.Length - 1; i++)
                {
                    if (!result.Keys.Contains(charcount[i]))
                    {
                        result.Add(charcount[i], 1);
                    }
                    else if (result.Keys.Contains(charcount[i]))
                    {
                        result[charcount[i]] = result[charcount[i]] + 1;
                    }
                }
            }
            return result;
        }

        public static Dictionary<char, int> CountCharOccurrences_Foreach(string str)
        {
            var charCounts = new Dictionary<char, int>();
            foreach (char ch in str.ToLowerInvariant().Replace(" ", string.Empty))
            {
                if (charCounts.ContainsKey(ch))
                {
                    charCounts[ch]++;
                }
                else
                {
                    charCounts.Add(ch, 1);
                }
            }
            return charCounts;
        }

        public static Dictionary<char, int> CountCharOccurrences_LINQ(string str)
        {
            Dictionary<char, int> charCounts = str.ToLowerInvariant().Replace(" ", string.Empty)
                                         .GroupBy(c => c)
                                         .ToDictionary(gr => gr.Key, gr => gr.Count());
            
            return charCounts;
        }

        public static void CountCharOccurrences_Loop(string message)
        {
            while (message.Length > 0)
            {
                Console.Write(message[0].ToString().ToLowerInvariant() + " : ");
                int count = 0;
                for (int j = 0; j < message.Length; j++)
                {
                    if (message[0] == message[j])
                    {
                        count++;
                    }
                }
                Console.WriteLine(count);
                message = message.Replace(message[0].ToString(), string.Empty);
            }
        }
    }
}
