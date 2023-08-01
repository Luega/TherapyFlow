using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using therapyFlow.Data;
using therapyFlow.Modules.Customer.Services;
using therapyFlow.Modules.Note;
using therapyFlow.Modules.Note.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB context injection
builder.Services.AddDbContext<DataContext>(options => 
    options.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"]));

// Service Injection
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Ignore object cycle
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins(builder.Configuration["Policy_url"]!)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});

var app = builder.Build();

// CORS
app.UseCors(MyAllowSpecificOrigins);

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
