using System;
using System.Collections.Generic;

namespace LibraryTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Library lib = new Library();
            int menuChoice;
            bool notFinished = true;
            while (notFinished)
            {
                lib.DisplayMenu();
                // GetMenuChoice is stored as an int and passed into ExecuteMenuChoice which calls the appropriate method based on user choice
                menuChoice = lib.GetMenuChoice();
                lib.ExecuteMenuChoice(menuChoice);
                // save an changes made to text file (database)
                lib.UploadStockInformation();
                // prompt user to continue
                notFinished = lib.ReturnContinueChoice();
            }
        }

        public List<Book> Books { get; set; } = new List<Book>();

        //public Book CheckOut()
        //{
        //    PrintBookList();
        //    Console.Write("What book would you like to check out?  ");
        //    int book = int.Parse(Console.ReadLine());

        //    switch (book.Status)
        //    {
        //        case "CheckedOut":
        //            Console.WriteLine($"I'm sorry, that book is already checked out. It is due back on {book.DueDate}.");
        //            break;
        //        case "OnShelf":
        //            book.Status = "CheckedOut";
        //            book.DueDate = DateTime.Now.AddDays(14);
        //            break;
        //    }
        //}
    }
}
