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
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlServerBackupArchivalVault",
        ConfirmImpact = ConfirmImpact.Medium)]
    public class SetAzureSqlServerBackupArchivalVault : AzureSqlServerBackupArchivalVaultCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the backup archival vault
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the backup archival vault.")]
        [ValidateNotNullOrEmpty]
        public string BackupArchivalVaultName { get; set; }

        /// <summary>
        /// Gets or sets the vault resource ID
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The vault resource ID.")]
        [ValidateNotNullOrEmpty]
        public string VaultResourceId { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlServerBackupArchivalVaultModel> GetEntity()
        {
            return new List<AzureSqlServerBackupArchivalVaultModel>() { 
                ModelAdapter.GetBackupArchivalVault(this.ResourceGroupName, this.ServerName, this.BackupArchivalVaultName) 
            };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlServerBackupArchivalVaultModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerBackupArchivalVaultModel> model)
        {
            List<Model.AzureSqlServerBackupArchivalVaultModel> newEntity = new List<AzureSqlServerBackupArchivalVaultModel>();
            newEntity.Add(new AzureSqlServerBackupArchivalVaultModel()
            {
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                BackupArchivalVaultID = VaultResourceId
            });
            return newEntity;
        }

        /// <summary>
        /// Update the database
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlServerBackupArchivalVaultModel> PersistChanges(IEnumerable<AzureSqlServerBackupArchivalVaultModel> entity)
        {
            return new List<AzureSqlServerBackupArchivalVaultModel>() {
                ModelAdapter.SetBackupArchivalVault(this.ResourceGroupName, this.ServerName, this.BackupArchivalVaultName, entity.First())
            };
        }
    }
}
