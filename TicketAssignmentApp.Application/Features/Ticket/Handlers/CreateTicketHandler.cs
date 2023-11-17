using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignmentApp.Application.Features.Ticket.Dtos;

namespace TicketAssignmentApp.Application.Features.Ticket.Handlers
{
  // Open-Closed olarak her bir operasyon için yeni bir sınıf var olan kodda güncelleme yapmadık, kodun yeni bir operasyona adapte olmasını sağladık
  // feature bazlı setler oluşturduk
  public class CreateTicketHandler : IRequestHandler<CreateTicketDto>
  {
    public Task Handle(CreateTicketDto request, CancellationToken cancellationToken)
    {
      return Task.CompletedTask;
    }
  }
}
