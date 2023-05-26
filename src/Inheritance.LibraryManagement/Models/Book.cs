using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.LibraryManagement.Models
{
    public class Book
    {
        public Book
        (string title,
         string author,
         string isbn)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            if (string.IsNullOrEmpty(Isbn) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(title))
            {
                throw new ArgumentException();
            }
        }
        public string Title { get; set; }   
        public string Author { get; set; }  
        public string Isbn { get; set; }
        public bool Availability { get; set; } = true;
      

        public void MarkAsAvailable() => Availability = true;
        public void MarkAsUnavailable() => Availability = false;
        public string GetBookInfo()
        {
            string avialable = "";
            if (Availability)
                avialable = "Available";
            else avialable = "UnAvailable";
            var expectedBookInfo =
        @$"Title:           {Title}
           Author:          {Author}
           ISBN:            {Isbn}
           Availability:    {avialable}
           ------------------------------------";
            return
            expectedBookInfo;




        }
           



    }
}
