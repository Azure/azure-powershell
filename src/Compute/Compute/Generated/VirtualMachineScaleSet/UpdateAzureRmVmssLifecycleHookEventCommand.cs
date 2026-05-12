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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsData.Update, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmssLifecycleHookEvent",
        SupportsShouldProcess = true, DefaultParameterSetName = ByNameParameterSet)]
    [OutputType(typeof(VMScaleSetLifecycleHookEvent))]
    public class UpdateAzureRmVmssLifecycleHookEventCommand : ComputeAutomationBaseCmdlet
    {
        private const string ByNameParameterSet = "ByNameParameterSet";
        private const string ByObjectParameterSet = "ByObjectParameterSet";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByNameParameterSet,
            HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByNameParameterSet,
            HelpMessage = "The name of the VM scale set.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachineScaleSets", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [Alias("VMScaleSetName")]
        public string VMScaleSetName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ByNameParameterSet,
            HelpMessage = "The name (GUID) of the lifecycle hook event to update.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ParameterSetName = ByObjectParameterSet,
            HelpMessage = "The lifecycle hook event object from Get-AzVmssLifecycleHookEvent.")]
        [ValidateNotNull]
        public VMScaleSetLifecycleHookEvent InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The action state to apply to the lifecycle hook event targets. Accepted values: 'Approved', 'Rejected'. Note: 'Rejected' returns a server error during preview.")]
        [PSArgumentCompleter("Approved", "Rejected")]
        [ValidateSet("Approved", "Rejected")]
        public string ActionState { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Filters the update to a subset of target VM instance IDs (decimal IDs for Uniform VMSS) or VM names (for Flex VMSS). When omitted, the action state is applied to all target resources in the event.")]
        public string[] InstanceId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Delays the event deadline to the specified UTC timestamp (ISO 8601 format, e.g. '2026-05-08T11:00:00Z'). The timestamp must not be beyond MaxWaitUntil.")]
        public string WaitUntil { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName;
                string vmScaleSetName;
                string eventName;
                VMScaleSetLifecycleHookEvent existingEvent;

                if (this.ParameterSetName.Equals(ByObjectParameterSet))
                {
                    // Extract resource group, VMSS name, and event name from the object's ID
                    // ID format: /subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Compute/virtualMachineScaleSets/{vmss}/lifecycleHookEvents/{name}
                    var id = this.InputObject?.Id;
                    if (string.IsNullOrEmpty(id))
                    {
                        ThrowTerminatingError(new ErrorRecord(
                            new ArgumentException("The InputObject does not have a valid Id."),
                            "InvalidInputObject",
                            ErrorCategory.InvalidArgument,
                            this.InputObject));
                        return;
                    }

                    var parts = id.Split('/');
                    // Find resourceGroups index
                    int rgIndex = Array.FindIndex(parts, p => string.Equals(p, "resourceGroups", StringComparison.OrdinalIgnoreCase));
                    int vmssIndex = Array.FindIndex(parts, p => string.Equals(p, "virtualMachineScaleSets", StringComparison.OrdinalIgnoreCase));
                    int eventIndex = Array.FindIndex(parts, p => string.Equals(p, "lifecycleHookEvents", StringComparison.OrdinalIgnoreCase));

                    if (rgIndex < 0 || vmssIndex < 0 || eventIndex < 0)
                    {
                        ThrowTerminatingError(new ErrorRecord(
                            new ArgumentException($"Could not parse resource group, VMSS name, or event name from Id: {id}"),
                            "InvalidResourceId",
                            ErrorCategory.InvalidArgument,
                            id));
                        return;
                    }

                    resourceGroupName = parts[rgIndex + 1];
                    vmScaleSetName = parts[vmssIndex + 1];
                    eventName = parts[eventIndex + 1];
                    existingEvent = this.InputObject;
                }
                else
                {
                    resourceGroupName = this.ResourceGroupName;
                    vmScaleSetName = this.VMScaleSetName;
                    eventName = this.Name;
                    existingEvent = null;
                }

                if (ShouldProcess(eventName, "Update-AzVmssLifecycleHookEvent"))
                {
                    // If we need to filter by InstanceId or apply ActionState, get current target resources
                    List<VMScaleSetLifecycleHookEventTargetResource> targetResources = null;

                    if (this.IsParameterBound(c => c.ActionState))
                    {
                        // Get target resources from existing event (either piped object or fetched)
                        IList<VMScaleSetLifecycleHookEventTargetResource> currentTargets;
                        if (existingEvent?.Properties?.TargetResources != null)
                        {
                            currentTargets = existingEvent.Properties.TargetResources;
                        }
                        else
                        {
                            var fetchedEvent = VirtualMachineScaleSetLifeCycleHookEventsClient.Get(
                                resourceGroupName, vmScaleSetName, eventName);
                            currentTargets = fetchedEvent?.Properties?.TargetResources ?? new List<VMScaleSetLifecycleHookEventTargetResource>();
                        }

                        if (this.IsParameterBound(c => c.InstanceId) && this.InstanceId != null && this.InstanceId.Length > 0)
                        {
                            // Filter to only the specified instance IDs
                            var instanceIdSet = new HashSet<string>(this.InstanceId, StringComparer.OrdinalIgnoreCase);
                            targetResources = currentTargets
                                .Where(t => t.Resource?.Id != null && instanceIdSet.Any(id =>
                                    t.Resource.Id.EndsWith("/" + id, StringComparison.OrdinalIgnoreCase) ||
                                    t.Resource.Id.EndsWith("_" + id, StringComparison.OrdinalIgnoreCase) ||
                                    string.Equals(t.Resource.Id, id, StringComparison.OrdinalIgnoreCase)))
                                .Select(t => new VMScaleSetLifecycleHookEventTargetResource
                                {
                                    Resource = t.Resource,
                                    ActionState = this.ActionState
                                })
                                .ToList();
                        }
                        else
                        {
                            // Apply to all targets
                            targetResources = currentTargets
                                .Select(t => new VMScaleSetLifecycleHookEventTargetResource
                                {
                                    Resource = t.Resource,
                                    ActionState = this.ActionState
                                })
                                .ToList();
                        }
                    }

                    var updateParams = new VMScaleSetLifecycleHookEventUpdate
                    {
                        TargetResources = targetResources,
                        WaitUntil = this.IsParameterBound(c => c.WaitUntil) ? this.WaitUntil : null
                    };

                    var result = VirtualMachineScaleSetLifeCycleHookEventsClient.Update(
                        resourceGroupName,
                        vmScaleSetName,
                        eventName,
                        updateParams);

                    WriteObject(result);
                }
            });
        }
    }
}
