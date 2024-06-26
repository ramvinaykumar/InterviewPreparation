using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Interview.Questionnaire.PrimeNumber
{
    public static class PrimeNumber
    {
        /// <summary>
        /// Check whether given number is prime or not
        /// </summary>
        /// <param name="number">input number to check prime</param>
        /// <returns>Returns true or false</returns>
        public static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
