using OnlineShoppingSystem;
using Xunit;

public class DisplayTextTests
{
    [Fact]
    public void Customer_DisplayCart_ShouldDisplayFormattedCart()
    {
        // Arrange
        Customer customer = new Customer("John Doe", "john@example.com", "123 Main St");

        IProduct laptop = new Laptop("Dell Laptop", 999.99m, 10, "Dell", "Intel Core i7", 16, 512);
        IProduct tShirt = new ClothingProduct("T-Shirt", 19.99m, 5, EColor.Blue, ESize.Large);

        customer.AddToCart(laptop);
        customer.AddToCart(tShirt);

        // Act
        string cartContent = customer.DisplayCart();

        // Assert
        string expectedOutput = 
@"-------------------------------------------------------------
Shopping Cart:
    Name            Price       Quantity        Available
    Dell Laptop     $999.99     1               10
    T-Shirt         $19.99      1               5
-------------------------------------------------------------";

        Assert.Equal(expectedOutput, cartContent);
    }

    [Fact]
    public void Order_DisplayOrderInfo_ShouldDisplayFormattedOrderInfo()
    {
        // Arrange
        Customer customer = new Customer("John Doe", "john@example.com", "123 Main St");

        IProduct laptop = new Laptop("Dell Laptop", 999.99m, 10, "Dell", "Intel Core i7", 16, 512);
        IProduct tShirt = new ClothingProduct("T-Shirt", 19.99m, 5, EColor.Blue, ESize.Large);

        customer.AddToCart(laptop);
        customer.AddToCart(laptop);
        customer.AddToCart(tShirt);

        Order order = customer.Checkout();

        // Act
        string orderInfo = order.DisplayOrderInfo();

        // Assert
        string expectedOutput =
@"-----------------------------------------------------
Order Information:
    ID      Customer        Date        Total Amount
    1       John Doe        2023/05/30  $2019.97

Order Products
    Name            Price       Quantity
    Dell Laptop     $999.99     2
    T-Shirt         $19.99      1
-----------------------------------------------------";

        Assert.Equal(expectedOutput, orderInfo);
    }

    [Fact]
    public void Customer_DisplayUserInfo_ShouldDisplayFormattedUserInfo()
    {
        // Arrange
        Customer customer = new Customer("John Doe", "john@example.com", "123 Main St");

        customer.UpdateUserInfo("Jane Smith", "jane@example.com", "456 Elm St");

        // Act
        string userInfo = customer.DisplayUserInfo();

        // Assert
        string expectedOutput = 
@"-------------------------------------------------------
Customer Information:
    Name            Email                   Address
    Jane Smith      jane@example.com        456 Elm St
-------------------------------------------------------";

        Assert.Equal(expectedOutput, userInfo);
    }

    [Fact]
    public void Customer_DisplayCart_ShouldTrimDataToFitColumn()
    {
        // Arrange
        Customer customer = new Customer("John Doe", "john@example.com", "123 Main St");

        IProduct laptop = new Laptop("This is a long laptop name that exceeds the column width", 999.99m, 10, "Dell", "Intel Core i7", 16, 512);
        IProduct tShirt = new ClothingProduct("T-Shirt", 19.99m, 5, EColor.Blue, ESize.Large);

        customer.AddToCart(laptop);
        customer.AddToCart(tShirt);

        // Act
        string cartContent = customer.DisplayCart();

        // Assert
        string expectedOutput = 
@"-------------------------------------------------------------
Shopping Cart:
    Name            Price       Quantity        Available
    This is a lo... $999.99     1               10
    T-Shirt         $19.99      1               5
-------------------------------------------------------------";

        Assert.Equal(expectedOutput, cartContent);
    }

    [Fact]
    public void Order_DisplayOrderInfo_ShouldTrimDataToFitColumn()
    {
        // Arrange
        Customer customer = new Customer("John Doe", "john@example.com", "123 Main St");

        IProduct laptop = new Laptop("Dell Laptop", 999.99m, 10, "Dell", "Intel Core i7", 16, 512);
        IProduct tShirt = new ClothingProduct("This is a long t-shirt name that exceeds the column width", 19.99m, 5, EColor.Blue, ESize.Large);

        customer.AddToCart(laptop);
        customer.AddToCart(tShirt);

        Order order = customer.Checkout();

        // Act
        string orderInfo = order.DisplayOrderInfo();

        // Assert
        string expectedOutput = 
@"-----------------------------------------------------
Order Information:
    ID      Customer        Date        Total Amount
    1       John Doe        2023/05/30  $2019.97

Order Products
    Name            Price       Quantity
    Dell Laptop     $999.99     1
    This is a lo... $19.99      1
-----------------------------------------------------";

        Assert.Equal(expectedOutput, orderInfo);
    }

