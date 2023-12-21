using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAssignmentApp.Application.Features.Ticket.Dtos
{
    // use-case data structure
    public record AssignTicketDto : IRequest
    {
    //[Required(ErrorMessage = "")]
        public string TicketId { get; set; }
        public string EmployeeId { get; set; }
        public int EstimatedHour { get; set; } // 4 saat

    }
}
