using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LibraryTerminal
{
    class Library
    {
        public List<Media> BookStock { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();

        public Library() {
            List<Media> booksFromFile = new List<Media>();
            StreamReader read = new StreamReader("../../../Data/BookStock.txt");
            string line = read.ReadLine();

            while (line != null)
            {
                string[] bookProperties = line.Split("|");
                Status status = (Status) Enum.Parse(typeof(Status), bookProperties[1]);
                booksFromFile.Add(new Book(
                    bookProperties[0],
                    status,
                    DateTime.Parse(bookProperties[2]),
                    bookProperties[3]
                    ));
                line = read.ReadLine();
            }
            read.Close();
            BookStock = booksFromFile;
        }

        public void UploadStockInformation()
        {
            List<Media> bookStock = new List<Media>();
            StreamWriter streamWriter = new StreamWriter("../../../Data/BookStock.txt");
            bookStock = BookStock;

            foreach (Book book in bookStock)
            {
                streamWriter.WriteLine($"{book.Title}|{book.Status}|{book.DueDate}|{book.Author}");
            }
            streamWriter.Close();
        }

        public void DisplayMenu()
        {
            Console.WriteLine($"Welcome to the Grand Circus Library{Environment.NewLine}");
            Console.WriteLine("Please select an option: ");
            Console.WriteLine("1) List Books");
            Console.WriteLine("2) Search for a book by Author");
            Console.WriteLine("3) Search for a book by Title");
            Console.WriteLine("4) Checkout a book");
        }

        public void PrintBookList()
        {
            for (int i = 0; i < Books.Count; i++)
            {
                Book bookList = Books[i];
                Console.WriteLine($"{i + 1} : {bookList.Title}");
            }
        }

        public void CheckOut()
        {
            PrintBookList();
            Console.Write("What book would you like to check out?  ");
            int bookIndex = int.Parse(Console.ReadLine());

            Book book = Books[bookIndex -1];

            switch (book.Status)
            {
                case Status.CheckedOut:
                    Console.WriteLine($"I'm sorry, that book is already checked out. It is due back on {book.DueDate}.");
                    break;
                case Status.OnShelf:
                    book.Status = Status.CheckedOut;
                    book.DueDate = DateTime.Now.AddDays(14);
                    Console.WriteLine($"Thank you for checking out {book.Title}, please return it by {book.DueDate}.");
                    break;
            }
        }
    }
}
