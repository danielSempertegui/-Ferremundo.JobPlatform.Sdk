using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.JobExecutions.Requests;
using Ferremundo.JobPlatform.Contracts.JobExecutions.Responses;

namespace Ferremundo.JobPlatform.Client.Abstractions;

public interface IJobExecutionClient
{
    Task<ResponseBase<IReadOnlyCollection<JobExecutionResponse>>?> GetAllAsync(CancellationToken cancellationToken = default);

    Task<ResponseBase<JobExecutionResponse>?> GetByGuidAsync(Guid jobExecutionGuid, CancellationToken cancellationToken = default);

    Task<ResponseBase<IReadOnlyCollection<JobExecutionResponse>>?> GetByJobDefinitionAsync(Guid jobDefinitionGuid, CancellationToken cancellationToken = default);

    Task<ResponseBase<IReadOnlyCollection<JobExecutionResponse>>?> GetByWorkerNodeAsync(Guid workerNodeGuid, CancellationToken cancellationToken = default);

    Task<ResponseBase<JobExecutionResponse>?> CreateAsync(CreateJobExecutionRequest request, CancellationToken cancellationToken = default);

    Task<ResponseBase<JobExecutionResponse>?> CompleteAsync(Guid jobExecutionGuid, CompleteJobExecutionRequest request, CancellationToken cancellationToken = default);
}
