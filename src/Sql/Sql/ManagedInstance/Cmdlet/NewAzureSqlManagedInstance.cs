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
using System.Linq;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Adapter;

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Cmdlet
{
    /// <summary>
    /// Defines the New-AzSqlInstance cmdlet
    /// </summary>
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

        /// <summary>
        /// Gets or sets the name of the instance.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the instance.")]
        [Alias("InstanceName")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the admin credential of the instance
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The SQL authentication credential of the instance.")]
        [ValidateNotNull]
        public PSCredential AdministratorCredential { get; set; }

        /// <summary>
        /// The location in which to create the instance
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The location in which to create the instance.")]
        [LocationCompleter("Microsoft.Sql/managedInstances")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the instance Subnet Id
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The Subnet Id to use for instance creation.")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        /// <summary>
        /// Gets or sets the instance License Type
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Determines which License Type to use. Possible values are BasePrice (with AHB discount) and LicenseIncluded (without AHB discount).")]
        [PSArgumentCompleter(Constants.LicenseTypeBasePrice, Constants.LicenseTypeLicenseIncluded)]
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets the Storage Size in GB for instance
        /// </summary>
        [Parameter(Mandatory = true,
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
        [PSArgumentCompleter(ManagedInstanceProxyOverride.Proxy, ManagedInstanceProxyOverride.Redirect, ManagedInstanceProxyOverride.Default)]
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
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Overriding to add warning message
        /// </summary>
        public override void ExecuteCmdlet()
        {
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
            else if (string.Equals(this.ParameterSetName, NewByEditionAndComputeGenerationParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                string editionShort = AzureSqlManagedInstanceAdapter.GetInstanceSkuPrefix(Edition);
                Sku.Name = editionShort + "_" + ComputeGeneration;
            }

            newEntity.Add(new Model.AzureSqlManagedInstanceModel()
            {
                Location = this.Location,
                ResourceGroupName = this.ResourceGroupName,
                FullyQualifiedDomainName = this.Name,
                AdministratorLogin = this.AdministratorCredential.UserName,
                AdministratorPassword = this.AdministratorCredential.Password,
                Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true),
                Identity = ResourceIdentityHelper.GetIdentityObjectFromType(this.AssignIdentity.IsPresent),
                LicenseType = this.LicenseType,
                StorageSizeInGB = this.StorageSizeInGB,
                SubnetId = this.SubnetId,
                VCores = this.VCore,
                Sku = Sku,
                Collation = this.Collation,
                PublicDataEndpointEnabled = this.PublicDataEndpointEnabled,
                ProxyOverride = this.ProxyOverride,
                TimezoneId = this.TimezoneId,
            });
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
