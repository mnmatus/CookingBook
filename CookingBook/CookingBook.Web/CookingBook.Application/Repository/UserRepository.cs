using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookingBook.Application.IRepository;
using CookingBook.Entity.Entity;

namespace CookingBook.Application.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public User GetUserByUserName(string userName)
        {
            var user = Context.Users.FirstOrDefault(u => u.UserName == userName);
            return user;
        }
        public User GetUserById(int id)
        {
            var user = Context.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }
    }
}
