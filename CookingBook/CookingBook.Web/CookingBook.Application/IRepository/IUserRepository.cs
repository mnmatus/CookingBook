using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookingBook.Entity.Entity;


namespace CookingBook.Application.IRepository
{
    public interface IUserRepository : IDisposable
    {
        User GetUserByUserName(string userName);
        User GetUserById(int id);
    }
}
