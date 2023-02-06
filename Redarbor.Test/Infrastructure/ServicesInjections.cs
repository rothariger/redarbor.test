using Redarbor.Test.Commands;
using Redarbor.Test.Queries;

namespace Redarbor.Test.Infrastructure
{
    public static class ServicesInjections
    {
        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddScoped<CandidateCommandHandler>();
            services.AddScoped<CandidateQueriesHandler>();
            return services;
        }
    }
}
