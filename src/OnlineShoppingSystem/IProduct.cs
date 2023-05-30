namespace Masalalar.OnlineShoppingSystem;

public interface IProduct
{
    int ProductId { get; }
    string Name { get; }
    decimal Price { get; }
    uint Quantity { get; }

    void DisplayProductInfo();
    void DecreaseQuantityBy(uint quantity);
}
