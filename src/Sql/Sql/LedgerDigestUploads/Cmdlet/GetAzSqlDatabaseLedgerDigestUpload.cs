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
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlDatabaseLedgerDigestUpload", DefaultParameterSetName = DatabaseSet, SupportsShouldProcess = true), OutputType(typeof(AzureSqlDatabaseLedgerDigestUploadModel))]
    public class GetAzSqlDatabaseLedgerDigestUpload : AzureSqlDatabaseLedgerDigestUploadBase
    {
        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override AzureSqlDatabaseLedgerDigestUploadModel GetEntity()
        {
            if (InputObject != null)
            {
                ServerName = InputObject.ServerName;
                DatabaseName = InputObject.DatabaseName;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (!string.IsNullOrWhiteSpace(ResourceId))
            {
                ResourceIdentifier identifier = new ResourceIdentifier(ResourceId);
                DatabaseName = identifier.ResourceName;
                ResourceGroupName = identifier.ResourceGroupName;
                ServerName = identifier.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            return ModelAdapter.GetLedgerDigestUpload(
                    this.ResourceGroupName,
                    this.ServerName,
                    this.DatabaseName);
        }

        /// <summary>
        /// No user input to apply to model
        /// </summary>
        /// <param name="model">Model retrieved from service</param>
        /// <returns>The model that was passed in</returns>
        protected override AzureSqlDatabaseLedgerDigestUploadModel ApplyUserInputToModel(
            AzureSqlDatabaseLedgerDigestUploadModel model)
        {
            return model;
        }

        /// <summary>
        /// No changes to persist to server
        /// </summary>
        /// <param name="entity">The output of apply user input to model</param>
        /// <returns>The input entity</returns>
        protected override AzureSqlDatabaseLedgerDigestUploadModel PersistChanges(
            AzureSqlDatabaseLedgerDigestUploadModel entity)
        {
            return entity;
        }
    }
}
