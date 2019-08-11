using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class AccountTypeDetailsRepository:RepositoryBase<AccountTypeDetails>
    {
        public AccountTypeDetailsRepository(EFPackageDbContext context) : base(context) { }
    }
}
