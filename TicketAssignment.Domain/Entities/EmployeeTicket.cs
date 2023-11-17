using TicketAssignment.Domain.SeedWork;

namespace TicketAssignment.Domain.Entities
{
  public class EmployeeTicket:Entity
  {
    public EmployeeTicket(int estimatedHour, string employeeId, string ticketId)
    {
      EstimatedHour = estimatedHour;
      AssignedAt = DateTime.Now;
      EmployeeId = employeeId;
      TicketId = ticketId;
    }

    public int EstimatedHour { get; init; }
    public DateTime AssignedAt { get; init; }

    public string EmployeeId { get; init; }
    public string TicketId { get;init; }


  }
}