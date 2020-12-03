namespace Microsoft.Azure.Commands.Synapse.Common
{
    public static class ResourceTypes
    {
        public const string Workspace = "Microsoft.Synapse/workspaces";
        public const string SparkPool = "Microsoft.Synapse/workspaces/bigDataPools";
        public const string SqlPool = "Microsoft.Synapse/workspaces/sqlPools";
        public const string RecoverableSqlPool = "Microsoft.Synapse/workspaces/recoverableSqlPools";
        public const string StorageAccount = "Microsoft.Storage/storageAccounts";
        public const string SqlDatabase = "Microsoft.Sql/servers/databases";
        public const string RecoverablSqlDatabase = "Microsoft.Sql/servers/recoverableDatabases";
        public const string IntegrationRuntime = "Microsoft.Synapse/workspaces/integrationruntimes";
    }
}
