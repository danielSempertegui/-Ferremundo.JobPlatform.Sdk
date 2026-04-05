using Ferremundo.JobPlatform.Client.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ferremundo.JobPlatform.Client;

public static class DependencyInjection
{
    public static IServiceCollection AddJobPlatformClient(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddOptions<JobPlatformClientOptions>()
            .Bind(configuration.GetSection(JobPlatformClientOptions.SectionName))
            .Validate(options => !string.IsNullOrWhiteSpace(options.BaseUrl), "JobPlatformClient:BaseUrl is required.")
            .ValidateOnStart();

        return services;
    }
}
