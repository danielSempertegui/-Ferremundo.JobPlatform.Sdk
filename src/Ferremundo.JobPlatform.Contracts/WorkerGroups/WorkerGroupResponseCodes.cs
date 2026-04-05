namespace Ferremundo.JobPlatform.Contracts.WorkerGroups;

public static class WorkerGroupResponseCodes
{
    public const string WorkerGroupCreated = "WORKER_GROUP_CREATED";
    public const string WorkerGroupUpdated = "WORKER_GROUP_UPDATED";
    public const string WorkerGroupDeleted = "WORKER_GROUP_DELETED";
    public const string WorkerGroupNotFound = "WORKER_GROUP_NOT_FOUND";
    public const string WorkerGroupCodeAlreadyExists = "WORKER_GROUP_CODE_ALREADY_EXISTS";
    public const string WorkerGroupInvalidStatus = "WORKER_GROUP_INVALID_STATUS";
}
