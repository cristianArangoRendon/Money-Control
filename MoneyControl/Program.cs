using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Core.Interfaces.UserCases.User;
using MoneyControl.Infraestructure.Repository.DataContext;
using MoneyControl.Infraestructure.Repository.User;
using MoneyControl.Infraestructure.Services.ExecuteStoreProcedure;
using MoneyControl.Infraestructure.Services.LogService;
using MoneyControl.Infraestructure.Services.SqlCommandService;
using MoneyControl.Infraestructure.UserCases.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IDataContext, DataContext>();
builder.Services.AddTransient<ISqlCommandService, SqlCommandService>();
builder.Services.AddTransient<ILogService, LogService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserUserCase, UserUserCase>();
builder.Services.AddTransient<IExecuteStoreProcedureService, ExecuteStoreProcedureService>();


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
