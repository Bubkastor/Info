using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Info.Models;
using JetBrains.Annotations;

namespace Info.Data
{
    public class InfoContext : DbContext
    {
        public InfoContext(DbContextOptions<InfoContext> options) : base(options)
        {
        }

        public DbSet<App> Apps { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<App>().ToTable("App");
            modelBuilder.Entity<Article>().ToTable("Article");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
