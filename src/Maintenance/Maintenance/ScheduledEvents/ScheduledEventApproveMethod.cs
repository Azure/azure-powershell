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
using Microsoft.Azure.Management.Maintenance;
using Microsoft.Azure.Management.Maintenance.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Maintenance
{
    [Cmdlet(VerbsLifecycle.Approve, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledEvent", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType(typeof(ScheduledEventsApproveResponse), typeof(MaintenanceError))]
    public partial class ApproveAzureRmScheduledEvent : MaintenanceAutomationBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName = NormalizeRequiredValue(this.ResourceGroupName, nameof(ResourceGroupName));
                string resourceType = NormalizeRequiredValue(this.ResourceType, nameof(ResourceType));
                string resourceName = NormalizeRequiredValue(this.ResourceName, nameof(ResourceName));
                string scheduledEventId = NormalizeScheduledEventId(this.ScheduledEventId, nameof(ScheduledEventId));
                string target = $"resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/scheduledEvents/{scheduledEventId}";

                if (ShouldProcess(target, VerbsLifecycle.Approve))
                {
                    try
                    {
                        ScheduledEventsApproveResponse response = ScheduledEventsClient.Acknowledge(
                            resourceGroupName,
                            resourceType,
                            resourceName,
                            scheduledEventId);
                        WriteObject(response);
                    }
                    catch (MaintenanceErrorException exception)
                    {
                        WriteObject(exception.Body ?? new MaintenanceError(
                            new Microsoft.Azure.Management.Maintenance.Models.ErrorDetails(
                                exception.Response?.StatusCode.ToString(),
                                exception.Message)));
                    }
                }
            });
        }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 0,
            Mandatory = true,
            HelpMessage = "The resource Group Name.",
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 1,
            Mandatory = true,
            HelpMessage = "The Microsoft.Compute resource type that owns the ScheduledEvents. Supported values are virtualMachines, virtualMachineScaleSets, and availabilitySets.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceType { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 2,
            Mandatory = true,
            HelpMessage = "The resource name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 3,
            Mandatory = true,
            HelpMessage = "The ScheduledEvents ID.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ScheduledEventId { get; set; }
    }
}
