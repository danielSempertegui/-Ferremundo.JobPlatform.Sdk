using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Client.Configuration;
using Ferremundo.JobPlatform.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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

        services.AddHttpClient<IWorkerGroupClient, WorkerGroupClient>((serviceProvider, httpClient) =>
        {
            var options = serviceProvider
                .GetRequiredService<IOptions<JobPlatformClientOptions>>()
                .Value;

            httpClient.BaseAddress = new Uri(options.BaseUrl, UriKind.Absolute);
        });

        services.AddHttpClient<IWorkerNodeClient, WorkerNodeClient>((serviceProvider, httpClient) =>
        {
            var options = serviceProvider
                .GetRequiredService<IOptions<JobPlatformClientOptions>>()
                .Value;

            httpClient.BaseAddress = new Uri(options.BaseUrl, UriKind.Absolute);
        });

        services.AddHttpClient<IJobDefinitionClient, JobDefinitionClient>((serviceProvider, httpClient) =>
        {
            var options = serviceProvider
                .GetRequiredService<IOptions<JobPlatformClientOptions>>()
                .Value;

            httpClient.BaseAddress = new Uri(options.BaseUrl, UriKind.Absolute);
        });

        services.AddHttpClient<IJobScheduleClient, JobScheduleClient>((serviceProvider, httpClient) =>
        {
            var options = serviceProvider
                .GetRequiredService<IOptions<JobPlatformClientOptions>>()
                .Value;

            httpClient.BaseAddress = new Uri(options.BaseUrl, UriKind.Absolute);
        });

        services.AddHttpClient<IJobCommandClient, JobCommandClient>((serviceProvider, httpClient) =>
        {
            var options = serviceProvider
                .GetRequiredService<IOptions<JobPlatformClientOptions>>()
                .Value;

            httpClient.BaseAddress = new Uri(options.BaseUrl, UriKind.Absolute);
        });

        return services;
    }
}

