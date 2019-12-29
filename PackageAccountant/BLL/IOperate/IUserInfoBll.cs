using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.IOperate
{
    public interface IUserInfoBll
    {
        UserInfo GetUserInfo(string username);
        bool CheckUserInfo(string username);
        bool SetUserSession(string username);
    }
}
