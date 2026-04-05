using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.JobCommands.Requests;
using Ferremundo.JobPlatform.Contracts.JobCommands.Responses;

namespace Ferremundo.JobPlatform.Client.Abstractions;

public interface IJobCommandClient
{
    Task<ResponseBase<IReadOnlyCollection<JobCommandResponse>>?> GetAllAsync(CancellationToken cancellationToken = default);

    Task<ResponseBase<JobCommandResponse>?> GetByGuidAsync(Guid jobCommandGuid, CancellationToken cancellationToken = default);

    Task<ResponseBase<IReadOnlyCollection<JobCommandResponse>>?> GetPendingByWorkerNodeAsync(Guid workerNodeGuid, CancellationToken cancellationToken = default);

    Task<ResponseBase<JobCommandResponse>?> CreateRunNowAsync(CreateRunNowJobCommandRequest request, CancellationToken cancellationToken = default);

    Task<ResponseBase<JobCommandResponse>?> UpdateStatusAsync(Guid jobCommandGuid, UpdateJobCommandStatusRequest request, CancellationToken cancellationToken = default);
}
