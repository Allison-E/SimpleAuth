using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Reflection;
using SimpleAuth.Services.Abstractions;
using SimpleAuth.Services;
using SimpleAuth.Persistence;

var builder = WebApplication.CreateBuilder(args);

#region Service configuration.
Assembly controllersAssembly = typeof(SimpleAuth.Presentation.AssemblyReference).Assembly;

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserContext, UserContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{controllersAssembly.GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddControllers().AddApplicationPart(controllersAssembly);
builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow All", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

builder.Services.AddDbContext<UserContext>(options =>
{
    options.UseSqlServer(builder.Configuration["Db:ConnectionString"]);
    options.EnableSensitiveDataLogging();
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Allow All");

app.UseAuthorization();

app.MapControllers();

app.Run();
