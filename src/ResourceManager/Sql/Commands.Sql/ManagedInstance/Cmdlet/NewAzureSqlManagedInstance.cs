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

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Cmdlet
{
    /// <summary>
    /// Defines the New-AzureSqlManagedInstance cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureRmSqlManagedInstance",
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedInstanceModel))]
    public class NewAzureSqlManagedInstance : ManagedInstanceCmdletBase
    {
        protected const string NewBySkuNameParameterSet =
            "NewBySkuNameParameterSetParameter";

        protected const string NewByEditionAndComputeGenerationParameterSet =
            "NewByEditionAndComputeGenerationParameterSet";

        /// <summary>
        /// Gets or sets the name of the managed instance name.
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "SQL Database Managed Instance name.")]
        [Alias("ManagedInstanceName")]
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
        /// Gets or sets the admin credential of the Managed instance
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The SQL authentication credential of the Managed Instance.")]
        [ValidateNotNull]
        public PSCredential AdministratorCredential { get; set; }

        /// <summary>
        /// The location in which to create the Managed instance
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The location in which to create the Managed instance")]
        [LocationCompleter("Microsoft.Sql/managedInstances")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Managed instance Subnet Id
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The Subnet Id to use for Managed instance creation")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        /// <summary>
        /// Gets or sets the Managed instance License Type
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Determines which License Type of Sql Azure Managed instance to use")]
        [PSArgumentCompleter(Constants.LicenseTypeBasePrice, Constants.LicenseTypeLicenseIncluded)]
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets the Storage Size in GB for Managed instance
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Determines how much Storage size to associate with Managed instance")]
        [ValidateNotNullOrEmpty]
        public int StorageSizeInGB { get; set; }

        /// <summary>
        /// Gets or sets the VCore for Managed instance
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Determines how much VCore to associate with Managed instance")]
        [ValidateNotNullOrEmpty]
        public int VCore { get; set; }

        /// <summary>
        /// Gets or sets the managed instance SKU name
        /// </summary>
        [Parameter(ParameterSetName = NewBySkuNameParameterSet,
            Mandatory = true,
            HelpMessage = "The SKU name for the Sql Azure Managed Instance e.g. 'GP_Gen4', 'BC_Gen4'.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.GeneralPurposeGen4, Constants.GeneralPurposeGen5, Constants.BusinessCriticalGen4, Constants.BusinessCriticalGen5)]
        public string SkuName { get; set; }

        /// <summary>
        /// Gets or sets the managed instance edition
        /// </summary>
        [Parameter(ParameterSetName = NewByEditionAndComputeGenerationParameterSet,
            Mandatory = true,
            HelpMessage = "The edition for the Sql Azure Managed Instance.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.GeneralPurposeEdition, Constants.BusinessCriticalEdition)]
        public string Edition { get; set; }

        /// <summary>
        /// Gets or sets the managed instance compute generation
        /// </summary>
        [Parameter(ParameterSetName = NewByEditionAndComputeGenerationParameterSet,
            Mandatory = true,
            HelpMessage = "The compute generation for the Sql Azure Managed Instance.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.ComputeGenerationGen4, Constants.ComputeGenerationGen5)]
        public string ComputeGeneration { get; set; }

        /// <summary>
        /// Gets or sets the tags to associate with the Azure Sql Managed Instance
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Azure Sql Managed Instance")]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Gets or sets whether or not to assign identity for Managed instance
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Generate and assign an Azure Active Directory Identity for this Managed instance for use with key management services like Azure KeyVault.")]
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
        /// Check to see if the managed instance already exists in this resource group.
        /// </summary>
        /// <returns>Null if the managed instance doesn't exist.  Otherwise throws exception</returns>
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
                    // This is what we want.  We looked and there is no managed instance with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // The managed instance already exists
            throw new PSArgumentException(
                string.Format(Microsoft.Azure.Commands.Sql.Properties.Resources.ServerNameExists, this.Name),
                "Name");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the managed instance doesn't exist yet</param>
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
                string editionShort = Edition.Equals(Constants.GeneralPurposeEdition) ? "GP" : Edition.Equals(Constants.BusinessCriticalEdition) ? "BC" : "Unknown";
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
                Sku = Sku
            });
            return newEntity;
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the managed instance
        /// </summary>
        /// <param name="entity">The managed instance to create</param>
        /// <returns>The created managed instance</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> PersistChanges(IEnumerable<Model.AzureSqlManagedInstanceModel> entity)
        {
            return new List<Model.AzureSqlManagedInstanceModel>() {
                ModelAdapter.UpsertManagedInstance(entity.First())
            };
        }
    }
}
