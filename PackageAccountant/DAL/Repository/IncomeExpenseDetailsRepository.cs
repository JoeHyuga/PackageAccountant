using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repository
{
    public class IncomeExpenseDetailsRepository : RepositoryBase<IncomeExpenseDetails>
    {
        public IncomeExpenseDetailsRepository(EFPackageDbContext context) : base(context) { }
    }
}
