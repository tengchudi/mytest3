using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.Models
{
    public class ChooseCourse:RootEntity
    {
        
        public int CourseId { get; set; }
        public int CodeId { get; set; }
        public int grade { get; set; }
    }
}
