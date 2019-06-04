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

using Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Cmdlet
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDeletedInstanceDatabaseBackup",
        DefaultParameterSetName = DeletedDatabaseList)]
    [OutputType(typeof(AzureSqlDeletedManagedDatabaseBackupModel))]
    public class GetAzureSqlDeletedManagedDatabaseBackup : AzureSqlDeletedManagedDatabaseBackupCmdletBase
    {
        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDeletedManagedDatabaseBackupModel> GetEntity()
        {
            ICollection<AzureSqlDeletedManagedDatabaseBackupModel> results;

            if (MyInvocation.BoundParameters.ContainsKey("DatabaseName"))
            {
                if (MyInvocation.BoundParameters.ContainsKey("DeletionDate"))
                {
                    results = new List<AzureSqlDeletedManagedDatabaseBackupModel>();
                    // The server expects a deleted database entity ID that consists of the database name and deletion time as a windows file time separated by a comma.
                    results.Add(ModelAdapter.GetDeletedDatabaseBackup(this.ResourceGroupName, this.InstanceName, this.DatabaseName + "," + this.DeletionDate.Value.ToFileTimeUtc()));
                }
                else
                {
                    results = ModelAdapter.ListDeletedDatabaseBackups(this.ResourceGroupName, this.InstanceName).Where(backup => backup.Name == DatabaseName).ToList();
                }
            }
            else
            {
                results = ModelAdapter.ListDeletedDatabaseBackups(this.ResourceGroupName, this.InstanceName);
            }

            return results;
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDeletedManagedDatabaseBackupModel> ApplyUserInputToModel(IEnumerable<AzureSqlDeletedManagedDatabaseBackupModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDeletedManagedDatabaseBackupModel> PersistChanges(IEnumerable<AzureSqlDeletedManagedDatabaseBackupModel> entity)
        {
            return entity;
        }
    }
}
