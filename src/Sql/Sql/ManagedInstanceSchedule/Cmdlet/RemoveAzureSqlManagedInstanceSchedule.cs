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
using Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Model;
using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Cmdlet
{
    /// <summary>
    /// Defines the Get-AzSqlInstance cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceStartStopSchedule",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet),
        OutputType(typeof(bool))]
    public class RemoveAzureSqlManagedInstanceSchedule : ManagedInstanceScheduleCmdletBase<bool>
    {
        private const string DefaultParameterSet = "GetInstanceScheduleInputParameters";
        private const string InstanceModelParameterSet = "GetInstanceScheduleByInstanceModelInputParameters";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, HelpMessage = "The name of the Azure SQL Managed Instance", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets the instance model.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = InstanceModelParameterSet, ValueFromPipeline = true, HelpMessage = "Instance model input object.")]
        public AzureSqlManagedInstanceModel InstanceModel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to receive output from a cmdlet which does not return anything.")]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }


        protected override bool GetEntity()
        {
            if (ParameterSetName == InstanceModelParameterSet)
            {
                InstanceName = InstanceModel.ManagedInstanceName;
                ResourceGroupName = InstanceModel.ResourceGroupName;
            }

            return false;
        }

        protected override bool PersistChanges(bool entity)
        {
            if (Force || ShouldContinue("Are you sure you want to remove start/stop schedule?", "Removing start/stop schedule"))
            {
                ModelAdapter.RemoveSchedule(ResourceGroupName, InstanceName);
            }

            return true;
        }

        protected override string GetConfirmActionProcessMessage()
        {
            return "You are about to remove start/stop schedule of a Azure SQL Managed Instance.";
        }

        protected override string GetResourceId(bool model)
        {
            return $"{ResourceGroupName}/{InstanceName}";
        }

        protected override bool WriteResult()
        {
            return PassThru.IsPresent;
        }
    }
}
