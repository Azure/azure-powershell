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

using Microsoft.Azure.Commands.ResourceManager.Common;
using System;

namespace Microsoft.Azure.Commands.EventGrid
{
    public abstract class AzureEventGridCmdletBase : AzureRMCmdlet
    {
        protected const string EventGridTopicVerb = "AzureRmEventGridTopic";
        protected const string EventGridTopicKeyVerb = "AzureRmEventGridTopicKey";
        protected const string EventGridEventSubscriptionVerb = "AzureRmEventGridSubscription";
        protected const string EventGridTopicTypeVerb = "AzureRmEventGridTopicType";

        protected const string TopicInputObjectParameterSet = "TopicInputObjectParameterSet";
        protected const string TopicKeyInputObjectParameterSet = "TopicKeyInputObjectParameterSet";
        protected const string EventSubscriptionInputObjectParameterSet = "EventSubscriptionInputObjectSet";

        protected const string EventSubscriptionCustomTopicInputObjectParameterSet = "EventSubscriptionCustomTopicInputObjectParameterSet";
        protected const string EventSubscriptionDomainInputObjectParameterSet = "EventSubscriptionDomainInputObjectParameterSet";
        protected const string EventSubscriptionDomainTopicInputObjectParameterSet = "EventSubscriptionDomainTopicInputObjectParameterSet";

        protected const string DomainInputObjectParameterSet = "DomainInputObjectParameterSet";
        protected const string DomainTopicInputObjectParameterSet = "DomainTopicInputObjectParameterSet";
        protected const string DomainKeyInputObjectParameterSet = "DomainKeyInputObjectParameterSet";

        protected const string DomainEventSubscriptionParameterSet = "DomainEventSubscriptionParameterSet";
        protected const string DomainTopicEventSubscriptionParameterSet = "DomainTopicEventSubscriptionParameterSet";
        protected const string EventSubscriptionDomainNameParameterSet = "EventSubscriptionDomainNameParameterSet";
        protected const string EventSubscriptionDomainTopicNameParameterSet = "EventSubscriptionDomainTopicNameParameterSet";

        protected const string TopicNameParameterSet = "TopicNameParameterSet";
        protected const string SystemTopicNameParameterSet = "SystemTopicNameParameterSet";
        protected const string SystemTopicEventSuscriptionParameterSet = "SystemTopicEventSuscriptionParameterSet";
        protected const string ResourceGroupNameParameterSet = "ResourceGroupNameParameterSet";
        protected const string CustomTopicEventSubscriptionParameterSet = "CustomTopicEventSubscriptionParameterSet";
        protected const string SubscriptionAndResourceGroupEventSubscriptionParameterSet = "SubscriptionAndResourceGroupEventSubscriptionParameterSet";
        protected const string ResourceIdDomainParameterSet = "ResourceIdDomainParameterSet";
        protected const string ResourceIdDomainTopicParameterSet = "ResourceIdDomainTopicParameterSet";
        protected const string ResourceIdEventSubscriptionParameterSet = "ResourceIdEventSubscriptionParameterSet";
        protected const string EventSubscriptionNameParameterSet = "EventSubscriptionNameParameterSet";
        protected const string NextLinkParameterSet = "NextLinkParameterSet";

        protected const string EventSubscriptionTopicNameParameterSet = "EventSubscriptionTopicNameParameterSet";
        protected const string EventSubscriptionTopicTypeNameParameterSet = "EventSubscriptionTopicTypeNameParameterSet";
        protected const string EventSubscriptionFullUrlInResponseHelp = "If specified, include the full endpoint URL of the event subscription destination in the response.";

        protected const string AliasKey = "KeyName";
        protected const string AliasResourceGroup = "ResourceGroup";
        protected const string AliasDomain = "Domain";
        protected const string AliasDomainName = "DomainName";
        protected const string AliasDomainTopicName = "DomainTopicName";
        protected const string AliasAadAppIdUri = "AliasAadAppIdUri";
        protected const string AliasAadTenantId = "AliasAadTenantId";

        protected static TimeSpan LongRunningOperationDefaultTimeout = TimeSpan.FromMinutes(1);

        protected const string EventGridDomainVerb = "AzureRmEventGridDomain";
        protected const string EventGridDomainTopicVerb = "AzureRmEventGridDomainTopic";
        protected const string EventGridDomainKeyVerb = "AzureRmEventGridDomainKey";
        protected const string DomainNameParameterSet = "DomainNameParameterSet";
        protected const string DomainTopicNameParameterSet = "DomainTopicNameParameterSet";

        EventGridClient client;

        public EventGridClient Client
        {
            get
            {
                if (this.client == null)
                {
                    this.client = new EventGridClient(this.DefaultContext);
                }
                return this.client;
            }
            set
            {
                this.client = value;
            }
        }
    }
}
