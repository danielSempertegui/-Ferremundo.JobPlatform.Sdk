using System.Net.Http.Json;
using System.Text.Json;
using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.JobExecutionTraces.Requests;
using Ferremundo.JobPlatform.Contracts.JobExecutionTraces.Responses;

namespace Ferremundo.JobPlatform.Client.Services;

public sealed class JobExecutionTraceClient : IJobExecutionTraceClient
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);
    private readonly HttpClient _httpClient;

    public JobExecutionTraceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<ResponseBase<IReadOnlyCollection<JobExecutionTraceResponse>>?> GetByJobExecutionAsync(Guid jobExecutionGuid, CancellationToken cancellationToken = default)
        => SendAsync<IReadOnlyCollection<JobExecutionTraceResponse>>(HttpMethod.Get, $"api/v1/job-execution-traces/job-executions/{jobExecutionGuid}", cancellationToken: cancellationToken);

    public Task<ResponseBase<JobExecutionTraceResponse>?> GetByGuidAsync(Guid jobExecutionTraceGuid, CancellationToken cancellationToken = default)
        => SendAsync<JobExecutionTraceResponse>(HttpMethod.Get, $"api/v1/job-execution-traces/{jobExecutionTraceGuid}", cancellationToken: cancellationToken);

    public Task<ResponseBase<JobExecutionTraceResponse>?> CreateAsync(CreateJobExecutionTraceRequest request, CancellationToken cancellationToken = default)
        => SendAsync<JobExecutionTraceResponse>(HttpMethod.Post, "api/v1/job-execution-traces", request, cancellationToken);

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
