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
using System.Linq;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.LedgerDigestUploads.Model;
using Microsoft.Azure.Commands.Sql.Database.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.LedgerDigestUploads.Cmdlet
{
    /// <summary>
    /// Defines the Disable-AzSqlDatabaseLedgerDigestUpload cmdlet
    /// </summary>
    [Cmdlet("Disable", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseLedgerDigestUpload", ConfirmImpact = ConfirmImpact.Low, SupportsShouldProcess = true), OutputType(typeof(AzureSqlDatabaseLedgerDigestLocationModel))]
    public class DisableAzSqlDatabaseLedgerDigestUpload : AzureSqlDatabaseLedgerDigestUploadBase
    {
        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureSqlDatabaseLedgerDigestUploadModel> GetEntity()
        {
            if (AzureSqlDatabaseObject != null)
            {
                ServerName = AzureSqlDatabaseObject.ServerName;
                DatabaseName = AzureSqlDatabaseObject.DatabaseName;
                ResourceGroupName = AzureSqlDatabaseObject.ResourceGroupName;
            }
            else if (!string.IsNullOrWhiteSpace(ResourceId))
            {
                ResourceIdentifier identifier = new ResourceIdentifier(ResourceId);
                DatabaseName = identifier.ResourceName;
                ResourceGroupName = identifier.ResourceGroupName;
                ServerName = identifier.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            ICollection<AzureSqlDatabaseLedgerDigestUploadModel> results = new List<AzureSqlDatabaseLedgerDigestUploadModel>()
            {
                ModelAdapter.GetLedgerDigestUpload(
                    this.ResourceGroupName,
                    this.ServerName,
                    this.DatabaseName)
            };

            return results;
        }

        /// <summary>
        /// Create the model from user input
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override IEnumerable<AzureSqlDatabaseLedgerDigestUploadModel> ApplyUserInputToModel(IEnumerable<AzureSqlDatabaseLedgerDigestUploadModel> model)
        {
            return new List<AzureSqlDatabaseLedgerDigestUploadModel>()
            {
                new AzureSqlDatabaseLedgerDigestUploadModel(
                    ResourceGroupName,
                    ServerName,
                    DatabaseName,
                    new Management.Sql.Models.LedgerDigestUploads{
                        DigestStorageEndpoint = null
                    })
            };
        }

        /// <summary>
        /// Update the entity
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override IEnumerable<AzureSqlDatabaseLedgerDigestUploadModel> PersistChanges(IEnumerable<AzureSqlDatabaseLedgerDigestUploadModel> entity)
        {
            if (!ShouldProcess(DatabaseName)) return null;

            return new List<AzureSqlDatabaseLedgerDigestUploadModel>() {
                ModelAdapter.SetLedgerDigestUpload(this.ResourceGroupName, this.ServerName, this.DatabaseName, entity.First())
            };
        }
    }
}