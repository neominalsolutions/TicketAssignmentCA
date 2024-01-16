using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.Entities;
using TicketAssignmentApp.Persistance.EF.Configurations;

namespace TicketAssignmentApp.Persistance.EF.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<EmployeeTicket> EmployeeTickets { get; set; }

        public DbSet<Customer> Customers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TicketDB;uid=sa;pwd=123");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // sistem ayağa kalkarken bu konfigürasyon ayarlarını migration üzerinden dbye yansıt.
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
