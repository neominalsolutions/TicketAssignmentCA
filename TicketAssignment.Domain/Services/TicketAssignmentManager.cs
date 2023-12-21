using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.Repositories;
using TicketAssignment.Domain.SeedWork;

namespace TicketAssignment.Domain.Services
{
  // Strategy Design Pattern

  /// <summary>
  /// Atanacak işin saatine göre çalışanın günlük ve haftalık iş yükü baz alınarak atanacak olan işin aylık mı günlük mü yoksa haftalık mı atanacağına kendisi karar veren bir service.
  /// </summary>
  public class TicketAssignmentManager : ITicketAssignment
  {
    private readonly IEmployeeRepository employeeRepository;
    private readonly ITicketRepository ticketRepository;
    private readonly IEmployeeTicketRepository employeeTicketRepository;


    public TicketAssignmentManager(IEmployeeRepository employeeRepository, ITicketRepository ticketRepository, IEmployeeTicketRepository employeeTicketRepository)
    {
      this.employeeRepository = employeeRepository;
      this.ticketRepository = ticketRepository;
      this.employeeTicketRepository = employeeTicketRepository;
      
    }

    // Yapılacak olan bir işleme ait operasyonun parametrik olarak dinamik değiştiriği durumlarda farklı strategy kodlarını tetiklemek için kullanılan bir pattern Strategy pattern.
    public void AssignTicket(string ticketId, string employeeId, int estimatedHour)
    {
      // Atanacak olan işin haftalık mı yoksa günlük mü yoksa aylık mı atanacağını bulan buna göre çalışan bir servis tanımı yapalım

      var dailyAssignedTicketTotalHours = this.employeeTicketRepository
        .FindWithCriteria(x => x.AssignedAt.Date == DateTime.Now.Date && x.EmployeeId == employeeId)
        .Sum(x => x.EstimatedHour);

      int weekOfDayIndex = (int)DateTime.Now.DayOfWeek; // 0-6
      DateTime weekStartDate = DateTime.Now.AddDays(-weekOfDayIndex);
      DateTime weekEndDate = DateTime.Now.AddDays(6 - weekOfDayIndex);


      int weeklyAssignedTicketsTotalHours = employeeTicketRepository
        .FindWithCriteria(x => x.AssignedAt.Date >= weekStartDate.Date && x.AssignedAt.Date <= weekEndDate.Date && x.EmployeeId == employeeId)
        .Sum(x => x.EstimatedHour);


      if((dailyAssignedTicketTotalHours + estimatedHour) > 6 &&  (dailyAssignedTicketTotalHours + estimatedHour) <= 30)
      {
        var service = new WeeklyTicketAssignmentService(employeeTicketRepository, employeeRepository, ticketRepository);
        service.AssignTicket(ticketId, employeeId, estimatedHour);

      } 
      else if((weeklyAssignedTicketsTotalHours + estimatedHour) > 30 && (weeklyAssignedTicketsTotalHours + estimatedHour)<=120)
      {
        var service = new MontlyTicketAssigmentService();
        service.AssignTicket(ticketId, employeeId, estimatedHour);

      } 
      else if((dailyAssignedTicketTotalHours + estimatedHour) < 6 && (dailyAssignedTicketTotalHours + estimatedHour) >=1)
      {
        var service = new DailyTicketAssignmentService(employeeTicketRepository, employeeRepository, ticketRepository);
        service.AssignTicket(ticketId, employeeId, estimatedHour);

      } 
      else
      {
        throw new Exception("Görev ataması uygun değildir");
      }

    }
  }
}
