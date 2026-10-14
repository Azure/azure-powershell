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
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

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
            HelpMessage = "The action state to apply to the lifecycle hook event targets. Accepted values: 'Approved', 'Rejected'.")]
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

            // Reject silent no-op: the cmdlet must do something. At least one of -ActionState or -WaitUntil is required.
            if (!this.IsParameterBound(c => c.ActionState) && !this.IsParameterBound(c => c.WaitUntil))
            {
                ThrowTerminatingError(new ErrorRecord(
                    new ArgumentException("At least one of -ActionState or -WaitUntil must be specified."),
                    "NoUpdateSpecified",
                    ErrorCategory.InvalidArgument,
                    null));
                return;
            }

            // -InstanceId is a per-target filter that is only meaningful when -ActionState is supplied;
            // without -ActionState it would be silently ignored, which is confusing.
            if (this.IsParameterBound(c => c.InstanceId) && !this.IsParameterBound(c => c.ActionState))
            {
                ThrowTerminatingError(new ErrorRecord(
                    new ArgumentException("The -InstanceId parameter requires -ActionState to be specified."),
                    "InstanceIdRequiresActionState",
                    ErrorCategory.InvalidArgument,
                    this.InstanceId));
                return;
            }

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

                    if (rgIndex < 0 || rgIndex + 1 >= parts.Length
                        || vmssIndex < 0 || vmssIndex + 1 >= parts.Length
                        || eventIndex < 0 || eventIndex + 1 >= parts.Length)
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

                if (ShouldProcess(eventName, VerbsData.Update))
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

                    // The Update REST API returns 202 Accepted (LRO), but the generated SDK Update method
                    // only accepts 200. Issue the PATCH manually, accept 200/202, and poll the LRO to completion
                    // before re-fetching the updated event to return.
                    var result = UpdateLifecycleHookEventLro(
                        resourceGroupName,
                        vmScaleSetName,
                        eventName,
                        updateParams);

                    WriteObject(result);
                }
            });
        }

        // Custom LRO-aware Update implementation. Bypasses the generated SDK Update method because
        // it does not accept the 202 LRO response the service returns. Should be removed once the
        // SDK is regenerated against an OpenAPI spec that declares 202 + LRO polling for this op.
        private VMScaleSetLifecycleHookEvent UpdateLifecycleHookEventLro(
            string resourceGroupName,
            string vmScaleSetName,
            string lifecycleHookEventName,
            VMScaleSetLifecycleHookEventUpdate properties)
        {
            return UpdateLifecycleHookEventLroAsync(
                resourceGroupName, vmScaleSetName, lifecycleHookEventName, properties, CancellationToken.None)
                .ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private async Task<VMScaleSetLifecycleHookEvent> UpdateLifecycleHookEventLroAsync(
            string resourceGroupName,
            string vmScaleSetName,
            string lifecycleHookEventName,
            VMScaleSetLifecycleHookEventUpdate properties,
            CancellationToken cancellationToken)
        {
            var client = (Microsoft.Azure.Management.Compute.ComputeManagementClient)this.ComputeClient.ComputeManagementClient;
            const string apiVersion = "2025-11-01";

            var baseUrl = client.BaseUri.AbsoluteUri;
            var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith("/") ? "" : "/")),
                "subscriptions/" + Uri.EscapeDataString(client.SubscriptionId) +
                "/resourceGroups/" + Uri.EscapeDataString(resourceGroupName) +
                "/providers/Microsoft.Compute/virtualMachineScaleSets/" + Uri.EscapeDataString(vmScaleSetName) +
                "/lifecycleHookEvents/" + Uri.EscapeDataString(lifecycleHookEventName) +
                "?api-version=" + Uri.EscapeDataString(apiVersion)).ToString();

            var httpRequest = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(url)
            };
            var requestContent = SafeJsonConvert.SerializeObject(properties, client.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, System.Text.Encoding.UTF8);
            httpRequest.Content.Headers.ContentType =
                System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");

            if (client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            cancellationToken.ThrowIfCancellationRequested();
            var httpResponse = await client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            var statusCode = (int)httpResponse.StatusCode;

            if (statusCode != 200 && statusCode != 202)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                CloudError errorBody = null;
                try
                {
                    errorBody = SafeJsonConvert.DeserializeObject<CloudError>(responseContent, client.DeserializationSettings);
                }
                catch (Newtonsoft.Json.JsonException) { /* ignore */ }
                var ex = errorBody != null
                    ? new CloudException(errorBody.Message) { Body = errorBody }
                    : new CloudException("Operation returned an invalid status code '" + httpResponse.StatusCode + "'");
                ex.Request = new HttpRequestMessageWrapper(httpRequest, requestContent);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                throw ex;
            }

            var operationResponse = new AzureOperationResponse<VMScaleSetLifecycleHookEvent>
            {
                Request = httpRequest,
                Response = httpResponse
            };
            if (httpResponse.Headers.Contains("x-ms-request-id"))
            {
                operationResponse.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
            }

            if (statusCode == 200)
            {
                var bodyContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                operationResponse.Body = SafeJsonConvert.DeserializeObject<VMScaleSetLifecycleHookEvent>(
                    bodyContent, client.DeserializationSettings);
                httpResponse.Dispose();
                httpRequest.Dispose();
                return operationResponse.Body;
            }

            // 202 — poll the LRO via Azure-AsyncOperation / Location headers until completion.
            await client.GetPutOrPatchOperationResultAsync(operationResponse, null, cancellationToken).ConfigureAwait(false);

            httpResponse.Dispose();
            httpRequest.Dispose();

            // The LRO terminal response may not include the resource body. Re-fetch via GET to return final state.
            var fetched = await client.VirtualMachineScaleSetLifeCycleHookEvents
                .GetWithHttpMessagesAsync(resourceGroupName, vmScaleSetName, lifecycleHookEventName, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return fetched.Body;
        }
    }
}
