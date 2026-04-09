using Ferremundo.Integrations.Rest.Authentication;
using Ferremundo.JobPlatform.Client.Abstractions;

namespace Ferremundo.JobPlatform.Client.Authentication;

public sealed class JobPlatformClientAuthenticationStrategy : IJobPlatformClientAuthenticationStrategy
{
    private readonly BearerTokenAuthenticationStrategy _innerStrategy;

    public JobPlatformClientAuthenticationStrategy(IJobPlatformAccessTokenProvider accessTokenProvider)
    {
        _innerStrategy = new BearerTokenAuthenticationStrategy(new JobPlatformAccessTokenProviderAdapter(accessTokenProvider));
    }

    public Task ApplyAsync(HttpRequestMessage request, CancellationToken cancellationToken = default)
        => _innerStrategy.ApplyAsync(request, cancellationToken);
}
