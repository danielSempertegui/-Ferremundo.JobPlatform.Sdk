using System.ComponentModel.DataAnnotations;

namespace Ferremundo.JobPlatform.Contracts.JobDefinitions.Requests;

public sealed class ReportJobDefinitionRuntimeStateRequest
{
    public DateTime? LastKnownRunUtc { get; set; }

    public DateTime? LastKnownNextRunUtc { get; set; }
}
