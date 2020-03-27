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
using System.Management.Automation;
using System.IO;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstanceOperation.Model;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceOperation.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzSqlInstance cmdlet
    /// </summary>
    [Cmdlet("Stop", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceOperation",
        DefaultParameterSetName = StopByNameAndManagedInstanceAndResourceGroupParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(AzureSqlManagedInstanceOperationModel))]
    public class StopAzureSqlManagedInstanceOperation : ManagedInstanceOperationCmdletBase
    {
        protected const string StopByNameAndManagedInstanceAndResourceGroupParameterSet =
            "StopByNameAndManagedInstanceAndResourceGroupParameterSet";

        protected const string StopByResourceIdParameterSet =
            "StopByResourceIdParameterSet";

        protected const string StopByInputObjectParameterSet =
            "StopByInputObjectParameterSet";


        /// <summary>
        /// Gets or sets the name of the operation to use.
        /// </summary>
        [Parameter(
            ParameterSetName = StopByNameAndManagedInstanceAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the operation.")]
        [Alias("OperationName")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstance/operations", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance to use.
        /// </summary>
        [Parameter(
            ParameterSetName = StopByNameAndManagedInstanceAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the instance.")]
        [ValidateNotNullOrEmpty]
        public string ManagedInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(ParameterSetName = StopByNameAndManagedInstanceAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 1,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the operation
        /// </summary>
        [Parameter(ParameterSetName = StopByResourceIdParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of operation object to stop")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Operation object to cancel
        /// </summary>
        [Parameter(ParameterSetName = StopByInputObjectParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "The operation to cancel")]
        [ValidateNotNullOrEmpty]
        [Alias("SqlInstanceOperation")]
        public AzureSqlManagedInstanceOperationModel InputObject { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets the entity to delete
        /// </summary>
        /// <returns>The entity going to be deleted</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceOperationModel> GetEntity()
        {
            return new List<Model.AzureSqlManagedInstanceOperationModel>() {
                ModelAdapter.GetManagedInstanceOperation(this.ResourceGroupName, this.ManagedInstanceName, System.Guid.Parse(this.Name))
            };
        }

        /// <summary>
        /// Apply user input.  Here nothing to apply
        /// </summary>
        /// <param name="model">The result of GetEntity</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceOperationModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlManagedInstanceOperationModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the instance.
        /// </summary>
        /// <param name="entity">The instance being deleted</param>
        /// <returns>The instance that was deleted</returns>
        protected override IEnumerable<Model.AzureSqlManagedInstanceOperationModel> PersistChanges(IEnumerable<Model.AzureSqlManagedInstanceOperationModel> entity)
        {
            ModelAdapter.CancelManagedInstanceOperation(this.ResourceGroupName, this.ManagedInstanceName, System.Guid.Parse(this.Name));
            return entity;
        }

        /// <summary>
        /// Entry point for the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (string.Equals(this.ParameterSetName, StopByInputObjectParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                ManagedInstanceName = InputObject.ManagedInstanceName;
                Name = InputObject.Name;
            }
            else if (string.Equals(this.ParameterSetName, StopByResourceIdParameterSet, System.StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);

                ResourceGroupName = resourceInfo.ResourceGroupName;
                ManagedInstanceName = resourceInfo.ParentResource.Split('/')[1];
                Name = resourceInfo.ResourceName;
            }

            if (!Force.IsPresent && !ShouldContinue(
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.StopAzureSqlInstanceOperationDescription, this.Name, this.ManagedInstanceName),
               string.Format(CultureInfo.InvariantCulture, Microsoft.Azure.Commands.Sql.Properties.Resources.StopAzureSqlInstanceOperationWarning, this.Name, this.ManagedInstanceName)))
            {
                return;
            }

            base.ExecuteCmdlet();
        }
    }
}
