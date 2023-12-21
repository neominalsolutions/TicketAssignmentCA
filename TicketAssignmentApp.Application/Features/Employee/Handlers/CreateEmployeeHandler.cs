using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignmentApp.Application.Features.Employee.Dtos;

namespace TicketAssignmentApp.Application.Features.Employee.Handlers
{
  public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeRequest, CreateEmployeeResponse>
  {
    public async Task<CreateEmployeeResponse> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
    {

      // BUSSINESS OPERATIONS CALL
      // INFRA SERVICE CALL

     return await Task.FromResult<CreateEmployeeResponse>(new CreateEmployeeResponse { CreatedAt = DateTime.Now, EmployeeId = 1 });
    }
  }
}
