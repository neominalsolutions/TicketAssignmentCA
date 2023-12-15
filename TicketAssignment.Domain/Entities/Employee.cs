using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.SeedWork;

namespace TicketAssignment.Domain.Entities
{
  
  public class Employee:Entity
  {

    public string FirstName { get; set; }
    public string LastName { get; set; }

    private List<EmployeeTicket> tickets = new List<EmployeeTicket>();

    // çalışana atanmış tüm ticket değerleri
    public IReadOnlyList<EmployeeTicket> AssignedTickets => tickets;


    // Information Expert olarak Ticket atama sorumluluğu verdik
    public void AssignTicket(int estimatedHour, Ticket ticket)
    {
      // kontrolü bir instance yöntemi mevcut Grasp creator bir örnek. 
      tickets.Add(new EmployeeTicket(estimatedHour,Id,ticket.Id));
      // Information Log
      Console.WriteLine($"{ticket.Title} is Assigned to {FirstName} {LastName}");


    }
  }
}
