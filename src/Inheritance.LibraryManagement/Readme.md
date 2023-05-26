# Library Management System

### Description
In this project, you will create a library management system that allows users to manage books, library members, and borrowing transactions. You need to design and implement several classes with necessary functionality to achieve this.

### Classes to be implemented

#### 1. `Book.cs`
| Properties | Methods |
|:------------|:-----|
| **Title**: `string` | `void MarkAsAvailable()`  |
| **Author**: `string`      |  `void MarkAsUnavailable()` |
| **Isbn**: `string`      |  `string GetBookInfo()` |
| **Availability**: `bool`      |   |



#### 2. `Member.cs`

| Properties | Methods |
|:------------|:-----|
| **Id**: `int` | `void BorrowBook(Book)`  |
| **Name**: `string`  |  `void ReturnBook(Book)` |
| **BooksBorrowed**: `List<Book>`  |  `string GetMemberInfo()` |

> Member class should have an internal static field to keep track of current ID. Everytime a new member create, the ID should increase. `Id` property of the Member should be readonly. It can only be set internally, and increments sequantially using the static int field to keep track.

#### 3. `Library.cs`

| Properties | Methods |
|:------------|:-----|
| **Books**: `List<Book>` | `void AddBook(Book)`  |
| **Members**: `List<Member>`  |  `void RemoveBook(Book)` |
|  |  `void AddMember(Member)` |
|  |  `void RemoveMember(Member)` |

#### 4. `Transaction.cs`

| Properties | Methods |
|:------------|:-----|
| **Member**: `Member` | `void SetReturnDate(DateTime)`  |
| **Book**: `Book`  |  `void CalculateFine()` |
| **BorrowedDate**: `DateTime` |   |
| **ReturnedData**: `DateTime` |   |



Your task is to implement these classes with appropriate properties and methods to achieve the desired functionality. Think about the relationships between these classes and how they interact with each other. Ensure proper encapsulation and validation of data.



### Examples
##### `Program.cs`
```cs
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
```

##### Terminal Output
```sh
Member Name:        John Doe
Member ID:          1
Books Borrowed:

1. The Catcher in the Rye
------------------------------------

Member Name:        Jane Smith
Member ID:          2
Books Borrowed:

1. To Kill a Mockingbird
------------------------------------

Title:          The Catcher in the Rye
Author:         J.D. Salinger
ISBN:           9780316769488
Availability:   Unavailable
------------------------------------

Title:          The Catcher in the Rye
Author:         J.D. Salinger
ISBN:           9780316769488
Availability:   Available
------------------------------------

Member Name:        John Doe
Member ID:          1
Books Borrowed:

------------------------------------

0       # assuming the current date is before the due date
------------------------------------

0       # assuming the current date is before the due date
------------------------------------

10       # assuming the current date is after the due date and there is a fine of $10 per day
------------------------------------
```