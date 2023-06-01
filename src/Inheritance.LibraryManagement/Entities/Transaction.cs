using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.LibraryManagement.Entities
{
    public class Transaction
    {
        public Member Member { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnedData { get; set; }

        public Transaction(Member member, Book book, DateTime borrowDate)
        {
            Member = member;
            Book = book;
            BorrowedDate = borrowDate;
        }

        public void SetReturnDate(DateTime dateTime)
        {
            BorrowedDate = dateTime;
        }

        public int CalculateFine()
        {
            if (ReturnedData < DateTime.Now)
            {
                int result = (DateTime.Now.Day - ReturnedData.Day) * 10;

                return result;
            }
            return 0;
        }
    }

}
