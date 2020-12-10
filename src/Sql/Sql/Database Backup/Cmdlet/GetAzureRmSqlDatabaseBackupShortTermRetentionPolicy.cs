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
using Microsoft.Azure.Commands.Sql.Backup.Model;

namespace Microsoft.Azure.Commands.Sql.Backup.Cmdlet
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseBackupShortTermRetentionPolicy",
        DefaultParameterSetName = PolicyByResourceServerDatabaseSet),
    OutputType(typeof(AzureSqlDatabaseBackupShortTermRetentionPolicyModel))]
    public class GetAzureRmSqlDatabaseBackupShortTermRetentionPolicy : AzureSqlDatabaseBackupShortTermRetentionPolicyCmdletBase
    {
        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> GetEntity()
        {
            ICollection<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> results = new List<AzureSqlDatabaseBackupShortTermRetentionPolicyModel>();

            results.Add(ModelAdapter.GetDatabaseBackupShortTermRetentionPolicy(
                ResourceGroupName,
                ServerName,
                DatabaseName));

            return results;
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> ApplyUserInputToModel(
            IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> PersistChanges(
            IEnumerable<AzureSqlDatabaseBackupShortTermRetentionPolicyModel> entity)
        {
            return entity;
        }
    }
}
