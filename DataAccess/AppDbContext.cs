using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Data.SQLite;
using System.Text;
using TaskMaster.DataAccess.Models;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=.\TaskMasterDataBase.db");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskForEmployee> TaskForEmployees { get; set; }
    }
}
