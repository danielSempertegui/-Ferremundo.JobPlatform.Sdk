using System.ComponentModel.DataAnnotations;
using Ferremundo.JobPlatform.Contracts.Common.Enums;

namespace Ferremundo.JobPlatform.Contracts.JobCommands.Requests;

public sealed class UpdateJobCommandStatusRequest
{
    public Guid? WorkerNodeGuid { get; set; }

    [Required]
    [EnumDataType(typeof(JobCommandStatus))]
    public JobCommandStatus Status { get; set; }

    [MaxLength(1000)]
    public string? ResultMessage { get; set; }
}
