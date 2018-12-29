using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class Res
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public dynamic Rows { get; set; }
        public int total { get; set; }
    }
}
