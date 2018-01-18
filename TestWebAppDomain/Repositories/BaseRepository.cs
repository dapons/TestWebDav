using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAppDomain.DAL;

namespace TestWebAppDomain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DocDesignerEntities DbContext;

        protected BaseRepository(DocDesignerEntities dbContext)
        {
            this.DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

    }
}
