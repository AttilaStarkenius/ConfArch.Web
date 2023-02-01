using System.Collections.Generic;
using System.Linq;
using ConfArch.Data.Models;


namespace ConfArch.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<user> users = new List<user>
        {
            new user { Id = 3522, Name = "roland", Password = "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=",
                FavoriteColor = "blue", Role = "Admin", GoogleId = "101517359495305583936" }
        };

        public user GetByUsernameAndPassword(string username, string password)
        {
            var user = users.SingleOrDefault(u => u.Name == username &&
                u.Password == password.Sha256());
            return user;
        }

        public user GetByGoogleId(string googleId)
        {
            var user = users.SingleOrDefault(u => u.GoogleId == googleId);
            return user;
        }
    }
}
