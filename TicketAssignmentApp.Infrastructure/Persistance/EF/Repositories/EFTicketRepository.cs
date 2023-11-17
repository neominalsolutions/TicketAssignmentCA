using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.Entities;
using TicketAssignment.Domain.Repositories;
using TicketAssignmentApp.Persistance.EF.Contexts;

namespace TicketAssignmentApp.Infrastructure.Persistance.EF.Repositories
{
  public class EFTicketRepository : EFReadOnlyRepository<Ticket, AppDbContext>, ITicketRepository
  {
    public EFTicketRepository(AppDbContext context) : base(context)
    {
    }
  }
}
