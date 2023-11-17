using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignmentApp.Application.Features.Ticket.Dtos;

namespace TicketAssignmentApp.Application.Features.Ticket.Handlers
{
  public class AssignTicketHandler : IRequestHandler<AssignTicketDto>
  {
    // Event Driven bir programlama mantığı ile yazılmış bir paket.
    public async Task Handle(AssignTicketDto request, CancellationToken cancellationToken)
    {
       await Task.CompletedTask;
    }
  }
}
