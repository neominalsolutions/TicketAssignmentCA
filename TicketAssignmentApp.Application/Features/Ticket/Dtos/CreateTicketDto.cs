using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAssignmentApp.Application.Features.Ticket.Dtos
{
  public record CreateTicketDto:IRequest
  {
    public string Title { get; set; }
    public string Description { get; set; }

  }
}
