using Ferremundo.Integrations.Rest.Abstractions.Correlation;
using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Client.Authentication;
using Ferremundo.JobPlatform.Client.Configuration;
using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.JobCommands.Requests;
using Ferremundo.JobPlatform.Contracts.JobCommands.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ferremundo.JobPlatform.Client.Services;

public sealed class JobCommandClient : JobPlatformClientBase, IJobCommandClient
{
    public JobCommandClient(
        HttpClient httpClient,
        IOptions<JobPlatformClientOptions> options,
        IJobPlatformClientAuthenticationStrategy authenticationStrategy,
        IExternalCorrelationProvider correlationProvider,
        ILogger<JobCommandClient> logger)
        : base(httpClient, options, authenticationStrategy, correlationProvider, logger)
    {
    }

    public async Task<ResponseBase<IReadOnlyCollection<JobCommandResponse>>?> GetAllAsync(CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<IReadOnlyCollection<JobCommandResponse>>>("api/v1/job-commands", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<IReadOnlyCollection<JobCommandResponse>>>();

    public async Task<ResponseBase<JobCommandResponse>?> GetByGuidAsync(Guid jobCommandGuid, CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<JobCommandResponse>>($"api/v1/job-commands/{jobCommandGuid}", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<JobCommandResponse>>();

    public async Task<ResponseBase<IReadOnlyCollection<JobCommandResponse>>?> GetPendingByWorkerNodeAsync(Guid workerNodeGuid, CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<IReadOnlyCollection<JobCommandResponse>>>($"api/v1/job-commands/pending/worker-nodes/{workerNodeGuid}", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<IReadOnlyCollection<JobCommandResponse>>>();

    public async Task<ResponseBase<JobCommandResponse>?> CreateRunNowAsync(CreateRunNowJobCommandRequest request, CancellationToken cancellationToken = default)
        => await PostAsync<CreateRunNowJobCommandRequest, ResponseBase<JobCommandResponse>>("api/v1/job-commands/run-now", request, cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<JobCommandResponse>>();

    public async Task<ResponseBase<JobCommandResponse>?> UpdateStatusAsync(Guid jobCommandGuid, UpdateJobCommandStatusRequest request, CancellationToken cancellationToken = default)
        => await PostAsync<UpdateJobCommandStatusRequest, ResponseBase<JobCommandResponse>>($"api/v1/job-commands/{jobCommandGuid}/status", request, cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<JobCommandResponse>>();
}
