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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.DataSync.Model;

namespace Microsoft.Azure.Commands.Sql.DataSync.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlSyncSchema",
        ConfirmImpact = ConfirmImpact.None), OutputType(typeof(AzureSqlSyncFullSchemaModel))]
    public class GetAzureSqlSyncSchema : AzureSqlSyncSchemaCmdletBase
    {
        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlSyncFullSchemaModel> GetEntity()
        {
            return new List<AzureSqlSyncFullSchemaModel>() { 
                MyInvocation.BoundParameters.ContainsKey("SyncMemberName") 
                    ? ModelAdapter.GetSyncMemberSchema(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.SyncGroupName, this.SyncMemberName)
                        : ModelAdapter.GetSyncHubSchema(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.SyncGroupName) 
            };
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlSyncFullSchemaModel> PersistChanges(IEnumerable<AzureSqlSyncFullSchemaModel> entity)
        {
            return entity;
        }
    }
}
