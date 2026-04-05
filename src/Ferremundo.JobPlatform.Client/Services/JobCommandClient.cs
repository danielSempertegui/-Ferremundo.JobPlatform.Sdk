using System.Net.Http.Json;
using System.Text.Json;
using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.JobCommands.Requests;
using Ferremundo.JobPlatform.Contracts.JobCommands.Responses;

namespace Ferremundo.JobPlatform.Client.Services;

public sealed class JobCommandClient : IJobCommandClient
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);
    private readonly HttpClient _httpClient;

    public JobCommandClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<ResponseBase<IReadOnlyCollection<JobCommandResponse>>?> GetAllAsync(CancellationToken cancellationToken = default)
        => SendAsync<IReadOnlyCollection<JobCommandResponse>>(HttpMethod.Get, "api/v1/job-commands", cancellationToken: cancellationToken);

    public Task<ResponseBase<JobCommandResponse>?> GetByGuidAsync(Guid jobCommandGuid, CancellationToken cancellationToken = default)
        => SendAsync<JobCommandResponse>(HttpMethod.Get, $"api/v1/job-commands/{jobCommandGuid}", cancellationToken: cancellationToken);

    public Task<ResponseBase<IReadOnlyCollection<JobCommandResponse>>?> GetPendingByWorkerNodeAsync(Guid workerNodeGuid, CancellationToken cancellationToken = default)
        => SendAsync<IReadOnlyCollection<JobCommandResponse>>(HttpMethod.Get, $"api/v1/job-commands/pending/worker-nodes/{workerNodeGuid}", cancellationToken: cancellationToken);

    public Task<ResponseBase<JobCommandResponse>?> CreateRunNowAsync(CreateRunNowJobCommandRequest request, CancellationToken cancellationToken = default)
        => SendAsync<JobCommandResponse>(HttpMethod.Post, "api/v1/job-commands/run-now", request, cancellationToken);

    public Task<ResponseBase<JobCommandResponse>?> UpdateStatusAsync(Guid jobCommandGuid, UpdateJobCommandStatusRequest request, CancellationToken cancellationToken = default)
        => SendAsync<JobCommandResponse>(HttpMethod.Post, $"api/v1/job-commands/{jobCommandGuid}/status", request, cancellationToken);

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
