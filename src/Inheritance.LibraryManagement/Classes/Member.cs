namespace Inheritance.LibraryManagement.Classes
{
    public class Member
    {
        
        private static int _id = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> BooksBorrowed { get; set; } = new();

        public Member(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            Id = _id++;
            Name = name;
            
        }

        public void BorrowBook(Book book)
        {
            if(book!=null)
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
            int count = 1;
            string bookName = "";
            foreach (var item in BooksBorrowed)
            {
                bookName += $"{count++}. {item.Title}";
            }
            
            return
$@"Member Name: {Name}
Member ID: {Id}
Books Borrowed:

{bookName}
------------------------------------";
        }
    }
}
