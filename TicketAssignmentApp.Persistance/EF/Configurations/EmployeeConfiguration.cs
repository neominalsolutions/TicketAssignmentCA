using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.Entities;

namespace TicketAssignmentApp.Persistance.EF.Configurations
{
  public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
  {
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
      builder.ToTable("Employee");
      builder.HasKey(x => x.Id); // PK
      builder.HasMany(x => x.AssignedTickets); // one to Many relations
      builder.Property(x => x.FirstName).HasMaxLength(20).HasColumnType("nvarchar").HasColumnOrder(1);
      builder.Property(x => x.LastName).HasMaxLength(20).HasColumnType("nvarchar").HasColumnOrder(2);

    }
  }
}
