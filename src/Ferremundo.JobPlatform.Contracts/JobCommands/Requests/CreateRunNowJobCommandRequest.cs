using System.ComponentModel.DataAnnotations;

namespace Ferremundo.JobPlatform.Contracts.JobCommands.Requests;

public sealed class CreateRunNowJobCommandRequest
{
    [Required]
    public Guid JobDefinitionGuid { get; set; }

    public Guid? WorkerNodeGuid { get; set; }
}
