using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.LibraryManagement.Entities
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public bool Availability { get; set; }

        public Book(string Title, string Author, string Isbn)
        {
            if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Author) || string.IsNullOrEmpty(Isbn))
            {
                throw new ArgumentException();
            }
            this.Title = Title;
            this.Author = Author;
            this.Isbn = Isbn;
        }

        public void MarkAsAvailable()
        {
            Availability = true;
        }

        public void MarkAsUnavailable()
        {
            Availability = false;
        }

        public string GetBookInfo()
        {
            var expectedBookInfo =
@$"Title:          {Title}
Author:         {Author}
ISBN:           {Isbn}
Availability:   {Availability}
------------------------------------";

            return expectedBookInfo;
        }

    }
}
