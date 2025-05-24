using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;

namespace Restorant.WebUI.Extension
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddDbContext<RestorantDbContext>();
            services.AddIdentity<AppUser, AppRole>()
                    .AddEntityFrameworkStores<RestorantDbContext>();
            services.AddHttpClient();

            var requireAuthorizePolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Admin/Login/Index";
            });

            return services;
        }
    }
}
