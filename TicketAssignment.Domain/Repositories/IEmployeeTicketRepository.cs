using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.Entities;
using TicketAssignment.Domain.SeedWork;

namespace TicketAssignment.Domain.Repositories
{
  public interface IEmployeeTicketRepository:ICrudRepository<EmployeeTicket>
  {
  }
}
