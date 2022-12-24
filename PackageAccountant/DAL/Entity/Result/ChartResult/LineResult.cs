using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entity.Result.ChartResult
{
    public class LineResult
    {
        public List<string> backgroundColor { get; set; }
        public List<decimal> data { get; set; }
        public List<string> labels { get; set; }
        public string label { get; set; }
    }
}
