using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAssignment.Domain.Services
{
  public interface ITicketAssignment
  {
    void AssignTicket(string ticketId, string employeeId, int estimatedHour);
  }
}
