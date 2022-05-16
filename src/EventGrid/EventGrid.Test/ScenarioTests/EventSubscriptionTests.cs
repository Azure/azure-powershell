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

using Microsoft.Azure.Commands.EventGrid.Test.ScenarioTests;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.EventGrid.Tests.ScenarioTests
{
    public class EventSubscriptionTests : EventGridTestRunner
    {
        public EventSubscriptionTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EventGrid_EventSubscription_CustomTopics()
        {
            TestRunner.RunTestScript("EventSubscriptionTests_CustomTopic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EventGrid_EventSubscription_CustomTopics_InputMapping()
        {
            TestRunner.RunTestScript("EventSubscriptionTests_CustomTopic_InputMapping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EventGrid_EventSubscription_CustomTopics_WebhookBatching()
        {
            TestRunner.RunTestScript("EventSubscriptionTests_CustomTopic_Webhook_Batching");
        }

        /* not applicable [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EventGrid_EventSubscription_CustomTopics_WebhookAad()
        {
            TestRunner.RunTestScript("EventSubscriptionTests_CustomTopic_Webhook_AAD");
        }*/

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EventGrid_EventSubscription_AzureSubscription()
        {
            // NOTE: Uncomment when testing in live mode.
            // TestRunner.RunTestScript("EventSubscriptionTests_Subscription");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EventGrid_EventSubscription_AzureSubscription2()
        {
            TestRunner.RunTestScript("EventSubscriptionTests_Subscription2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EventGrid_EventSubscription_ResourceGroup()
        {
            TestRunner.RunTestScript("EventSubscriptionTests_ResourceGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EventGrid_EventSubscription_ResourceGroup2()
        {
            TestRunner.RunTestScript("EventSubscriptionTests_ResourceGroup2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EventGrid_EventSubscription_ResourceCRUD()
        {
            TestRunner.RunTestScript("EventSubscriptionTests_Resource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EventGrid_EventSubscription_Deadletter()
        {
            // NOTE: Uncomment when testing in live mode.
            // TestRunner.RunTestScript("EventSubscriptionTests_Deadletter");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EventGrid_EventSubscription_Domains()
        {
            TestRunner.RunTestScript("EventSubscriptionTests_Domains");
        }

        /* no longer applicable[Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EventGrid_EventSubscription_DomainTopics()
        {
            TestRunner.RunTestScript("EventSubscriptionTests_DomainTopics");
        }*/
    }
}
