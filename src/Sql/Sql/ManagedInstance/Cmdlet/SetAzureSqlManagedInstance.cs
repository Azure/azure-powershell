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
<<<<<<< HEAD
=======
using System;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
        public Model.AzureSqlManagedInstanceModel InputObject { get; set; }
=======
        public AzureSqlManagedInstanceModel InputObject { get; set; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

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
<<<<<<< HEAD
        [PSArgumentCompleter(ManagedInstanceProxyOverride.Proxy, ManagedInstanceProxyOverride.Redirect, ManagedInstanceProxyOverride.Default)]
=======
        [PSArgumentCompleter("Proxy", "Redirect", "Default")]
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
=======
        /// Gets or sets the instance pool name
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The instance pool name.")]
        [ResourceNameCompleter("Microsoft.Sql/instancePools")]
        public string InstancePoolName { get; set; }

        /// <summary>
        /// Gets or sets the managed instance minimal tls version
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Minimal Tls Version for the Sql Azure Managed Instance. Options are: None, 1.0, 1.1 and 1.2 ")]
        [ValidateSet("None", "1.0", "1.1", "1.2")]
        [PSArgumentCompleter("None", "1.0", "1.1", "1.2")]
        public string MinimalTlsVersion { get; set; }

        /// <summary>
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }
<<<<<<< HEAD
        
=======

        /// <summary>
        /// Gets or sets the instance compute generation
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The compute generation for the instance.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.ComputeGenerationGen5)]
        public string ComputeGeneration { get; set; }

        /// <summary>
        /// Gets or sets the managed instance maintenance configuration id
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Maintenance configuration id for the Sql Azure Managed Instance.")]
        public string MaintenanceConfigurationId { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        /// <summary>
        /// Get the instance to update
        /// </summary>
        /// <returns>The instance being updated</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> GetEntity()
        {
<<<<<<< HEAD
            return new List<Model.AzureSqlManagedInstanceModel>() { ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.Name) };
=======
            return new List<AzureSqlManagedInstanceModel>() { ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.Name) };
        }

        /// <summary>
        /// Validate requested Hardware family.
        /// </summary>
        protected bool ShouldConfirmHardwareFamilyChange()
        {
            bool shouldConfirmHardwareFamilyChange = false;

            ModelAdapter = InitModelAdapter();
            AzureSqlManagedInstanceModel existingInstance = ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.Name);

            // Get current hardware family
            string currentHardwareFamily = existingInstance.Sku.Family;

            // Check whether the hardware family was changed
            bool isHardwareFamilyChanged = !currentHardwareFamily.Equals(this.ComputeGeneration, StringComparison.InvariantCultureIgnoreCase);

            // Check whether hardware family is being changed to a newer hardware family
            if (isHardwareFamilyChanged && currentHardwareFamily.Equals(Constants.ComputeGenerationGen4, StringComparison.InvariantCultureIgnoreCase))
            {
                shouldConfirmHardwareFamilyChange = true;
            }

            return shouldConfirmHardwareFamilyChange;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        /// <summary>
        /// Constructs the model to send to the update API
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
<<<<<<< HEAD
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlManagedInstanceModel> model)
=======
        protected override IEnumerable<AzureSqlManagedInstanceModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceModel> model)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        {
            AzureSqlManagedInstanceModel existingInstance = ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.Name);
            Management.Internal.Resources.Models.Sku Sku = new Management.Internal.Resources.Models.Sku();

<<<<<<< HEAD
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
=======
            // Get current edition and family
            string currentEdition = existingInstance.Sku.Tier;
            string currentComputeGeneration = existingInstance.Sku.Family;

            // If either edition or compute generation are set, get the new sku
            if (this.Edition != null || this.ComputeGeneration != null)
            {
                string editionShort = AzureSqlManagedInstanceAdapter.GetInstanceSkuPrefix(!string.IsNullOrWhiteSpace(Edition) ? this.Edition : currentEdition);
                Sku.Name = editionShort + "_" + (!string.IsNullOrWhiteSpace(this.ComputeGeneration) ? this.ComputeGeneration : currentComputeGeneration);
                Sku.Tier = !string.IsNullOrWhiteSpace(this.Edition) ? this.Edition : null;
                Sku.Family = !string.IsNullOrWhiteSpace(this.ComputeGeneration) ? this.ComputeGeneration : currentComputeGeneration;
            }
            else
            {
                Sku = existingInstance.Sku;
            }

            // Construct a new entity so we only send the relevant data to the Managed instance
            List<AzureSqlManagedInstanceModel> updateData = new List<AzureSqlManagedInstanceModel>();
            updateData.Add(new AzureSqlManagedInstanceModel()
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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
<<<<<<< HEAD
=======
                InstancePoolName = this.InstancePoolName,
                MinimalTlsVersion = this.MinimalTlsVersion,
                MaintenanceConfigurationId = this.MaintenanceConfigurationId
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            });
            return updateData;
        }

        /// <summary>
        /// Sends the instance update request to the service
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
<<<<<<< HEAD
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> PersistChanges(IEnumerable<Model.AzureSqlManagedInstanceModel> entity)
        {
            return new List<Model.AzureSqlManagedInstanceModel>() { ModelAdapter.UpsertManagedInstance(entity.First()) };
=======
        protected override IEnumerable<AzureSqlManagedInstanceModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceModel> entity)
        {
            return new List<AzureSqlManagedInstanceModel>() { ModelAdapter.UpsertManagedInstance(entity.First()) };
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent && !ShouldContinue(
<<<<<<< HEAD
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.SetAzureSqlInstanceDescription, this.Name),
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.SetAzureSqlInstanceWarning, this.Name)))
=======
               string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAzureSqlInstanceDescription, this.Name),
               string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAzureSqlInstanceWarning, this.Name)))
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
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

<<<<<<< HEAD
=======
            // Validate requested hardware family
            if (!string.IsNullOrWhiteSpace(this.ComputeGeneration))
            {
                // Hardware family is being changed to a newer hardware family and it is not possible to scale back - Give confirmation message
                if (this.ShouldConfirmHardwareFamilyChange())
                {
                    if (!Force.IsPresent && !ShouldContinue(
                        string.Format(CultureInfo.InvariantCulture, Properties.Resources.DoYouWantToProceed, this.Name),
                        string.Format(CultureInfo.InvariantCulture, string.Format(Properties.Resources.ChangingHardwareFamilyIsIrreversable, this.ComputeGeneration), this.Name)))
                    {
                        return;
                    }
                }
            }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            base.ExecuteCmdlet();
        }
    }
}
