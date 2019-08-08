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
    }
}
