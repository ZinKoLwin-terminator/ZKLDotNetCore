using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZKLDotNetCore.ConsoleApp.Dots;
using ZKLDotNetCore.ConsoleApp.Services;

namespace ZKLDotNetCore.ConsoleApp.EfCoreExamples
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);


        }
        public DbSet<BlogDto> Blogs { get; set; }
    }
}
