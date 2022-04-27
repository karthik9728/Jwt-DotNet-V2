using JWT.TokenV2.Model;

namespace JWT.TokenV2.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        User Authenticate(string username,string password);
        User Register(string username,string password,string role);
    }
}
