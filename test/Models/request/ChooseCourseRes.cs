using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.Models
{
    public class ChooseCourseRes
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int CodeId { get; set; }
        public int grade { get; set; }
        public virtual Course Course { get; set; }
        public virtual Students Students { get; set; }
    }
}
