using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Service
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<terminals>().HasKey(t => new { t.Id });
        }


        public DbSet<terminals> terminals { get; set; }
    }
}
