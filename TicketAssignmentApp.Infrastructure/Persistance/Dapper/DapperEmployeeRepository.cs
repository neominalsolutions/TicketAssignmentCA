using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignment.Domain.Entities;
using TicketAssignment.Domain.Repositories;
using TicketAssignmentApp.Persistance.EF.Contexts;

namespace TicketAssignmentApp.Infrastructure.Persistance.Dapper
{
  public class DapperEmployeeRepository:DapperRepository<Employee, AppDbContext>,IEmployeeRepository
  {
  }
}
