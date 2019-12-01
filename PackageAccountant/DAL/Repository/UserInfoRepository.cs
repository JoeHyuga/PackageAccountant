using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class UserInfoRepository:RepositoryBase<UserInfo>
    {
        public UserInfoRepository(EFPackageDbContext context) : base(context){ }
    }
}
