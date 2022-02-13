// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Synapse.Common
{
    public static class ResourceTypes
    {
        public const string Workspace = "Microsoft.Synapse/workspaces";
        public const string SparkPool = "Microsoft.Synapse/workspaces/bigDataPools";
        public const string SqlPool = "Microsoft.Synapse/workspaces/sqlPools";
        public const string SqlPoolRestorePoint = "Microsoft.Synapse/workspaces/sqlPools/sqlPoolRestorePoints"; 
        public const string RecoverableSqlPool = "Microsoft.Synapse/workspaces/recoverableSqlPools";
        public const string StorageAccount = "Microsoft.Storage/storageAccounts";
        public const string SqlDatabase = "Microsoft.Sql/servers/databases";
        public const string RecoverablSqlDatabase = "Microsoft.Sql/servers/recoverableDatabases";
        public const string IntegrationRuntime = "Microsoft.Synapse/workspaces/integrationruntimes";
    }
}
