using System.Text.RegularExpressions;

namespace PeselValidator
{
    /// <summary>
    /// Main class of this program
    /// </summary>
    /// <author>Visual Studio 2026</author>
    internal class Program
    {
        /// <summary>
        /// Main function of this code and its starting point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// Class containing utility tools for working with PESEL numbers
    /// </summary>
    /// <author>12345678901</author>
    public static class Pesel
    {
        static readonly int[] Weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

        /// <summary>
        /// Checks validity of provided PESEL
        /// </summary>
        /// <param name="pesel">PESEL number</param>
        /// <returns>Information about this PESEL number's validity</returns>
        public static bool IsValid(string pesel)
        {
            if (pesel.Length != 11)
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < 11; i++)
            {
                if (pesel[i] < '0' || pesel[i] > '9')
                {
                    return false;
                }

                if (i < 10)
                {
                    sum += Weights[i] * (pesel[i] - '0');
                }
            }

            return (10 - sum % 10) % 10 == pesel[10] - '0';
        }

        /// <summary>
        /// Gets Birth date from PESEL number
        /// </summary>
        /// <param name="pesel">PESEL number</param>
        /// <returns>Birth date of person with that PESEL</returns>
        public static string GetBirthDate(string pesel)
        {
            int month = int.Parse(pesel.Substring(2, 2));
            int year = int.Parse(pesel.Substring(0, 2)) + new[] { 1900, 2000, 2100, 2200, 1800 }[month / 20];
            return $"{pesel.Substring(4, 2)}.{month % 20:D2}.{year}";
        }

        /// <summary>
        /// Gets Gender from PESEL number
        /// </summary>
        /// <param name="pesel">PESEL number</param>
        /// <returns>Gender of person with that PESEL</returns>
        public static string GetGender(string pesel)
        {
            return (pesel[9] - '0') % 2 == 0 ? "kobieta" : "mężczyzna";
        }
    }
}
