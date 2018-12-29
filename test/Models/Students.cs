using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class Students: RootEntity
    {
        public Students()
        {
            // 当遇到这个场景的时候(A表的某人下有N个小弟)时使用到
            //this.ChooseCourse = new HashSet<ChooseCourse>();
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string department { get; set; }

        //public virtual ICollection<ChooseCourse> ChooseCourse { get; set; } 
    }
}