    [Fact]
    public void Customer_DisplayUserInfo_ShouldTrimDataToFitColumn()
    {
        // Arrange
        Customer customer = new Customer("This is a long customer name that exceeds the column width", "john@example.com", "123 Main St");

        customer.UpdateUserInfo("Jane Smith", "thisisalongemailaddress@example.com", "This is a long address that exceeds the column width");

        // Act
        string userInfo = customer.DisplayUserInfo();

        // Assert
        string expectedOutput = 
@"-------------------------------------------------------
Customer Information:
    Name            Email                   Address
    This a long ... thisisalongemailaddr... This is a long address that...
-------------------------------------------------------";

        Assert.Equal(expectedOutput, userInfo);
    }

    [Fact]
    public void Customer_AddToCart_ShouldAddProductToCart()
    {
        // Arrange
        Customer customer = new Customer("John Doe", "john@example.com", "123 Main St");
        IProduct tShirt = new ClothingProduct("T-Shirt", 19.99m, 5, EColor.Blue, ESize.Large);

        // Act
        customer.AddToCart(tShirt);

        // Assert
        Assert.Single(customer.ShoppingCart);
        Assert.Equal(tShirt, customer.ShoppingCart[0]);
    }

    [Fact]
    public void Customer_RemoveFromCart_ShouldRemoveProductFromCart()
    {
        // Arrange
        Customer customer = new Customer("John Doe", "john@example.com", "123 Main St");
        IProduct tShirt = new ClothingProduct("T-Shirt", 19.99m, 5, EColor.Blue, ESize.Large);
        customer.AddToCart(tShirt);

        // Act
        customer.RemoveFromCart(tShirt);

        // Assert
        Assert.Empty(customer.ShoppingCart);
    }

    [Fact]
    public void Customer_RemoveFromCart_ShouldThrowExceptionIfProductNotInCart()
    {
        // Arrange
        Customer customer = new Customer("John Doe", "john@example.com", "123 Main St");
        IProduct tShirt = new ClothingProduct("T-Shirt", 19.99m, 5, EColor.Blue, ESize.Large);

        // Act and Assert
        Assert.Throws<InvalidOperationException>(() => customer.RemoveFromCart(tShirt));
    }

    [Fact]
    public void Customer_DisplayCart_ShouldDisplayCartContents()
    {
        // Arrange
        Customer customer = new Customer("John Doe", "john@example.com", "123 Main St");
        IProduct tShirt = new ClothingProduct("T-Shirt", 19.99m, 5, EColor.Blue, ESize.Large);
        customer.AddToCart(tShirt);

        // Act
        string cartContent = customer.DisplayCart();

        // Assert
        Assert.Contains("T-Shirt", cartContent);
        Assert.Contains("Blue", cartContent);
        Assert.Contains("Large", cartContent);
    }

    [Fact]
    public void Customer_Checkout_ShouldCreateOrderAndClearCart()
    {
        // Arrange
        Customer customer = new Customer("John Doe", "john@example.com", "123 Main St");
        IProduct tShirt = new ClothingProduct("T-Shirt", 19.99m, 5, EColor.Blue, ESize.Large);
        customer.AddToCart(tShirt);

        // Act
        Order order = customer.Checkout();

        // Assert
        Assert.Single(order.OrderedProducts);
        Assert.Equal(tShirt, order.OrderedProducts[0]);

        Assert.Empty(customer.ShoppingCart);
    }

    [Fact]
    public void Order_CalculateTotalAmount_ShouldCalculateCorrectTotalAmount()
    {
        // Arrange
        Customer customer = new Customer("John Doe", "john@example.com", "123 Main St");
        IProduct tShirt = new ClothingProduct("T-Shirt", 19.99m, 5, EColor.Blue, ESize.Large);
        IProduct laptop = new Laptop("Dell Laptop", 999.99m, 2, "Dell", "Intel Core i5", 8, 256);

        Order order = new Order(customer);
        order.AddProduct(tShirt);
        order.AddProduct(laptop);

        // Act
        decimal totalAmount = order.CalculateTotalAmount();

        // Assert
        decimal expectedTotalAmount = tShirt.Price * tShirt.Quantity + laptop.Price * laptop.Quantity;
        Assert.Equal(expectedTotalAmount, totalAmount);
    }
}
