namespace PasswordGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Hasło{i + 1}: {PasswordGenerator.Generate()}\n");
            }

        }
    }

    public class PasswordGenerator
    {
        private static Random rnd = new Random();
        private static string regularLetters = "qwertyuiopasdfghjklzxcvbnm";
        private static string capitalLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private static string diacreticLetters = "ąćęłńóśźżĄĆĘŁŃÓŚŹŻ";
        private static string specialCharacters = "!@#$%^&*()_+";
        private static string numbers = "1234567890";

        public PasswordGenerator() { }


        /// <summary>
        /// Generates password using specified number of characters
        /// </summary>
        /// <param name="regularLettersNumber">Number of regular letters</param>
        /// <param name="capitalLettersNumber">Number of capital letters</param>
        /// <param name="diacreticLettersNumber">Number of diacretic letters, don't use them, this will only bring pain and despair, have a mercy</param>
        /// <param name="numbersNumber">Number of numbers</param>
        /// <param name="specialCharactersNumber">Number of special characters</param>
        /// <returns>Generated password</returns>
        public static string Generate(
            int regularLettersNumber = 3,
            int capitalLettersNumber = 3,
            int diacreticLettersNumber = 2,
            int numbersNumber = 2,
            int specialCharactersNumber = 2
            )
        {
            int passwordLength = regularLettersNumber + capitalLettersNumber + diacreticLettersNumber + numbersNumber + specialCharactersNumber;

            List<char> chars = new List<char>();

            void Randomize(int length, string source)
            {
                for (int i = 0; i < length; i++)
                {
                    char c = source[rnd.Next(source.Length)];
                    chars.Add(c);
                }
            }

            Randomize(regularLettersNumber, regularLetters);
            Randomize(capitalLettersNumber, capitalLetters);
            Randomize(diacreticLettersNumber, diacreticLetters);
            Randomize(specialCharactersNumber, specialCharacters);
            Randomize(numbersNumber, numbers);

            string password = "";

            for (int i = chars.Count; i > 0; i--)
            {
                int r = rnd.Next(i);

                password += chars[r];

                chars.RemoveAt(r);
            }
            return password;

        }
    }
}