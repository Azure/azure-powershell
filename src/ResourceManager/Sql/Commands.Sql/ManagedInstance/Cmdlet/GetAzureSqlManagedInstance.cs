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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzSqlInstance cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstance",
        DefaultParameterSetName = GetByResourceGroupParameterSet),
        OutputType(typeof(AzureSqlManagedInstanceModel))]
    public class GetAzureSqlManagedInstance : ManagedInstanceCmdletBase
    {
        protected const string GetByNameAndResourceGroupParameterSet =
            "GetInstanceByNameAndResourceGroup";

        protected const string GetByResourceGroupParameterSet =
            "GetInstanceByResourceGroup";

        /// <summary>
        /// Gets or sets the name of the instance.
        /// </summary>
        [Parameter(ParameterSetName = GetByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the instance.")]
        [Alias("InstanceName")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group.
        /// </summary>
        [Parameter(ParameterSetName = GetByNameAndResourceGroupParameterSet, 
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the resource group.")]
        [Parameter(ParameterSetName = GetByResourceGroupParameterSet,
            Mandatory = false,
            Position = 1,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets an instance from the service.
        /// </summary>
        /// <returns>A single server</returns>
        protected override IEnumerable<AzureSqlManagedInstanceModel> GetEntity()
        {
            ICollection<AzureSqlManagedInstanceModel> results = null;

            if (string.Equals(this.ParameterSetName, GetByNameAndResourceGroupParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                results = new List<AzureSqlManagedInstanceModel>();
                results.Add(ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.Name));
            }
            else if (string.Equals(this.ParameterSetName, GetByResourceGroupParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                if (MyInvocation.BoundParameters.ContainsKey("ResourceGroupName"))
                {
                    results = ModelAdapter.ListManagedInstancesByResourceGroup(this.ResourceGroupName);
                }
                else
                {
                    results = ModelAdapter.ListManagedInstances();
                }
            }

            return results;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlManagedInstanceModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlManagedInstanceModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceModel> model)
        {
            return model;
        }
    }
}
