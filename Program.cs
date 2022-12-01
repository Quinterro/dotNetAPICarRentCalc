using CarRentCalculator;
using CarRentCalculator.Entities;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CarRentCalcDbContext>();
builder.Services.AddScoped<CarSeeder>();

void Configure(WebApplication host, CarSeeder seeder)
{
    seeder.Seed();
    using var scope = host.Services.CreateScope();
    var services = scope.ServiceProvider;

    // try
    // {
    //     var dbContext = services.GetRequiredService<CarRentCalcDbContext>();
    // }
}

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
