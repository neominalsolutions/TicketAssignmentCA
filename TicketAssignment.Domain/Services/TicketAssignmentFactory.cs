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

    public TicketAssignmentFactory(IEmployeeTicketRepository employeeTicketRepository)
    {
      this.employeeTicketRepository = employeeTicketRepository;
    }

    // 6 saat üsütnde farklı servis görevlensin
    public ITicketAssignment GetInstance(int estimatedHour)
    {
      if (estimatedHour > 6)
        return new WeeklyTicketAssignmentService(employeeTicketRepository);
      else
        return new DailyTicketAssignmentService(employeeTicketRepository);

    }
  }
}
