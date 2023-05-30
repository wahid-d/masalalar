namespace Masalalar.OnlineShoppingSystem;

public interface IUser
{
    string Name { get; }
    string Email { get; }
    string Address { get; }

    void DisplayUserInfo();
    void UpdateUserInfo(string name, string email, string address);
}