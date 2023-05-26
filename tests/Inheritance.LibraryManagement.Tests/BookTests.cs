using Xunit;

public class BookTests
{
    [Fact]
    public void MarkAsAvailable_ShouldSetAvailabilityToTrue()
    {
        // Arrange
        var book = new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488");
        book.MarkAsUnavailable();

        // Act
        book.MarkAsAvailable();

        // Assert
        Assert.True(book.Availability);
    }

    [Fact]
    public void MarkAsUnavailable_ShouldSetAvailabilityToFalse()
    {
        // Arrange
        Book book = new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488");

        // Act
        book.MarkAsUnavailable();

        // Assert
        Assert.False(book.Availability);
    }

    [Fact]
    public void GetBookInfo_ShouldReturnFormattedBookInfoString()
    {
        // Arrange
        Book book = new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488");
        var expectedBookInfo = 
@"Title:          The Catcher in the Rye
Author:         J.D. Salinger
ISBN:           9780316769488
Availability:   Available
------------------------------------";

        // Act
        string bookInfo = book.GetBookInfo();

        // Assert
        Assert.Equal(expectedBookInfo, bookInfo);
    }

    [Fact]
    public void Book_WithEmptyTitle_ShouldThrowException()
    {
        // Arrange, Act, and Assert
        Assert.Throws<ArgumentException>(() => new Book("", "J.D. Salinger", "9780316769488"));
    }

    [Fact]
    public void Book_WithEmptyAuthor_ShouldThrowException()
    {
        // Arrange, Act, and Assert
        Assert.Throws<ArgumentException>(() => new Book("The Catcher in the Rye", "", "9780316769488"));
    }

    [Fact]
    public void Book_WithInvalidISBN_ShouldThrowException()
    {
        // Arrange, Act, and Assert
        Assert.Throws<ArgumentException>(() => new Book("The Catcher in the Rye", "J.D. Salinger", ""));
    }
}
