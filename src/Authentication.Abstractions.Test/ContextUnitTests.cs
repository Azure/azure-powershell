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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Xunit;

namespace Authentication.Abstractions.Test
{
    public class ContextUnitTests
    {
        [Fact]
        public void TestDeepCopy()
        {
            IAzureSubscription subscription = new AzureSubscription()
            {
                Id = "DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDDDD",
                Name = "my sub",
                State = "my state",
            };
            const string SubHomeTenant = "my home tenant";
            subscription.SetHomeTenant(SubHomeTenant);

            IAzureAccount account = new AzureAccount()
            {
                Id = "someone@somewhere.com",
                Type = "User"
            };

            IAzureEnvironment environment = new AzureEnvironment()
            {
                Name = "my environment"
            };
            IAzureTenant tenant = new AzureTenant()
            {
                Id = "DDDDDDDD-DDDD-DDDD-DDDD-DDDDDDDDDDDD"
            };
            IAzureContext original = new AzureContext(subscription, account, environment, tenant);
            const string PropertyKey = "customPropertyKey";
            const string PropertyValue = "customPropertyValue";
            original.SetProperty(PropertyKey, PropertyValue);

            IAzureContext clone = original.DeepCopy();

            // references are not equal
            Assert.NotSame(original, clone);
            Assert.NotSame(original.Subscription, clone.Subscription);
            Assert.NotSame(original.Account, clone.Account);
            Assert.NotSame(original.Environment, clone.Environment);
            Assert.NotSame(original.Tenant, clone.Tenant);

            // values are equal
            Assert.Equal(original.Subscription.Id, clone.Subscription.Id);
            Assert.Equal(original.Account.Id, clone.Account.Id);
            Assert.Equal(original.Environment.Name, clone.Environment.Name);
            Assert.Equal(original.Tenant.Id, clone.Tenant.Id);

            // custom property
            Assert.Equal(SubHomeTenant, clone.Subscription.GetHomeTenant());
            Assert.Equal(PropertyValue, clone.GetProperty(PropertyKey));
        }

        [Fact]
        public void TestDeepCopyNull()
        {
            IAzureContext original = null;
            Assert.Null(original.DeepCopy());
        }
    }
}
