using Dotz.Infra.EF.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dotz.Api.Helpers
{
    public static class StartupExtensions
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            using (var context = serviceScope.ServiceProvider.GetRequiredService<SystemContext>())
                context.Database.Migrate();

            return app;
        }
    }
}
