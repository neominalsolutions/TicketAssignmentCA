using FluentValidation.AspNetCore;
using TicketAssignment.Domain.Repositories;
using TicketAssignment.Domain.Services;
using TicketAssignmentApp.Application.Features.Ticket.Handlers;
using TicketAssignmentApp.Application.Features.Ticket.Validators;
using TicketAssignmentApp.Infrastructure.Persistance.EF.Repositories;
using TicketAssignmentApp.Persistance.EF.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// servislerin IoC ye tarn�t�lamas� s�recinde web uygulama olmas� sebebi ile genelede scoped service tan�mlar�n� tercih ederiz. 

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient<TicketAssignmentFactory>(); // TicketAssigment Service Y�netimi

// hizmet �al��t�rma gibi controller,mediator,repository gibi web request bazl� �al��n yap�lar.
builder.Services.AddScoped<IEmployeeRepository, EFEmployeeRepository>();
builder.Services.AddScoped<ITicketRepository, EFTicketRepository>();
builder.Services.AddScoped<IEmployeeTicketRepository, EFEmployeeTicketRepository>();



builder.Services.AddControllers().AddFluentValidation(config =>
{
  config.RegisterValidatorsFromAssemblyContaining<AssignTicketValidator>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// reflection application katman�ndaki t�m request handler s�n�flar�n� otoload edip program taraf�nda ioc sa�layacak.
builder.Services.AddMediatR(config =>
{
  config.RegisterServicesFromAssemblyContaining<AssignTicketHandler>();
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
