using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Entity;

namespace TaskManager.DataAccess.Concrete.EFCore
{
    public class TaskManagerContext:DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\SqlExpress;Initial Catalog=TaskManagerDB;Integrated Security=SSPI");
        }
    }
}
