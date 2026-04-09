using Ferremundo.Integrations.Rest.Abstractions.Correlation;
using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Client.Authentication;
using Ferremundo.JobPlatform.Client.Configuration;
using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.JobSchedules.Requests;
using Ferremundo.JobPlatform.Contracts.JobSchedules.Responses;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Ferremundo.JobPlatform.Client.Services;

public sealed class JobScheduleClient : JobPlatformClientBase, IJobScheduleClient
{
    public JobScheduleClient(
        HttpClient httpClient,
        IOptions<JobPlatformClientOptions> options,
        IJobPlatformClientAuthenticationStrategy authenticationStrategy,
        IExternalCorrelationProvider correlationProvider,
        ILogger<JobScheduleClient> logger)
        : base(httpClient, options, authenticationStrategy, correlationProvider, logger)
    {
    }

    public async Task<ResponseBase<IReadOnlyCollection<JobScheduleResponse>>?> GetAllAsync(CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<IReadOnlyCollection<JobScheduleResponse>>>("api/v1/job-schedules", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<IReadOnlyCollection<JobScheduleResponse>>>();

    public async Task<ResponseBase<JobScheduleResponse>?> GetByGuidAsync(Guid jobScheduleGuid, CancellationToken cancellationToken = default)
        => await GetAsync<ResponseBase<JobScheduleResponse>>($"api/v1/job-schedules/{jobScheduleGuid}", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<JobScheduleResponse>>();

    public async Task<ResponseBase<JobScheduleResponse>?> CreateAsync(CreateJobScheduleRequest request, CancellationToken cancellationToken = default)
        => await PostAsync<CreateJobScheduleRequest, ResponseBase<JobScheduleResponse>>("api/v1/job-schedules", request, cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<JobScheduleResponse>>();

    public async Task<ResponseBase<JobScheduleResponse>?> UpdateAsync(Guid jobScheduleGuid, UpdateJobScheduleRequest request, CancellationToken cancellationToken = default)
        => await PutAsync<UpdateJobScheduleRequest, ResponseBase<JobScheduleResponse>>($"api/v1/job-schedules/{jobScheduleGuid}", request, cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<JobScheduleResponse>>();

    public async Task<ResponseBase<bool>?> DeleteAsync(Guid jobScheduleGuid, CancellationToken cancellationToken = default)
        => await DeleteAsync<ResponseBase<bool>>($"api/v1/job-schedules/{jobScheduleGuid}", cancellationToken)
           ?? throw CreateEmptyResponseException<ResponseBase<bool>>();
}
