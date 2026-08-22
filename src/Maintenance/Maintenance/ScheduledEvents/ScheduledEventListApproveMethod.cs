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
using Newtonsoft.Json.Linq;
using System;
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
                string[] scheduledEventIds = NormalizeScheduledEventIds(this.ScheduledEventIdList);
                string target = $"resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/scheduledEvents [{string.Join(", ", scheduledEventIds)}]";

                if (MaintenanceClient.MaintenanceManagementClient is MaintenanceManagementClient client
                    && !client.DeserializationSettings.Converters.Any(converter => converter is ScheduledEventsListAcknowledgeErrorConverter))
                {
                    client.DeserializationSettings.Converters.Add(new ScheduledEventsListAcknowledgeErrorConverter());
                }

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

        private static string[] NormalizeScheduledEventIds(IEnumerable<string> values)
        {
            if (values == null)
            {
                throw new PSArgumentException("The ScheduledEventIdList parameter cannot be null.", nameof(ScheduledEventIdList));
            }

            string[] normalizedValues = values
                .Select((value, index) => NormalizeScheduledEventId(value, nameof(ScheduledEventIdList), index))
                .ToArray();

            if (normalizedValues.Length == 0)
            {
                throw new PSArgumentException("The ScheduledEventIdList parameter must contain at least one scheduled event ID.", nameof(ScheduledEventIdList));
            }

            return normalizedValues;
        }

        private static PSScheduledEventsApproveResponse GetMultiStatusResponse(ScheduledEventsListAcknowledgeErrorException exception)
        {
            ScheduledEventsListAcknowledgeErrorDetails response = exception.Body?.Error;
            return new PSScheduledEventsApproveResponse
            {
                Response = new PSScheduledEventsListApproveStatus
                {
                    Code = response?.Code ?? exception.Response.StatusCode.ToString(),
                    Message = response?.Message ?? exception.Message
                },
                Details = response?.Details ?? new List<ScheduledEventsAcknowledgeErrorDetails>()
            };
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
            HelpMessage = "The Microsoft.Compute resource type. Supported values are virtualMachines, virtualMachineScaleSets, and availabilitySets.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        [ValidateSet("virtualMachines", "virtualMachineScaleSets", "availabilitySets", IgnoreCase = true)]
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
            HelpMessage = "List of ScheduledEvents Ids.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string[] ScheduledEventIdList { get; set; }
    }

    internal sealed class ScheduledEventsListAcknowledgeErrorConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ScheduledEventsListAcknowledgeError);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject responseBody = JObject.Load(reader);
            JToken errorToken = responseBody.GetValue("error", StringComparison.OrdinalIgnoreCase);
            JToken responseToken = responseBody.GetValue("response", StringComparison.OrdinalIgnoreCase);
            ScheduledEventsListAcknowledgeErrorDetails error =
                (errorToken ?? responseToken)?.ToObject<ScheduledEventsListAcknowledgeErrorDetails>(serializer);

            if (errorToken == null && error != null)
            {
                error.Details = responseBody.GetValue("details", StringComparison.OrdinalIgnoreCase)
                    ?.ToObject<IList<ScheduledEventsAcknowledgeErrorDetails>>(serializer);
            }

            return new ScheduledEventsListAcknowledgeError(error);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}
