using ElectLive_API.Controllers;
using ElectLive_API.Data.Model;
using ElectLive_API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection"), 
    options => options.EnableRetryOnFailure(maxRetryCount: 5,
                    maxRetryDelay: System.TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null)));
builder.Services.AddMvcCore();
builder.Services.AddScoped<IElecLiveRepository, ElecLiveRepository>();
builder.Services.AddSignalR(options =>
{
    options.MaximumParallelInvocationsPerClient = 1;
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://178.16.142.108:3000", "http://localhost:3000")
        .AllowCredentials();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


   
app.UseHttpsRedirection();

app.UseDeveloperExceptionPage();

app.UseRouting();

app.UseCors("ClientPermission");

app.UseAuthorization();

app.MapControllers();
app.MapHub<VotingsHub>("/votingsStream");

app.Run();
