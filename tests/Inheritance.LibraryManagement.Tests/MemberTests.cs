using Xunit;

public class MemberTests
{
    [Fact]
    public void BorrowBook_ShouldAddBookToBooksBorrowed()
    {
        // Arrange
        Member member = new Member("John Doe");
        Book book = new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488");

        // Act
        member.BorrowBook(book);

        // Assert
        Assert.Contains(book, member.BooksBorrowed);
    }

    [Fact]
    public void ReturnBook_ShouldRemoveBookFromBooksBorrowed()
    {
        // Arrange
        Member member = new Member("John Doe");
        Book book = new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488");
        member.BorrowBook(book);

        // Act
        member.ReturnBook(book);

        // Assert
        Assert.DoesNotContain(book, member.BooksBorrowed);
    }

    [Fact]
    public void ReturnBook_NotBorrowed_ShouldThrowException()
    {
        // Arrange
        Member member = new Member("John Doe");
        Book book = new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488");

        // Act and Assert
        Assert.Throws<BookNotBorrowedException>(() => member.ReturnBook(book));
    }

    [Fact]
    public void GetMemberInfo_ShouldReturnFormattedMemberInfoString()
    {
        // Arrange
        Member member = new Member("John Doe");
        Book book = new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488");
        member.BorrowBook(book);
        var expectedMemberInfo = @"
Member Name:        John Doe
Member ID:          1
Books Borrowed:

1. The Catcher in the Rye
------------------------------------";

        // Act
        string memberInfo = member.GetMemberInfo();

        // Assert
        Assert.Equal(expectedMemberInfo, memberInfo);
    }
}
