using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Infraestructure.IOC;
using Newtonsoft.Json;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    var MoneyControl = "MoneyControl";



    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = MoneyControl + " v1",


    });






    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Token de autenticacin Bearer",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });


    config.AddSecurityRequirement(new OpenApiSecurityRequirement
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

                    new List<string>()
                }
            }
     );


    // config.ExampleFilters();
    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //config.IncludeXmlComments(xmlPath);
});



builder.Services.AddMoneyControl();

var Key = Encoding.ASCII.GetBytes(builder.Configuration["JWT:key"]);

builder.Services.AddAuthentication(d =>
{
    d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(d =>
{
    d.RequireHttpsMetadata = false;
    d.SaveToken = true;
    d.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
    d.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            context.HandleResponse();

            if (!context.Response.HasStarted)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Response.ContentType = "application/json";
                var response = new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Unauthorized: Invalid credentials or access denied.",
                    Data = null
                };

                var result = JsonConvert.SerializeObject(response);

                return context.Response.WriteAsync(result);
            }

            return Task.CompletedTask;
        }
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MoneyControl API");
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
