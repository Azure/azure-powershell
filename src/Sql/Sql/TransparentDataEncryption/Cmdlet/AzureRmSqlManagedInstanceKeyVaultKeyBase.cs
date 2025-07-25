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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Server.Model;
using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Adapter;
using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;


namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Cmdlet
{
    /// <summary>
    /// Defines the Add-AzureRmSqlManagedInstanceKeyVaultKey cmdlet
    /// </summary>
    public abstract class AzureRmSqlManagedInstanceKeyVaultKeyBase : AzureSqlCmdletBase<IEnumerable<AzureRmSqlManagedInstanceKeyVaultKeyModel>, AzureSqlDatabaseTransparentDataEncryptionArmAdapter>
    {
        /// <summary>
        /// Parameter sets
        /// </summary>
        protected const string DefaultParameterSet = "AddAzureRmSqlManagedInstanceKeyVaultKeyDefaultParameterSet";
        protected const string InputObjectParameterSet = "AddAzureRmSqlManagedInstanceKeyVaultKeyInputObjectParameterSet";
        protected const string ResourceIdParameterSet = "AddAzureRmSqlManagedInstanceKeyVaultKeyResourceIdParameterSet";

        /// <summary>
        /// Gets or sets the instance Object
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            ValueFromPipeline = true,
            Position = 0,
            HelpMessage = "The instance input object")]
        [ValidateNotNullOrEmpty]
        [Alias("InputObject")]
        public AzureSqlManagedInstanceModel Instance { get; set; }

        /// <summary>
        /// Gets or sets the instance Resource Id
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The instance resource id")]
        [ValidateNotNullOrEmpty]
        [Alias("ResourceId")]
        public string InstanceResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 0,
            HelpMessage = "The Resource Group Name")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the instance name
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 1,
            HelpMessage = "The instance name")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the AzureKeyVault key id
        /// </summary>
        [Parameter(
            Mandatory = true,
            ParameterSetName = InputObjectParameterSet,
            Position = 1,
            HelpMessage = "AzureKeyVault key id")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = ResourceIdParameterSet,
            Position = 1,
            HelpMessage = "AzureKeyVault key id")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = DefaultParameterSet,
            Position = 2,
            HelpMessage = "AzureKeyVault key id")]
        [ValidateNotNullOrEmpty]
        public virtual string KeyId { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case InputObjectParameterSet:
                    this.ResourceGroupName = Instance.ResourceGroupName;
                    this.InstanceName = Instance.ManagedInstanceName;
                    break;
                case ResourceIdParameterSet:
                    var resourceInfo = new ResourceIdentifier(InstanceResourceId);
                    this.ResourceGroupName = resourceInfo.ResourceGroupName;
                    this.InstanceName = resourceInfo.ResourceName;
                    break;
                default:
                    break;
            }
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Intializes the model adapter
        /// </summary>
        /// <returns>The server adapter</returns>
        protected override AzureSqlDatabaseTransparentDataEncryptionArmAdapter InitModelAdapter()
        {
            return new AzureSqlDatabaseTransparentDataEncryptionArmAdapter(DefaultProfile.DefaultContext);
        }

        /// <summary>
        /// Returns null in default implementation
        /// </summary>
        /// <returns>null, since the certificate does not exist</returns>
        protected override IEnumerable<Model.AzureRmSqlManagedInstanceKeyVaultKeyModel> GetEntity()
        {
            return null;
        }

        /// <summary>
        /// Returns input model for default implementation
        /// </summary>
        /// <param name="model"> Model to send to the update API</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<AzureRmSqlManagedInstanceKeyVaultKeyModel> ApplyUserInputToModel(IEnumerable<AzureRmSqlManagedInstanceKeyVaultKeyModel> model)
        {
            return model;
        }

        /// <summary>
        /// Returns input model for default implementation
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<AzureRmSqlManagedInstanceKeyVaultKeyModel> PersistChanges(IEnumerable<AzureRmSqlManagedInstanceKeyVaultKeyModel> entity)
        {
            return entity;
        }
    }
}
