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
    [Cmdlet(VerbsCommon.New, "AzureRmSqlDatabaseRestorePoint", SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlDatabaseRestorePointModel))]
    public class NewAzureSqlDatabaseRestorePoint : AzureSqlDatabaseRestorePointCmdletBase
    {
        /// <summary>
        /// Gets or sets the restore point label.
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The label we associate a restore point with, may not be unique.")]
        [ValidateNotNullOrEmpty]
        public string RestorePointLabel { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseRestorePointModel> GetEntity()
        {
            // Every request is new restore point resource, two successive requests with same parameters are two resources
            // So we don't want to check existence
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
                RestorePointLabel = this.RestorePointLabel
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
            return ModelAdapter.NewRestorePoint(entity);
        }
    }
}
