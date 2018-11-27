using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookingBook.Entity.Entity;

namespace CookingBook.Application.Repository
{
    public class BaseRepository : IDisposable
    {
        protected CookingBookEntities dbContext = null;

        public CookingBookEntities Context
        {
            get
            {
                if (dbContext == null)
                    return dbContext = new CookingBookEntities();
                else
                    return dbContext;
            }
        }


        public void Dispose()
        {
            //this.dbContext.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.dbContext != null)
                {
                    this.dbContext.Dispose();
                    this.dbContext = null;
                }
            }
        }
    }
}
