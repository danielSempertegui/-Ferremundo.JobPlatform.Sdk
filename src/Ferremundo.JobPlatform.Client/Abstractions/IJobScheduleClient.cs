using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.JobSchedules.Requests;
using Ferremundo.JobPlatform.Contracts.JobSchedules.Responses;

namespace Ferremundo.JobPlatform.Client.Abstractions;

public interface IJobScheduleClient
{
    Task<ResponseBase<IReadOnlyCollection<JobScheduleResponse>>?> GetAllAsync(CancellationToken cancellationToken = default);

    Task<ResponseBase<JobScheduleResponse>?> GetByGuidAsync(Guid jobScheduleGuid, CancellationToken cancellationToken = default);

    Task<ResponseBase<JobScheduleResponse>?> CreateAsync(CreateJobScheduleRequest request, CancellationToken cancellationToken = default);

    Task<ResponseBase<JobScheduleResponse>?> UpdateAsync(Guid jobScheduleGuid, UpdateJobScheduleRequest request, CancellationToken cancellationToken = default);

    Task<ResponseBase<bool>?> DeleteAsync(Guid jobScheduleGuid, CancellationToken cancellationToken = default);
}
