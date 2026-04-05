using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.JobExecutionTraces.Requests;
using Ferremundo.JobPlatform.Contracts.JobExecutionTraces.Responses;

namespace Ferremundo.JobPlatform.Client.Abstractions;

public interface IJobExecutionTraceClient
{
    Task<ResponseBase<IReadOnlyCollection<JobExecutionTraceResponse>>?> GetByJobExecutionAsync(Guid jobExecutionGuid, CancellationToken cancellationToken = default);

    Task<ResponseBase<JobExecutionTraceResponse>?> GetByGuidAsync(Guid jobExecutionTraceGuid, CancellationToken cancellationToken = default);

    Task<ResponseBase<JobExecutionTraceResponse>?> CreateAsync(CreateJobExecutionTraceRequest request, CancellationToken cancellationToken = default);
}
