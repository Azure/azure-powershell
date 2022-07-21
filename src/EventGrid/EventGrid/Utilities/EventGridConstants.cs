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
        public const string DomainsResourceType = "providers/Microsoft.EventGrid/domains";

        public const string TopicInputObjectHelp = "EventGrid Topic object.";
        public const string DomainInputObjectHelp = "EventGrid Domain object.";
        public const string DomainTopicInputObjectHelp = "EventGrid Domain Topic object.";
        public const string EventSubscriptionInputObjectHelp = "EventGridSubscription object.";

        // Help text
        public const string IncludedEventTypesHelp = "Filter that specifies a list of event types to include. If not specified, all event types (for the custom topics and domains) or default event types (for other topic types) will be included.";
        public const string SubjectBeginsWithHelp = "Filter that specifies that only events matching the specified subject prefix will be included. If not specified, events with all subject prefixes will be included.";
        public const string SubjectEndsWithHelp = "Filter that specifies that only events matching the specified subject suffix will be included. If not specified, events with all subject suffixes will be included.";
        public const string SubjectCaseSensitiveHelp = "Filter that specifies that the subject field should be compared in a case sensitive manner. If not specified, subject will be compared in a case insensitive manner.";
        public const string LabelsHelp = "Labels for the event subscription.";
        public const string EndpointTypeHelp = "Endpoint Type. This can be webhook, eventhub, storagequeue, hybridconnection, servicebusqueue, servicebustopic or azurefunction. Default value is webhook.";
        public const string EndpointHelp = "Event subscription destination endpoint. This can be a webhook URL, or the Azure resource ID of an EventHub, storage queue, hybridconnection, servicebusqueue, servicebustopic or azurefunction. For example, the resource ID for a hybrid connection " +
                                           "takes the following form: /subscriptions/[Azure Subscription ID]/resourceGroups/[ResourceGroupName]/providers/Microsoft.Relay/namespaces/[NamespaceName]/hybridConnections/[HybridConnectionName]. It is expected that " +
                                           "the destination endpoint to be created and available for use before executing any Event Grid cmdlets.";
        public const string ResourceGroupNameHelp = "The name of the resource group.";
        public const string TopicNameHelp = "EventGrid topic name.";
        public const string DomainNameHelp = "EventGrid domain name.";
        public const string DomainTopicNameHelp = "EventGrid domain topic name.";
        public const string DomainNameForEventSubscriptionHelp = "The name of the Event Grid domain to which the event subscription should be created.";
        public const string DomainTopicNameForEventSubscriptionHelp = "The name of the domain topic to which the event subscription should be created.";
        public const string TopicTypeNameHelp = "EventGrid topic type name.";
        public const string EventSubscriptionNameHelp = "EventGrid event subscription name.";
        public const string TopicLocationHelp = "The location of the topic.";
        public const string DomainLocationHelp = "The location of the domain.";
        public const string TagsHelp = "Hashtable which represents resource Tags.";
        public const string ResourceIdNameHelp = "The identifier of the resource to which the event subscription should be created.";
        public const string AdvancedFilteringOnArraysHelp = "The presence of this parameter denotes that advanced filtering on arrays is enabled";

        public const string IdentityTypeHelp = "Different identity types. Could be either  of following 'SystemAssigned', 'UserAssigned', 'SystemAssigned, UserAssigned', 'None'";
        public const string IdentityIdsHelp = "The list of user assigned identities";
        public const string SourceHelp = "Source for a system topic";
        public const string ForceHelp = "Indicates that the cmdlet does not prompt you for confirmation. By default, this cmdlet prompts you to confirm that you want to delete the resource";

        public const string ODataQueryHelp = "The OData query used for filtering the list results. Filtering is currently allowed on the Name property only.The supported operations include: CONTAINS, eq (for equal), ne (for not equal), AND, OR and NOT.";
        public const string TopHelp = "The maximum number of resources to be obtained. Valid value is between 1 and 100. If top value is specified and more results are still available, the result will contain a link to the next page to be queried in NextLink. If the Top value is not specified, the full list of resources will be returned at once.";
        public const string NextLinkHelp = "The link for the next page of resources to be obtained. This value is obtained with the first Get-AzEventGrid cmdlet call when more resources are still available to be queried.";

        public const string TopicNameOfTheEventSubscriptionHelp = "The name of the topic to which the event subscription should be created.";
        public const string DomainNameOfTheEventSubscriptionHelp = "The name of the domain to which the event subscription should be created.";
        public const string DomainTopicNameOfTheEventSubscriptionHelp = "The name of the domain topic to which the event subscription should be created.";

        public const string InputSchemaHelp = "The schema of the input events for the topic. Allowed values are: eventgridschema, customeventschema, or cloudeventv01Schema. Default value is eventgridschema. Note that if customeventschema " +
                                              "is specified, then InputMappingField or/and InputMappingDefaultValue parameters need to be specified as well.";
        public const string InputMappingFieldHelp = "Hashtable which represents the input mapping fields in space separated key = value format. Allowed key names are: id, topic, eventtime, subject, eventtype, and dataversion. This is used when InputSchemaHelp is customeventschema only.";
        public const string InputMappingDefaultValueHelp = "Hashtable which represents the input mapping fields with default value in space separated key = value format. Allowed key names are: subject, eventtype, and dataversion. This is used when InputSchemaHelp is customeventschema only.";
        public const string EventTtlHelp = "The time in minutes for the event delivery. This value must be between 1 and 1440";
        public const string StorageQueueMessageTtlHelp = "The time in milliseconds for time to live of a storage queue message";
        public const string MaxDeliveryAttemptHelp = "The maximum number of attempts to deliver the event. This value must be between 1 and 30.";
        public const string DeliveryAttributeMappingHelp = "The delivery attribute mappings for this system topic event subscription";
        public const string DeliverySchemaHelp = "The schema to be used when delivering events to the destination. The possible values are: eventgridschema, CustomInputSchema, or cloudeventv01schema. Default value is CustomInputSchema.";
        public const string DeadletterEndpointHelp = "The endpoint used for storing undelivered events. Specify the Azure resource ID of a Storage blob container. For example: " +
                                                     "/subscriptions/[SubscriptionId]/resourceGroups/[ResourceGroupName]/providers/Microsoft.Storage/storageAccounts/[StorageAccountName]/blobServices/default/containers/[ContainerName].";
        public const string ExpirationDateHelp = "Determines the expiration DateTime for the event subscription after which event subscription will retire.";
        public const string AdvancedFilterHelp = "Advanced filter that specifies an array of multiple Hashtable values that are used for the attribute-based filtering. Each Hashtable value has the following keys-value info: Operation, Key and Value or Values. " +
                                                 "Operator can be one of the following values: NumberIn, NumberNotIn, NumberLessThan, NumberGreaterThan, NumberLessThanOrEquals, NumberGreaterThanOrEquals, BoolEquals, StringIn, StringNotIn, StringBeginsWith, StringEndsWith " +
                                                 "or StringContains. Key represents the payload property where the advanced filtering policies are applied. Finally, Value or Values represent the value or set of values to be matched. This can be a single value of the corresponding " +
                                                 "type or an array of values. As an example of the advanced filter parameters: " +
                                                 "$AdvancedFilters=@($AdvFilter1, $AdvFilter2) where $AdvFilter1=@{operator=\"NumberIn\"; key=\"Data.Key1\"; Values=@(1,2)} and $AdvFilter2=@{operator=\"StringBringsWith\"; key=\"Subject\"; Values=@(\"SubjectPrefix1\",\"SubjectPrefix2\")}";

        public const string KeyNameHelp = "The name of the key that needs to be regenerated";
        public const string TopicResourceIdHelp = "Resource Identifier representing the Event Grid Topic.";
        public const string DomainResourceIdHelp = "Resource Identifier representing the Event Grid Domain.";
        public const string DomainTopicResourceIdHelp = "Resource Identifier representing the Event Grid Domain Topic.";
        public const string DomainOrDomainTopicResourceIdHelp = "Resource Identifier representing the Event Grid Domain or Grid Domain Topic.";

        public const string EventSubscriptionFullUrlHelp = "Include the full endpoint URL of the event subscription destination.";
        public const string EventSubscriptionFullUrlInResponseHelp = "If specified, include the full endpoint URL of the event subscription destination in the response.";

        public const string MaxEventsPerBatchHelp = "The maximum number of events in a batch. This value must be between 1 and 5000. This parameter is valid when Endpint Type is webhook only.";
        public const string PreferredBatchSizeInKiloByteHelp = "The preferred batch size in kilobytes. This value must be between 1 and 1024. This parameter is valid when Endpint Type is webhook only.";

        public const string AzureActiveDirectoryTenantIdHelp = "The Azure Active Directory (AAD) Tenant Id to get the access token that will be included as the bearer token in delivery requests.Applicable only for webhook as a destination.";
        public const string AzureActiveDirectoryApplicationIdOrUriHelp = "The Azure Active Directory (AAD) Application Id or Uri to get the access token that will be included as the bearer token in delivery requests.Applicable only for webhook as a destination.";

        public const string InboundIpRuleHelp = "Hashtable which represents list of inbound IP rules. Each rule specifies the IP Address in CIDR notation e.g., 10.0.0.0/8 along with the corresponding Action to be performed based on the match or no match of the IpMask. Possible Action values include Allow only";
        public const string PublicNetworkAccessHelp = "This determines if traffic is allowed over public network. By default it is enabled. You can further restrict to specific IPs by configuring InboundIpRule parameters. Allowed values are disabled and enabled.";

        public const string DisableLocalAuthHelp = "Switch param to disable local auth.";
        public const string AutoCreateTopicWithFirstSubscriptionHelp = "Switch param to auto create topic with first subscription";
        public const string AutoDeleteTopicWithLastSubscriptionHelp = "Switch param to auto delete topic with last subscription";
        // Event Subscription destination types
        public const string Webhook = "webhook";
        public const string EventHub = "eventhub";
        public const string StorageQueue = "storagequeue";
        public const string HybridConnection = "hybridconnection";
        public const string ServiceBusQueue = "servicebusqueue";
        public const string ServiceBusTopic = "servicebustopic";
        public const string AzureFunction = "azurefunction";

        public const string Enabled = "enabled";
        public const string Disabled = "disabled";

        public const string EventSubscriptionHandshakeValidationMessage = "If the provided endpoint doesn't support subscription validation " +
                                                                          "handshake, navigate to the validation URL that you receive in the " +
                                                                          "subscription validation event, in order to complete the event " +
                                                                          "subscription creation or update. For more details, please visit http://aka.ms/esvalidation";

        public const string IncludedEventTypeDeprecationMessage = "The usage of \"All\" for -IncludedEventType is not allowed starting from api-version 2019-02-01-preview. However, the call here " +
                                                                  "is still permitted by replacing \"All\" with $null in order to return all the event types (for the custom topics " +
                                                                  "and domains case) or default event types (for other topic types case). In any future calls, please consider leaving -IncludedEventType unspecified or use $null instead.";

        // Input mapping keys
        public const string InputMappingId = "id";
        public const string InputMappingTopic = "topic";
        public const string InputMappingEventTime = "eventtime";
        public const string InputMappingSubject = "subject";
        public const string InputMappingEventType = "eventtype";
        public const string InputMappingDataVersion = "dataversion";
    }
}
