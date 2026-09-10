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

using Microsoft.Azure.Commands.Maintenance.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Maintenance;
using Microsoft.Azure.Management.Maintenance.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Maintenance
{
    [Cmdlet(VerbsLifecycle.Approve, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ScheduledEventList", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType(typeof(ScheduledEventsApproveResponse), typeof(PSScheduledEventsApproveResponse), typeof(ScheduledEventsListAcknowledgeError))]
    public partial class ApproveAzureRmScheduledEventList : MaintenanceAutomationBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                string resourceGroupName = NormalizeRequiredValue(this.ResourceGroupName, nameof(ResourceGroupName));
                string resourceType = NormalizeRequiredValue(this.ResourceType, nameof(ResourceType));
                string resourceName = NormalizeRequiredValue(this.ResourceName, nameof(ResourceName));
                if (this.ScheduledEventIdList == null || this.ScheduledEventIdList.Length == 0)
                {
                    throw new PSArgumentException("The ScheduledEventIdList parameter must contain at least one ScheduledEvents ID.", nameof(ScheduledEventIdList));
                }

                string[] scheduledEventIds = this.ScheduledEventIdList
                    .Select((value, index) => NormalizeScheduledEventId(value, nameof(ScheduledEventIdList), index))
                    .ToArray();
                string target = $"resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/scheduledEvents [{string.Join(", ", scheduledEventIds)}]";

                if (ShouldProcess(target, VerbsLifecycle.Approve))
                {
                    try
                    {
                        ScheduledEventsApproveResponse response = ScheduledEventsClient.AcknowledgeList(
                            resourceGroupName,
                            resourceType,
                            resourceName,
                            scheduledEventIds);
                        WriteObject(response);
                    }
                    catch (ScheduledEventsListAcknowledgeErrorException exception) when ((int?)exception.Response?.StatusCode == 207)
                    {
                        PSScheduledEventsApproveResponse response = GetMultiStatusResponse(exception);
                        PopulateMissingTargets(response.Details, scheduledEventIds);
                        WriteObject(response);
                    }
                    catch (ScheduledEventsListAcknowledgeErrorException exception)
                    {
                        WriteObject(exception.Body ?? new ScheduledEventsListAcknowledgeError(
                            new ScheduledEventsListAcknowledgeErrorDetails(
                                exception.Response?.StatusCode.ToString(),
                                exception.Message)));
                    }
                }
            });
        }

        /// <summary>
        /// Maps the service's HTTP 207 payload to the PowerShell response model. The service returns
        /// { "response": { "code", "message" }, "details": [...] }, while the existing AutoRest default
        /// response model expects { "error": { "code", "message", "details" } }. The SDK model is retained
        /// as a fallback for responses that follow the published specification.
        /// </summary>
        private static PSScheduledEventsApproveResponse GetMultiStatusResponse(ScheduledEventsListAcknowledgeErrorException exception)
        {
            PSScheduledEventsApproveResponse result = null;
            if (!string.IsNullOrWhiteSpace(exception.Response?.Content))
            {
                try
                {
                    result = JsonConvert.DeserializeObject<PSScheduledEventsApproveResponse>(exception.Response.Content);
                }
                catch (JsonException)
                {
                    // Fall back to the generated SDK body and transport-level status below.
                }
            }

            result = result ?? new PSScheduledEventsApproveResponse();
            result.Response = result.Response ?? new PSScheduledEventsListApproveStatus();

            ScheduledEventsListAcknowledgeErrorDetails sdkError = exception.Body?.Error;
            result.Response.Code = result.Response.Code ?? sdkError?.Code ?? exception.Response.StatusCode.ToString();
            result.Response.Message = result.Response.Message ?? sdkError?.Message ?? exception.Message;
            result.Details = result.Details ?? sdkError?.Details ?? new List<ScheduledEventsAcknowledgeErrorDetails>();

            return result;
        }

        private static void PopulateMissingTargets(
            IList<ScheduledEventsAcknowledgeErrorDetails> details,
            IReadOnlyList<string> requestedIds)
        {
            if (details == null)
            {
                return;
            }

            for (int index = 0; index < details.Count && index < requestedIds.Count; index++)
            {
                if (string.IsNullOrEmpty(details[index].Target))
                {
                    details[index].Target = requestedIds[index];
                }
            }
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
            HelpMessage = "The list of ScheduledEvents IDs.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string[] ScheduledEventIdList { get; set; }
    }
}
