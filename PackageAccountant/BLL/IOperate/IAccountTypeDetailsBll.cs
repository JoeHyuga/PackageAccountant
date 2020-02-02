using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL.IOperate
{
   public interface IAccountTypeDetailsBll
    {
        List<AccountTypeDetails> AccountTypeDetails();
        void Insert(DataTable data, string userid);
    }
}
