using Ferremundo.Integrations.Rest.Abstractions.Correlation;
using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Client.Authentication;
using Ferremundo.JobPlatform.Client.Configuration;
using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.JobExecutionTraces.Requests;
using Ferremundo.JobPlatform.Contracts.JobExecutionTraces.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ferremundo.JobPlatform.Client.Services;

public sealed class JobExecutionTraceClient : JobPlatformClientBase, IJobExecutionTraceClient
{
    public JobExecutionTraceClient(
        HttpClient httpClient,
        IOptions<JobPlatformClientOptions> options,
        IJobPlatformClientAuthenticationStrategy authenticationStrategy,
        IExternalCorrelationProvider correlationProvider,
        ILogger<JobExecutionTraceClient> logger)
        : base(httpClient, options, authenticationStrategy, correlationProvider, logger)
    {
    }

    public async Task<ResponseBase<IReadOnlyCollection<JobExecutionTraceResponse>>?> GetByJobExecutionAsync(Guid jobExecutionGuid, CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<IReadOnlyCollection<JobExecutionTraceResponse>>>($"api/v1/job-execution-traces/job-executions/{jobExecutionGuid}", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<IReadOnlyCollection<JobExecutionTraceResponse>>>();

    public async Task<ResponseBase<JobExecutionTraceResponse>?> GetByGuidAsync(Guid jobExecutionTraceGuid, CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<JobExecutionTraceResponse>>($"api/v1/job-execution-traces/{jobExecutionTraceGuid}", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<JobExecutionTraceResponse>>();

    public async Task<ResponseBase<JobExecutionTraceResponse>?> CreateAsync(CreateJobExecutionTraceRequest request, CancellationToken cancellationToken = default)
        => await PostAsync<CreateJobExecutionTraceRequest, ResponseBase<JobExecutionTraceResponse>>("api/v1/job-execution-traces", request, cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<JobExecutionTraceResponse>>();
}
