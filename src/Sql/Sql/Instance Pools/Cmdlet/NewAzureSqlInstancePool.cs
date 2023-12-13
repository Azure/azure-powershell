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

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Instance_Pools.Model;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.Sql.Instance_Pools.Cmdlet
{
    /// <summary>
    /// Defines the New-AzSqlInstancePool cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstancePool",
        SupportsShouldProcess = true)]
    [OutputType(typeof(AzureSqlInstancePoolModel))]
    public class NewAzureSqlInstancePool : InstancePoolCmdletBase
    {
        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the instance pool name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the instance pool.")]
        [Alias("InstancePoolName")]
        [ResourceNameCompleter("Microsoft.Sql/instancePools", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// The location to create the instance pool
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The location to create the instance pool.")]
        [LocationCompleter("Microsoft.Sql/locations/instancePools")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the instance subnet id
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The subnet id to use for instance pool creation.")]
        [ValidateNotNullOrEmpty]
        public string SubnetId { get; set; }

        /// <summary>
        /// Gets or sets the VCore for instance
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Determines how much VCore to associate with instance.")]
        [ValidateNotNullOrEmpty]
        [Alias("VCores")]
        [PSArgumentCompleter("8", "16", "24", "32", "40", "64", "80")]
        public int VCore { get; set; }

        /// <summary>
        /// Gets or sets the instance edition
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The edition for the instance pool.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.GeneralPurposeEdition)]
        public string Edition { get; set; }

        /// <summary>
        /// Gets or sets the instance compute generation
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The compute generation for the instance pool.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter(Constants.ComputeGenerationGen5)]
        public string ComputeGeneration { get; set; }

        /// <summary>
        /// Gets or sets the instance License Type
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Determines which License Type to use. Possible values are BasePrice (with AHB discount) and LicenseIncluded (without AHB discount).")]
        [PSArgumentCompleter(Constants.LicenseTypeBasePrice, Constants.LicenseTypeLicenseIncluded)]
        public string LicenseType { get; set; }

        /// <summary>
        /// Gets or sets the tags to associate with the instance pool
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The tags to associate with the instance")]
        [Alias("Tags")]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Gets or sets the maintenance configuration id.
        /// </summary>
        [Parameter(Mandatory = false,
            HelpMessage = "The maintenance configuration id to associate with the instance")]
        public string MaintenanceConfigurationId { get; set; }

        /// <summary>
        /// Overriding to add warning message
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Check to see if the instance pool already exists in the resource group
        /// </summary>
        /// <returns>Null if the instance pool doesn't exist. Otherwise throws exception</returns>
        protected override IEnumerable<AzureSqlInstancePoolModel> GetEntity()
        {
            try
            {
                ModelAdapter.GetInstancePool(this.ResourceGroupName, this.Name);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // This is what we want.  We looked and there is no instance pool with this name.
                    return null;
                }

                // Unexpected exception encountered
                throw;
            }

            // Instance pool already exists - should not be able to create
            throw new PSArgumentException(
                string.Format(Properties.Resources.AzureSqlInstancePoolExists, this.Name), "InstancePoolName");
        }

        /// <summary>
        /// Generates the model from user input.
        /// </summary>
        /// <param name="model">This is null since the instance pool doesn't exist yet</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureSqlInstancePoolModel> ApplyUserInputToModel
            (IEnumerable<AzureSqlInstancePoolModel> model)
        {
            string editionShort = Edition.Equals(Constants.GeneralPurposeEdition) ? "GP" :
                Edition.Equals(Constants.BusinessCriticalEdition) ? "BC" : "Unknown";
            string skuName = editionShort + "_" + ComputeGeneration;

            AzureSqlInstancePoolModel newEntity = new AzureSqlInstancePoolModel
            {
                Location = this.Location,
                ResourceGroupName = this.ResourceGroupName,
                InstancePoolName = this.Name,
                Tags = TagsConversionHelper.CreateTagDictionary(Tag, validate: true),
                Sku = new Sku()
                {
                    Name = skuName,
                    Tier = Edition,
                    Family = ComputeGeneration
                },
                SubnetId = SubnetId,
                VCores = VCore,
                LicenseType = LicenseType,
                MaintenanceConfigurationId = this.MaintenanceConfigurationId,
            };

            return new List<AzureSqlInstancePoolModel> { newEntity };
        }

        /// <summary>
        /// Sends the changes to the service -> Creates the instance pool
        /// </summary>
        /// <param name="entity">The instance pool to create</param>
        /// <returns>The created instance pool</returns>
        protected override IEnumerable<AzureSqlInstancePoolModel> PersistChanges(IEnumerable<AzureSqlInstancePoolModel> entity)
        {
            return new List<AzureSqlInstancePoolModel>
            {
                ModelAdapter.UpsertInstancePool(entity.First())
            };
        }
    }
}