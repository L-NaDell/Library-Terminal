using System;
using System.Collections.Generic;

namespace LibraryTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Library lib = new Library();
            lib.DisplayMenu();
            lib.ReturnBook();
            lib.UploadStockInformation();
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
