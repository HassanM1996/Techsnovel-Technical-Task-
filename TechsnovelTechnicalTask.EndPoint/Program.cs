using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TechsnovelTechnicalTask.Application.Interfaces.Contexts;
using TechsnovelTechnicalTask.Infrastructure;
using TechsnovelTechnicalTask.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithMethods("GET", "PUT", "DELETE", "POST", "PATCH")
            );
});


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddInfrastructureDependency();
builder.Services.AddCors();
// Add services to the container.


builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ISqlDataBaseContext, SqlDataBaseContext>();
builder.Services.AddEntityFrameworkSqlServer().AddDbContext <SqlDataBaseContext>(option => option.UseSqlServer(builder.Configuration["ConnectionStrings"]));

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition(
              "Bearer",
              new OpenApiSecurityScheme
              {
                  Name = "Authorization",
                  Type = SecuritySchemeType.ApiKey,
                  Scheme = "Bearer",
                  BearerFormat = "JWT",
                  In = ParameterLocation.Header,
                  Description = "JWT Authorization header using the Bearer scheme."
              });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                            {
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new string[] { }
    }
});
}
    );
builder.Services.AddAuthorization();
var app = builder.Build();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
if (builder.Configuration["Environment"] != "Development")
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{

    app.MapControllerRoute(
    name: "default",
    pattern: "/swagger/index.html");


});
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");

});

app.Run();
