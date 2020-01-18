using BLL.IOperate;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entity;
using DAL;
using System.Linq;

namespace BLL.Operate
{
    public class MenuBll : BaseBll, IMenuBll
    {
        public MenuBll(EFPackageDbContext context) : base(context) { }
        public List<Menu> GetMenuList()
        {
            var list= unit.MenuRepository.GetAllList();
            return list.ToList();
        }
    }
}
