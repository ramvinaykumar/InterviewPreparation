using ConsoleApp.Interview.Questionnaire.OccurrencesOfCharacterInString;
using ConsoleApp.Interview.Questionnaire.PrimeNumber;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // number of occurrences of a character in a string
            // Using Dictionary and for loop
            Console.WriteLine("Using Dictionary and for loop!");
            var countCharOccurrences = OccurrencesOfACharacterInString.GetOccurrencesOfACharacterInString("SHUBHLAXMI");
            foreach (var character in countCharOccurrences)
            {
                Console.WriteLine(character.Key + ", " + character.Value);
            }

            // Using Dictionary and foreach
            Console.WriteLine("Using Dictionary and foreach!");
            var charOccurrences = OccurrencesOfACharacterInString.CountCharOccurrences_Foreach("RamVinayKumar");
            foreach (var character in charOccurrences)
            {
                Console.WriteLine(character.Key + ", " + character.Value);
            }

            // Using Linq
            Console.WriteLine("Using Linq!");
            var charOccurrenceLinq = OccurrencesOfACharacterInString.CountCharOccurrences_LINQ("KeshavAnand");
            foreach (var character in charOccurrenceLinq)
            {
                Console.WriteLine(character.Key + ", " + character.Value);
            }

            // Using Loop
            Console.WriteLine("Using Loop!");
            OccurrencesOfACharacterInString.CountCharOccurrences_Loop("KaushikiAnand");
            Console.WriteLine("Hello World!");

            // Prime number function
            Console.WriteLine("Enter the from number: ");
            int fromNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the to number: ");
            int toNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Prime numbers between {fromNumber} and {toNumber} are:");
            for (int i = fromNumber; i <= toNumber; i++)
            {
                if (PrimeNumber.IsPrime(i))
                {
                    Console.WriteLine("This Number ==>> " + i + " Is A Prime Number ==>> " + PrimeNumber.IsPrime(i));
                }
                else
                {
                    Console.WriteLine("This Number ==>> " + i + " Is Not A Prime Number ==>> " + PrimeNumber.IsPrime(i));
                }
            }

            Console.ReadLine();
        }
    }
}