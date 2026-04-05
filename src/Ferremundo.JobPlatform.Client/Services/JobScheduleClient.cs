using System.Net.Http.Json;
using System.Text.Json;
using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.JobSchedules.Requests;
using Ferremundo.JobPlatform.Contracts.JobSchedules.Responses;

namespace Ferremundo.JobPlatform.Client.Services;

public sealed class JobScheduleClient : IJobScheduleClient
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);
    private readonly HttpClient _httpClient;

    public JobScheduleClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<ResponseBase<IReadOnlyCollection<JobScheduleResponse>>?> GetAllAsync(CancellationToken cancellationToken = default)
        => SendAsync<IReadOnlyCollection<JobScheduleResponse>>(HttpMethod.Get, "api/v1/job-schedules", cancellationToken: cancellationToken);

    public Task<ResponseBase<JobScheduleResponse>?> GetByGuidAsync(Guid jobScheduleGuid, CancellationToken cancellationToken = default)
        => SendAsync<JobScheduleResponse>(HttpMethod.Get, $"api/v1/job-schedules/{jobScheduleGuid}", cancellationToken: cancellationToken);

    public Task<ResponseBase<JobScheduleResponse>?> CreateAsync(CreateJobScheduleRequest request, CancellationToken cancellationToken = default)
        => SendAsync<JobScheduleResponse>(HttpMethod.Post, "api/v1/job-schedules", request, cancellationToken);

    public Task<ResponseBase<JobScheduleResponse>?> UpdateAsync(Guid jobScheduleGuid, UpdateJobScheduleRequest request, CancellationToken cancellationToken = default)
        => SendAsync<JobScheduleResponse>(HttpMethod.Put, $"api/v1/job-schedules/{jobScheduleGuid}", request, cancellationToken);

    public Task<ResponseBase<bool>?> DeleteAsync(Guid jobScheduleGuid, CancellationToken cancellationToken = default)
        => SendAsync<bool>(HttpMethod.Delete, $"api/v1/job-schedules/{jobScheduleGuid}", cancellationToken: cancellationToken);

    private async Task<ResponseBase<T>?> SendAsync<T>(
        HttpMethod method,
        string requestUri,
        object? payload = null,
        CancellationToken cancellationToken = default)
    {
        using var request = new HttpRequestMessage(method, requestUri);

        if (payload is not null)
        {
            request.Content = JsonContent.Create(payload, options: SerializerOptions);
        }

        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var content = await response.Content.ReadFromJsonAsync<ResponseBase<T>>(SerializerOptions, cancellationToken);

        if (content is null)
        {
            response.EnsureSuccessStatusCode();
        }

        return content;
    }
}
