using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Http;
using BLL.IOperate;

namespace BLL.Operate
{
    public class AccountTypeDetailsBll : BaseBll, IAccountTypeDetailsBll
    {
        public AccountTypeDetailsBll(EFPackageDbContext context) : base(context) { }

        public List<AccountTypeDetails> AccountTypeDetails()
        {
            var list = unit.AccountTypeDetailsRepository.GetAllList();
            return list.ToList();
        }

        public void Insert(DataTable data, string userid)
        {
            try
            {
                var list = AccountTypeDetails();

                var toView = data.DefaultView;
                DataTable toData = toView.ToTable(true, "账户");

                for (int i = 0; i < toData.Rows.Count; i++)
                {
                    var r1 = list.Where(p => p.AccountType == toData.Rows[i]["账户"].ToString() && p.UserId == userid).ToList();
                    if (r1.Count == 0)
                    {
                        var accountIterm = new AccountTypeDetails()
                        {
                            AccountType= toData.Rows[i]["账户"].ToString(),
                            UserId = userid
                        };
                        unit.AccountTypeDetailsRepository.Insert(accountIterm);
                    }
                }
                unit.saveChange();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
