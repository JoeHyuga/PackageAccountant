using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Domain.Entity;

namespace Web.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }

        public DbSet<AccountItermDetails> AccountItermDetails { get; set; }

        public DbSet<ExcelBackupInfor> ExcelBackupInfor { get; set; }
    }
}
