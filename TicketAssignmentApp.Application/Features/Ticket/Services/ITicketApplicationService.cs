using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignmentApp.Application.Features.Ticket.Dtos;

namespace TicketAssignmentApp.Application.Features.Ticket.Services
{
  public interface ITicketApplicationService
  {
    void CreateTicket(CreateTicketDto dto);
    void AssignTicket(AssignTicketDto dto);
  }
}
