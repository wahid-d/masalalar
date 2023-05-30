namespace Masalalar.OnlineShoppingSystem;

public class Order
{
    private static int id = 0;

    public int OrderId { get; }
    public Customer Customer { get; }
    public DateTime OrderDate { get; }
    public List<IProduct> OrderedProducts { get; } = new List<IProduct>();
    public decimal TotalAmount
    {
        get
        {
            var totalAmount = 0m;
            foreach(var product in OrderedProducts.DistinctBy(p => p.ProductId))
            {
                var count = OrderedProducts.Count(p => p.ProductId == product.ProductId);
                totalAmount += product.Price * count;
            }

            return totalAmount;
        }
    }
}