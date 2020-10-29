using System;
using System.Collections.Generic;

namespace LibraryTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public void PrintBookList()
        {
            for (int i = 0; i < Books.Count; i++)
            {
                Book bookList = Books[i];
                Console.WriteLine($"{i + 1} : {bookList.Title}");
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
