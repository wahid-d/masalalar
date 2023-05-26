using Inheritance.LibraryManagement.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.LibraryManagement.Models
{
    public class Member
    {
        internal static int _Id { get; private set; } = 0;
        public int Id { get; set; }

        public Member(string name = "no name")
        {
            Name = name;
            _Id++;
            Id = _Id;

        }
       
        public string Name { get; set; }
        public List<Book> BooksBorrowed { get; set; } = new List<Book>();


        public void BorrowBook(Book book)
        {
           BooksBorrowed.Add(book);
            
        }
        public void ReturnBook(Book book)
        {
            if (BooksBorrowed.Contains(book))
                BooksBorrowed.Remove(book);
            else throw new BookNotBorrowedException();
        }

        public string GetMemberInfo()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < BooksBorrowed.Count; i++)
            {
                sb.AppendLine("1. "+BooksBorrowed[i].Title);
            }
            var expectedMemberInfo =
        @$"Member Name:        {Name}
        Member ID:          {Id}
        Books Borrowed:

        " + sb +
        "------------------------------------";
            return expectedMemberInfo;
          
                
        }
       
    }
}
