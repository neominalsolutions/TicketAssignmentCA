using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.SeedWork;

namespace TicketAssignment.Domain.Entities
{
  public class Customer:Entity
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }


  }
}
