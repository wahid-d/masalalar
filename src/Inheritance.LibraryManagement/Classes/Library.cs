using System.Linq;

namespace Inheritance.LibraryManagement.Classes
{
    public class Library
    {
        public int BookCount;
       
        public List<Book> Books { get; set; } = new();
        public List<Member> Members { get; set; } = new();
        
        public void AddBook(Book book)
        {
            if(book != null)
            {
                Books.Add(book);
                BookCount = Books.Count;
            }
            else throw new ArgumentNullException(nameof(book));
            
        }

        public void RemoveBook(Book book)
        {
            if(!Books.Contains(book))
            {
                throw new BookNotFoundException();
            }
            Books.Remove(book);
            BookCount = Books.Count;
        }
        
        public void AddMember(Member member)
        {
            if(member != null)
                Members.Add(member);
        }

        public void RemoveMember(Member member)
        {
            if (!Members.Contains(member))
            {
                throw new MemberNotFoundException();
            }
            Members.Remove(member);
        }

    }
}
