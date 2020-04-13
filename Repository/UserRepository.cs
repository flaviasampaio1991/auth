using System.Collections.Generic;
using System.Linq;
using shop.Models;


namespace Shop.Repository
{
    public static class UserRepository
    {
        public static Users Get (string username, string password)
        {
            var users = new List <Users>();
            users.Add(new Users { Id = 1, UserName = "batman", Password = "batman", Role ="manager"});
            users.Add(new Users { Id = 2, UserName = "robin", Password = "robin", Role = "employee"});
            return users.Where(x => x.UserName.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrder;
        }
    }
}