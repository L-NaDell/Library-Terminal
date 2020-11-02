using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibraryTerminal
{
    class Library
    {
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
            for (int i = 0; i < BookStock.Count; i++)
            {
                Book bookList = BookStock[i];
                Console.WriteLine($"{i + offset} : {bookList.Author}");
            }
        }







































































































































































































        public void SearchByAuthor(Status status)
        {
            int counter = 0;
            string userInput;
            Console.WriteLine("Which Author would you like to search for?");
            userInput = Console.ReadLine().Trim().ToLower();

            while (userInput.Equals(""))
            {
                Console.WriteLine("You must enter a value.");
                userInput = Console.ReadLine().Trim().ToLower();
            }

            for (int i = 0; i < BookStock.Count; i++)
            {
                Book bookList = BookStock[i];
                if (bookList.Author.ToLower() == userInput)
                {
                    Console.WriteLine($"{i + offset} : {bookList.Author}");
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("There are no books to list by this Author.");
            }
        }


        public void SearchByTitle(Status status)
        {
            int counter = 0;
            string userInput;
            Console.WriteLine("Which Author would you like to search for?");
            userInput = Console.ReadLine().Trim().ToLower();

            while (userInput.Equals(""))
            {
                Console.WriteLine("You must enter a value.");
                userInput = Console.ReadLine().Trim().ToLower();
            }

            for (int i = 0; i < BookStock.Count; i++)
            {
                Book bookList = BookStock[i];
                if (bookList.Title.ToLower().Contains(userInput))
                {
                    Console.WriteLine($"{i + offset} : {bookList.Title}");
                    counter++;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("There are no books to list.");
            }
        }
    }
}
