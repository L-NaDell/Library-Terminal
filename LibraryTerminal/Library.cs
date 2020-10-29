using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibraryTerminal
{
    class Library
    {
        const int offset = 1;
        public List<Media> BookStock { get; set; }

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
            List<Media> bookStock;
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
            Console.WriteLine("5) Return a book");
        }

        public void PrintBookList()
        {
            for (int i = 0; i < BookStock.Count; i++)
            {
                Book bookList = (Book) BookStock[i];
                Console.WriteLine($"{i + 1} : {bookList.Title}");
            }
        }

        public void ReturnBook()
        {
            Console.Clear();
            int bookChoice;

            Console.WriteLine($"Book Return{Environment.NewLine}");
            PrintBookList();
            Console.Write($"Please select a book to return: ");
            while(int.TryParse(Console.ReadLine(), out bookChoice) == false || bookChoice < 1 || bookChoice > BookStock.Count)
            {
                Console.Write($"You must enter 1 - {BookStock.Count}: ");
            }
            Console.WriteLine();
            BookStock[bookChoice - offset].Status = Status.OnShelf;
        }
    }
}
