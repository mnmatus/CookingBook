using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingBook.Web.Models.DB;

namespace CookingBook.Web.IRepository
{
    public interface IUserRepository
    {
        User GetUserByCredential(string userName, string password);

        User GetUserById(Guid id);
    }
}
