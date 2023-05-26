using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.LibraryManagement.Models
{
    public class Transaction
    {
        public Transaction(Member member, Book book, DateTime dateTime)
        {
            Member = member;
            Book = book;
            BorrowedDate = dateTime;

        }
        public Member Member { get; set; }
        public Book Book { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnedDate { get;set; } 
        public void SetReturnDate(DateTime ReturnedDate)
        {
            this.ReturnedDate = ReturnedDate;
        }

        public string CalculateFine()
        {
            if(ReturnedDate < DateTime.Now)
            {
                int days = DateTime.Now.Day - ReturnedDate.Day;
                return $"Fine:{days * 10} $";
            }
            return $"Fine is 0 $";
        }

    }
}
