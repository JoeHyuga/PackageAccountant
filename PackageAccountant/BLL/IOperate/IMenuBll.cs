using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.IOperate
{
    public interface IMenuBll
    {
        List<Menu> GetMenuList();
    }
}
