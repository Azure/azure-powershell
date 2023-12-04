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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Model;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Commands.Sql.ManagedInstance.Adapter;

namespace Microsoft.Azure.Commands.Sql.ManagedInstance.Cmdlet
{
    /// <summary>
    /// Defines the Stop-AzSqlInstance cmdlet
    /// </summary>
    [Cmdlet(VerbsLifecycle.Stop, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstance",
        DefaultParameterSetName = StopByNameAndResourceGroupParameterSet,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class StopAzureSqlManagedInstance : AzureSqlCmdletBase<AzureSqlManagedInstanceModel, AzureSqlManagedInstanceAdapter>
    {
        protected const string StopByNameAndResourceGroupParameterSet =
            "StopInstanceFromInputParameters";

        protected const string StopByInputObjectParameterSet =
            "StopInstanceFromAzureSqlManagedInstanceModelInstanceDefinition";

        protected const string StopByResourceIdParameterSet =
            "StopInstanceFromAzureResourceId";


        /// <summary>
        /// Gets or sets the name of the instance to use.
        /// </summary>
        [Parameter(
            ParameterSetName = StopByNameAndResourceGroupParameterSet,
            Mandatory = true,
            Position = 0,
            HelpMessage = "The name of the instance.")]
        [Alias("InstanceName")]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Instance object to Stop
        /// </summary>
        [Parameter(ParameterSetName = StopByInputObjectParameterSet, Mandatory = true, Position = 0, ValueFromPipeline = true, HelpMessage = "The instance object to Stop")]
        [ValidateNotNullOrEmpty]
        [Alias("SqlInstance")]
        public AzureSqlManagedInstanceModel InputObject { get; set; }

        /// <summary>
        /// Gets or sets the resource id of the instance
        /// </summary>
        [Parameter(ParameterSetName = StopByResourceIdParameterSet, Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource id of instance object to Stop")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Gets the entity to delete
        /// </summary>
        /// <returns>The entity going to be deleted</returns>
        protected override AzureSqlManagedInstanceModel GetEntity()
        {
            if (string.Equals(ParameterSetName, StopByInputObjectParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                ResourceGroupName = InputObject.ResourceGroupName;
                Name = InputObject.ManagedInstanceName;
            }
            else if (string.Equals(ParameterSetName, StopByResourceIdParameterSet, StringComparison.OrdinalIgnoreCase))
            {
                var resourceInfo = new ResourceIdentifier(ResourceId);

                ResourceGroupName = resourceInfo.ResourceGroupName;
                Name = resourceInfo.ResourceName;
            }
            return ModelAdapter.GetManagedInstance(ResourceGroupName, Name);
        }

        protected override void ConfirmAction(string processMessage, string target, Action action)
        {
            base.ConfirmAction(Force, "Are you sure you want to stop Azure SQL Managed instance?", processMessage, target, action);
        }

        /// <summary>
        /// Stops the instance.
        /// </summary>
        /// <param name="entity">The instance being deleted</param>
        /// <returns>The instance that was deleted</returns>
        protected override AzureSqlManagedInstanceModel PersistChanges(AzureSqlManagedInstanceModel entity)
        {
            ModelAdapter.StopManagedInstance(ResourceGroupName, Name);

            return entity;
        }

        protected override AzureSqlManagedInstanceAdapter InitModelAdapter()
        {
            return new AzureSqlManagedInstanceAdapter(DefaultContext);
        }

        protected override bool WriteResult()
        {
            return false;
        }
    }
}
