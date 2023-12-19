using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignmentApp.Application.Features.Ticket.Dtos;

namespace TicketAssignmentApp.Application.Features.Ticket.Services
{
  // Buradaki Application Service Kullanım örneği Open Closed Prensibine uygun değildir.
  // TicketApplicationService kodu her yeni bir feature eklendiğinde içine eklemek yapılacak kod blogu değişecek. 
  public class TicketApplicationService:ITicketApplicationService
  {
    public void CreateTicket(CreateTicketDto dto)
    {

    }

    public void AssignTicket(AssignTicketDto dto)
    {

    }
  }
}
