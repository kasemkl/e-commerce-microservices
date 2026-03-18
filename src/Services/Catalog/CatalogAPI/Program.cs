using Carter;
using Marten;

var builder = WebApplication.CreateBuilder(args);

// Add services to the conatainer
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(opt => {
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);

}).UseLightweightSessions();
var app = builder.Build();
// Configure the HTTP requuest pipline

app.MapCarter();
app.Run();
