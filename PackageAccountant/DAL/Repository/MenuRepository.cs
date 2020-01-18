using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class MenuRepository : RepositoryBase<Menu>
    {
        public MenuRepository(EFPackageDbContext context) : base(context) { }
    }
}
