using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity.Result.ChartResult
{
   public class PieResult
    {
        public List<string> backgroundColor { get; set; }
        public List<decimal> data { get; set; }
        public List<string> labels { get; set; }
    }
}
