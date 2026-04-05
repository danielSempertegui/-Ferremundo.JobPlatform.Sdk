using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.JobDefinitions.Requests;
using Ferremundo.JobPlatform.Contracts.JobDefinitions.Responses;

namespace Ferremundo.JobPlatform.Client.Abstractions;

public interface IJobDefinitionClient
{
    Task<ResponseBase<IReadOnlyCollection<JobDefinitionResponse>>?> GetAllAsync(CancellationToken cancellationToken = default);

    Task<ResponseBase<JobDefinitionResponse>?> GetByGuidAsync(Guid jobDefinitionGuid, CancellationToken cancellationToken = default);

    Task<ResponseBase<JobDefinitionResponse>?> CreateAsync(CreateJobDefinitionRequest request, CancellationToken cancellationToken = default);

    Task<ResponseBase<JobDefinitionResponse>?> UpdateAsync(Guid jobDefinitionGuid, UpdateJobDefinitionRequest request, CancellationToken cancellationToken = default);

    Task<ResponseBase<bool>?> DeleteAsync(Guid jobDefinitionGuid, CancellationToken cancellationToken = default);
}
