using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.Entities;
using TicketAssignment.Domain.Repositories;
using TicketAssignmentApp.Infrastructure.Persistance.EF.SeedWork;
using TicketAssignmentApp.Persistance.EF.Contexts;

namespace TicketAssignmentApp.Infrastructure.Persistance.EF.Repositories
{
    public class EFEmployeeTicketRepository : EFCrudRepository<EmployeeTicket, AppDbContext>, IEmployeeTicketRepository
  {
    public EFEmployeeTicketRepository(AppDbContext context) : base(context)
    {
    }
  }
}
