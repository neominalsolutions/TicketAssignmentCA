using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.Repositories;

namespace TicketAssignment.Domain.Services
{
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
      if (estimatedHour > 6)
        return new WeeklyTicketAssignmentService(employeeTicketRepository, employeeRepository, ticketRepository);
      else
        return new DailyTicketAssignmentService(employeeTicketRepository,employeeRepository,ticketRepository);

    }
  }
}
