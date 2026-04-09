using Ferremundo.Integrations.Rest;
using Ferremundo.Integrations.Rest.Abstractions.Correlation;
using Ferremundo.Integrations.Rest.Configuration;
using Ferremundo.JobPlatform.Client.Authentication;
using Ferremundo.JobPlatform.Client.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ferremundo.JobPlatform.Client.Services;

public abstract class JobPlatformClientBase : ExternalRestClientBase
{
    protected JobPlatformClientBase(
        HttpClient httpClient,
        IOptions<JobPlatformClientOptions> options,
        IJobPlatformClientAuthenticationStrategy authenticationStrategy,
        IExternalCorrelationProvider correlationProvider,
        ILogger logger)
        : base(
            httpClient,
            BuildExternalRestClientOptions(options.Value),
            authenticationStrategy,
            correlationProvider,
            logger)
    {
    }

    private static ExternalRestClientOptions BuildExternalRestClientOptions(JobPlatformClientOptions options)
    {
        ArgumentNullException.ThrowIfNull(options);

        return new ExternalRestClientOptions
        {
            ServiceName = "Ferremundo.JobPlatform",
            BaseUrl = options.BaseUrl,
            TimeoutSeconds = options.TimeoutSeconds,
            RetryCount = options.RetryCount,
            RetryDelayMilliseconds = options.RetryDelayMilliseconds,
            CorrelationHeaderName = options.CorrelationHeaderName
        };
    }

    protected static InvalidOperationException CreateEmptyResponseException<T>()
        => new($"The API response could not be deserialized to {typeof(T).Name}.");
}
