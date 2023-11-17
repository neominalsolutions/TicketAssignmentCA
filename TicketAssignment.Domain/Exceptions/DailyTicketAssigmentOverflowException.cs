using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAssignment.Domain.Exceptions
{
  public class DailyTicketAssigmentOverflowException:Exception
  {
    public DailyTicketAssigmentOverflowException():base("Günlük görev atama sınırı aşıldı")
    {

    }
  }
}
