using Refit;
using RefitRESTLib.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Register Refit client
builder.Services.AddRefitClient<IJsonPlaceholderApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();