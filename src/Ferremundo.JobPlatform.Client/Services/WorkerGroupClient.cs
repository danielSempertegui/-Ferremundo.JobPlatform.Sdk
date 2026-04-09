using Ferremundo.Integrations.Rest.Abstractions.Correlation;
using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Client.Authentication;
using Ferremundo.JobPlatform.Client.Configuration;
using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.WorkerGroups.Requests;
using Ferremundo.JobPlatform.Contracts.WorkerGroups.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ferremundo.JobPlatform.Client.Services;

public sealed class WorkerGroupClient : JobPlatformClientBase, IWorkerGroupClient
{
    public WorkerGroupClient(
        HttpClient httpClient,
        IOptions<JobPlatformClientOptions> options,
        IJobPlatformClientAuthenticationStrategy authenticationStrategy,
        IExternalCorrelationProvider correlationProvider,
        ILogger<WorkerGroupClient> logger)
        : base(httpClient, options, authenticationStrategy, correlationProvider, logger)
    {
    }

    public async Task<ResponseBase<IReadOnlyCollection<WorkerGroupResponse>>?> GetAllAsync(CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<IReadOnlyCollection<WorkerGroupResponse>>>("api/v1/worker-groups", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<IReadOnlyCollection<WorkerGroupResponse>>>();

    public async Task<ResponseBase<WorkerGroupResponse>?> GetByGuidAsync(Guid workerGroupGuid, CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<WorkerGroupResponse>>($"api/v1/worker-groups/{workerGroupGuid}", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<WorkerGroupResponse>>();

    public async Task<ResponseBase<WorkerGroupResponse>?> CreateAsync(CreateWorkerGroupRequest request, CancellationToken cancellationToken = default)
        => await PostAsync<CreateWorkerGroupRequest, ResponseBase<WorkerGroupResponse>>("api/v1/worker-groups", request, cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<WorkerGroupResponse>>();

    public async Task<ResponseBase<WorkerGroupResponse>?> UpdateAsync(Guid workerGroupGuid, UpdateWorkerGroupRequest request, CancellationToken cancellationToken = default)
        => await PutAsync<UpdateWorkerGroupRequest, ResponseBase<WorkerGroupResponse>>($"api/v1/worker-groups/{workerGroupGuid}", request, cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<WorkerGroupResponse>>();

    public async Task<ResponseBase<bool>?> DeleteAsync(Guid workerGroupGuid, CancellationToken cancellationToken = default)
        => await DeleteAsync<ResponseBase<bool>>($"api/v1/worker-groups/{workerGroupGuid}", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<bool>>();
}
