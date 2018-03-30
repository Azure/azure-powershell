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
using System;

namespace Microsoft.Azure.Commands.Sql.Backup.Cmdlet
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlDatabaseRestorePoint", SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlDatabaseRestorePointModel))]
    public class RemoveAzureSqlDatabaseRestorePoint : AzureSqlDatabaseRestorePointCmdletBase
    {
        /// <summary>
        /// Gets or sets the restore point create time.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The restore point create time.")]
        [ValidateNotNullOrEmpty]
        public DateTime RestorePointCreationDate { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseRestorePointModel> GetEntity()
        {
            // Get Api has no support for single value
            return null;
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseRestorePointModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseRestorePointModel> model)
        {
            List<AzureSqlDatabaseRestorePointModel> newEntity = new List<AzureSqlDatabaseRestorePointModel>();
            newEntity.Add(new AzureSqlDatabaseRestorePointModel()
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                DatabaseName = this.DatabaseName,
                RestorePointCreationDate = this.RestorePointCreationDate
            });

            return newEntity;
        }

        /// <summary>
        /// Creates a new restore point
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The output entity</returns>
        protected override IEnumerable<AzureSqlDatabaseRestorePointModel> PersistChanges(IEnumerable<AzureSqlDatabaseRestorePointModel> entity)
        {
            ModelAdapter.RemoveRestorePoint(entity);
            return entity;
        }
    }
}
