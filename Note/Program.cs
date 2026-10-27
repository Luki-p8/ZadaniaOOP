namespace Note
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Note note1 = new Note("abc", "def", true);

            string temp = Console.ReadLine();
            Note note2 = new Note(temp);

            note1.Display();
            note2.Display();
        }
    }

    public class Note
    {
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public bool IsImportant { get; set; } = false;
        public DateOnly CreationDate { get; set; }

        public Note(string title, string content, bool isImportant)
        {
            this.Title = title;
            this.Content = content;
            this.IsImportant = isImportant;

            this.CreationDate = DateOnly.FromDateTime(DateTime.Now);
        }

        public Note(string title)
        {
            this.Title = title;
            this.Content = "";
            this.IsImportant = false;

            this.CreationDate = DateOnly.FromDateTime(DateTime.Now);
        }

        /// <summary>
        /// Displays Note's information
        /// </summary>
        public void Display()
        {
            Console.WriteLine("_____________________________");
            Console.WriteLine($"Notatka {(IsImportant ? "WAŻNA! " : "") + Title}");
            Console.WriteLine(Content);
            Console.WriteLine(CreationDate.ToString());
            Console.WriteLine("_____________________________");
        }
    }
}
