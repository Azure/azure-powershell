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

        public const string TopicInputObject = "EventGrid Topic object.";
        public const string EventSubscriptionInputObject = "EventGridSubscription object.";

        // Help text
        public const string IncludedEventTypesHelp = "Filter that specifies a list of event types to include.If not specified, all event types will be included.";
        public const string SubjectBeginsWithHelp = "Filter that specifies that only events matching the specified subject prefix will be included. If not specified, events with all subject prefixes will be included.";
        public const string SubjectEndsWithHelp = "Filter that specifies that only events matching the specified subject suffix will be included. If not specified, events with all subject suffixes will be included.";
        public const string SubjectCaseSensitiveHelp = "Filter that specifies that the subject field should be compared in a case sensitive manner. If not specified, subject will be compared in a case insensitive manner.";
        public const string LabelsHelp = "Labels for the event subscription.";
        public const string EndpointTypeHelp = "Endpoint Type. This can be webhook, eventhub, storagequeue or hybridconnection. Default is webhook.";
        public const string EndpointHelp = "Event subscription destination endpoint. This can be a webhook URL, or the Azure resource ID of an EventHub, storage queue or hybridconnection. For example, the resource ID for a hybrid connection " +
                                           "takes the following form: /subscriptions/[Azure Subscription ID]/resourceGroups/[ResourceGroupName]/providers/Microsoft.Relay/namespaces/[NamespaceName]/hybridConnections/[HybridConnectionName]";
        public const string ResourceGroupNameHelp = "The name of the resource group.";
        public const string TopicNameHelp = "The name of the topic.";
        public const string TopicTypeNameHelp = "The name of the topic type.";
        public const string EventSubscriptionNameHelp = "The name of the event subscription.";
        public const string TopicLocationHelp = "The location of the topic.";
        public const string TagsHelp = "Hashtable which represents resource Tags.";
        public const string ResourceIdNameHelp = "The identifier of the resource to which the event subscription should be created.";
        public const string TopicNameOfTheEventSubscriptionHelp = "The name of the topic to which the event subscription should be created.";
        public const string InputSchemaHelp = "The schema of the input events for the topic. Allowed values are: eventgridschema, customeventschema, or cloudeventv01Schema. Default is eventgridschema.";
        public const string InputMappingFieldsHelp = "Hashtable which represents the input mapping fields in space separated key=value format. Allowed key names are id, topic, eventtime, subject, eventtype, and dataversion.";
        public const string InputMappingDefaultValuesHelp = "Hashtable which represents the input mapping fields with default value in space separated key=value format. Allowed key names are subject, eventtype, and dataversion.";
        public const string EventTtlHelp = "The time in minutes for the event delivery. This value must be between 1 and 1440";
        public const string MaxDeliveryAttemptsHelp = "The maximum number of attempts to deliver the event. This value must be between 1 and 30";
        public const string DeliverySchemaHelp = "The schema to be used when delivering events to the destination. The possible values are: eventgridschema, inputeventschema, or cloudeventv01schema. Default is eventgridschema";
        public const string DeadletterEndpointHelp = "The endpoint used for storing undelivered events. Specify the Azure resource ID of a Storage blob container. For example: " +
                                                     "/subscriptions/[SubscriptionId]/resourceGroups/[ResourceGroupName]/providers/Microsoft.Storage/storageAccounts/[StorageAccountName]/blobServices/default/containers/[ContainerName].";

        // Event Subscription destination types
        public const string Webhook = "webhook";
        public const string EventHub = "eventhub";
        public const string StorageQueue = "storagequeue";
        public const string HybridConnection = "hybridconnection";

        public const string EventSubscriptionHandshakeValidationMessage = "If the provided endpoint doesn't support subscription validation " +
                                                                          "handshake, navigate to the validation URL that you receive in the " +
                                                                          "subscription validation event, in order to complete the event " +
                                                                          "subscription creation or update. For more details, please visit http://aka.ms/esvalidation";

        // Input mapping keys
        public const string InputMappingId = "id";
        public const string InputMappingTopic = "topic";
        public const string InputMappingEventTime = "eventtime";
        public const string InputMappingSubject = "subject";
        public const string InputMappingEventType = "eventtype";
        public const string InputMappingDataVersion = "dataversion";
    }
}
