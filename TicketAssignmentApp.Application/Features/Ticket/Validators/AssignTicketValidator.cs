using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignmentApp.Application.Features.Ticket.Dtos;

namespace TicketAssignmentApp.Application.Features.Ticket.Validators
{
  // Validation işlemlerinden sorumlu sınıf
  public class AssignTicketValidator:AbstractValidator<AssignTicketDto>
  {
    public AssignTicketValidator()
    {
      // hata varsa 400 hata kodu olarak api dönüş yap.
      RuleFor(x => x.EstimatedHour).LessThanOrEqualTo(6).GreaterThanOrEqualTo(1).WithMessage("En az 1 En fazla 6 saatlik bir task ataması yapılabilir");
      RuleFor(x => x.EmployeeId).NotNull().NotEmpty().WithMessage("Employee seçimi yapınız");
      RuleFor(x => x.TicketId).NotNull().NotEmpty().WithMessage("Employee seçimi yapınız");
    }
  }
}
