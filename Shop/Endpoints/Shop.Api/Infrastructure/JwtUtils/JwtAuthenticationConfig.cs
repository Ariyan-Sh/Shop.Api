using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Shop.Api.Infrastructure.JwtUtil;

public static class JwtAuthenticationConfig
{
    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddAuthentication(option =>
        {
            option.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(option =>
        {
            option.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                ValidateAudience = true,
                IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SecretKey"])),
                ValidIssuer = configuration["JwtConfig:Issuer"],
                ValidAudience = configuration["JwtConfig:Audience"],

            };
            option.SaveToken = true;
            option.Events = new JwtBearerEvents()
            {
                OnTokenValidated = async context =>
                {
                    var customValidate = context.HttpContext.RequestServices
                        .GetRequiredService<CustomJwtValidation>();
                    await customValidate.Validate(context);
                }
            }
            ; //مشکل اینه
        });
        //        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //.AddJwtBearer(options =>
        //{
        //    options.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidateLifetime = true,
        //        ValidateIssuerSigningKey = true,
        //        ValidIssuer = configuration["JwtConfig:Issuer"],
        //        ValidAudience = configuration["JwtConfig:Audience"],
        //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SecretKey"]))
        //    };
        //});
        services.AddAuthorization();
    }
}