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
