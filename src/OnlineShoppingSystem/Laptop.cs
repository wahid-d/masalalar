namespace Masalalar.OnlineShoppingSystem;

public class Laptop : Product
{
    public string Manufacturer { get; private set; }
    public int Ram { get; private set; }
    public int SsdStorage { get; private set; }

    public Laptop(string name, decimal price, uint quantity, string manufacturer, int ram, int ssdStorage)
        : base(name, price, quantity)
    {
        Manufacturer = manufacturer;
        Ram = ram;
        SsdStorage = ssdStorage;
    }
}