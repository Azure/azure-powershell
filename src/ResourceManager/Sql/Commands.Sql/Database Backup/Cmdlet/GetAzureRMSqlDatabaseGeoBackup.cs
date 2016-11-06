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

using Microsoft.Azure.Commands.Sql.Backup.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.Backup.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlDatabaseGeoBackup", SupportsShouldProcess = true)]
    public class GetAzureRMSqlDatabaseGeoBackup : AzureSqlDatabaseGeoBackupCmdletBase
    {
        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseGeoBackupModel> GetEntity()
        {
            ICollection<AzureSqlDatabaseGeoBackupModel> results;

            if (MyInvocation.BoundParameters.ContainsKey("DatabaseName"))
            {
                results = new List<AzureSqlDatabaseGeoBackupModel>();
                results.Add(ModelAdapter.GetGeoBackup(this.ResourceGroupName, this.ServerName, this.DatabaseName));
            }
            else
            {
                results = ModelAdapter.ListGeoBackups(this.ResourceGroupName, this.ServerName);
            }

            return results;
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseGeoBackupModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseGeoBackupModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseGeoBackupModel> PersistChanges(IEnumerable<AzureSqlDatabaseGeoBackupModel> entity)
        {
            return entity;
        }
    }
}
