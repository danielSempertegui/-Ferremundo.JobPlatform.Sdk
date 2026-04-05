using System.Net.Http.Json;
using System.Text.Json;
using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.WorkerNodes.Requests;
using Ferremundo.JobPlatform.Contracts.WorkerNodes.Responses;

namespace Ferremundo.JobPlatform.Client.Services;

public sealed class WorkerNodeClient : IWorkerNodeClient
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);
    private readonly HttpClient _httpClient;

    public WorkerNodeClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<ResponseBase<IReadOnlyCollection<WorkerNodeResponse>>?> GetAllAsync(CancellationToken cancellationToken = default)
        => SendAsync<IReadOnlyCollection<WorkerNodeResponse>>(HttpMethod.Get, "api/v1/worker-nodes", cancellationToken: cancellationToken);

    public Task<ResponseBase<WorkerNodeResponse>?> GetByGuidAsync(Guid workerNodeGuid, CancellationToken cancellationToken = default)
        => SendAsync<WorkerNodeResponse>(HttpMethod.Get, $"api/v1/worker-nodes/{workerNodeGuid}", cancellationToken: cancellationToken);

    public Task<ResponseBase<WorkerNodeResponse>?> CreateAsync(CreateWorkerNodeRequest request, CancellationToken cancellationToken = default)
        => SendAsync<WorkerNodeResponse>(HttpMethod.Post, "api/v1/worker-nodes", request, cancellationToken);

    public Task<ResponseBase<WorkerNodeResponse>?> UpdateAsync(Guid workerNodeGuid, UpdateWorkerNodeRequest request, CancellationToken cancellationToken = default)
        => SendAsync<WorkerNodeResponse>(HttpMethod.Put, $"api/v1/worker-nodes/{workerNodeGuid}", request, cancellationToken);

    public Task<ResponseBase<bool>?> DeleteAsync(Guid workerNodeGuid, CancellationToken cancellationToken = default)
        => SendAsync<bool>(HttpMethod.Delete, $"api/v1/worker-nodes/{workerNodeGuid}", cancellationToken: cancellationToken);

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
