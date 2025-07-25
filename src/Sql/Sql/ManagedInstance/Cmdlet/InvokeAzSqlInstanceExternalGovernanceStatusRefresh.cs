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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Cmdlet
{
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceExternalGovernanceStatusRefresh", SupportsShouldProcess = true, DefaultParameterSetName = InvokeByNameParameterSet), OutputType(typeof(RefreshExternalGovernanceMIModel))]
    public class InvokeAzSqlInstanceExternalGovernanceStatusRefresh : AzureSqlInstanceRefreshExternalGovernanceCmdletBase
    {
        private const string InvokeByNameParameterSet = "InvokeByNameParameterSet";
        private const string InvokeByParentObjectParameterSet = "InvokeByParentObjectParameterSet";
        private const string InvokeByResourceIdParameterSet = "InvokeByResourceIdParameterSet";
        
        /// <summary>
        /// Sets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = InvokeByNameParameterSet, Position = 0,
            HelpMessage = "Name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public override string ResourceGroupName { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the Azure Sql Managed Instance to use
        /// </summary>
        [Parameter(Mandatory = true,
            ParameterSetName = InvokeByNameParameterSet,
            Position = 1,
            HelpMessage = "The Azure Sql managed instance name.")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }
        
        /// <summary>
        /// Sets the instance Object
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = InvokeByParentObjectParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Input object of the managed instance.")]
        [ValidateNotNullOrEmpty]
        public AzureSqlManagedInstanceModel InstanceObject { get; set; }
        
        /// <summary>
        /// Sets the instance resource id
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = InvokeByResourceIdParameterSet, ValueFromPipeline = true, Position = 0, HelpMessage = "Resource ID of the managed instance DTC.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }
        
        /// <summary>
        /// Get the refresh external governance status.
        /// </summary>
        /// <returns>Refresh external governance status.</returns>
        protected override RefreshExternalGovernanceMIModel GetEntity()
        {
            return new RefreshExternalGovernanceMIModel();
        }

        public override void ExecuteCmdlet()
        {
            switch (ParameterSetName)
            {
                case InvokeByParentObjectParameterSet:
                    ResourceGroupName = InstanceObject.ResourceGroupName;
                    InstanceName = InstanceObject.ManagedInstanceName;
                    break;
                case InvokeByResourceIdParameterSet:
                    var identifier = new ResourceIdentifier(ResourceId);
                    ResourceGroupName = identifier.ResourceGroupName;
                    InstanceName = identifier.ResourceName;
                    break;
            }
            
            base.ExecuteCmdlet();
        }

        /// <summary>
        /// Apply user input to model.
        /// </summary>
        /// <param name="model">The result of the get operation</param>
        /// <returns>The model to send to the update</returns>
        protected override RefreshExternalGovernanceMIModel ApplyUserInputToModel(RefreshExternalGovernanceMIModel model)
        {
            model.ResourceGroupName = ResourceGroupName;
            model.InstanceName = InstanceName;
            return model;
        }

        /// <summary>
        /// Sends the refresh external governance status to the service.
        /// </summary>
        /// <param name="entity">The refresh external governance entity.</param>
        /// <returns>The response object from the service</returns>
        protected override RefreshExternalGovernanceMIModel PersistChanges(RefreshExternalGovernanceMIModel entity)
        {
            return ModelAdapter.RefreshExternalGovernanceStatus(entity.ResourceGroupName, entity.InstanceName);
        }
    }
}
