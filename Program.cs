using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RegistrationAPI;
using RegistrationAPI.Data;
using RegistrationAPI.Services.CharacterService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RegistrationAPIContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("RegistrationAPIContext") ?? throw new InvalidOperationException("Connection string 'RegistrationAPIContext' not found.")));

builder.Services.AddScoped<ICharacterService, CharacterService>();

builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();  


app.UseRouting();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;

    });
}

app.UseEndpoints(endpoints =>
    endpoints.MapControllers());

app.Run();
