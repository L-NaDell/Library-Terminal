using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibraryTerminal
{
    class Library
    {
        public List<Media> LibraryStock { get; set; }

        public Library() {
            List<Media> booksFromFile = new List<Media>();
            StreamReader read = new StreamReader("../../../Data/BookStock.txt");
            string line = read.ReadLine();

            while(line != null)
            {
                string[] bookProperties = line.Split("|");
                booksFromFile.Add(new Book(
                    bookProperties[0],
                    )
            }
        }

        List<Media> libraryStock = new List<Media>();

        
    }
}
