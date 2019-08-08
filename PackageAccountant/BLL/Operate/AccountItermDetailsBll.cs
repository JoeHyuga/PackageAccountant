﻿using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;

namespace BLL.Operate
{
    public class AccountItermDetailsBll
    {
        private EFPackageDbContext _context = null;
        public AccountItermDetailsBll(EFPackageDbContext context)
        {
            _context = context;
        }

        public List<AccountItermDetails> AccountItermDetailsList()
        {
            var unit = new UnitOfWork(_context);
            var list= unit.AccountItermDetailsRepository.GetAllList();
            return list.ToList();
        }

        public void Insert(DataTable data)
        {
            var unit = new UnitOfWork(_context);
            var list = AccountItermDetailsList();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                var r1 = list.Where(p => p.AccountIterm == data.Rows[i]["账目分类"].ToString()).ToList();
                var r2 =list.Where(p => p.AccountIterm == data.Rows[i]["账目分类"].ToString()).ToList();
                if (r1.Count == 0&&r2.Count==0)
                {
                    var accountIterm = new AccountItermDetails()
                    {
                        AccountIterm = data.Rows[i][2].ToString()
                    };
                    unit.AccountItermDetailsRepository.Insert(accountIterm);
                }
                
            }
            unit.saveChange();
        }
    }
}
