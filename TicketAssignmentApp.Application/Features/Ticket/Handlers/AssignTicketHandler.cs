using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.Entities;
using TicketAssignment.Domain.Factory;
using TicketAssignment.Domain.Services;
using TicketAssignmentApp.Application.Features.Ticket.Dtos;

namespace TicketAssignmentApp.Application.Features.Ticket.Handlers
{
    public class AssignTicketHandler : IRequestHandler<AssignTicketDto>
  {
    // facade işlemi yaptık
    // AssignTicketHandler => TaskAssigmentService
    // indirection
    private TicketAssignmentFactory ticketAssignment;
    private TicketAssignmentManager assignmentManager;

    // TicketAssignmentFactory servisi Dependecy Injection ile çağırıp
    // Zaten TicketAssignmentFactory Program.cs dosyasında IoC tarafından üretildi.
    public AssignTicketHandler(TicketAssignmentFactory ticketAssignmentFactory, TicketAssignmentManager assignmentManager)
    {
      this.ticketAssignment = ticketAssignmentFactory;
      this.assignmentManager = assignmentManager;
    }



    // Event Driven bir programlama mantığı ile yazılmış bir paket.
    public async Task Handle(AssignTicketDto request, CancellationToken cancellationToken)
    {

      // algoritmik olarak yönlendirme yapıyor.
      //assignmentManager.AssignTicket(request.TicketId, request.EmployeeId, request.EstimatedHour);

      var ticketService = ticketAssignment
        .TicketServiceInstance(request.EstimatedHour);

      ticketService.AssignTicket(request.TicketId, request.EmployeeId, request.EstimatedHour);

      // email gönderme vs gibi süreçleri yönetebilirim.

    }
  }
}
