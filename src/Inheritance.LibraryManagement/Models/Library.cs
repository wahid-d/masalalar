using Inheritance.LibraryManagement.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.LibraryManagement.Models
{
    public class Library
    {
        

        public Library()
        {
          
        }
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Member> Members { get; set; } = new List<Member>();

        public int BookCount { get; set; }

        public void AddBook(Book book)
        {
           
            Books.Add(book);
            BookCount = Books.Count;
        }
        public void RemoveBook(Book book)
        {
            if (!(Books.Contains(book)))
                throw new BookNotFoundException();

           
            Books.Remove(book);
            BookCount = Books.Count;

        }
        public void AddMember(Member member)
        {
            Members.Add(member);
        }
        public void RemoveMember(Member member)
        {
            if(!Members.Contains(member))
                throw new MemberNotFoundException();
            Members.Remove(member);
        }

    }
}
