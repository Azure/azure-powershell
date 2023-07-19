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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceSchedule.Cmdlet
{
    /// <summary>
    /// Defines the New-AzSqlInstanceSchedule cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceStartStopSchedule",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DefaultParameterSet),
        OutputType(typeof(AzureSqlManagedInstanceScheduleModel))]
    public class NewAzureSqlManagedInstanceSchedule : ManagedInstanceScheduleCmdletBase<AzureSqlManagedInstanceScheduleModel>
    {
        private const string DefaultParameterSet = "NewInstanceScheduleInputParameters";
        private const string InstanceModelParameterSet = "NewInstanceScheduleByInstanceModelInputParameters";

        /// <summary>
        /// Gets or sets the name of the resource group to use.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = DefaultParameterSet, HelpMessage = "The name of the Azure SQL Managed Instance", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Sql/managedInstances", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string InstanceName { get; set; }

        /// <summary>
        /// Gets or sets timezone
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The name of the timezone for the schedule. Please refer to https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.management/get-timezone?view=powershell-7.3#examples for valid values.")]
        [ValidateNotNullOrEmpty]
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets schedule items
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Array of valid SheduleItem objects.")]
        public ScheduleItem[] ScheduleList { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The description of the schedule.")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the instance model.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = InstanceModelParameterSet, ValueFromPipeline = true, HelpMessage = "Instance model input object.")]
        public AzureSqlManagedInstanceModel InstanceModel { get; set; }


        /// <summary>
        /// Defines whether it is ok to skip the requesting of rule removal confirmation
        /// </summary>
        [Parameter(HelpMessage = "Skip confirmation message for performing the action")]
        public SwitchParameter Force { get; set; }


        protected override AzureSqlManagedInstanceScheduleModel GetEntity()
        {
            if (ParameterSetName == InstanceModelParameterSet)
            {
                InstanceName = InstanceModel.ManagedInstanceName;
                ResourceGroupName = InstanceModel.ResourceGroupName;
            }

            return null;
        }

        protected override AzureSqlManagedInstanceScheduleModel PersistChanges(AzureSqlManagedInstanceScheduleModel entity)
        {
            if (Force || ShouldContinue("Are you sure you want to create start/stop schedule? The new schedule will replace existing one.", "Removing start/stop schedule"))
            {
                return ModelAdapter.CreateOrUpdateSchedule(ResourceGroupName, InstanceName, TimeZone, Description, ScheduleList);
            }

            return null;
        }

        protected override string GetConfirmActionProcessMessage()
        {
            return "Creating new start/stop schedule for an Azure SQL Managed Instance.";
        }

        protected override string GetResourceId(AzureSqlManagedInstanceScheduleModel model)
        {
            return $"{ResourceGroupName}/{InstanceName}";
        }
    }
}
