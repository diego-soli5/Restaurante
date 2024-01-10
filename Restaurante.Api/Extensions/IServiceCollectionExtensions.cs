using Humanizer.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Restaurante.AccesoDatos;
using Restaurante.AccesoDatos.Repositories.Interfaces;
using Restaurante.AccesoDatos.Repositories;
using System.Text;
using Restaurante.LogicaNegocio.Services.Interfaces;
using Restaurante.LogicaNegocio.Services;
using Restaurante.LogicaNegocio.Options;

namespace Restaurante.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestauranteContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CNN"), sqlServerOptions =>
                {
                    sqlServerOptions.CommandTimeout(420);
                    sqlServerOptions.EnableRetryOnFailure();
                });

            });
        }

        public static void ConfigureAthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //El esquema de autenticacion por defecto a usar.
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; //La prueba por defecto que se debe realizar para la autenticacion
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, //Valida quien generó el token (dominio servidor)
                    ValidateAudience = true, //Valida la audiencia del token (dominio cliente)
                    ValidateLifetime = true, //Valida el tiempo de vida del token, por seguridad los tokens deben de tener un tiempo de expiracion
                    ValidateIssuerSigningKey = true, //Valida la firma del emisor del token (nosotros, api)
                    ValidIssuer = configuration["Options:Authentication:Issuer"], //Especifica el emisor valido ya que estamos validando el emisor (dominio)
                    ValidAudience = configuration["Options:Authentication:Audience"], //Especifica la audiencia o clientes que usan nuestro token (dominio)
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Options:Authentication:Key"])) //Especifica el key secreto a usar para firmar y validar los tokens
                };
            });
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPasswordService), typeof(PasswordService));
            services.AddScoped(typeof(ITokenService), typeof(TokenService));
            services.AddScoped(typeof(IClienteService), typeof(ClienteService));
            services.AddScoped(typeof(IMenuService), typeof(MenuService));
            services.AddScoped(typeof(IMesaService), typeof(MesaService));
            services.AddScoped(typeof(IReservacionService), typeof(ReservacionService));
            services.AddScoped(typeof(ITipoMenuService), typeof(TipoMenuService));
            services.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IClienteRepository), typeof(ClienteRepository));
            services.AddScoped(typeof(IMenuRepository), typeof(MenuRepository));
            services.AddScoped(typeof(IMesaRepository), typeof(MesaRepository));
            services.AddScoped(typeof(IReservacionRepository), typeof(ReservacionRepository));
            services.AddScoped(typeof(ITipoMenuRepository), typeof(TipoMenuRepository));
            services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }

        public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthenticationOptions>(configuration.GetSection("Options:Authentication"));

            services.Configure<PasswordOptions>(configuration.GetSection("Options:Password"));
        }
    }
}
