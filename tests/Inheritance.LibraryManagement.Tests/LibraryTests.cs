using Inheritance.LibraryManagement.CustomExceptions;
using Inheritance.LibraryManagement.Entities;
using Xunit;

public class LibraryTests
{
    [Fact]
    public void AddBook_ShouldIncreaseBookCount()
    {
        // Arrange
        Library library = new Library();
        Book book = new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488");

        // Act
        library.AddBook(book);

        // Assert
        Assert.Equal(1, library.BookCount);
    }

    [Fact]
    public void RemoveBook_ShouldDecreaseBookCount()
    {
        // Arrange
        Library library = new Library();
        Book book = new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488");
        library.AddBook(book);

        // Act
        library.RemoveBook(book);

        // Assert
        Assert.Equal(0, library.BookCount);
    }

    [Fact]
    public void RemoveBook_NotInLibrary_ShouldThrowException()
    {
        // Arrange
        Library library = new Library();
        Book book = new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488");

        // Act and Assert
        Assert.Throws<BookNotFoundException>(() => library.RemoveBook(book));
    }

    [Fact]
    public void AddMember_ShouldIncreaseMemberCount()
    {
        // Arrange
        Library library = new Library();
        Member member = new Member("John Doe");

        // Act
        library.AddMember(member);

        // Assert
        Assert.Equal(1, library.Members.Count());
    }

    [Fact]
    public void RemoveMember_ShouldDecreaseMemberCount()
    {
        // Arrange
        Library library = new Library();
        Member member = new Member("John Doe");
        library.AddMember(member);

        // Act
        library.RemoveMember(member);

        // Assert
        Assert.Equal(0, library.Members.Count());
    }

    [Fact]
    public void RemoveMember_NotInLibrary_ShouldThrowException()
    {
        // Arrange
        Library library = new Library();
        Member member = new Member("John Doe");

        // Act and Assert
        Assert.Throws<MemberNotFoundException>(() => library.RemoveMember(member));
    }
}
