using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.Entities;
using TicketAssignment.Domain.Repositories;
using TicketAssignment.Domain.SeedWork;

namespace TicketAssignment.Domain.Services
{
    // eğer atanacak görevin yaklaşık tamamlama süresi 6 saat ve üstünde ise aynı zaman toplamda 30 saatin aldında ise haftalık görev atama poliçesi uygulansın.
    public class WeeklyTicketAssignmentService : ITicketAssignment
  {
    private readonly IEmployeeTicketRepository employeeTicketRepository;
    private readonly IEmployeeRepository employeeRepository;
    private readonly ITicketRepository ticketRepository;
    public WeeklyTicketAssignmentService(IEmployeeTicketRepository employeeTicketRepository, IEmployeeRepository employeeRepository, ITicketRepository ticketRepository)
    {
      this.employeeTicketRepository = employeeTicketRepository;
      this.employeeRepository = employeeRepository;
      this.ticketRepository = ticketRepository;
    }

    public void AssignTicket(string ticketId, string employeeId, int estimatedHour)
    {
      int weekOfDayIndex = (int)DateTime.Now.DayOfWeek; // 0-6
      DateTime weekStartDate = DateTime.Now.AddDays(-(weekOfDayIndex+1));
      DateTime weekEndDate = DateTime.Now.AddDays(6 - weekOfDayIndex);


      int weeklyAssignedTicketsTotalHours = employeeTicketRepository
        .FindWithCriteria(x => x.AssignedAt.Date >= weekStartDate.Date && x.AssignedAt.Date <= weekEndDate.Date)
        .Sum(x => x.EstimatedHour);

      if ((weeklyAssignedTicketsTotalHours + estimatedHour) > 30)
      {
        throw new NotImplementedException("Haftalık görev atama limiti aşıldı");
      }

      var employee = employeeRepository.FindById(employeeId);
      var ticket = ticketRepository.FindById(ticketId);
      employee.AssignTicket(estimatedHour, ticket);

      employeeRepository.Update(employee); // Artık employee nesnesni içindeki ticket tanımı ile update et.



    }
  }
}
