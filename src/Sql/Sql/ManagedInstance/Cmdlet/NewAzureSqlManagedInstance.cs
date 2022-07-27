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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Rest.Azure;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Adapter;
using Microsoft.Azure.Commands.Sql.Instance_Pools.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Sql.Instance_Pools.Services;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Cmdlet
{
    /// <summary>
    /// Defines the New-AzSqlInstance cmdlet
    /// </summary>
    [CmdletOutputBreakingChange(
        deprecatedCmdletOutputTypeName: typeof(AzureSqlManagedInstanceModel),
        deprecateByVersion: "4.0.0",
        DeprecatedOutputProperties = new String[] { "BackupStorageRedundancy" },
        NewOutputProperties = new String[] { "CurrentBackupStorageRedundancy", "RequestedBackupStorageRedundancy" })]
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstance",
        DefaultParameterSetName = NewByEditionAndComputeGenerationParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedInstanceModel))]
    public class NewAzureSqlManagedInstance : ManagedInstanceCmdletBase
    {
        protected const string NewBySkuNameParameterSet =
            "NewBySkuNameParameterSetParameter";

        protected const string NewByEditionAndComputeGenerationParameterSet =
            "NewByEditionAndComputeGenerationParameterSet";

        protected const string NewByInstancePoolParentObjectParameterSet =
            "NewByInstancePoolParentObjectParameterSet";

        protected const string NewByInstancePoolResourceIdParameterSet =
            "NewByInstancePoolResourceIdParameterSet";

        protected static readonly string[] ListOfRegionsToShowWarningMessageForGeoBackupStorage = { "eastasia", "southeastasia", "brazilsouth", "east asia", "southeast asia", "brazil south" };

        /// <summary>
        /// Gets or sets the instance pool parent object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The instance pool parent object.",
            ValueFromPipeline = true,
            ParameterSetName = NewByInstancePoolParentObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("ParentObject")]
        public AzureSqlInstancePoolModel InstancePool { get; set; }

        /// <summary>
        /// Gets or sets the instance pool resource id
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The instance pool resource id.",
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NewByInstancePoolResourceIdParameterSet)]
        [Alias("ResourceId")]
        [ResourceIdCompleter("Microsoft.Sql/instancePools")]
        public string InstancePoolResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the instance.",
            ParameterSetName = NewBySkuNameParameterSet)]
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the instance.",
            ParameterSetName = NewByEditionAndComputeGenerationParameterSet)]
        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the instance.",
            ParameterSetName = NewByInstancePoolParentObjectParameterSet)]
        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the instance.",
            ParameterSetName = NewByInstancePoolResourceIdParameterSet)]
        [Alias("InstanceName")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the resource group.",
            ParameterSetName = NewBySkuNameParameterSet)]
        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the resource group.",
            ParameterSetName = NewByEditionAndComputeGenerationParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the admin credential of the instance
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The SQL authentication credential of the instance.")]
        public PSCredential AdministratorCredential { get; set; }

        /// <summary>
        /// The location in which to create the instance
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The location in which to create the instance.",
            ParameterSetName = NewBySkuNameParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "The location in which to create the instance.",
            ParameterSetName = NewByEditionAndComputeGenerationParameterSet)]
        [LocationCompleter("Microsoft.Sql/managedInstances")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the instance Subnet Id
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The Subnet Id to use for instance creation.",
            ParameterSetName = NewBySkuNameParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "The Subnet Id to use for instance creation.",
            ParameterSetName = NewByEditionAndComputeGenerationParameterSet)]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        /// <summary>
        /// Gets or sets the instance License Type
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = NewBySkuNameParameterSet,
            HelpMessage = "Determines which License Type to use. Possible values are BasePrice (with AHB discount) and LicenseIncluded (without AHB discount).")]
        [Parameter(Mandatory = false,
            ParameterSetName = NewByEditionAndComputeGenerationParameterSet,
            HelpMessage = "Determines which License Type to use. Possible values are BasePrice (with AHB discount) and LicenseIncluded (without AHB discount).")]
        [PSArgumentCompleter(Constants.LicenseTypeBasePrice, Constants.LicenseTypeLicenseIncluded)]
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets the Storage Size in GB for instance
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Determines how much Storage size to associate with instance.")]
        [ValidateNotNullOrEmpty]
        public int StorageSizeInGB { get; set; }

        /// <summary>
        /// Gets or sets the VCore for instance
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Determines how much VCore to associate with instance.")]
        [ValidateNotNullOrEmpty]
        public int VCore { get; set; }

        /// <summary>
        /// Gets or sets the instance SKU name
        /// </summary>
        [Parameter(ParameterSetName = NewBySkuNameParameterSet,
            Mandatory = true,
            HelpMessage = "The SKU name for the instance e.g. 'GP_Gen4', 'BC_Gen4'.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.GeneralPurposeGen4, Constants.GeneralPurposeGen5, Constants.BusinessCriticalGen4, Constants.BusinessCriticalGen5)]
        public string SkuName { get; set; }

        /// <summary>
        /// Gets or sets the instance edition
        /// </summary>
        [Parameter(ParameterSetName = NewByEditionAndComputeGenerationParameterSet,
            Mandatory = true,
            HelpMessage = "The edition for the instance.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.GeneralPurposeEdition, Constants.BusinessCriticalEdition)]
        public string Edition { get; set; }

        /// <summary>
        /// Gets or sets the instance compute generation
        /// </summary>
        [Parameter(ParameterSetName = NewByEditionAndComputeGenerationParameterSet,
            Mandatory = true,
            HelpMessage = "The compute generation for the instance.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.ComputeGenerationGen4, Constants.ComputeGenerationGen5)]
        public string ComputeGeneration { get; set; }

        /// <summary>
        /// Gets or sets the instance collation
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The collation of the instance to use.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.CollationSqlLatin1, Constants.CollationLatin1)]
        public string Collation { get; set; }

        /// <summary>
        /// Gets or sets whether or not the public data endpoint is enabled.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Whether or not the public data endpoint is enabled for the instance.")]
        public SwitchParameter PublicDataEndpointEnabled { get; set; }

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
        /// Gets or sets the instance time zone
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The time zone id for the instance to set. A list of time zone ids is exposed through the sys.time_zone_info (Transact-SQL) view.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Dateline Standard Time", "UTC-11", "Aleutian Standard Time", "Hawaiian Standard Time", "Marquesas Standard Time", "Alaskan Standard Time", "UTC-09",
         "Pacific Standard Time (Mexico)", "UTC-08", "Pacific Standard Time", "US Mountain Standard Time", "Mountain Standard Time (Mexico)", "Mountain Standard Time",
         "Central America Standard Time", "Central Standard Time", "Easter Island Standard Time", "Central Standard Time (Mexico)", "Canada Central Standard Time",
         "SA Pacific Standard Time", "Eastern Standard Time (Mexico)", "Eastern Standard Time", "Haiti Standard Time", "Cuba Standard Time", "US Eastern Standard Time",
         "Turks And Caicos Standard Time", "Paraguay Standard Time", "Atlantic Standard Time", "Venezuela Standard Time", "Central Brazilian Standard Time",
         "SA Western Standard Time", "Pacific SA Standard Time", "Newfoundland Standard Time", "Tocantins Standard Time", "E. South America Standard Time",
         "SA Eastern Standard Time", "Argentina Standard Time", "Greenland Standard Time", "Montevideo Standard Time", "Magallanes Standard Time", "Saint Pierre Standard Time",
         "Bahia Standard Time", "UTC-02", "Mid-Atlantic Standard Time", "Azores Standard Time", "Cape Verde Standard Time", "UTC", "GMT Standard Time",
         "Greenwich Standard Time", "W. Europe Standard Time", "Central Europe Standard Time", "Romance Standard Time", "Morocco Standard Time", "Sao Tome Standard Time",
         "Central European Standard Time", "W. Central Africa Standard Time", "Jordan Standard Time", "GTB Standard Time", "Middle East Standard Time", "Egypt Standard Time",
         "E. Europe Standard Time", "Syria Standard Time", "West Bank Standard Time", "South Africa Standard Time", "FLE Standard Time", "Israel Standard Time",
         "Kaliningrad Standard Time", "Sudan Standard Time", "Libya Standard Time", "Namibia Standard Time", "Arabic Standard Time", "Turkey Standard Time",
         "Arab Standard Time", "Belarus Standard Time", "Russian Standard Time", "E. Africa Standard Time", "Iran Standard Time", "Arabian Standard Time",
         "Astrakhan Standard Time", "Azerbaijan Standard Time", "Russia Time Zone 3", "Mauritius Standard Time", "Saratov Standard Time", "Georgian Standard Time",
         "Volgograd Standard Time", "Caucasus Standard Time", "Afghanistan Standard Time", "West Asia Standard Time", "Ekaterinburg Standard Time",
         "Pakistan Standard Time", "India Standard Time", "Sri Lanka Standard Time", "Nepal Standard Time", "Central Asia Standard Time", "Bangladesh Standard Time",
         "Omsk Standard Time", "Myanmar Standard Time", "SE Asia Standard Time", "Altai Standard Time", "W. Mongolia Standard Time", "North Asia Standard Time",
         "N. Central Asia Standard Time", "Tomsk Standard Time", "China Standard Time", "North Asia East Standard Time", "Singapore Standard Time", "W. Australia Standard Time",
         "Taipei Standard Time", "Ulaanbaatar Standard Time", "Aus Central W. Standard Time", "Transbaikal Standard Time", "Tokyo Standard Time", "North Korea Standard Time",
         "Korea Standard Time", "Yakutsk Standard Time", "Cen. Australia Standard Time", "AUS Central Standard Time", "E. Australia Standard Time", "AUS Eastern Standard Time",
         "West Pacific Standard Time", "Tasmania Standard Time", "Vladivostok Standard Time", "Lord Howe Standard Time", "Bougainville Standard Time", "Russia Time Zone 10",
         "Magadan Standard Time", "Norfolk Standard Time", "Sakhalin Standard Time", "Central Pacific Standard Time", "Russia Time Zone 11", "New Zealand Standard Time", "UTC+12",
         "Fiji Standard Time", "Kamchatka Standard Time", "Chatham Islands Standard Time", "UTC+13", "Tonga Standard Time", "Samoa Standard Time", "Line Islands Standard Time")]
        public string TimezoneId { get; set; }

        /// <summary>
        /// Gets or sets the tags to associate with the instance
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the instance")]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Gets or sets whether or not to assign identity for instance
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Generate and assign an Azure Active Directory Identity for this instance for use with key management services like Azure KeyVault.")]
        public SwitchParameter AssignIdentity { get; set; }

        /// <summary>
        /// Gets or sets the managed instance compute generation
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Dns Zone Partner Resource ID for the Sql Azure Managed Instance.")]
        [ResourceIdCompleter("Microsoft.Sql/managedInstances")]
        public string DnsZonePartner { get; set; }

        /// <summary>
        /// Gets or sets the instance pool name
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The instance pool to place this instance in.",
            ParameterSetName = NewBySkuNameParameterSet)]
        [Parameter(Mandatory = false,
            HelpMessage = "The instance pool to place this instance in.",
            ParameterSetName = NewByEditionAndComputeGenerationParameterSet)]
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
        /// Gets or sets the managed instance backup storage redundancy
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Backup storage redundancy used to store backups for the Sql Azure Managed Instance. Options are: Local, Zone and Geo ")]
        [ValidateSet("Local", "Zone", "Geo", "GeoZone")]
        public string BackupStorageRedundancy { get; set; }

        /// <summary>
        /// Gets or sets the managed instance maintenance configuration id
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The Maintenance configuration id for the Sql Azure Managed Instance.")]
        public string MaintenanceConfigurationId { get; set; }

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
        /// List of user assigned identities.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "List of user assigned identities")]
        public List<string> UserAssignedIdentityId { get; set; }

        /// <summary>
        /// Type of identity to be assigned to the server..
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Type of Identity to be used. Possible values are SystemAssigned, UserAssigned, 'SystemAssigned,UserAssigned' and None.")]
        [PSArgumentCompleter("SystemAssigned", "UserAssigned", "\"SystemAssigned,UserAssigned\"", "None")]
        public string IdentityType { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Enable Active Directory Only Authentication on the server
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Enable Active Directory Only Authentication on the server.")]
        public SwitchParameter EnableActiveDirectoryOnlyAuthentication { get; set; }

        /// <summary>
        /// Azure Active Directory display name for a user or group
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Specifies the display name of the user, group or application which is the Azure Active Directory administrator for the server. This display name must exist in the active directory associated with the current subscription.")]
        public string ExternalAdminName { get; set; }

        /// <summary>
        /// Azure Active Directory object id for a user, group or application
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Specifies the object ID of the user, group or application which is the Azure Active Directory administrator.")]
        public Guid? ExternalAdminSID { get; set; }

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
        /// Overriding to add warning message
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (this.EnableActiveDirectoryOnlyAuthentication.IsPresent && this.ExternalAdminName == null)
            {
                throw new PSArgumentException(Properties.Resources.MissingExternalAdmin, "ExternalAdminName");
            }

            if (!this.EnableActiveDirectoryOnlyAuthentication.IsPresent && this.AdministratorCredential == null)
            {
                throw new PSArgumentException(Properties.Resources.MissingSQLAdministratorCredentials, "AdministratorCredential");
            }

            if (this.IsParameterBound(c => c.InstancePool))
            {
                this.ResourceGroupName = this.InstancePool.ResourceGroupName;
                this.InstancePoolName = this.InstancePool.InstancePoolName;
                this.ComputeGeneration = this.InstancePool.ComputeGeneration;
                this.Edition = this.InstancePool.Edition;
                this.SubnetId = this.InstancePool.SubnetId;
                this.LicenseType = this.InstancePool.LicenseType;
                this.Location = this.InstancePool.Location;
            }

            if (this.IsParameterBound(c => c.InstancePoolResourceId))
            {
                var resourceId = new ResourceIdentifier(this.InstancePoolResourceId);
                this.ResourceGroupName = resourceId.ResourceGroupName;
                this.InstancePoolName = resourceId.ResourceName;

                try
                {
                    AzureSqlInstancePoolCommunicator communicator = new AzureSqlInstancePoolCommunicator(DefaultContext);
                    var instancePool = communicator.GetInstancePool(this.ResourceGroupName, this.InstancePoolName);
                    this.ComputeGeneration = instancePool.Sku.Family;
                    this.Edition = instancePool.Sku.Tier;
                    this.SubnetId = instancePool.SubnetId;
                    this.LicenseType = instancePool.LicenseType;
                    this.Location = instancePool.Location;
                }
                catch (CloudException ex)
                {
                    if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // The instance pool does not exist
                        throw new PSArgumentException(
                            string.Format(Properties.Resources.AzureSqlInstancePoolNotExists, this.InstancePoolName),
                            "InstancePoolName");
                    }

                    // Unexpected exception
                    throw;
                }
            }

            if (ListOfRegionsToShowWarningMessageForGeoBackupStorage.Contains(this.Location.ToLower()))
            {
                if (this.BackupStorageRedundancy == null)
                {
                    if (!Force.IsPresent && !ShouldContinue(
                        string.Format(CultureInfo.InvariantCulture, Properties.Resources.DoYouWantToProceed, this.Name),
                        string.Format(CultureInfo.InvariantCulture, Properties.Resources.BackupRedundancyNotChosenTakeGeoWarning, this.Name)))
                    {
                        return;
                    }
                }
                else if (string.Equals(this.BackupStorageRedundancy, "Geo", System.StringComparison.OrdinalIgnoreCase))
                {
                    if (!Force.IsPresent && !ShouldContinue(
                        string.Format(CultureInfo.InvariantCulture, Properties.Resources.DoYouWantToProceed, this.Name),
                        string.Format(CultureInfo.InvariantCulture, Properties.Resources.BackupRedundancyChosenIsGeoWarning, this.Name)))
                    {
                        return;
                    }
                }
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Check to see if the instance already exists in this resource group.
        /// </summary>
        /// <returns>Null if the instance doesn't exist.  Otherwise throws exception</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> GetEntity()
        {
            try
            {
                ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.Name);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no instance with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The instance already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ServerNameExists, this.Name),
                "Name");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the instance doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlManagedInstanceModel> model)
        {
            List<Model.AzureSqlManagedInstanceModel> newEntity = new List<Model.AzureSqlManagedInstanceModel>();
            Management.Internal.Resources.Models.Sku Sku = new Management.Internal.Resources.Models.Sku();

            if (string.Equals(this.ParameterSetName, NewBySkuNameParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                Sku.Name = SkuName;
            }
            else if (string.Equals(this.ParameterSetName, NewByEditionAndComputeGenerationParameterSet, System.StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(this.ParameterSetName, NewByInstancePoolParentObjectParameterSet, System.StringComparison.OrdinalIgnoreCase) ||
                     string.Equals(this.ParameterSetName, NewByInstancePoolResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                string editionShort = AzureSqlManagedInstanceAdapter.GetInstanceSkuPrefix(Edition);
                Sku.Name = editionShort + "_" + ComputeGeneration;
            }

            newEntity.Add(new AzureSqlManagedInstanceModel()
            {
                Location = this.Location,
                ResourceGroupName = this.ResourceGroupName,
                FullyQualifiedDomainName = this.Name,
                AdministratorPassword = (this.AdministratorCredential != null) ? this.AdministratorCredential.Password : null,
                AdministratorLogin = (this.AdministratorCredential != null) ? this.AdministratorCredential.UserName : null,
                Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true),
                Identity = ResourceIdentityHelper.GetIdentityObjectFromType(this.AssignIdentity.IsPresent, this.IdentityType ?? null, UserAssignedIdentityId, null),
                LicenseType = this.LicenseType,
                // `-StorageSizeInGB 0` as a parameter to this cmdlet means "use default".
                // For non-MI database, we can just pass in 0 and the server will treat 0 as default.
                // However this is (currently) not the case for MI. We need to convert the 0 to null
                // here in client before sending to the server.
                StorageSizeInGB = SqlSkuUtils.ValueIfNonZero(this.StorageSizeInGB),
                SubnetId = this.SubnetId,
                VCores = this.VCore,
                Sku = Sku,
                Collation = this.Collation,
                PublicDataEndpointEnabled = this.PublicDataEndpointEnabled,
                ProxyOverride = this.ProxyOverride,
                TimezoneId = this.TimezoneId,
                DnsZonePartner = this.DnsZonePartner,
                InstancePoolName = this.InstancePoolName,
                MinimalTlsVersion = this.MinimalTlsVersion,
                RequestedBackupStorageRedundancy = this.BackupStorageRedundancy,
                MaintenanceConfigurationId = this.MaintenanceConfigurationId,
                PrimaryUserAssignedIdentityId = this.PrimaryUserAssignedIdentityId,
                KeyId = this.KeyId,
                Administrators = new Management.Sql.Models.ManagedInstanceExternalAdministrator()
                {
                    AzureADOnlyAuthentication = (this.EnableActiveDirectoryOnlyAuthentication.IsPresent) ? (bool?)true : null,
                    Login = this.ExternalAdminName,
                    Sid = this.ExternalAdminSID
                },
                ZoneRedundant = this.ZoneRedundant.IsPresent ? this.ZoneRedundant.ToBool() : (bool?)null,
                ServicePrincipal = ResourceServicePrincipalHelper.GetServicePrincipalObjectFromType(this.ServicePrincipalType ?? null)
            }); ;
            return newEntity;
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the instance
        /// </summary>
        /// <param name="entity">The instance to create</param>
        /// <returns>The created instance</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> PersistChanges(IEnumerable<Model.AzureSqlManagedInstanceModel> entity)
        {
            return new List<Model.AzureSqlManagedInstanceModel>() {
                ModelAdapter.UpsertManagedInstance(entity.First())
            };
        }
    }
}
