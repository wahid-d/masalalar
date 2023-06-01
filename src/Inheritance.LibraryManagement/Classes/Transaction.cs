namespace Inheritance.LibraryManagement.Classes
{
    public class Transaction
    {
        public Member Member { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnedData { get; set; }

        public Transaction(Member menber, Book book, DateTime time)
        {
            Member = menber;
            Book = book;
            BorrowedDate = time;
        }

        public void SetReturnDate(DateTime time)
        {
            ReturnedData = time;
        }
        public string CalculateFine()
        {
            if(DateTime.Now > ReturnedData)
            {
                int res = (DateTime.Now.Day - ReturnedData.Day) * 10;

                return $"{res}";
            }
            return "0";
        }
    }
}
