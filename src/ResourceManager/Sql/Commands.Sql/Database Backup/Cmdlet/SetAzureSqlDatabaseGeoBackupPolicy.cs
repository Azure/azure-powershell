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
    /// Cmdlet to create or update a new Azure Sql Database geo backup policy
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlDatabaseGeoBackupPolicy",
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Medium)]
    public class SetAzureSqlDatabaseGeoBackupPolicy : AzureSqlDatabaseGeoBackupPolicyCmdletBase
    {
        /// <summary>
        /// Gets or sets the geo backup policy state
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The state of the geo backup policy, 'Enabled' or 'Disabled'")]
        [ValidateNotNullOrEmpty]
        public AzureSqlDatabaseGeoBackupPolicyModel.GeoBackupPolicyState State { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseGeoBackupPolicyModel> GetEntity()
        {
            return new List<AzureSqlDatabaseGeoBackupPolicyModel>() { 
                ModelAdapter.GetDatabaseGeoBackupPolicy(this.ResourceGroupName, this.ServerName, this.DatabaseName) 
            };
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseGeoBackupPolicyModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseGeoBackupPolicyModel> model)
        {
            List<Model.AzureSqlDatabaseGeoBackupPolicyModel> newEntity =
                new List<AzureSqlDatabaseGeoBackupPolicyModel>();
            newEntity.Add(new AzureSqlDatabaseGeoBackupPolicyModel()
            {
                Location = model.FirstOrDefault().Location,
                ResourceGroupName = ResourceGroupName,
                ServerName = ServerName,
                DatabaseName = DatabaseName,
                State = State,
            });
            return newEntity;
        }

        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseGeoBackupPolicyModel> PersistChanges(IEnumerable<AzureSqlDatabaseGeoBackupPolicyModel> entity)
        {
            if (ShouldProcess(DatabaseName))
            {
                return new List<AzureSqlDatabaseGeoBackupPolicyModel>() {
                    ModelAdapter.SetDatabaseGeoBackupPolicy(this.ResourceGroupName, this.ServerName, this.DatabaseName, entity.First())
                };
            }
            else
            {
                return null;
            }
        }
    }
}
