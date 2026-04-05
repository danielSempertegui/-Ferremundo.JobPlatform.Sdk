using System.Net.Http.Json;
using System.Text.Json;
using Ferremundo.JobPlatform.Client.Abstractions;
using Ferremundo.JobPlatform.Contracts.Common;
using Ferremundo.JobPlatform.Contracts.JobDefinitions.Requests;
using Ferremundo.JobPlatform.Contracts.JobDefinitions.Responses;

namespace Ferremundo.JobPlatform.Client.Services;

public sealed class JobDefinitionClient : IJobDefinitionClient
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);
    private readonly HttpClient _httpClient;

    public JobDefinitionClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<ResponseBase<IReadOnlyCollection<JobDefinitionResponse>>?> GetAllAsync(CancellationToken cancellationToken = default)
        => SendAsync<IReadOnlyCollection<JobDefinitionResponse>>(HttpMethod.Get, "api/v1/job-definitions", cancellationToken: cancellationToken);

    public Task<ResponseBase<JobDefinitionResponse>?> GetByGuidAsync(Guid jobDefinitionGuid, CancellationToken cancellationToken = default)
        => SendAsync<JobDefinitionResponse>(HttpMethod.Get, $"api/v1/job-definitions/{jobDefinitionGuid}", cancellationToken: cancellationToken);

    public Task<ResponseBase<JobDefinitionResponse>?> CreateAsync(CreateJobDefinitionRequest request, CancellationToken cancellationToken = default)
        => SendAsync<JobDefinitionResponse>(HttpMethod.Post, "api/v1/job-definitions", request, cancellationToken);

    public Task<ResponseBase<JobDefinitionResponse>?> UpdateAsync(Guid jobDefinitionGuid, UpdateJobDefinitionRequest request, CancellationToken cancellationToken = default)
        => SendAsync<JobDefinitionResponse>(HttpMethod.Put, $"api/v1/job-definitions/{jobDefinitionGuid}", request, cancellationToken);

    public Task<ResponseBase<JobDefinitionResponse>?> ReportRuntimeStateAsync(Guid jobDefinitionGuid, ReportJobDefinitionRuntimeStateRequest request, CancellationToken cancellationToken = default)
        => SendAsync<JobDefinitionResponse>(HttpMethod.Post, $"api/v1/job-definitions/{jobDefinitionGuid}/runtime-state", request, cancellationToken);

    public Task<ResponseBase<bool>?> DeleteAsync(Guid jobDefinitionGuid, CancellationToken cancellationToken = default)
        => SendAsync<bool>(HttpMethod.Delete, $"api/v1/job-definitions/{jobDefinitionGuid}", cancellationToken: cancellationToken);

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
