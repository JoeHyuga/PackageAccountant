using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL
{
    public class EFPackageDbContext: DbContext
    {
        public EFPackageDbContext(DbContextOptions<EFPackageDbContext> options) : base(options) { }

        public DbSet<AccountItermDetails> AccountItermDetails { get; set; }

        public DbSet<ExcelBackupInfor> ExcelBackupInfor { get; set; }

        public DbSet<UserInfo> UserInfo { get; set; }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<IncomeExpenseDetails> IncomeExpenseDetails { get; set; }
    }
}
