using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.Repositories;
using TicketAssignment.Domain.SeedWork;
using TicketAssignment.Domain.Services;

namespace TicketAssignment.Domain.Factory
{
  // Factory Method Design Pattern ile parametre bazlı hangi servisi dinamik olarak titkleneceğine karar verecek bir strateji yaptık
  // GRASP Creator özelliğini kullandık.
  public class TicketAssignmentFactory
  {
    private readonly IEmployeeTicketRepository employeeTicketRepository;
    private readonly IEmployeeRepository employeeRepository;
    private readonly ITicketRepository ticketRepository;

    public TicketAssignmentFactory(IEmployeeTicketRepository employeeTicketRepository, IEmployeeRepository employeeRepository, ITicketRepository ticketRepository)
    {
      this.employeeTicketRepository = employeeTicketRepository;
      this.ticketRepository = ticketRepository;
      this.employeeRepository = employeeRepository;
    }

    // 6 saat üsütnde farklı servis görevlensin
    public ITicketAssignment TicketServiceInstance(int estimatedHour)
    {
      if (estimatedHour > 6 && estimatedHour <= 30)
        return new WeeklyTicketAssignmentService(employeeTicketRepository, employeeRepository, ticketRepository);
      else if (estimatedHour < 6 && estimatedHour >= 1)
        return new DailyTicketAssignmentService(employeeTicketRepository, employeeRepository, ticketRepository);
      else if (estimatedHour > 30)
        return new MontlyTicketAssigmentService();
      else
        throw new Exception("1 saatten az görev ataması yapılamaz veya 120 saat üzerinde görev ataması yapılamaz.");

    }
  }
}
