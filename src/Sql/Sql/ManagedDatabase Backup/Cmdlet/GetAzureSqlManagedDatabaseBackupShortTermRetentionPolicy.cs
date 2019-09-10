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
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using System.Management.Automation;
using System.Collections;
using System.Collections.Generic;
using System;


namespace Microsoft.Azure.Commands.Sql.ManagedDatabaseBackup.Cmdlet
{
    /// <summary>
    /// Cmdlet to create a new Azure Sql Managed Database
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceDatabaseBackupShortTermRetentionPolicy",
        DefaultParameterSetName = PolicyByResourceServerDatabaseSet),
        OutputType(typeof(AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel))]
    public class GetAzureSqlManagedDatabaseBackupShortTermRetentionPolicy : AzureSqlManagedDatabaseBackupCmdletBase<IEnumerable<AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel>>
    {
        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }
        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel> GetEntity()
        {
            ICollection<AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel> results;

            if (this.DeletionDate.HasValue)
            {
                results = ModelAdapter.ListManagedBackupShortTermRetentionPoliciesDropped(this.ResourceGroupName, this.InstanceName, this.DatabaseName, this.DeletionDate.Value);
            }
            else
            {
                results = ModelAdapter.ListManagedBackupShortTermRetentionPolicies(this.ResourceGroupName, this.InstanceName, this.DatabaseName);
            }

            return results;
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel> model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to managed instance
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel> PersistChanges(IEnumerable<AzureSqlManagedDatabaseBackupShortTermRetentionPolicyModel> entity)
        {
            return entity;
        }
    }
}
