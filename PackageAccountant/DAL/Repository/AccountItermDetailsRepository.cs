using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class AccountItermDetailsRepository:RepositoryBase<AccountItermDetails>
    {
        public AccountItermDetailsRepository(EFPackageDbContext context) : base(context){ }
    }
}
