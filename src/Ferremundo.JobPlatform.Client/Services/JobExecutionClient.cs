using Ferremundo.Integrations.Rest.Abstractions.Correlation;
using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Client.Authentication;
using Ferremundo.JobPlatform.Client.Configuration;
using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.JobExecutions.Requests;
using Ferremundo.JobPlatform.Contracts.JobExecutions.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ferremundo.JobPlatform.Client.Services;

public sealed class JobExecutionClient : JobPlatformClientBase, IJobExecutionClient
{
    public JobExecutionClient(
        HttpClient httpClient,
        IOptions<JobPlatformClientOptions> options,
        IJobPlatformClientAuthenticationStrategy authenticationStrategy,
        IExternalCorrelationProvider correlationProvider,
        ILogger<JobExecutionClient> logger)
        : base(httpClient, options, authenticationStrategy, correlationProvider, logger)
    {
    }

    public async Task<ResponseBase<IReadOnlyCollection<JobExecutionResponse>>?> GetAllAsync(CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<IReadOnlyCollection<JobExecutionResponse>>>("api/v1/job-executions", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<IReadOnlyCollection<JobExecutionResponse>>>();

    public async Task<ResponseBase<JobExecutionResponse>?> GetByGuidAsync(Guid jobExecutionGuid, CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<JobExecutionResponse>>($"api/v1/job-executions/{jobExecutionGuid}", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<JobExecutionResponse>>();

    public async Task<ResponseBase<IReadOnlyCollection<JobExecutionResponse>>?> GetByJobDefinitionAsync(Guid jobDefinitionGuid, CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<IReadOnlyCollection<JobExecutionResponse>>>($"api/v1/job-executions/job-definitions/{jobDefinitionGuid}", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<IReadOnlyCollection<JobExecutionResponse>>>();

    public async Task<ResponseBase<IReadOnlyCollection<JobExecutionResponse>>?> GetByWorkerNodeAsync(Guid workerNodeGuid, CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<IReadOnlyCollection<JobExecutionResponse>>>($"api/v1/job-executions/worker-nodes/{workerNodeGuid}", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<IReadOnlyCollection<JobExecutionResponse>>>();

    public async Task<ResponseBase<JobExecutionResponse>?> CreateAsync(CreateJobExecutionRequest request, CancellationToken cancellationToken = default)
        => await PostAsync<CreateJobExecutionRequest, ResponseBase<JobExecutionResponse>>("api/v1/job-executions", request, cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<JobExecutionResponse>>();

    public async Task<ResponseBase<JobExecutionResponse>?> CompleteAsync(Guid jobExecutionGuid, CompleteJobExecutionRequest request, CancellationToken cancellationToken = default)
        => await PostAsync<CompleteJobExecutionRequest, ResponseBase<JobExecutionResponse>>($"api/v1/job-executions/{jobExecutionGuid}/complete", request, cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<JobExecutionResponse>>();
}
