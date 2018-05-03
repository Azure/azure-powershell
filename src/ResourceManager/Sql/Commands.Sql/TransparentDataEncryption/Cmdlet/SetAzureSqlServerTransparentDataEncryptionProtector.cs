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

using Microsoft.Azure.Commands.Sql.ServerKeyVaultKey.Model;
using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Cmdlet
{
    /// <summary>
    /// Defines the Set-AzureRmSqlServerTransparentDataEncryptionProtector cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureRmSqlServerTransparentDataEncryptionProtector", SupportsShouldProcess = true)]
    public class SetAzureSqlServerTransparentDataEncryptionProtector : AzureSqlServerTransparentDataEncryptionProtectorCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the Azure Sql Database Transparent Data Encryption protector type
        /// </summary>
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "The Azure Sql Database Transparent Data Encryption Protector type.")]
        [ValidateNotNullOrEmpty]
        public EncryptionProtectorType Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure Sql Database server key vault KeyId
        /// </summary>
        [Parameter(Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 3,
            HelpMessage = "The Azure Key Vault KeyId.")]
        [ValidateNotNullOrEmpty]
        public string KeyId { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of setting Transparent Data Encryption protector confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Get the Transparent Data Encryption to update
        /// </summary>
        /// <returns>The Transparent Data Encryption being updated</returns>
        protected override IEnumerable<Model.AzureSqlServerTransparentDataEncryptionProtectorModel> GetEntity()
        {
            return new List<Model.AzureSqlServerTransparentDataEncryptionProtectorModel>() { ModelAdapter.GetEncryptionProtector(this.ResourceGroupName, this.ServerName) };
        }

        /// <summary>
        /// Constructs the model to send to the update API
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<Model.AzureSqlServerTransparentDataEncryptionProtectorModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerTransparentDataEncryptionProtectorModel> model)
        {
            List<Model.AzureSqlServerTransparentDataEncryptionProtectorModel> newEntity = new List<Model.AzureSqlServerTransparentDataEncryptionProtectorModel>();

            newEntity.Add(new Model.AzureSqlServerTransparentDataEncryptionProtectorModel()
            {
                ResourceGroupName = this.ResourceGroupName,
                ServerName = this.ServerName,
                Type = this.Type,
                ServerKeyVaultKeyName = AzureSqlServerKeyVaultKeyModel.CreateServerKeyNameFromKeyId(this.KeyId),
                KeyId = this.KeyId
            });
            return newEntity;
        }

        /// <summary>
        /// Sends the TDE protector update request to the service
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<Model.AzureSqlServerTransparentDataEncryptionProtectorModel> PersistChanges(IEnumerable<Model.AzureSqlServerTransparentDataEncryptionProtectorModel> entity)
        {
            return new List<Model.AzureSqlServerTransparentDataEncryptionProtectorModel>() {
                ModelAdapter.CreateOrUpdateEncryptionProtector(entity.First())
            };
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (ShouldProcess(this.KeyId))
            {
                if (Force || this.Type == EncryptionProtectorType.ServiceManaged || ShouldContinue(
                    string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.SetAzureSqlServerTransparentDataEncryptionProtectorWarning, this.KeyId), ""))
                {
                    base.ExecuteCmdlet();
                }
            }
        }
    }
}
