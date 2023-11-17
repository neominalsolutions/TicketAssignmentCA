using TicketAssignment.Domain.SeedWork;

namespace TicketAssignment.Domain.Entities
{
  public class Ticket:Entity
  {
    public string Title { get; set; }
    public string Description { get; set; }

  }
}