using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.Exceptions;
using TicketAssignment.Domain.Repositories;

namespace TicketAssignment.Domain.Services
{
  public class DailyTicketAssignmentService : ITicketAssignment
  {
    private IEmployeeTicketRepository employeeTicketRepository;

    public DailyTicketAssignmentService(IEmployeeTicketRepository employeeTicketRepository)
    {
      this.employeeTicketRepository = employeeTicketRepository;
    }

    // bir günde en fazla 6 saatlik bir görev ataması yapılabilir
    public void CheckTicketAssignmentRules(string ticketId, string employeeId, int estimatedHour)
    {

      var dailyAssignedTicketTotalHours =  this.employeeTicketRepository
        .FindWithCriteria(x => x.AssignedAt.Date == DateTime.Now.Date)
        .Sum(x => x.EstimatedHour);

      if((dailyAssignedTicketTotalHours + estimatedHour) > 6)
      {
        throw new DailyTicketAssigmentOverflowException();
      }

      
    }
  }
}
