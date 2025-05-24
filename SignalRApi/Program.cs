using SignalR.Api.Extension;
using SignalR.Api.Hubs;
using SignalR.BusinessLayer.Abstract;
using SignalR.BusinessLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
    });
});
builder.Services.AddSignalR();

builder.Services.AddProjectServices();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsPolicy");

app.UseAuthorization();
app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");

app.Run();
