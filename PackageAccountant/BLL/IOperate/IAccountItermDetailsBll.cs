using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL.IOperate
{
    public interface IAccountItermDetailsBll
    {
        List<AccountItermDetails> AccountItermDetailsList();
        void Insert(DataTable data, string userid);
    }
}
