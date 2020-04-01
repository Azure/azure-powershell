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
using Microsoft.Azure.Commands.Sql.Instance_Pools.Model;
using Microsoft.Azure.Commands.Sql.ManagedInstanceOperation.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceOperation.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzSqlInstance cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceOperation",
        DefaultParameterSetName = DefaultParameterSet),
        OutputType(typeof(AzureSqlManagedInstanceOperationModel))]
    public class GetAzureSqlManagedInstanceOperation : ManagedInstanceOperationCmdletBase
    {
        /// <summary>
        /// Parameter sets
        /// </summary>
        protected const string DefaultParameterSet = "DefaultParameterSet";
        protected const string ListByManagedInstanceParameterSet = "ListByManagedInstanceParameterSet";
        protected const string GetByManagedInstanceOperationResourceIdentifierParameterSet = "GetByManagedInstanceOperationResourceIdentifierParameterSet";

        /// <summary>
        /// Gets or sets the managed instance operation resource id
        /// </summary>
        [Parameter(ParameterSetName = GetByManagedInstanceOperationResourceIdentifierParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The managed instance operation resource identifier.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceIdCompleter("Microsoft.Sql/managedInstance/operations")]
        public string ResourceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the operation.
        /// </summary>
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = false,
            HelpMessage = "The name of the operation.")]
        [Alias("OperationName")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstance/operations", "OperationName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance.
        /// </summary>
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            HelpMessage = "The name of the instance.")]
        [Parameter(
            ParameterSetName = ListByManagedInstanceParameterSet,
            Mandatory = true,
            HelpMessage = "The name of the instance.")]
        [Alias("InstanceName")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstance/operations", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group.
        /// </summary>
        [Parameter(ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            HelpMessage = "The name of the resource group.")]
        [Parameter(ParameterSetName = ListByManagedInstanceParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceId = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceId.ResourceGroupName;
                this.ManagedInstanceName = resourceId.ParentResource.Split('/')[1];
                this.Name = resourceId.ResourceName;
            }

            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Gets an instance from the service.
        /// </summary>
        /// <returns>A single server</returns>
        protected override IEnumerable<AzureSqlManagedInstanceOperationModel> GetEntity()
        {
            ICollection<AzureSqlManagedInstanceOperationModel> results = new List<AzureSqlManagedInstanceOperationModel>();

            if (ParameterSetName == GetByManagedInstanceOperationResourceIdentifierParameterSet || (MyInvocation.BoundParameters.ContainsKey("Name") && !WildcardPattern.ContainsWildcardCharacters(Name)))
            {
                results.Add(ModelAdapter.GetManagedInstanceOperation(this.ResourceGroupName, this.ManagedInstanceName, System.Guid.Parse(this.Name)));
            }
            else
            {
                results = ModelAdapter.ListOperationsByManagedInstance(this.ResourceGroupName, this.ManagedInstanceName);
            }

            return results;
        }

        /// <summary>
        /// No changes, thus nothing to persist.
        /// </summary>
        /// <param name="entity">The entity retrieved</param>
        /// <returns>The unchanged entity</returns>
        protected override IEnumerable<AzureSqlManagedInstanceOperationModel> PersistChanges(IEnumerable<AzureSqlManagedInstanceOperationModel> entity)
        {
            return entity;
        }

        /// <summary>
        /// No user input to apply to model.
        /// </summary>
        /// <param name="model">The model to modify</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<AzureSqlManagedInstanceOperationModel> ApplyUserInputToModel(IEnumerable<AzureSqlManagedInstanceOperationModel> model)
        {
            return model;
        }
    }
}
