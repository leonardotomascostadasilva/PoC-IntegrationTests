using PoCTests.Api.Features.Login;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ILogin, Login>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);


builder.Services
    .AddRefitClient<IValidate>()
    .ConfigureHttpClient(c =>
{
    var url = builder.Configuration.GetSection("ValidateConfiguration:url").Value;
    c.BaseAddress = new Uri(url);
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();


app.Run();