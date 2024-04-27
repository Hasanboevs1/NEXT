using Microsoft.EntityFrameworkCore;
using NEXT.Api.Extensions;
using NEXT.Api.Middlewares;
using NEXT.Data.DbContexts;
using NEXT.Service.Mappings;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomServices();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var connection = builder.Configuration.GetConnectionString("next");

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseNpgsql(connection);
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlerMiddleWare>();
app.MapControllers();

app.Run();
