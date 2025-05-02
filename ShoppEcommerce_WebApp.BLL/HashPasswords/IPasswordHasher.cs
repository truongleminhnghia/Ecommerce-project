

namespace ShoppEcommerce_WebApp.BLL.HashPasswords
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
