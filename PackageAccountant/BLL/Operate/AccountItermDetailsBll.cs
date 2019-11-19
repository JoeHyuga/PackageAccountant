using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace BLL.Operate
{
    public class AccountItermDetailsBll : BaseBll
    {
        public AccountItermDetailsBll(EFPackageDbContext context) : base(context) { }

        public List<AccountItermDetails> AccountItermDetailsList()
        {
            var list = unit.AccountItermDetailsRepository.GetAllList();
            return list.ToList();
        }

        public void Insert(DataTable data, string userid)
        {
            var list = AccountItermDetailsList();

            var toView = data.DefaultView;
            DataTable toData = toView.ToTable(true, "账目分类");

            for (int i = 0; i < toData.Rows.Count; i++)
            {
                var r1 = list.Where(p => p.AccountIterm == toData.Rows[i]["账目分类"].ToString()&&p.UserId==userid).ToList();
                if (r1.Count == 0)
                {
                    var accountIterm = new AccountItermDetails()
                    {
                        AccountIterm = toData.Rows[i][0].ToString() ,
                        UserId = userid
                    };
                    unit.AccountItermDetailsRepository.Insert(accountIterm);
                }
            }
            unit.saveChange();
        }
    }
}
