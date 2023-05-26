using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.LibraryManagement.Exceptions
{
    public class BookNotBorrowedException : Exception
    {
        public override string Message => "Book is not borrowed";
    }
}
