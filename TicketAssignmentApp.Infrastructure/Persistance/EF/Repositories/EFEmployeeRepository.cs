using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.Entities;
using TicketAssignment.Domain.Repositories;
using TicketAssignmentApp.Persistance.EF.Contexts;

namespace TicketAssignmentApp.Infrastructure.Persistance.EF.Repositories
{
  public class EFEmployeeRepository : EFCrudRepository<Employee, AppDbContext>, IEmployeeRepository
  {
    public EFEmployeeRepository(AppDbContext context) : base(context)
    {
    }

    public override void Create(Employee entity)
    {
      base.Create(entity);
    }
  }
}
