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

using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzureRmSqlDatabaseTransparentDataEncryption cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlDatabaseTransparentDataEncryption", ConfirmImpact = ConfirmImpact.Low, SupportsShouldProcess = true)]
    public class SetAzureSqlDatabaseTransparentDataEncryption : AzureSqlDatabaseTransparentDataEncryptionCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the Azure Sql Database Transparent Data Encryption
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The Azure Sql Database Transparent Data Encryption state.")]
        [ValidateNotNullOrEmpty]
        public TransparentDataEncryptionStateType State { get; set; }

        /// <summary>
        /// Get the Transparent Data Encryption to update
        /// </summary>
        /// <returns>The Transparent Data Encryption being updated</returns>
        protected override IEnumerable<Model.AzureSqlDatabaseTransparentDataEncryptionModel> GetEntity()
        {
            return new List<Model.AzureSqlDatabaseTransparentDataEncryptionModel>() { ModelAdapter.GetTransparentDataEncryption(this.ResourceGroupName, this.ServerName, this.DatabaseName) };
        }

        /// <summary>
        /// Constructs the model to send to the update API
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<Model.AzureSqlDatabaseTransparentDataEncryptionModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlDatabaseTransparentDataEncryptionModel> model)
        {
            // Construct a new entity so we only send the relevant data to the server
            List<Model.AzureSqlDatabaseTransparentDataEncryptionModel> updateData = new List<Model.AzureSqlDatabaseTransparentDataEncryptionModel>();
            updateData.Add(new Model.AzureSqlDatabaseTransparentDataEncryptionModel()
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                DatabaseName = this.DatabaseName,
                State = this.State
            });
            return updateData;
        }

        /// <summary>
        /// Sends the Firewall Rule update request to the service
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<Model.AzureSqlDatabaseTransparentDataEncryptionModel> PersistChanges(IEnumerable<Model.AzureSqlDatabaseTransparentDataEncryptionModel> entity)
        {
            return new List<Model.AzureSqlDatabaseTransparentDataEncryptionModel>() {
                ModelAdapter.UpsertTransparentDataEncryption(entity.First())
            };
        }
    }
}
