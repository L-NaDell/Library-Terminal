using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTerminal
{
    class Movie : Media
    {
        public Movie(string Title, Status Status, DateTime DueDate)
            : base(Title, Status, DueDate)
        {
        }
    }
}
