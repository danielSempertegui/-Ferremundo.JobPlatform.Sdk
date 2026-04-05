using System.Net.Http.Json;
using System.Text.Json;
using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.JobExecutions.Requests;
using Ferremundo.JobPlatform.Contracts.JobExecutions.Responses;

namespace Ferremundo.JobPlatform.Client.Services;

public sealed class JobExecutionClient : IJobExecutionClient
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);
    private readonly HttpClient _httpClient;

    public JobExecutionClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<ResponseBase<IReadOnlyCollection<JobExecutionResponse>>?> GetAllAsync(CancellationToken cancellationToken = default)
        => SendAsync<IReadOnlyCollection<JobExecutionResponse>>(HttpMethod.Get, "api/v1/job-executions", cancellationToken: cancellationToken);

    public Task<ResponseBase<JobExecutionResponse>?> GetByGuidAsync(Guid jobExecutionGuid, CancellationToken cancellationToken = default)
        => SendAsync<JobExecutionResponse>(HttpMethod.Get, $"api/v1/job-executions/{jobExecutionGuid}", cancellationToken: cancellationToken);

    public Task<ResponseBase<IReadOnlyCollection<JobExecutionResponse>>?> GetByJobDefinitionAsync(Guid jobDefinitionGuid, CancellationToken cancellationToken = default)
        => SendAsync<IReadOnlyCollection<JobExecutionResponse>>(HttpMethod.Get, $"api/v1/job-executions/job-definitions/{jobDefinitionGuid}", cancellationToken: cancellationToken);

    public Task<ResponseBase<IReadOnlyCollection<JobExecutionResponse>>?> GetByWorkerNodeAsync(Guid workerNodeGuid, CancellationToken cancellationToken = default)
        => SendAsync<IReadOnlyCollection<JobExecutionResponse>>(HttpMethod.Get, $"api/v1/job-executions/worker-nodes/{workerNodeGuid}", cancellationToken: cancellationToken);

    public Task<ResponseBase<JobExecutionResponse>?> CreateAsync(CreateJobExecutionRequest request, CancellationToken cancellationToken = default)
        => SendAsync<JobExecutionResponse>(HttpMethod.Post, "api/v1/job-executions", request, cancellationToken);

    public Task<ResponseBase<JobExecutionResponse>?> CompleteAsync(Guid jobExecutionGuid, CompleteJobExecutionRequest request, CancellationToken cancellationToken = default)
        => SendAsync<JobExecutionResponse>(HttpMethod.Post, $"api/v1/job-executions/{jobExecutionGuid}/complete", request, cancellationToken);

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
