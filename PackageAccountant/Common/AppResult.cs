using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class AppResult<T>
    {
        public T obj { get; set; }
        public List<T> list { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public int count { get; set; }
    }
}
