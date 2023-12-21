using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketAssignmentApp.Application.Features.Employee.Dtos
{
  public class CreateEmployeeResponse
  {
    public int EmployeeId { get; set; }
    public DateTime CreatedAt { get; set; }

  }
}
