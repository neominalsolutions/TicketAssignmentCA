using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketAssignmentApp.Application.Features.Employee.Dtos;

namespace TicketAssignmentApp.Application.Features.Ticket.Validators
{
  // Single Responsibity Prensibinide uygulamış oluyoruz.
  public class CreateEmployeeRequestValidator:AbstractValidator<CreateEmployeeRequest>
  {
    public CreateEmployeeRequestValidator()
    {
      // 400 BadRequest ile hata mesajları
      RuleFor(x => x.FirstName)
        .NotNull().WithMessage("Null Geçilemez")
        .NotEmpty().WithMessage("Boşluklu bırakılamaz")
        .MinimumLength(5).WithMessage("Min 5")
        .MaximumLength(20).WithMessage("Maks 20");
      // LastName boş değilken firstName boş geçilemez dedik 2 farklı property when ile birbirine bağladık.
      RuleFor(x => x.LastName).NotEmpty().When(x => x.FirstName != "").WithMessage("Fisrtname ile LastName boş geçilemez");
    }
  }
}
