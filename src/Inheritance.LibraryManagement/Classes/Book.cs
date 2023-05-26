namespace Inheritance.LibraryManagement.Classes
{
    public class Book
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Isbn { get; set; } = string.Empty;
        public bool Availability { get; set; }

        public Book(string title, string author, string isbn)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(isbn))
            {
                throw new ArgumentException();
            }

            Title = title;
            Author = author;
            Isbn = isbn;
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
            
            return
$@"Title:          {Title}
Author:         {Author}
ISBN:           {Isbn}
Availability:   {Availability}
------------------------------------";

        }

    }
}
