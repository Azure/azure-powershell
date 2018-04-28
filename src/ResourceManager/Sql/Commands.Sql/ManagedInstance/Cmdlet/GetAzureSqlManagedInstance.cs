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
    /// Defines the Get-ManagedInstance cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSqlManagedInstance", ConfirmImpact = ConfirmImpact.None)]
    public class GetAzureSqlManagedInstance : ManagedInstanceCmdletBase
    {
        protected const string GetByNameAndResourceGroupParameterSet =
            "GetManagedInstanceFromInputParameters";

        protected const string GetByResourceIdParameterSet =
            "GetManagedInstanceFromAzureResourceId";

        /// <summary>
        /// Gets or sets the name of the resource group.
        /// </summary>
        [Parameter(ParameterSetName = GetByNameAndResourceGroupParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the name of the managed instance.
        /// </summary>
        [Parameter(ParameterSetName = GetByNameAndResourceGroupParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "SQL managed instance name.")]
        [Alias("Name")]
        [ValidateNotNullOrEmpty]
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the Managed instance
        /// </summary>
        [Parameter(ParameterSetName = GetByResourceIdParameterSet,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of Managed instance object to get")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets a managed instance from the service.
        /// </summary>
        /// <returns>A single server</returns>
        protected override IEnumerable<AzureSqlManagedInstanceModel> GetEntity()
        {
            ICollection<AzureSqlManagedInstanceModel> results = null;

            if (string.Equals(this.ParameterSetName, GetByResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);

                ResourceGroupName = resourceInfo.ResourceGroupName;
                ManagedInstanceName = resourceInfo.ResourceName;

                results = new List<AzureSqlManagedInstanceModel>();
                results.Add(ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.ManagedInstanceName));
            }
            else if (MyInvocation.BoundParameters.ContainsKey("ManagedInstanceName") && MyInvocation.BoundParameters.ContainsKey("ResourceGroupName"))
            {
                results = new List<AzureSqlManagedInstanceModel>();
                results.Add(ModelAdapter.GetManagedInstance(this.ResourceGroupName, this.ManagedInstanceName));
            }
            else if (MyInvocation.BoundParameters.ContainsKey("ResourceGroupName"))
            {
                results = ModelAdapter.ListManagedInstancesByResourceGroup(this.ResourceGroupName);
            }
            else if (!MyInvocation.BoundParameters.ContainsKey("ManagedInstanceName"))
            {
                results = ModelAdapter.ListManagedInstances();
            }
            else
            {
                throw new PSArgumentException("When specifying the managedInstanceName parameter the ResourceGroup parameter must also be used");
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
