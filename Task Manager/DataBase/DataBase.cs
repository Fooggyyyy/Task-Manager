using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Task_Manager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging; 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Diagnostics.Metrics;

namespace Task_Manager.DataBase
{
    public class DataBase : DbContext
    {
        private string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=TaskManager;Trusted_Connection=True;";
        readonly StreamWriter logStreamInformation = new StreamWriter("C:\\Users\\user\\source\\repos\\Task Manager\\Task Manager\\LoggingInformation.json", false);
        readonly StreamWriter logStreamError = new StreamWriter("C:\\Users\\user\\source\\repos\\Task Manager\\Task Manager\\LoggingError.json", false);

        public DbSet<User> Users => Set<User>();
        public DbSet<Task_> Tasks => Set<Task_>();

        public DataBase(string _connectionstring) 
        {
            Database.EnsureCreated(); 
            this._connectionString = _connectionstring;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.LogTo(logStreamInformation.WriteLine, LogLevel.Information);
            optionsBuilder.LogTo(logStreamError.WriteLine, LogLevel.Error);
        }

        public override void Dispose()
        {
            base.Dispose();
            logStreamInformation.Dispose();
            logStreamError.Dispose();
        }
    }
}
