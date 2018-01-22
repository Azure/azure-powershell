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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Model;
using Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Services;

namespace Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Cmdlet
{
    /// <summary>
    /// Defines the Add-AzureRmSqlServerKeyVaultKey cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Add, "AzureRmSqlServerKeyVaultKey", 
        ConfirmImpact = ConfirmImpact.Low, 
        SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlServerKeyVaultKeyModel))]
    public class AddAzureSqlServerKeyVaultKey : AzureSqlServerKeyVaultKeyCmdletBase
    {
        /// <summary>
        /// Gets or sets the KeyId of the Azure Key Vault
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The Azure Key Vault KeyId.")]
        [ValidateNotNullOrEmpty]
        public string KeyId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Check to see if the Server Key Vault Key already exists on the server.
        /// </summary>
        /// <returns>Null if the Server Key Vault Key doesn't exist.</returns>
        protected override IEnumerable<AzureSqlServerKeyVaultKeyModel> GetEntity()
        {
            return null;
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the model doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureSqlServerKeyVaultKeyModel> ApplyUserInputToModel(IEnumerable<AzureSqlServerKeyVaultKeyModel> model)
        {
            List<AzureSqlServerKeyVaultKeyModel> newEntity = new List<AzureSqlServerKeyVaultKeyModel>();

            newEntity.Add(new AzureSqlServerKeyVaultKeyModel()
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                ServerKeyName = AzureSqlServerKeyVaultKeyModel.CreateServerKeyNameFromKeyId(this.KeyId),
                Uri = this.KeyId,
                Type = AzureSqlServerKeyVaultKeyModel.ServerKeyType.AzureKeyVault
            });

            return newEntity;
        }

        /// <summary>
        /// Sends the changes to the service -> Associates the Azure Key Vault key with the server
        /// </summary>
        /// <param name="entity">The Server Key</param>
        /// <returns>The Server Key added to the server</returns>
        protected override IEnumerable<AzureSqlServerKeyVaultKeyModel> PersistChanges(IEnumerable<AzureSqlServerKeyVaultKeyModel> entity)
        {
            return new List<AzureSqlServerKeyVaultKeyModel>() {
                ModelAdapter.CreateOrUpdate(entity.First())
            };
        }
    }
}
