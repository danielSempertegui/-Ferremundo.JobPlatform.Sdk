using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.WorkerGroups.Requests;
using Ferremundo.JobPlatform.Contracts.WorkerGroups.Responses;

namespace Ferremundo.JobPlatform.Client.Abstractions;

public interface IWorkerGroupClient
{
    Task<ResponseBase<IReadOnlyCollection<WorkerGroupResponse>>?> GetAllAsync(CancellationToken cancellationToken = default);

    Task<ResponseBase<WorkerGroupResponse>?> GetByGuidAsync(Guid workerGroupGuid, CancellationToken cancellationToken = default);

    Task<ResponseBase<WorkerGroupResponse>?> CreateAsync(CreateWorkerGroupRequest request, CancellationToken cancellationToken = default);

    Task<ResponseBase<WorkerGroupResponse>?> UpdateAsync(Guid workerGroupGuid, UpdateWorkerGroupRequest request, CancellationToken cancellationToken = default);

    Task<ResponseBase<bool>?> DeleteAsync(Guid workerGroupGuid, CancellationToken cancellationToken = default);
}
