using Inheritance.LibraryManagement.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Inheritance.LibraryManagement.Entities
{
    public class Member
    {
        private static int nextId = 1;

        public int Id { get; private set; }
        public string Name { get; set; }
        public List<Book> BooksBorrowed { get; set; } = new List<Book>();

        public Member(string Name)
        {
            this.Id = nextId++;
            this.Name = Name;
        }


        public void BorrowBook(Book book)
        {
            BooksBorrowed.Add(book);
        }

        public void ReturnBook(Book book)
        {
            if (!BooksBorrowed.Contains(book))
            {
                throw new BookNotBorrowedException();
            }
            BooksBorrowed.Remove(book);
        }

        public string GetMemberInfo()
        {
            int i = 1;
            string booksName = "";
            foreach (var book in BooksBorrowed)
            {
                booksName += $"{i++}. {book.Title} \n";
            }

            var expectedMemberInfo =
@$"Member Name:        {Name}
Member ID:          {Id}
Books Borrowed:

{booksName}
------------------------------------";

            return expectedMemberInfo;
        }
    }

}
