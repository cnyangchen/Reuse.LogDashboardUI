using LogDashboard.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace LogDashboard
{
    public static class LogDashboardApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseLogDashboard(
            this IApplicationBuilder builder, string pathMatch = "/LogDashboard")
        {
            var options = builder.ApplicationServices?.GetRequiredService<LogDashboardOptions>();
            options?.SetPathMatch(pathMatch);
            return builder.Map(pathMatch, app => { app.UseMiddleware<LogDashboardMiddleware>(); });
        }
    }

}
