using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingBook.Web.IRepository;
using CookingBook.Web.Models.DB;

namespace CookingBook.Web.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly CookingBookContext _context;
        public UserRepository(CookingBookContext context)
        {
            _context = context;
        }
        public User GetUserByCredential(string userName, string password)
        {
            var user = _context.User.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            return user;
        }

        public User GetUserById(Guid id)
        {
            var user = _context.User.FirstOrDefault(u => u.Guid == id);
            return user;
        }
    }
}
