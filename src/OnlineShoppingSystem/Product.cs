namespace Masalalar.OnlineShoppingSystem;

public class Product : IProduct
{
    private static int id = 0;

    public int ProductId { get; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public uint Quantity { get; private set; }

    public Product(string name, decimal price, uint quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;

        ProductId = ++id;
    }

    public void DecreaseQuantityBy(uint quantity)
    {
        if(quantity > Quantity)
            throw new InvalidOperationException($"We only have {Quantity} products left.");
        
        Quantity -= quantity;
    }

    public void DisplayProductInfo()
    {
        throw new NotImplementedException();
    }
}
