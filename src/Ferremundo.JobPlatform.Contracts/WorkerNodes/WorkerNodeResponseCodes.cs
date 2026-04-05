namespace Ferremundo.JobPlatform.Contracts.WorkerNodes;

public static class WorkerNodeResponseCodes
{
    public const string WorkerNodeCreated = "WORKER_NODE_CREATED";
    public const string WorkerNodeUpdated = "WORKER_NODE_UPDATED";
    public const string WorkerNodeDeleted = "WORKER_NODE_DELETED";
    public const string WorkerNodeNotFound = "WORKER_NODE_NOT_FOUND";
    public const string WorkerNodeInvalidStatus = "WORKER_NODE_INVALID_STATUS";
    public const string WorkerNodeNameAlreadyExists = "WORKER_NODE_NAME_ALREADY_EXISTS";
    public const string WorkerNodeWorkerGroupNotFound = "WORKER_NODE_WORKER_GROUP_NOT_FOUND";
}
