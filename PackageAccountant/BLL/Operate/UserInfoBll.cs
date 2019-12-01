using DAL;
using DAL.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Operate
{
    public class UserInfoBll:BaseBll
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public UserInfoBll(EFPackageDbContext context,IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserInfo GetUserInfo(string username)
        {
            try
            {
                return unit.UserInfoRepository.Get(p => p.UserName == username);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckUserInfo(string username)
        {
            UserInfo info = GetUserInfo(username);
            if (info == null)
                return false;
            else
                return true;

        }

        public bool SetUserSession(string username)
        {
            var user = GetUserInfo(username);
            var result = CheckUserInfo(username);
            if (result)
            {
                _session.SetString("username",username);
            }
            return result;
        }
    }
}
