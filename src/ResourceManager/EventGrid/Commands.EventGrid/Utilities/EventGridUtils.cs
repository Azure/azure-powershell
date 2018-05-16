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

namespace Microsoft.Azure.Commands.EventGrid.Utilities
{
    class EventGridUtils
    {
        public static void GetResourceGroupNameAndTopicName(
            string resourceId,
            out string resourceGroupName,
            out string topicName)
        {
            if (string.IsNullOrEmpty(resourceId))
            {
                throw new ArgumentNullException(nameof(resourceId));
            }

            // ResourceID should be in the following format:
            // /subscriptions/{subid}/resourceGroups/{rg}/providers/Microsoft.EventGrid/topics/topic1
            string[] tokens = resourceId.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length != 8)
            {
                throw new Exception($"ResourceId {resourceId} not in the expected format");
            }

            resourceGroupName = tokens[3];
            topicName = tokens[7];
        }

        public static string GetScope(string subscriptionId, string resourceGroupName, string topicName)
        {
            if (string.IsNullOrEmpty(subscriptionId))
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }

            string scope;

            if (string.IsNullOrEmpty(resourceGroupName))
            {
                // ResourceGroup name was not specified, hence this is subscription level scope
                scope = $"/{EventGridConstants.Subscriptions}/{subscriptionId}";
            }
            else if (string.IsNullOrEmpty(topicName))
            {
                // ResourceGroup name was specified, but a custom topic name was not specified
                // Hence, this is a resource group level scope.
                scope = $"/{EventGridConstants.Subscriptions}/{subscriptionId}/{EventGridConstants.ResourceGroups}/{resourceGroupName}";
            }
            else
            {
                // Both resource group name and custom topic name was specified
                // Hence, the scope is for an EventGrid custom topic.
                scope = $"/{EventGridConstants.Subscriptions}/{subscriptionId}/{EventGridConstants.ResourceGroups}/{resourceGroupName}/{EventGridConstants.TopicsResourceType}/{topicName}";
            }

            return scope;
        }

        public static string ParseResourceGroupFromId(string resourceId)
        {
            if (!string.IsNullOrEmpty(resourceId))
            {
                string[] tokens = resourceId.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                return tokens[3];
            }

            return null;
        }

        public static bool ShouldShowEventSubscriptionWarningMessage(string Endpoint, string EndpointType)
        {
            if (string.IsNullOrWhiteSpace(Endpoint) || string.IsNullOrWhiteSpace(EndpointType))
            {
                return false;
            }

            // If the endpoint belongs to a service that we know implements the subscription validation
            // handshake, there's no need to show this message, hence we check for those services
            // before showing this message. This list includes Azure Automation, EventGrid Trigger based
            // Azure functions, and Azure Logic Apps.

            return (string.Equals(EndpointType, "webhook", System.StringComparison.OrdinalIgnoreCase) &&
                !Endpoint.ToLowerInvariant().Contains("eventgridextension") &&
                !Endpoint.ToLowerInvariant().Contains("logic.azure.com") &&
                !Endpoint.ToLowerInvariant().Contains("hookbin") &&
                !Endpoint.ToLowerInvariant().Contains("azure-automation"));
        }
    }
}
