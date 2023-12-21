using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketAssignment.Domain.Repositories;
using TicketAssignmentApp.Application.Features.Employee;
using TicketAssignmentApp.Application.Features.Employee.Dtos;
using TicketAssignmentApp.Application.Features.Ticket.Dtos;
using TicketAssignmentApp.Application.Features.Ticket.Services;

namespace TicketAssignment.Presentation.API.Controllers
{
    [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : ControllerBase
  {
    // Grasp Indirection sorumluluğu mediator ile uygulamış olduk.
    private readonly IMediator mediator; // kule

    // bir controller içerisinde birden fazla servis ile gelen istekleri yönetimini sağlamak kaotik bir ortama sebebiyet veriyor.
    //private readonly ITicketApplicationService ticketApplicationService;
    //private readonly IEmployeeApplicationService employeeApplicationService;
    //private readonly IEmployeeRepository employeeRepository;

    //public EmployeesController(ITicketApplicationService ticketApplicationService, IEmployeeApplicationService employeeApplicationService, IEmployeeRepository employeeRepository)
    //{
    //  this.employeeApplicationService = employeeApplicationService;
    //  this.ticketApplicationService = ticketApplicationService;
    //  this.employeeRepository = employeeRepository;
    //}
    public EmployeesController(IMediator mediator)
    {
      this.mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request){
      var response = await this.mediator.Send(request);
      return Ok(response);
    }

    [HttpPost("assingTask")]
    public async Task<IActionResult> AssignTicket([FromBody] AssignTicketDto request)
    {
      //this.employeeRepository.FindAll();

      // indirect communication with mediator(Application.dll Request)
     await this.mediator.Send(request);
      // direct communication
      //ticketApplicationService.AssignTicket(request);

      return Created("",""); // 201 status kod
    }
  }
}
