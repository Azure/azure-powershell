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

using System.Linq;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Backup.Model;
using Microsoft.Azure.Commands.Sql.Database.Model;

namespace Microsoft.Azure.Commands.Sql.Backup.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlDatabaseBackupLongTermRetentionPolicy",
        ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlDatabaseBackupArchivalPolicy : AzureSqlDatabaseBackupArchivalPolicyCmdletBase
    {
        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupArchivalPolicyModel> GetEntity()
        {
            ICollection<AzureSqlDatabaseBackupArchivalPolicyModel> results;

            if (MyInvocation.BoundParameters.ContainsKey("BackupLongTermRetentionPolicyName"))
            {
                results = new List<AzureSqlDatabaseBackupArchivalPolicyModel>();
                results.Add(ModelAdapter.GetDatabaseBackupArchivalPolicy(this.ResourceGroupName, this.ServerName, this.DatabaseName, this.BackupLongTermRetentionPolicyName));
            }
            else
            {
                results = ModelAdapter.ListDatabaseBackupArchivalPolicies(this.ResourceGroupName, this.ServerName, this.DatabaseName);
            }

            return results;
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupArchivalPolicyModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseBackupArchivalPolicyModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupArchivalPolicyModel> PersistChanges(IEnumerable<AzureSqlDatabaseBackupArchivalPolicyModel> entity)
        {
            return entity;
        }
    }
}
