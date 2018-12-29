using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class TodoItem: RootEntity
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
