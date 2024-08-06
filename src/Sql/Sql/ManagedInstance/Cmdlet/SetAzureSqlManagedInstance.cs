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
using System;
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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

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
        public AzureSqlManagedInstanceModel InputObject { get; set; }

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
        /// Gets or sets the instance Subnet Id
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "ID of a subnet to move the managed instance to.")]
        public string SubnetId { get; set; }

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
        [PSArgumentCompleter("Proxy", "Redirect", "Default")]
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
            HelpMessage = "Generate and assign a Microsoft Entra identity for this instance for use with key management services like Azure KeyVault.")]
        public SwitchParameter AssignIdentity { get; set; }

        /// <summary>
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
        /// Id of the primary user assigned identity
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The primary user managed identity(UMI) id")]
        public string PrimaryUserAssignedIdentityId { get; set; }

        /// <summary>
        /// URI of the key to use for encryption
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Key Vault URI for encryption")]
        public string KeyId { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets the instance compute generation
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The compute generation for the instance.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.ComputeGenerationGen5, Constants.ComputeGenerationG8IH, Constants.ComputeGenerationG8IM)]
        public string ComputeGeneration { get; set; }

        /// <summary>
        /// Gets or sets the managed instance maintenance configuration id
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Maintenance configuration id for the Sql Azure Managed Instance.")]
        public string MaintenanceConfigurationId { get; set; }

        /// <summary>
        /// List of user assigned identities.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "List of user assigned identities")]
        public List<string> UserAssignedIdentityId { get; set; }

        /// <summary>
        /// List of user assigned identities.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Type of Identity to be used. Possible values are SystemAssigned, UserAssigned, 'SystemAssigned,UserAssigned' and None.")]
        [PSArgumentCompleter("SystemAssigned", "UserAssigned", "\"SystemAssigned,UserAssigned\"", "None")]
        public string IdentityType { get; set; }

        /// <summary>
        /// Gets or sets the managed instance backup storage redundancy
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Backup storage redundancy used to store backups for the Sql Azure Managed Instance. Options are: Local, Zone and Geo ")]
        [ValidateSet("Local", "Zone", "Geo", "GeoZone")]
        public string BackupStorageRedundancy { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Gets or sets whether or not the multi-az is enabled
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Use zone redundant storage")]
        public SwitchParameter ZoneRedundant { get; set; }

        /// <summary>
        /// Gets or sets service principal type
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Type of Service Principal to be used. Possible values are SystemAssigned and None.")]
        [ValidateSet("None", "SystemAssigned")]
        [PSArgumentCompleter("SystemAssigned", "None")]
        public string ServicePrincipalType { get; set; }

        /// <summary>
        /// Specifies the internal format of instance databases specific to the SQL engine version
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The instance databases specific to the SQL engine version")]
        [PSArgumentCompleter("AlwaysUpToDate", "SQLServer2022")]
        public string DatabaseFormat { get; set; }

        /// <summary>
        /// Specifies weather or not Managed Instance is freemium
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Weather or not Managed Instance is freemium")]
        [PSArgumentCompleter("Regular", "Freemium")]
        public string PricingModel { get; set; }

        /// <summary>
        /// Gets or sets whether or not this is a GPv2 variant of General Purpose edition.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Whether or not this is a GPv2 variant of General Purpose edition.")]
        public bool? IsGeneralPurposeV2 { get; set; }

        /// <summary>
        /// Gets or sets the Storage IOps for instance
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Determines how much Storage IOps to associate with instance.")]
        public int? StorageIOps { get; set; }

        /// <summary>
        /// Specifies weather or not Managed Instance is freemium
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Preferred metadata to use for authentication of synced on-prem users. Default is AzureAD.")]
        [ValidateSet("AzureAD", "Paired", "Windows")]
        [PSArgumentCompleter("AzureAD", "Paired", "Windows")]
        public string AuthenticationMetadata { get; set; }

        /// <summary>
        /// Get the instance to update
        /// </summary>
        /// <returns>The instance being updated</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> GetEntity()
        {
            return new List<AzureSqlManagedInstanceModel>() { ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.Name, "administrators/activedirectory") };
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
        }

        /// <summary>
        /// Constructs the model to send to the update API
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<AzureSqlManagedInstanceModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceModel> model)
        {
            AzureSqlManagedInstanceModel existingInstance = ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.Name, "administrators/activedirectory");
            Management.Internal.Resources.Models.Sku Sku = new Management.Internal.Resources.Models.Sku();

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
            updateData.Add(model.FirstOrDefault());
            updateData[0].ResourceGroupName = this.ResourceGroupName;
            updateData[0].ManagedInstanceName = this.Name;
            updateData[0].FullyQualifiedDomainName = this.Name;
            updateData[0].Location = model.FirstOrDefault().Location;
            updateData[0].Sku = Sku;
            updateData[0].AdministratorPassword = this.AdministratorPassword;
            updateData[0].LicenseType = this.LicenseType ?? updateData[0].LicenseType;
            updateData[0].StorageSizeInGB = this.StorageSizeInGB ?? model.FirstOrDefault().StorageSizeInGB;
            updateData[0].VCores = this.VCore ?? updateData[0].VCores;
            updateData[0].PublicDataEndpointEnabled = this.PublicDataEndpointEnabled ?? updateData[0].PublicDataEndpointEnabled;
            updateData[0].ProxyOverride = this.ProxyOverride ?? this.ProxyOverride;
            updateData[0].Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true);
            updateData[0].Identity = ResourceIdentityHelper.GetIdentityObjectFromType(this.AssignIdentity.IsPresent, this.IdentityType ?? null, UserAssignedIdentityId, model.FirstOrDefault().Identity);
            updateData[0].InstancePoolName = this.InstancePoolName ?? updateData[0].InstancePoolName;
            updateData[0].MinimalTlsVersion = this.MinimalTlsVersion ?? updateData[0].MinimalTlsVersion;
            updateData[0].MaintenanceConfigurationId = this.MaintenanceConfigurationId ?? updateData[0].MaintenanceConfigurationId;
            updateData[0].AdministratorLogin = model.FirstOrDefault().AdministratorLogin;
            updateData[0].PrimaryUserAssignedIdentityId = this.PrimaryUserAssignedIdentityId ?? model.FirstOrDefault().PrimaryUserAssignedIdentityId;
            updateData[0].KeyId = this.KeyId ?? updateData[0].KeyId;
            updateData[0].SubnetId = this.SubnetId ?? model.FirstOrDefault().SubnetId;
            updateData[0].ZoneRedundant = this.ZoneRedundant.IsPresent ? this.ZoneRedundant.ToBool() : (bool?)null;
            updateData[0].RequestedBackupStorageRedundancy = this.BackupStorageRedundancy ?? updateData[0].CurrentBackupStorageRedundancy;
            updateData[0].ServicePrincipal = ResourceServicePrincipalHelper.GetServicePrincipalObjectFromType(this.ServicePrincipalType ?? null);
            updateData[0].DatabaseFormat = this.DatabaseFormat?? updateData[0].DatabaseFormat;
            updateData[0].PricingModel = this.PricingModel ?? updateData[0].PricingModel;
            // If this parameter was not set by the user, we do not want to pick up its current value.
            // This is due to the fact that this update might have a target edition that does not use this parameter.
            updateData[0].IsGeneralPurposeV2 = this.IsGeneralPurposeV2;
            // If this parameter was not set by the user, we do not want to pick up its current value.
            // This is due to the fact that this update might have a target edition that does not use this parameter.
            // If the target edition uses the parameter, the current value will get picked up later in the update process.
            updateData[0].StorageIOps = this.StorageIOps;
            updateData[0].AuthenticationMetadata = this.AuthenticationMetadata ?? updateData[0].AuthenticationMetadata;

            return updateData;
        }

        /// <summary>
        /// Sends the instance update request to the service
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<AzureSqlManagedInstanceModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceModel> entity)
        {
            return new List<AzureSqlManagedInstanceModel>() { ModelAdapter.UpsertManagedInstance(entity.First()) };
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (!Force.IsPresent && !ShouldContinue(
               string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAzureSqlInstanceDescription, this.Name),
               string.Format(CultureInfo.InvariantCulture, Properties.Resources.SetAzureSqlInstanceWarning, this.Name)))
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

            if (string.Equals(this.BackupStorageRedundancy, "Geo", StringComparison.OrdinalIgnoreCase))
            {
                ModelAdapter = InitModelAdapter();
                var existingManagedInstance = ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.Name);
                if (existingManagedInstance.CurrentBackupStorageRedundancy != "Geo" && !Force.IsPresent && !ShouldContinue(
                    string.Format(CultureInfo.InvariantCulture, Properties.Resources.DoYouWantToProceed, this.Name),
                    string.Format(CultureInfo.InvariantCulture, Properties.Resources.BackupRedundancyChosenIsGeoWarning, this.Name)))
                {
                    return;
                }
            }

            base.ExecuteCmdlet();
        }
    }
}
