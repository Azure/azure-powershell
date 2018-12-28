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
    class EventGridConstants
    {
        public const string Subscriptions = "subscriptions";
        public const string ResourceGroups = "resourceGroups";
        public const string TopicsResourceType = "providers/Microsoft.EventGrid/topics";

        public const string IncludedEventTypesHelp = "Filter that specifies a list of event types to include.If not specified, all event types will be included.";
        public const string SubjectBeginsWithHelp = "Filter that specifies that only events matching the specified subject prefix will be included. If not specified, events with all subject prefixes will be included.";
        public const string SubjectEndsWithHelp = "Filter that specifies that only events matching the specified subject suffix will be included. If not specified, events with all subject suffixes will be included.";
        public const string SubjectCaseSensitiveHelp = "Filter that specifies that the subject field should be compared in a case sensitive manner. If not specified, subject will be compared in a case insensitive manner.";
        public const string LabelsHelp = "Labels for the event subscription";
        public const string EndpointTypeHelp = "Endpoint Type. This can be webhook or eventhub";
        public const string EndpointHelp = "Event subscription destination endpoint. This can be a webhook URL or the Azure resource ID of an EventHub.";

        public const string TopicInputObject = "EventGrid Topic object.";
        public const string EventSubscriptionInputObject = "EventGridSubscription object.";

        public const string ResourceGroupName = "The name of the resource group";
        public const string TopicName = "The name of the topic";
        public const string TopicTypeName = "The name of the topic type";
        public const string EventSubscriptionName = "The name of the event subscription";
    }
}
