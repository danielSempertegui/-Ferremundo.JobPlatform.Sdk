using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.WorkerNodes.Requests;
using Ferremundo.JobPlatform.Contracts.WorkerNodes.Responses;

namespace Ferremundo.JobPlatform.Client.Abstractions;

public interface IWorkerNodeClient
{
    Task<ResponseBase<IReadOnlyCollection<WorkerNodeResponse>>?> GetAllAsync(CancellationToken cancellationToken = default);

    Task<ResponseBase<WorkerNodeResponse>?> GetByGuidAsync(Guid workerNodeGuid, CancellationToken cancellationToken = default);

    Task<ResponseBase<WorkerNodeResponse>?> CreateAsync(CreateWorkerNodeRequest request, CancellationToken cancellationToken = default);

    Task<ResponseBase<WorkerNodeResponse>?> UpdateAsync(Guid workerNodeGuid, UpdateWorkerNodeRequest request, CancellationToken cancellationToken = default);

    Task<ResponseBase<bool>?> DeleteAsync(Guid workerNodeGuid, CancellationToken cancellationToken = default);
}
