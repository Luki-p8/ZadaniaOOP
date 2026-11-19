namespace Library
{
    /// <summary>
    /// Class containing data about one singular book
    /// </summary>
    /// <author>
    /// 12345678901
    /// </author>
    public class Book
    {
        static int nextId = 1;

        public int Id { get; }
        public string Title { get; }
        public string Author { get; }
        public int Year { get; }
        public bool Available { get; set; } = true;


        /// <summary>
        /// Constructor of class Book
        /// </summary>
        /// <param name="title">Title of book</param>
        /// <param name="author">Author of book</param>
        /// <param name="year">Release year</param>
        /// <author>
        /// 12345678901
        /// </author>
        public Book(string title, string author, int year)
        {
            Id = nextId++;
            Title = title;
            Author = author;
            Year = year;
        }


        /// <summary>
        /// Function describing a book - all its data
        /// </summary>
        /// <returns>String containing short info about the book</returns>
        /// <author>
        /// 12345678901
        /// </author>
        public string Describe()
        {
            return $"[{Id}] {Title} - {Author} ({Year}) - {(Available ? "dostępna" : "wypożyczona")}";
        }
    }


    /// <summary>
    /// Class containing collection of books - library
    /// </summary>
    /// <author>
    /// 12345678901
    /// </author>
    public class Library
    {
        readonly List<Book> books = new List<Book>();

        public List<Book> All => books;

        /// <summary>
        /// Adds new book to the library
        /// </summary>
        /// <param name="book">Book object</param>
        public void Add(Book book)
        {
            books.Add(book);
        }

        /// <summary>
        /// Finds a book in the library by its id
        /// </summary>
        /// <param name="id">Id of a book</param>
        /// <returns>Book object</returns>
        public Book Find(int id)
        {
            foreach (Book book in books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }

            return null;
        }

        /// <summary>
        /// Marks a book as borrowed
        /// </summary>
        /// <param name="id">Id of a book</param>
        /// <returns>Availability of that book</returns>
        public bool Borrow(int id)
        {
            Book book = Find(id);

            if (book == null || !book.Available)
            {
                return false;
            }

            book.Available = false;
            return true;
        }

        /// <summary>
        /// Returns borrowed book
        /// </summary>
        /// <param name="id">Id of a book</param>
        /// <returns>Result of that operation</returns>
        public bool Return(int id)
        {
            Book book = Find(id);

            if (book == null || book.Available)
            {
                return false;
            }

            book.Available = true;
            return true;
        }

        /// <summary>
        /// Searches a book by its author
        /// </summary>
        /// <param name="fragment">Fragment of authors name</param>
        /// <returns>List of books mathing search criteria</returns>
        public List<Book> SearchByAuthor(string fragment)
        {
            List<Book> result = new List<Book>();

            foreach (Book book in books)
            {
                if (book.Author.ToLower().Contains(fragment.ToLower()))
                {
                    result.Add(book);
                }
            }

            return result;
        }


        /// <summary>
        /// Lists all available books
        /// </summary>
        /// <returns>List of available books</returns>
        public List<Book> ListAvailable()
        {
            List<Book> result = new List<Book>();

            foreach (Book book in books)
            {
                if (book.Available)
                {
                    result.Add(book);
                }
            }

            return result;
        }

        /// <summary>
        /// Finds the oldest book in library
        /// </summary>
        /// <returns>Oldest book</returns>
        public Book Oldest()
        {
            Book oldest = null;

            foreach (Book book in books)
            {
                if (oldest == null || book.Year < oldest.Year)
                {
                    oldest = book;
                }
            }

            return oldest;
        }
    }

    /// <summary>
    /// Main class of this Program
    /// </summary>
    /// <authors>
    /// 012345678901
    /// Visual Studio 2026
    /// </authors>
    static class Program
    {

        /// <summary>
        /// Main function of this code and its starting point
        /// </summary>
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Library library = new Library();
            library.Add(new Book("Pan Tadeusz", "Adam Mickiewicz", 1834));
            library.Add(new Book("Lalka", "Bolesław Prus", 1890));
            library.Add(new Book("Quo Vadis", "Henryk Sienkiewicz", 1896));
            library.Add(new Book("Chłopi", "Władysław Reymont", 1904));
            library.Add(new Book("Dziady", "Adam Mickiewicz", 1822));
            library.Add(new Book("Ferdydurke", "Witold Gombrowicz", 1937));

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Lista wszystkich książek");
                Console.WriteLine("2. Lista dostępnych książek");
                Console.WriteLine("3. Wypożycz");
                Console.WriteLine("4. Zwróć");
                Console.WriteLine("5. Szukaj po autorze");
                Console.WriteLine("6. Najstarsza książka");
                Console.WriteLine("0. Koniec");
                Console.Write("Wybór: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        PrintBooks(library.All);
                        break;
                    case "2":
                        PrintBooks(library.ListAvailable());
                        break;
                    case "3":
                        int borrowNumber = ReadNumber();
                        Book toBorrow = library.Find(borrowNumber);
                        Console.WriteLine(library.Borrow(borrowNumber)
                            ? $"Wypożyczono: {toBorrow.Title}"
                            : "Nie można wypożyczyć: książka nie istnieje lub jest już wypożyczona");
                        break;
                    case "4":
                        int returnNumber = ReadNumber();
                        Book toReturn = library.Find(returnNumber);
                        Console.WriteLine(library.Return(returnNumber)
                            ? $"Zwrócono: {toReturn.Title}"
                            : "Nie można zwrócić: książka nie istnieje lub nie jest wypożyczona");
                        break;
                    case "5":
                        Console.Write("Fragment nazwiska autora: ");
                        List<Book> found = library.SearchByAuthor(Console.ReadLine() ?? "");
                        if (found.Count == 0)
                        {
                            Console.WriteLine("Nie znaleziono książek tego autora");
                        }
                        else
                        {
                            PrintBooks(found);
                        }
                        break;
                    case "6":
                        Book oldest = library.Oldest();
                        Console.WriteLine(oldest == null ? "Biblioteka jest pusta" : oldest.Describe());
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Nieznana opcja");
                        break;
                }
            }
        }

        /// <summary>
        /// User input number prompt and handling
        /// </summary>
        /// <returns>Number from user's keyboard</returns>
        static int ReadNumber()
        {
            Console.Write("Numer książki: ");
            int.TryParse(Console.ReadLine(), out int number);
            return number;
        }

        /// <summary>
        /// Prints Data of Multiple books
        /// </summary>
        /// <param name="books">List of books</param>
        static void PrintBooks(List<Book> books)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Brak książek");
                return;
            }

            foreach (Book book in books)
            {
                Console.WriteLine(book.Describe());
            }
        }
    }
}
