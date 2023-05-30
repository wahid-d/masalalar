using Masalalar.OnlineShoppingSystem;

var customer = new Customer("Eshmat", "eshmat@ilmhub.uz", "Toshkent");

var mbp = new Laptop("MacBook Pro Ultra Pro max 2022 M1 256BG", 2599.00m, 10);
// customer.RemoveFromCart(mbp);

customer.AddToCart(new Laptop("Lenovo", 999.99m, 2));
customer.AddToCart(new Laptop("HP", 1299.75m, 5));
customer.AddToCart(mbp);
customer.AddToCart(mbp);

customer.DisplayCart();
customer.DisplayUserInfo();