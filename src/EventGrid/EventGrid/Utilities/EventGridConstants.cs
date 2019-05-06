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

namespace Microsoft.Azure.Commands.EventGrid.Utilities
{
    class EventGridConstants
    {
        public const string Subscriptions = "subscriptions";
        public const string ResourceGroups = "resourceGroups";
        public const string TopicsResourceType = "providers/Microsoft.EventGrid/topics";

        public const string TopicInputObjectHelp = "EventGrid Topic object.";
        public const string EventSubscriptionInputObjectHelp = "EventGridSubscription object.";

        // Help text
        public const string IncludedEventTypesHelp = "Filter that specifies a list of event types to include. If not specified, all event types will be included.";
        public const string SubjectBeginsWithHelp = "Filter that specifies that only events matching the specified subject prefix will be included. If not specified, events with all subject prefixes will be included.";
        public const string SubjectEndsWithHelp = "Filter that specifies that only events matching the specified subject suffix will be included. If not specified, events with all subject suffixes will be included.";
        public const string SubjectCaseSensitiveHelp = "Filter that specifies that the subject field should be compared in a case sensitive manner. If not specified, subject will be compared in a case insensitive manner.";
        public const string LabelsHelp = "Labels for the event subscription.";
        public const string EndpointTypeHelp = "Endpoint Type. This can be webhook, eventhub, storagequeue, or hybridconnection. Default value is webhook.";
        public const string EndpointHelp = "Event subscription destination endpoint. This can be a webhook URL, or the Azure resource ID of an EventHub, storage queue or hybridconnection. For example, the resource ID for a hybrid connection " +
                                           "takes the following form: /subscriptions/[Azure Subscription ID]/resourceGroups/[ResourceGroupName]/providers/Microsoft.Relay/namespaces/[NamespaceName]/hybridConnections/[HybridConnectionName]. It is expected that " +
                                           "the destination endpoint to be created and available for use before executing any Event Grid cmdlets.";
        public const string ResourceGroupNameHelp = "The name of the resource group.";
        public const string TopicNameHelp = "EventGrid topic name.";
        public const string TopicTypeNameHelp = "EventGrid topic type name.";
        public const string EventSubscriptionNameHelp = "EventGrid event subscription name.";
        public const string TopicLocationHelp = "The location of the topic.";
        public const string TagsHelp = "Hashtable which represents resource Tags.";
        public const string ResourceIdNameHelp = "The identifier of the resource to which the event subscription should be created.";

        public const string TopicNameOfTheEventSubscriptionHelp = "The name of the topic to which the event subscription should be created.";

        public const string EventTtlHelp = "The time in minutes for the event delivery. This value must be between 1 and 1440";
        public const string MaxDeliveryAttemptHelp = "The maximum number of attempts to deliver the event. This value must be between 1 and 30";
        public const string DeadletterEndpointHelp = "The endpoint used for storing undelivered events. Specify the Azure resource ID of a Storage blob container. For example: " +
                                                     "/subscriptions/[SubscriptionId]/resourceGroups/[ResourceGroupName]/providers/Microsoft.Storage/storageAccounts/[StorageAccountName]/blobServices/default/containers/[ContainerName].";

        public const string KeyNameHelp = "The name of the key that needs to be regenerated";
        public const string TopicResourceIdHelp = "Resource Identifier representing the Event Grid Topic.";

        public const string EventSubscriptionFullUrlHelp = "Include the full endpoint URL of the event subscription destination.";
        public const string EventSubscriptionFullUrlInResponseHelp = "If specified, include the full endpoint URL of the event subscription destination in the response.";

        // Event Subscription destination types
        public const string Webhook = "webhook";
        public const string EventHub = "eventhub";
        public const string StorageQueue = "storagequeue";
        public const string HybridConnection = "hybridconnection";

        public const string EventSubscriptionHandshakeValidationMessage = "If the provided endpoint doesn't support subscription validation " +
                                                                          "handshake, navigate to the validation URL that you receive in the " +
                                                                          "subscription validation event, in order to complete the event " +
                                                                          "subscription creation or update. For more details, please visit http://aka.ms/esvalidation";
    }
}
