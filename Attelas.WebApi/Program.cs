using Attelas.Application;
using Attelas.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//register application services
builder.Services.RegisterServices();
builder.Services.AddControllers();
//routes in lowercase
builder.Services.AddRouting(opt => opt.LowercaseUrls = true);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

//entry point
app.Run();