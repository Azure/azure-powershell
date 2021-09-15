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
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Cmdlet
{
    /// <summary>
    /// Defines the Set-AzureRmSqlInstanceTransparentDataEncryptionProtector cmdlet
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceTransparentDataEncryptionProtector", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet)]
    [Alias("Set-" + ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceTDEProtector")]
    [OutputType(typeof(AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel))]
    public class SetAzureRmSqlManagedInstanceTransparentDataEncryptionProtector : AzureSqlRmManagedInstanceTransparentDataEncryptionProtectorBase
    {
        /// <summary>
        /// Gets or sets the name of the Azure Sql Database Transparent Data Encryption protector type
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            Position = 1,
            HelpMessage = "The Azure Sql Database Transparent Data Encryption Protector type.")]
        [Parameter(Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            Position = 1,
            HelpMessage = "The Azure Sql Database Transparent Data Encryption Protector type.")]
        [Parameter(Mandatory = true,
            Position = 2,
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "The Azure Sql Database Transparent Data Encryption Protector type.")]
        [ValidateNotNullOrEmpty]
        public EncryptionProtectorType Type { get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure Sql Database server key vault KeyId
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = InputObjectParameterSet,
            Position = 2,
            HelpMessage = "The Azure Key Vault KeyId.")]
        [Parameter(Mandatory = false,
            ParameterSetName = ResourceIdParameterSet,
            Position = 2,
            HelpMessage = "The Azure Key Vault KeyId.")]
        [Parameter(Mandatory = false,
            ParameterSetName = DefaultParameterSet,
            Position = 3,
            HelpMessage = "The Azure Key Vault KeyId.")]
        [ValidateNotNullOrEmpty]
        public string KeyId { get; set; }

        /// <summary>
        /// Gets or sets the encryption protector key auto rotation status
        /// </summary>
        [Parameter(Mandatory = false,
        ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Key Auto Rotation status")]
        [ValidateNotNullOrEmpty]
        public bool? AutoRotationEnabled { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of setting Transparent Data Encryption protector confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel> GetEntity()
        {
            IList<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel> resultList = new List<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel>();

            AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel model = new AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel(
                resourceGroupName: this.ResourceGroupName,
                managedInstanceName: this.InstanceName);

            resultList.Add(ModelAdapter.GetAzureRmSqlManagedInstanceTransparentDataEncryptionProtector(model));

            return resultList;
        }

        /// <summary>
        /// Constructs the model to send to the update API
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<Model.AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel> ApplyUserInputToModel(IEnumerable<Model.AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel> model)
        {
            List<Model.AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel> newEntity = new List<Model.AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel>();

            newEntity.Add(new Model.AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel(
                resourceGroupName: this.ResourceGroupName, 
                managedInstanceName: this.InstanceName, 
                type: this.Type, 
                keyId: this.KeyId,
                autoRotatonEnabled: this.AutoRotationEnabled));

            return newEntity;
        }
        
        /// <summary>
        /// Sends the TDE protector update request to the service
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel> PersistChanges(IEnumerable<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel> entity)
        {
            return new List<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel>() {
                ModelAdapter.CreateOrUpdateManagedInstanceEncryptionProtector(entity.First())
            };
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!this.MyInvocation.BoundParameters.ContainsKey("KeyId") && this.Type.Equals(EncryptionProtectorType.AzureKeyVault))
            {
                throw new PSArgumentException(
                    string.Format(CultureInfo.InvariantCulture, Properties.Resources.KeyIdNotFoundForAzureKeyVaultEncryptionProtectorError),
                    "KeyId");
            }

            if (ShouldProcess(this.KeyId))
            {
                if (Force || this.Type != EncryptionProtectorType.AzureKeyVault || ShouldContinue(
                        string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAzureSqlInstanceTransparentDataEncryptionProtectorWarning, this.KeyId), ""))
                {
                    base.ExecuteCmdlet();
                }
            }
        }
    }
}
