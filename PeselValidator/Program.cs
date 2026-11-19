using System.Text.RegularExpressions;

namespace PeselValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public static class Pesel
    {
        static readonly int[] Weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

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

        public static string GetBirthDate(string pesel)
        {
            int month = int.Parse(pesel.Substring(2, 2));
            int year = int.Parse(pesel.Substring(0, 2)) + new[] { 1900, 2000, 2100, 2200, 1800 }[month / 20];
            return $"{pesel.Substring(4, 2)}.{month % 20:D2}.{year}";
        }

        public static string GetGender(string pesel)
        {
            return (pesel[9] - '0') % 2 == 0 ? "kobieta" : "mężczyzna";
        }
    }
}
