using Microsoft.EntityFrameworkCore;
using SincomBlog.DataAccessLayer.Abstract;
using SincomBlog.EntityLayer.Concrete;
using SincomBlog.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SincomBlog.DataAccessLayer.Concrete.EntityFramework.Repository
{//11
    public class EfCoreRolerepository : EfCoreEntityRepositoryBase<Role>, IRoleRepository
    {
        public EfCoreRolerepository(DbContext context) : base(context)
        {
        }
    }
}
