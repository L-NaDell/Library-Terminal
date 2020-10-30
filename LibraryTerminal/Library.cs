using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibraryTerminal
{
    class Library
    {
        // global variables
        const int offset = 1;
        // properties
        public List<Media> BookStock { get; set; }
        // constructor
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
        // methods
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
            Console.Clear();
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
            // if the user enters something other than a number or if the choice is out of range, it will continue to prompt the user to choose
            while(int.TryParse(Console.ReadLine(), out bookChoice) == false || bookChoice < 1 || bookChoice > BookStock.Count)
            {
                Console.Write($"You must enter 1 - {BookStock.Count}: ");
            }
            Console.WriteLine();
            // changes the Status of the book chosen by the user. offset is used to subtract 1 from the users choice to call the correct index
            BookStock[bookChoice - offset].Status = Status.OnShelf;
        }
        public int GetMenuChoice()
        {
            string userInput;
            int userChoice;
            const int lowestChoice = 1;
            const int highestChoice = 5;

            Console.Write($"{Environment.NewLine}Enter your choice: ");

            while(int.TryParse(Console.ReadLine(), out userChoice) == false || userChoice < lowestChoice || userChoice > highestChoice)
            {
                Console.Write($"You must enter {lowestChoice} - {highestChoice}: ");
            }
            return userChoice;
        }
        public void ExecuteMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    PrintBookList();
                    break;
                case 2:
                    ReturnBook();
                    break;
                case 3:
                    ReturnBook();
                    break;
                case 4:
                    //CheckOut();
                    break;
                case 5:
                    ReturnBook();
                    break;
                default:
                    break;
            }
        }
        public bool ReturnContinueChoice()
        {
            string userInput;
            Console.Write($"{Environment.NewLine}Would you like to continue? (y or n): ");
            userInput = Console.ReadLine().Trim().ToLower();

            while(userInput != "y" && userInput != "n")
            {
                Console.Write("You must enter y or n: ");
                userInput = Console.ReadLine().Trim().ToLower();
            }

            if (userInput == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}