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
using System.Linq;
using System.Management.Automation;
using System.Security;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Cmdlet
{
    /// <summary>
    /// Defines the Update-AzureRmSqlManagedInstance cmdlet
    /// </summary>
    [Cmdlet(VerbsData.Update, "AzureRmSqlManagedInstance",
        SupportsShouldProcess = true,
        ConfirmImpact = ConfirmImpact.Medium)]
    public class UpdateAzureSqlManagedInstance : ManagedInstanceCmdletBase
    {
        protected const string UpdateByNameAndResourceGroupParameterSet =
            "Update a Managed Instance from cmdlet input parameters";

        protected const string UpdateByInputObjectParameterSet =
            "Update a Managed Instance from AzureSqlManagedInstanceModel instance definition";

        protected const string UpdateByResourceIdParameterSet =
            "Update a Managed Instance from an Azure resource id";

        /// <summary>
        /// Gets or sets the name of the Managed instance to use.
        /// </summary>
        [Parameter(
            ParameterSetName = UpdateByNameAndResourceGroupParameterSet, 
            Mandatory = true,
            Position = 0,
            HelpMessage = "SQL Database Managed instance name.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(ParameterSetName = UpdateByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// The new SQL administrator password for the Managed instance.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The new SQL administrator password for the Managed instance.")]
        [ValidateNotNull]
        public SecureString AdministratorPassword { get; set; }

        /// <summary>
        /// Gets or sets the Managed instance License Type
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Determines which License Type of Sql Azure Managed Instance to use")]
        [ValidateSet(Constants.LicenseTypeBasePrice, Constants.LicenseTypeLicenseIncluded, IgnoreCase = false)]
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets the Storage Size in GB for Managed instance
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Determines how much Storage size to associate with Managed instance")]
        public int? StorageSizeInGB { get; set; }

        /// <summary>
        /// Gets or sets the VCores for Managed instance
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "Determines how much VCores to associate with Managed instance")]
        public int? VCoreCount { get; set; }

        /// <summary>
        /// The tags to associate with the Managed instance.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the Managed instance.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Generate and assign an Azure Active Directory Identity for this Managed instance for use with key management services like Azure KeyVault.")]
        public SwitchParameter AssignIdentity { get; set; }

        /// <summary>
        /// AzureSqlManagedInstanceModel object to remove
        /// </summary>
        [Parameter(ParameterSetName = UpdateByInputObjectParameterSet,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The AzureSqlManagedInstanceModel object to remove")]
        [ValidateNotNullOrEmpty]
        public Model.AzureSqlManagedInstanceModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the Managed instance
        /// </summary>
        [Parameter(ParameterSetName = UpdateByResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the Managed instance to remove")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }
        
        /// <summary>
        /// Get the Managed instance to update
        /// </summary>
        /// <returns>The Managed instance being updated</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> GetEntity()
        {
            return new List<Model.AzureSqlManagedInstanceModel>() { ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.ManagedInstanceName) };
        }

        /// <summary>
        /// Constructs the model to send to the update API
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlManagedInstanceModel> model)
        {
            if (string.Equals(this.ParameterSetName, UpdateByInputObjectParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                ManagedInstanceName = InputObject.ManagedInstanceName;
            }
            else if (string.Equals(this.ParameterSetName, UpdateByResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);

                ResourceGroupName = resourceInfo.ResourceGroupName;
                ManagedInstanceName = resourceInfo.ResourceName;
            }

            // Construct a new entity so we only send the relevant data to the Managed instance
            List<Model.AzureSqlManagedInstanceModel> updateData = new List<Model.AzureSqlManagedInstanceModel>();
            updateData.Add(new Model.AzureSqlManagedInstanceModel()
            {
                ResourceGroupName = this.ResourceGroupName,
                Location = model.FirstOrDefault().Location,
                FullyQualifiedDomainName = this.ManagedInstanceName,
                AdministratorPassword = this.AdministratorPassword,
                LicenseType = this.LicenseType,
                StorageSizeInGB = this.StorageSizeInGB,
                VCores = this.VCoreCount,
                Tags = TagsConversionHelper.ReadOrFetchTags(this, model.FirstOrDefault().Tags),
                Identity = model.FirstOrDefault().Identity ?? ResourceIdentityHelper.GetIdentityObjectFromType(this.AssignIdentity.IsPresent),
            });
            return updateData;
        }

        /// <summary>
        /// Sends the Managed instance update request to the service
        /// </summary>
        /// <param name="entity">The update parameters</param>
        /// <returns>The response object from the service</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceModel> PersistChanges(IEnumerable<Model.AzureSqlManagedInstanceModel> entity)
        {
            return new List<Model.AzureSqlManagedInstanceModel>() { ModelAdapter.UpdateManagedInstance(entity.First()) };
        }
    }
}
