using ConfArch.Data.Models;

namespace ConfArch.Data.Repositories
{
    public interface IUserRepository
    {
        user GetByUsernameAndPassword(string username, string password);
        user GetByGoogleId(string googleId);
    }
}