using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAssignment.Domain.SeedWork
{
  public abstract class Entity
  {
    public string Id { get; init; }

    public Entity()
    {
      Id = Guid.NewGuid().ToString();
    }

  }
}
