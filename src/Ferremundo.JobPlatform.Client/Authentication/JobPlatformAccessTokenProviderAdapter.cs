using Ferremundo.Integrations.Rest.Abstractions.Authentication;
using Ferremundo.JobPlatform.Client.Abstractions;

namespace Ferremundo.JobPlatform.Client.Authentication;

public sealed class JobPlatformAccessTokenProviderAdapter : IAccessTokenProvider
{
    private readonly IJobPlatformAccessTokenProvider _innerProvider;

    public JobPlatformAccessTokenProviderAdapter(IJobPlatformAccessTokenProvider innerProvider)
    {
        _innerProvider = innerProvider;
    }

    public async Task<string?> GetAccessTokenAsync(CancellationToken cancellationToken = default)
    {
        return await _innerProvider.GetAccessTokenAsync(cancellationToken);
    }
}
