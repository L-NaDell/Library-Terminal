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

            lib.UploadStockInformation();

       
        }


    }
}
