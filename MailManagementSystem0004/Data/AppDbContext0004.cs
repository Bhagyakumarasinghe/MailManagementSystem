
using MailManagementSystem0004.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MailManagementSystem0004.Data
{
    public class AppDbContext0004 : DbContext
    {
        public AppDbContext0004(DbContextOptions<AppDbContext0004> options) : base(options)
        {
        }

        public DbSet<Department0004> Departments0004 { get; set; }
        public DbSet<Mail0004> Mails0004 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Department0004>().HasData(
                new Department0004 { Id = 1, Name = "Registrar" },
                new Department0004 { Id = 2, Name = "Finance" },
                new Department0004 { Id = 3, Name = "IT Department" }
            );
        }
    }
}