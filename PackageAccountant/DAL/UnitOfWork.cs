using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UnitOfWork : IDisposable
    {
        private EFPackageDbContext _context = null;
        private ExcelBackupInforRepository excelBackupInforRepository = null;
        private AccountItermDetailsRepository accountItermDetailsRepository = null;
        private AccountTypeDetailsRepository accountTypeDetailsRepository = null;
        private UserInfoRepository userInfoRepository = null;
        private MenuRepository menuRepository = null;
        private IncomeExpenseDetailsRepository incomeExpenseDetailsRepository = null;

        public UnitOfWork(EFPackageDbContext context)
        {
            _context = context;
        }

        public ExcelBackupInforRepository ExcelBackupInforRepository
        {
            get { return excelBackupInforRepository == null ? (excelBackupInforRepository = new ExcelBackupInforRepository(_context)) : excelBackupInforRepository; }
        }

        public AccountItermDetailsRepository AccountItermDetailsRepository
        {
            get { return accountItermDetailsRepository == null ? (accountItermDetailsRepository = new AccountItermDetailsRepository(_context)) : accountItermDetailsRepository; }
        }

        public AccountTypeDetailsRepository AccountTypeDetailsRepository
        {
            get { return accountTypeDetailsRepository == null ? (accountTypeDetailsRepository = new AccountTypeDetailsRepository(_context)) : accountTypeDetailsRepository; }
        }

        public UserInfoRepository UserInfoRepository
        {
            get { return userInfoRepository == null ? (userInfoRepository = new UserInfoRepository(_context)) : userInfoRepository; }
        }

        public MenuRepository MenuRepository
        {
            get { return menuRepository == null ? (menuRepository = new MenuRepository(_context)) : menuRepository; }
        }

        public IncomeExpenseDetailsRepository IncomeExpenseDetailsRepository
        {
            get { return incomeExpenseDetailsRepository == null ? (incomeExpenseDetailsRepository = new IncomeExpenseDetailsRepository(_context)) : incomeExpenseDetailsRepository; }
        }

        public void saveChange()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
