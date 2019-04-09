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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.Common;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Adapter;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Cmdlet
{
    /// <summary>
    /// Defines the Set-AzSqlInstance cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstance",
        DefaultParameterSetName = SetByNameAndResourceGroupParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedInstanceModel))]
    public class SetAzureSqlManagedInstance : ManagedInstanceCmdletBase
    {
        protected const string SetByNameAndResourceGroupParameterSet =
            "SetInstanceFromInputParameters";

        protected const string SetByInputObjectParameterSet =
            "SetInstanceFromAzureSqlManagedInstanceModelInstanceDefinition";

        protected const string SetByResourceIdParameterSet =
            "SetInstanceFromAzureResourceId";

        /// <summary>
        /// Instance object to remove
        /// </summary>
        [Parameter(ParameterSetName = SetByInputObjectParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The instance object to remove")]
        [ValidateNotNullOrEmpty]
        [Alias("SqlInstance")]
        public Model.AzureSqlManagedInstanceModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the instance
        /// </summary>
        [Parameter(ParameterSetName = SetByResourceIdParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of instance to remove")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance to use.
        /// </summary>
        [Parameter(ParameterSetName = SetByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the instance.")]
        [Alias("InstanceName")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(ParameterSetName = SetByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// The new SQL administrator password for the instance.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The new SQL administrator password for the instance.")]
        [ValidateNotNull]
        public SecureString AdministratorPassword { get; set; }

        /// <summary>
        /// Gets or sets the edition to assign to the instance
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The edition to assign to the instance.")]
        [PSArgumentCompleter(Constants.GeneralPurposeEdition, Constants.BusinessCriticalEdition)]
        [ValidateNotNullOrEmpty]
        public string Edition { get; set; }

        /// <summary>
        /// Gets or sets the instance License Type
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Determines which License Type to use. Possible values are BasePrice (with AHB discount) and LicenseIncluded (without AHB discount).")]
        [PSArgumentCompleter(Constants.LicenseTypeBasePrice, Constants.LicenseTypeLicenseIncluded)]
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets the Storage Size in GB for instance
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Determines how much Storage size to associate with instance")]
        public int? StorageSizeInGB { get; set; }

        /// <summary>
        /// Gets or sets the VCore for instance
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Determines how much VCore to associate with instance")]
        public int? VCore { get; set; }

        /// <summary>
        /// Gets or sets whether or not the public data endpoint is enabled.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Whether or not the public data endpoint is enabled for the instance.")]
        [ValidateNotNullOrEmpty]
        public bool? PublicDataEndpointEnabled { get; set; }

        /// <summary>
        /// Gets or sets connection type used for connecting to the instance.
        /// Possible values include: 'Proxy', 'Redirect', 'Default'
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The connection type used for connecting to the instance.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(ManagedInstanceProxyOverride.Proxy, ManagedInstanceProxyOverride.Redirect, ManagedInstanceProxyOverride.Default)]
        public string ProxyOverride { get; set; }

        /// <summary>
        /// The tags to associate with the instance.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the instance.")]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Gets or sets whether or not to assign identity for instance
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Generate and assign an Azure Active Directory Identity for this instance for use with key management services like Azure KeyVault.")]
        public SwitchParameter AssignIdentity { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }
        
        /// <summary>
        /// Get the instance to update
        /// </summary>
        /// <returns>The instance being updated</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> GetEntity()
        {
            return new List<Model.AzureSqlManagedInstanceModel>() { ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.Name) };
        }

        /// <summary>
        /// Constructs the model to send to the update API
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlManagedInstanceModel> model)
        {
            AzureSqlManagedInstanceModel existingInstance = ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.Name);
            Management.Internal.Resources.Models.Sku Sku = new Management.Internal.Resources.Models.Sku();

            if (Edition != null)
            {
                string computeGeneration = existingInstance.Sku.Name.Contains(Constants.ComputeGenerationGen4) ? Constants.ComputeGenerationGen4 : Constants.ComputeGenerationGen5;
                string editionShort = AzureSqlManagedInstanceAdapter.GetInstanceSkuPrefix(Edition);
                Sku.Name = editionShort + "_" + computeGeneration;
                Sku.Tier = Edition;
            }
            else
            {
                Sku = null;
            }

            // Construct a new entity so we only send the relevant data to the Managed instance
            List<Model.AzureSqlManagedInstanceModel> updateData = new List<Model.AzureSqlManagedInstanceModel>();
            updateData.Add(new Model.AzureSqlManagedInstanceModel()
            {
                ResourceGroupName = this.ResourceGroupName,
                ManagedInstanceName = this.Name,
                FullyQualifiedDomainName = this.Name,
                Location = model.FirstOrDefault().Location,
                Sku = Sku,
                AdministratorPassword = this.AdministratorPassword,
                LicenseType = this.LicenseType,
                StorageSizeInGB = this.StorageSizeInGB ?? model.FirstOrDefault().StorageSizeInGB,
                VCores = this.VCore,
                PublicDataEndpointEnabled = this.PublicDataEndpointEnabled,
                ProxyOverride = this.ProxyOverride,
                Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true),
                Identity = model.FirstOrDefault().Identity ?? ResourceIdentityHelper.GetIdentityObjectFromType(this.AssignIdentity.IsPresent),
            });
            return updateData;
        }

        /// <summary>
        /// Sends the instance update request to the service
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> PersistChanges(IEnumerable<Model.AzureSqlManagedInstanceModel> entity)
        {
            return new List<Model.AzureSqlManagedInstanceModel>() { ModelAdapter.UpsertManagedInstance(entity.First()) };
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent && !ShouldContinue(
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.SetAzureSqlInstanceDescription, this.Name),
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.SetAzureSqlInstanceWarning, this.Name)))
            {
                return;
            }

            if (string.Equals(this.ParameterSetName, SetByInputObjectParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                Name = InputObject.ManagedInstanceName;
            }
            else if (string.Equals(this.ParameterSetName, SetByResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);

                ResourceGroupName = resourceInfo.ResourceGroupName;
                Name = resourceInfo.ResourceName;
            }

            base.ExecuteCmdlet();
        }
    }
}
