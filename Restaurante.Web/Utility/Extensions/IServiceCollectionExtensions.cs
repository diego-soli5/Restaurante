using Restaurante.Web.Services.Interfaces;
using Restaurante.Web.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Restaurante.Web.Utility.Options;
using Restaurante.Web.Utility.ApiRoutes;

namespace Restaurante.Web.Utility.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IHttpClientService), typeof(HttpClientService));
            services.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));
            services.AddScoped(typeof(IMesaService), typeof(MesaService));
            services.AddScoped(typeof(ITipoMenuService), typeof(TipoMenuService));
            services.AddScoped(typeof(IMenuService), typeof(MenuService));
            services.AddScoped(typeof(IClienteService), typeof(ClienteService));
            services.AddScoped(typeof(IReservacionService), typeof(ReservacionService));
        }

        public static void ConfigureAthentication(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
                    {
                        config.Cookie.Name = "App.Auth.Restaurante";
                        config.LoginPath = "/Usuario/Login";
                        config.AccessDeniedPath = "/Usuario/UnauthorizedView";
                        config.LogoutPath = "/Usuario/Logout";
                        config.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                    });
        }

        public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            string domain = configuration.GetSection("Options:Api:Domain").Value;

            services.Configure<ApiOptions>(x =>
            {
                x.Domain = domain;
            });
        }

        public static void AddRoutes(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ApiRoutesProvider));
            services.AddSingleton(typeof(UsuarioRoutes));
            services.AddSingleton(typeof(TipoMenuRoutes));
            services.AddSingleton(typeof(MenuRoutes));
            services.AddSingleton(typeof(MesaRoutes));
            services.AddSingleton(typeof(ReservacionRoutes));
            services.AddSingleton(typeof(ClienteRoutes));
        }
    }
}
