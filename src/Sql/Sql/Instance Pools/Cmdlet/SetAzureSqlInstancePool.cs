﻿// ----------------------------------------------------------------------------------
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
using Hyak.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.Instance_Pools.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Sql.Instance_Pools.Cmdlet
{
    /// <summary>
    /// Defines the Set-AzSqlInstancePool cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstancePool",
            SupportsShouldProcess = true, DefaultParameterSetName = DefaultSetInstancePoolParameterSet)]
    [OutputType(typeof(AzureSqlInstancePoolModel))]
    public class SetAzureSqlInstancePool : InstancePoolCmdletBase
    {
        /// <summary>
        /// Parameter sets
        /// </summary>
        private const string InputObjectSetInstancePoolParameterSet = "InputObjectSetInstancePoolParameterSet";
        private const string ResourceIdSetInstancePoolParameterSet = "ResourceIdSetInstancePoolParameterSet";
        private const string DefaultSetInstancePoolParameterSet = "DefaultSetInstancePoolParameterSet";

        /// <summary>
        /// Gets or sets the azure sql instance pool input object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = InputObjectSetInstancePoolParameterSet,
            HelpMessage = "The instance pool input object.",
            ValueFromPipeline = true)]
        public AzureSqlInstancePoolModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the azure sql instance pool resource identifer
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ResourceIdSetInstancePoolParameterSet,
            HelpMessage = "The instance pool resource identifier.",
            ValueFromPipelineByPropertyName = true)]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = DefaultSetInstancePoolParameterSet,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the instance pool name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            ParameterSetName = DefaultSetInstancePoolParameterSet,
            HelpMessage = "The name of the instance pool.")]
        [Alias("InstancePoolName")]
        [ResourceNameCompleter("Microsoft.Sql/instancePools", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the instance License Type
        /// </summary>
        [Parameter(Mandatory = false,
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
        /// Overriding to add warning message
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.InputObject))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.InstancePoolName;
            }

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Check to see if the instance pool already exists in the resource group
        /// </summary>
        /// <returns>Null if the instance pool exists. Otherwise throws exception</returns>
        protected override IEnumerable<AzureSqlInstancePoolModel> GetEntity()
        {
            try
            {
                return new List<AzureSqlInstancePoolModel> {
                    ModelAdapter.GetInstancePool(this.ResourceGroupName, this.Name)
                };
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // Instance pool already exists - should not be able to create
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureSqlInstancePoolNotExists, this.Name), "InstancePoolName");
                }

                // Unexpected exception encountered
                throw;
            }
        }
        /// <summary>
        /// Generates the updated model from user input.
        /// </summary>
        /// <param name="existingEntity">The existing instance pool model</param>
        /// <returns>The generated model from user input</returns>
        protected override IEnumerable<AzureSqlInstancePoolModel> ApplyUserInputToModel(IEnumerable<AzureSqlInstancePoolModel> model)
        {
            var existingEntity = model.FirstOrDefault();

            AzureSqlInstancePoolModel newEntity = new AzureSqlInstancePoolModel
            {
                Location = existingEntity.Location,
                ResourceGroupName = this.ResourceGroupName,
                InstancePoolName = this.Name,
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true),
                Sku = existingEntity.Sku,
                SubnetId = existingEntity.SubnetId,
                VCores = existingEntity.VCores,
                LicenseType = LicenseType != null ? this.LicenseType : existingEntity.LicenseType,
            };

            return new List<AzureSqlInstancePoolModel> { newEntity };
        }

        /// <summary>
        /// Sends the changes to the service -> Updates the instance pool
        /// </summary>
        /// <param name="entity">The instance pool to update</param>
        /// <returns>The updated instance pool</returns>
        protected override IEnumerable<AzureSqlInstancePoolModel> PersistChanges(IEnumerable<AzureSqlInstancePoolModel> entity)
        {
            return new List<AzureSqlInstancePoolModel>
            {
                ModelAdapter.UpsertInstancePool(entity.First())
            };
        }
    }
}
