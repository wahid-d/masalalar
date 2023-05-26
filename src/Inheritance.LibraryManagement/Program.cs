// See https://aka.ms/new-console-template for more information
using Inheritance.LibraryManagement.Classes;

Library library = new Library();

Book book1 = new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488");
Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084");

library.AddBook(book1);
library.AddBook(book2);

Member member1 = new Member("John Doe");
Member member2 = new Member("Jane Smith");

library.AddMember(member1);
library.AddMember(member2);

member1.BorrowBook(book1);
member2.BorrowBook(book2);

Console.WriteLine(member1.GetMemberInfo());
Console.WriteLine(member2.GetMemberInfo());

book1.MarkAsUnavailable();
Console.WriteLine(book1.GetBookInfo());

book1.MarkAsAvailable();
Console.WriteLine(book1.GetBookInfo());

member1.ReturnBook(book1);
Console.WriteLine(member1.GetMemberInfo());


Transaction transaction1 = new Transaction(member1, book1, new DateTime(2023, 5, 1));
Console.WriteLine($"Fine: {transaction1.CalculateFine()}");

Transaction transaction2 = new Transaction(member2, book2, new DateTime(2023, 5, 10));
transaction2.SetReturnDate(new DateTime(2023, 5, 15));
Console.WriteLine($"Fine: {transaction2.CalculateFine()}");

Transaction transaction3 = new Transaction(member1, book1, new DateTime(2023, 5, 1));
transaction3.SetReturnDate(new DateTime(2023, 6, 1));
Console.WriteLine($"Fine: {transaction3.CalculateFine()}");
