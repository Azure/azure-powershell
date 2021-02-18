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

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Instance_Pools.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Sql.Instance_Pools.Cmdlet
{
    /// <summary>
    /// Defines the Remove-AzSqlInstancePool cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstancePool",
        SupportsShouldProcess = true, DefaultParameterSetName = DeleteByNameParameterSet)]
    [OutputType(typeof(AzureSqlInstancePoolModel))]
    public class RemoveAzureSqlInstancePool : InstancePoolCmdletBase
    {
        /// <summary>
        /// Parameter sets
        /// </summary>
        private const string DeleteByNameParameterSet = "DeleteByNameParameterSet";
        private const string DeleteByInputObjectParameterSet = "DeleteByInputObjectParameterSet";
        private const string DeleteByResourceIdParameterSet = "DeleteByResourceIdParameterSet";

        /// <summary>
        /// Gets or sets the instance pool input object
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The instance pool object to remove.",
            ValueFromPipeline = true,
            ParameterSetName = DeleteByInputObjectParameterSet)]
        [ValidateNotNullOrEmpty]
        public AzureSqlInstancePoolModel InputObject { get; set; }

        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The instance pool resource id to remove.",
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DeleteByResourceIdParameterSet)]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the resource group.",
            ParameterSetName = DeleteByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the instance pool name
        /// </summary>
        [Parameter(Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the instance pool.",
            ParameterSetName = DeleteByNameParameterSet)]
        [Alias("InstancePoolName")]
        [ResourceNameCompleter("Microsoft.Sql/instancePools", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
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
        /// Gets the entity to delete
        /// </summary>
        /// <returns>The entity going to be deleted</returns>
        protected override IEnumerable<AzureSqlInstancePoolModel> GetEntity()
        {
            try
            {
                WriteDebugWithTimestamp("InstancePoolName: {0}", Name);
                return new List<AzureSqlInstancePoolModel> { ModelAdapter.GetInstancePool(this.ResourceGroupName, this.Name) };
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // The agent doesn't exist
                    throw new PSArgumentException(
                        string.Format(Properties.Resources.AzureSqlInstancePoolNotExists, this.Name),
                        "InstancePoolName");
                }

                // Unexpected exception encountered
                throw;
            }
        }

        /// <summary>
        /// Apply user input.  Here nothing to apply
        /// </summary>
        /// <param name="model">The result of GetEntity</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlInstancePoolModel> ApplyUserInputToModel(IEnumerable<AzureSqlInstancePoolModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the agent.
        /// </summary>
        /// <param name="entity">The job account being deleted</param>
        /// <returns>The job account that was deleted</returns>
        protected override IEnumerable<AzureSqlInstancePoolModel> PersistChanges(IEnumerable<AzureSqlInstancePoolModel> entity)
        {
            var existingEntity = entity.First();
            ModelAdapter.RemoveInstancePool(existingEntity.ResourceGroupName, existingEntity.InstancePoolName);
            return entity;
        }
    }
}
