using System.Text;

namespace Masalalar.OnlineShoppingSystem;

public class Customer : IUser
{
    private static int id = 0;

    public int CustomerId { get; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Address { get; private set; }
    public List<IProduct> ShoppingCart { get; } = new List<IProduct>();

    public Customer(string name, string email, string address)
    {
        UpdateUserInfo(name, email, address);
        CustomerId = ++id;
    }

    public void AddToCart(IProduct product)
        => ShoppingCart.Add(product);

    public void RemoveFromCart(IProduct product)
    {
        if(ShoppingCart.Remove(product) is false)
            throw new InvalidOperationException("Product isn't in the cart yet.");
    }

    public void DisplayCart()
    {
        var builder = new StringBuilder();
        
        builder.AppendLine("-------------------------------------------------------------");
        builder.AppendLine("Shopping Cart:");
        builder.Append("Name".PadRight(15));
        builder.Append("Price".PadRight(15));
        builder.Append("Quantity".PadRight(15));
        builder.AppendLine("Available".PadRight(15));

        foreach(var product in ShoppingCart.DistinctBy(p => p.ProductId))
        {
            builder.Append(product.Name.Substring(0, Math.Min(product.Name.Length, 13)).PadRight(15));
            builder.Append($"{product.Price:C2}".PadRight(15));
            builder.Append($"{ShoppingCart.Count(p => p.ProductId == product.ProductId)}".PadRight(15));
            builder.AppendLine($"{product.Quantity}".PadRight(15));
        }

        builder.AppendLine("-------------------------------------------------------------");

        Console.WriteLine(builder);
    }

    public void DisplayUserInfo()
    {
        var builder = new StringBuilder();
        builder.AppendLine("-------------------------------------------------------------");
        builder.AppendLine("Customer Information:");
        builder.Append("Name".PadRight(15));
        builder.Append("Email".PadRight(15));
        builder.AppendLine("Address".PadRight(15));

        builder.Append(Name.Substring(0, Math.Min(Name.Length, 13)).PadRight(15));
        builder.Append(Email.Substring(0, Math.Min(Email.Length, 13)).PadRight(15));
        builder.AppendLine(Address.Substring(0, Math.Min(Address.Length, 13)).PadRight(15));

        builder.AppendLine("-------------------------------------------------------------");

        Console.WriteLine(builder);
    }

    public void UpdateUserInfo(string name, string email, string address)
    {
        Name = name;
        Email = email;
        Address = address;
    }
}
