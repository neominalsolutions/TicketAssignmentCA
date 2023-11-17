using FluentValidation.AspNetCore;
using TicketAssignmentApp.Application.Features.Ticket.Handlers;
using TicketAssignmentApp.Application.Features.Ticket.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
