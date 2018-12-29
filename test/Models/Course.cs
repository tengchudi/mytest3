using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class Course: RootEntity
    {
        public string Name { get; set; }
        public int score { get; set; }
    }
}
