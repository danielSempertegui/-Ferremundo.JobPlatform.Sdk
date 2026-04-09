using Ferremundo.Integrations.Rest.Abstractions.Correlation;
using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Client.Authentication;
using Ferremundo.JobPlatform.Client.Configuration;
using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.WorkerNodes.Requests;
using Ferremundo.JobPlatform.Contracts.WorkerNodes.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ferremundo.JobPlatform.Client.Services;

public sealed class WorkerNodeClient : JobPlatformClientBase, IWorkerNodeClient
{
    public WorkerNodeClient(
        HttpClient httpClient,
        IOptions<JobPlatformClientOptions> options,
        IJobPlatformClientAuthenticationStrategy authenticationStrategy,
        IExternalCorrelationProvider correlationProvider,
        ILogger<WorkerNodeClient> logger)
        : base(httpClient, options, authenticationStrategy, correlationProvider, logger)
    {
    }

    public async Task<ResponseBase<IReadOnlyCollection<WorkerNodeResponse>>?> GetAllAsync(CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<IReadOnlyCollection<WorkerNodeResponse>>>("api/v1/worker-nodes", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<IReadOnlyCollection<WorkerNodeResponse>>>();

    public async Task<ResponseBase<WorkerNodeResponse>?> GetByGuidAsync(Guid workerNodeGuid, CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<WorkerNodeResponse>>($"api/v1/worker-nodes/{workerNodeGuid}", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<WorkerNodeResponse>>();

    public async Task<ResponseBase<WorkerNodeResponse>?> CreateAsync(CreateWorkerNodeRequest request, CancellationToken cancellationToken = default)
        => await PostAsync<CreateWorkerNodeRequest, ResponseBase<WorkerNodeResponse>>("api/v1/worker-nodes", request, cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<WorkerNodeResponse>>();

    public async Task<ResponseBase<WorkerNodeResponse>?> UpdateAsync(Guid workerNodeGuid, UpdateWorkerNodeRequest request, CancellationToken cancellationToken = default)
        => await PutAsync<UpdateWorkerNodeRequest, ResponseBase<WorkerNodeResponse>>($"api/v1/worker-nodes/{workerNodeGuid}", request, cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<WorkerNodeResponse>>();

    public async Task<ResponseBase<WorkerNodeResponse>?> ReportHeartbeatAsync(Guid workerNodeGuid, ReportWorkerNodeHeartbeatRequest request, CancellationToken cancellationToken = default)
        => await PostAsync<ReportWorkerNodeHeartbeatRequest, ResponseBase<WorkerNodeResponse>>($"api/v1/worker-nodes/{workerNodeGuid}/heartbeat", request, cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<WorkerNodeResponse>>();

    public async Task<ResponseBase<bool>?> DeleteAsync(Guid workerNodeGuid, CancellationToken cancellationToken = default)
        => await DeleteAsync<ResponseBase<bool>>($"api/v1/worker-nodes/{workerNodeGuid}", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<bool>>();
}
