using System.Text.Json;
using System.Net.Http.Json;
using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.WorkerGroups.Requests;
using Ferremundo.JobPlatform.Contracts.WorkerGroups.Responses;

namespace Ferremundo.JobPlatform.Client.Services;

public sealed class WorkerGroupClient : IWorkerGroupClient
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);
    private readonly HttpClient _httpClient;

    public WorkerGroupClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<ResponseBase<IReadOnlyCollection<WorkerGroupResponse>>?> GetAllAsync(CancellationToken cancellationToken = default)
        => SendAsync<IReadOnlyCollection<WorkerGroupResponse>>(HttpMethod.Get, "api/v1/worker-groups", cancellationToken: cancellationToken);

    public Task<ResponseBase<WorkerGroupResponse>?> GetByGuidAsync(Guid workerGroupGuid, CancellationToken cancellationToken = default)
        => SendAsync<WorkerGroupResponse>(HttpMethod.Get, $"api/v1/worker-groups/{workerGroupGuid}", cancellationToken: cancellationToken);

    public Task<ResponseBase<WorkerGroupResponse>?> CreateAsync(CreateWorkerGroupRequest request, CancellationToken cancellationToken = default)
        => SendAsync<WorkerGroupResponse>(HttpMethod.Post, "api/v1/worker-groups", request, cancellationToken);

    public Task<ResponseBase<WorkerGroupResponse>?> UpdateAsync(Guid workerGroupGuid, UpdateWorkerGroupRequest request, CancellationToken cancellationToken = default)
        => SendAsync<WorkerGroupResponse>(HttpMethod.Put, $"api/v1/worker-groups/{workerGroupGuid}", request, cancellationToken);

    public Task<ResponseBase<bool>?> DeleteAsync(Guid workerGroupGuid, CancellationToken cancellationToken = default)
        => SendAsync<bool>(HttpMethod.Delete, $"api/v1/worker-groups/{workerGroupGuid}", cancellationToken: cancellationToken);

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

