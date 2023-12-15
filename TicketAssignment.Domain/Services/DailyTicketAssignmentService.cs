using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.Exceptions;
using TicketAssignment.Domain.Repositories;

namespace TicketAssignment.Domain.Services
{
  // OPEN-CLOSED Prensibi ile Görev atama işleminin gelişime açık değişime kapalı olmasını sağladık.s
  public class DailyTicketAssignmentService : ITicketAssignment
  {
    private IEmployeeTicketRepository employeeTicketRepository;
    private readonly IEmployeeRepository employeeRepository;
    private readonly ITicketRepository ticketRepository;
    // Dependecy Inversion Prensibi ile hangi veri kaynağı üzerinden repository yapılarını çalıştıracağımızı bilmediğimiz için araya interface yapıları koyarak TicketService ile Database arasındaki bağımlılğı azalttık. Infrastructor Layer ile Domain Layer arasındaki bu zayıf bağlılığı Hexagonal (Port And Adapter) Pattern kullanarak sağladık. IEmployeeRepository Output Port görevinde bir tanımlama.
    public DailyTicketAssignmentService(IEmployeeTicketRepository employeeTicketRepository, IEmployeeRepository employeeRepository, ITicketRepository ticketRepository)
    {
      this.employeeTicketRepository = employeeTicketRepository;
      this.employeeRepository = employeeRepository;
      this.ticketRepository = ticketRepository;
    }

    // bir günde en fazla 6 saatlik bir görev ataması yapılabilir
    public void AssignTicket(string ticketId, string employeeId, int estimatedHour)
    {

   
      var dailyAssignedTicketTotalHours =  this.employeeTicketRepository
        .FindWithCriteria(x => x.AssignedAt.Date == DateTime.Now.Date).ToList()
        .Sum(x => x.EstimatedHour);

      if((dailyAssignedTicketTotalHours + estimatedHour) > 6)
      {
        throw new DailyTicketAssigmentOverflowException();
      }

      var employee = employeeRepository.FindById(employeeId);
      var ticket = ticketRepository.FindById(ticketId);
      employee.AssignTicket(estimatedHour, ticket);

      employeeRepository.Update(employee); // Artık employee nesnesni içindeki ticket tanımı ile update et.


    }
  }
}
