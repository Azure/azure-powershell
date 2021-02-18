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
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.Instance_Pools.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.Sql.Instance_Pools.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzRmSqlInstancePool cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstancePool", DefaultParameterSetName = ListBySubOrResourceGroupParameterSet)]
    [OutputType(typeof(AzureSqlInstancePoolModel))]
    public class GetAzureSqlInstancePool : InstancePoolCmdletBase
    {
        /// <summary>
        /// Parameter setss
        /// </summary>
        private const string ListBySubOrResourceGroupParameterSet = "ListBySubOrResourceGroupParameterSet";
        private const string GetInstancePoolDefaultParameterSet = "ListByInstancePoolDefaultsParameterSet";
        private const string GetInstancePoolByInstancePoolResourceIdentifierParameterSet = "GetInstancePoolByInstancePoolResourceIdentifierParameterSet";

        /// <summary>
        /// Gets or sets the resource group name
        /// </summary>
        [Parameter(
            ParameterSetName = ListBySubOrResourceGroupParameterSet,
            Mandatory = false,
            HelpMessage = "The resource group name.")]
        [Parameter(
            ParameterSetName = GetInstancePoolDefaultParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the instance pool name
        /// </summary>
        [Parameter(
            ParameterSetName = GetInstancePoolDefaultParameterSet,
            Position = 1,
            Mandatory = true,
            HelpMessage = "The instance pool name.")]
        [Alias("InstancePoolName")]
        [ResourceNameCompleter("Microsoft.Sql/instancePools", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the instance pool resource identifier.s
        /// </summary>
        [Parameter(
            ParameterSetName = GetInstancePoolByInstancePoolResourceIdentifierParameterSet,
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The instance pool resource identifier.")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Gets an instance pool from the service.
        /// </summary>
        /// <returns>A single instance pool</returns>
        protected override IEnumerable<AzureSqlInstancePoolModel> GetEntity()
        {
            ICollection<AzureSqlInstancePoolModel> results = new List<AzureSqlInstancePoolModel>();

            // List by subscription id
            if (this.ResourceGroupName == null && this.Name == null)
            {
                results = ModelAdapter.List();
            }
            // List by resource group
            else if (this.ResourceGroupName != null && this.Name == null)
            {
                results = ModelAdapter.ListInstancePoolsByResourceGroup(this.ResourceGroupName);
            }
            // Get a specific instance pool
            else
            {
                results.Add(ModelAdapter.GetInstancePool(this.ResourceGroupName, this.Name));
            }

            return results;
        }

        /// <summary>
        /// No changes, nothing to persist
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlInstancePoolModel> PersistChanges(
            IEnumerable<AzureSqlInstancePoolModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to the model
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlInstancePoolModel> ApplyUserInputToModel(
            IEnumerable<AzureSqlInstancePoolModel> model)
        {
            return model;
        }
    }
}