using Ferremundo.Integrations.Rest.Abstractions.Correlation;
using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Client.Authentication;
using Ferremundo.JobPlatform.Client.Configuration;
using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.JobDefinitions.Requests;
using Ferremundo.JobPlatform.Contracts.JobDefinitions.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ferremundo.JobPlatform.Client.Services;

public sealed class JobDefinitionClient : JobPlatformClientBase, IJobDefinitionClient
{
    public JobDefinitionClient(
        HttpClient httpClient,
        IOptions<JobPlatformClientOptions> options,
        IJobPlatformClientAuthenticationStrategy authenticationStrategy,
        IExternalCorrelationProvider correlationProvider,
        ILogger<JobDefinitionClient> logger)
        : base(httpClient, options, authenticationStrategy, correlationProvider, logger)
    {
    }

    public async Task<ResponseBase<IReadOnlyCollection<JobDefinitionResponse>>?> GetAllAsync(CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<IReadOnlyCollection<JobDefinitionResponse>>>("api/v1/job-definitions", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<IReadOnlyCollection<JobDefinitionResponse>>>();

    public async Task<ResponseBase<JobDefinitionResponse>?> GetByGuidAsync(Guid jobDefinitionGuid, CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<JobDefinitionResponse>>($"api/v1/job-definitions/{jobDefinitionGuid}", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<JobDefinitionResponse>>();

    public async Task<ResponseBase<JobDefinitionResponse>?> CreateAsync(CreateJobDefinitionRequest request, CancellationToken cancellationToken = default)
        => await PostAsync<CreateJobDefinitionRequest, ResponseBase<JobDefinitionResponse>>("api/v1/job-definitions", request, cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<JobDefinitionResponse>>();

    public async Task<ResponseBase<JobDefinitionResponse>?> UpdateAsync(Guid jobDefinitionGuid, UpdateJobDefinitionRequest request, CancellationToken cancellationToken = default)
        => await PutAsync<UpdateJobDefinitionRequest, ResponseBase<JobDefinitionResponse>>($"api/v1/job-definitions/{jobDefinitionGuid}", request, cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<JobDefinitionResponse>>();

    public async Task<ResponseBase<JobDefinitionResponse>?> ReportRuntimeStateAsync(Guid jobDefinitionGuid, ReportJobDefinitionRuntimeStateRequest request, CancellationToken cancellationToken = default)
        => await PostAsync<ReportJobDefinitionRuntimeStateRequest, ResponseBase<JobDefinitionResponse>>($"api/v1/job-definitions/{jobDefinitionGuid}/runtime-state", request, cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<JobDefinitionResponse>>();

    public async Task<ResponseBase<bool>?> DeleteAsync(Guid jobDefinitionGuid, CancellationToken cancellationToken = default)
        => await DeleteAsync<ResponseBase<bool>>($"api/v1/job-definitions/{jobDefinitionGuid}", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<bool>>();
}
