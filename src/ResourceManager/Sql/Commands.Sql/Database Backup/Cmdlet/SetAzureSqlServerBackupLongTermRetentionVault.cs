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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.Backup.Model;
using Microsoft.Azure.Commands.Sql.Database.Model;

namespace Microsoft.Azure.Commands.Sql.Backup.Cmdlet
{
    /// <summary>
    /// Cmdlet to create or update a new Azure Sql Server backup archival vault
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlServerBackupLongTermRetentionVault",
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Low)]
    public class SetAzureSqlServerBackupLongTermRetentionVault : AzureSqlServerBackupLongTermRetentionVaultCmdletBase
    {
        /// <summary>
        /// Gets or sets the vault resource ID
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Resource ID of the Backup Long Term Retention Vault.")]
        [ValidateNotNullOrEmpty]
        [Alias("Id")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlServerBackupLongTermRetentionVaultModel> GetEntity()
        {
            return new List<AzureSqlServerBackupLongTermRetentionVaultModel>() { 
                ModelAdapter.GetBackupLongTermRetentionVault(this.ResourceGroupName, this.ServerName) 
            };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlServerBackupLongTermRetentionVaultModel> ApplyUserInputToModel(
            IEnumerable<AzureSqlServerBackupLongTermRetentionVaultModel> model)
        {
            List<Model.AzureSqlServerBackupLongTermRetentionVaultModel> newEntity = 
                new List<AzureSqlServerBackupLongTermRetentionVaultModel>();
            newEntity.Add(new AzureSqlServerBackupLongTermRetentionVaultModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                RecoveryServicesVaultResourceId = ResourceId,
                Location = model.FirstOrDefault().Location,
            });
            return newEntity;
        }

        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlServerBackupLongTermRetentionVaultModel> PersistChanges(
            IEnumerable<AzureSqlServerBackupLongTermRetentionVaultModel> entity)
        {
            if (ShouldProcess(ServerName))
            {
                return new List<AzureSqlServerBackupLongTermRetentionVaultModel>() {
                    ModelAdapter.SetBackupLongTermRetentionVault(this.ResourceGroupName, this.ServerName, entity.First())
                };
            }
            else
            {
                return null;
            }
        }
    }
}
