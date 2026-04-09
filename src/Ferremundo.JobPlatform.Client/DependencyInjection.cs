using Ferremundo.Integrations.Rest;
using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Client.Authentication;
using Ferremundo.JobPlatform.Client.Configuration;
using Ferremundo.JobPlatform.Client.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Ferremundo.JobPlatform.Client;

public static class DependencyInjection
{
    public static IServiceCollection AddJobPlatformClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddExternalRestSupport();

        services
            .AddOptions<JobPlatformClientOptions>()
            .Bind(configuration.GetSection(JobPlatformClientOptions.SectionName))
            .Validate(options => !string.IsNullOrWhiteSpace(options.BaseUrl), "JobPlatformClient:BaseUrl is required.")
            .ValidateOnStart();

        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.TryAddScoped<IJobPlatformAccessTokenProvider, CurrentRequestAccessTokenProvider>();
        services.TryAddScoped<IJobPlatformClientAuthenticationStrategy, JobPlatformClientAuthenticationStrategy>();

        AddConfiguredHttpClient<IWorkerGroupClient, WorkerGroupClient>(services);
        AddConfiguredHttpClient<IWorkerNodeClient, WorkerNodeClient>(services);
        AddConfiguredHttpClient<IJobDefinitionClient, JobDefinitionClient>(services);
        AddConfiguredHttpClient<IJobScheduleClient, JobScheduleClient>(services);
        AddConfiguredHttpClient<IJobCommandClient, JobCommandClient>(services);
        AddConfiguredHttpClient<IJobExecutionClient, JobExecutionClient>(services);
        AddConfiguredHttpClient<IJobExecutionTraceClient, JobExecutionTraceClient>(services);

        return services;
    }

    private static void AddConfiguredHttpClient<TClientContract, TClientImplementation>(IServiceCollection services)
        where TClientContract : class
        where TClientImplementation : class, TClientContract
    {
        services.AddHttpClient<TClientContract, TClientImplementation>((serviceProvider, httpClient) =>
        {
            var options = serviceProvider
                .GetRequiredService<IOptions<JobPlatformClientOptions>>()
                .Value;

            httpClient.BaseAddress = new Uri(options.BaseUrl, UriKind.Absolute);
        });
    }
}
