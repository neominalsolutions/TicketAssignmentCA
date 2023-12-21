using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TicketAssignmentApp.Application.Features.Employee.Dtos
{
  // CreateEmployeeRequest işlemi sonucunda CreateEmployeeResponse tipinde bir değer döndüreceğiz
  public class CreateEmployeeRequest:IRequest<CreateEmployeeResponse>
  {
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

  }
}
