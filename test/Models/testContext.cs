using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models
{
    public class testContext : DbContext
    {

        public DbSet<TodoItem> TodoItem { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<ChooseCourse> ChooseCourse { get; set; }
        public DbSet<Course> Course { get; set; }

        public testContext(DbContextOptions<testContext> options)
          : base(options)
        {
        }

    }
}
