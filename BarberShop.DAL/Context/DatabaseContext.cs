using BarberShop.Entities;
using System;
using System.Data.Entity;

namespace BarberShop.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Queue> Queues { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Properties<DateTime>()
           .Configure(property => property.HasColumnType("datetime2"));
        }
    }
}