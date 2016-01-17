using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock.Classes
{
    class NotANumberException : Exception
    {
        const string message = "Not a number was passed as curent time.";

        public NotANumberException( ) : base( message ) { }
    }
}
