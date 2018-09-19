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

        protected const string TopicNameParameterSet = "TopicNameParameterSet";
        protected const string ResourceGroupNameParameterSet = "ResourceGroupNameParameterSet";
        protected const string CustomTopicEventSubscriptionParameterSet = "CustomTopicEventSubscriptionParameterSet";
        protected const string SubscriptionAndResourceGroupEventSubscriptionParameterSet = "SubscriptionAndResourceGroupEventSubscriptionParameterSet";
        protected const string ResourceIdEventSubscriptionParameterSet = "ResourceIdEventSubscriptionParameterSet";
        protected const string EventSubscriptionNameParameterSet = "EventSubscriptionNameParameterSet";

        protected const string EventSubscriptionTopicNameParameterSet = "EventSubscriptionTopicNameParameterSet";
        protected const string EventSubscriptionTopicTypeNameParameterSet = "EventSubscriptionTopicTypeNameParameterSet";

        protected const string AliasResourceGroup = "ResourceGroup";

        protected static TimeSpan LongRunningOperationDefaultTimeout = TimeSpan.FromMinutes(1);

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
