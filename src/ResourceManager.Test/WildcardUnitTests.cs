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
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.ResourceManager.Test
{
    public class WildcardUnitTests
    {
        [Fact]
        public void ShouldGetByNameTest()
        {
            WildCardTestCmdlet cmdlet = new WildCardTestCmdlet();
            Assert.False(cmdlet.ShouldGetByName(null, null));
            Assert.False(cmdlet.ShouldGetByName("*", null));
            Assert.False(cmdlet.ShouldGetByName("testrg*", null));
            Assert.False(cmdlet.ShouldGetByName("*testrg*", null));
            Assert.False(cmdlet.ShouldGetByName("test*rg", null));
            Assert.False(cmdlet.ShouldGetByName("testrg", null));

            Assert.False(cmdlet.ShouldGetByName(null, "*"));
            Assert.False(cmdlet.ShouldGetByName("*", "*"));
            Assert.False(cmdlet.ShouldGetByName("testrg*", "*"));
            Assert.False(cmdlet.ShouldGetByName("*testrg*", "*"));
            Assert.False(cmdlet.ShouldGetByName("test*rg", "*"));
            Assert.False(cmdlet.ShouldGetByName("testrg", "*"));

            Assert.False(cmdlet.ShouldGetByName(null, "testname*"));
            Assert.False(cmdlet.ShouldGetByName("*", "testname*"));
            Assert.False(cmdlet.ShouldGetByName("testrg*", "testname*"));
            Assert.False(cmdlet.ShouldGetByName("*te?strg*", "testname*"));
            Assert.False(cmdlet.ShouldGetByName("test*rg", "testname*"));
            Assert.False(cmdlet.ShouldGetByName("testrg", "testname*"));

            Assert.False(cmdlet.ShouldGetByName(null, "*testname*"));
            Assert.False(cmdlet.ShouldGetByName("*", "*testname*"));
            Assert.False(cmdlet.ShouldGetByName("testrg*", "*testname*"));
            Assert.False(cmdlet.ShouldGetByName("*testrg*", "*testname*"));
            Assert.False(cmdlet.ShouldGetByName("test*rg", "*testname*"));
            Assert.False(cmdlet.ShouldGetByName("testrg", "*testname*"));

            Assert.False(cmdlet.ShouldGetByName(null, "testname"));
            Assert.False(cmdlet.ShouldGetByName("*", "testname"));
            Assert.False(cmdlet.ShouldGetByName("testrg*", "testname"));
            Assert.False(cmdlet.ShouldGetByName("*testrg*", "testname"));
            Assert.False(cmdlet.ShouldGetByName("test*rg", "testname"));
            Assert.True(cmdlet.ShouldGetByName("testrg", "testname"));
        }

        [Fact]
        public void ShouldListByResourceGroupTest()
        {
            WildCardTestCmdlet cmdlet = new WildCardTestCmdlet();
            Assert.False(cmdlet.ShouldListByResourceGroup(null, null));
            Assert.False(cmdlet.ShouldListByResourceGroup("*", null));
            Assert.False(cmdlet.ShouldListByResourceGroup("testrg*", null));
            Assert.False(cmdlet.ShouldListByResourceGroup("*testrg*", null));
            Assert.False(cmdlet.ShouldListByResourceGroup("test*rg", null));
            Assert.True(cmdlet.ShouldListByResourceGroup("testrg", null));

            Assert.False(cmdlet.ShouldListByResourceGroup(null, "*"));
            Assert.False(cmdlet.ShouldListByResourceGroup("*", "*"));
            Assert.False(cmdlet.ShouldListByResourceGroup("testrg*", "*"));
            Assert.False(cmdlet.ShouldListByResourceGroup("*testrg*", "*"));
            Assert.False(cmdlet.ShouldListByResourceGroup("test*rg", "*"));
            Assert.True(cmdlet.ShouldListByResourceGroup("testrg", "*"));

            Assert.False(cmdlet.ShouldListByResourceGroup(null, "testname*"));
            Assert.False(cmdlet.ShouldListByResourceGroup("*", "testname*"));
            Assert.False(cmdlet.ShouldListByResourceGroup("testrg*", "testname*"));
            Assert.False(cmdlet.ShouldListByResourceGroup("*testrg*", "testname*"));
            Assert.False(cmdlet.ShouldListByResourceGroup("test*rg", "testname*"));
            Assert.True(cmdlet.ShouldListByResourceGroup("testrg", "testname*"));

            Assert.False(cmdlet.ShouldListByResourceGroup(null, "*testname*"));
            Assert.False(cmdlet.ShouldListByResourceGroup("*", "*testname*"));
            Assert.False(cmdlet.ShouldListByResourceGroup("testrg*", "*testname*"));
            Assert.False(cmdlet.ShouldListByResourceGroup("*testrg*", "*testname*"));
            Assert.False(cmdlet.ShouldListByResourceGroup("test*rg", "*testname*"));
            Assert.True(cmdlet.ShouldListByResourceGroup("testrg", "*testname*"));

            Assert.False(cmdlet.ShouldListByResourceGroup(null, "testname"));
            Assert.False(cmdlet.ShouldListByResourceGroup("*", "testname"));
            Assert.False(cmdlet.ShouldListByResourceGroup("testrg*", "testname"));
            Assert.False(cmdlet.ShouldListByResourceGroup("*testrg*", "testname"));
            Assert.False(cmdlet.ShouldListByResourceGroup("test*rg", "testname"));
            Assert.False(cmdlet.ShouldListByResourceGroup("testrg", "testname"));
        }

        [Fact]
        public void ShouldListBySubscriptionTest()
        {
            WildCardTestCmdlet cmdlet = new WildCardTestCmdlet();
            Assert.True(cmdlet.ShouldListBySubscription(null, null));
            Assert.True(cmdlet.ShouldListBySubscription("*", null));
            Assert.True(cmdlet.ShouldListBySubscription("testrg*", null));
            Assert.True(cmdlet.ShouldListBySubscription("*testrg*", null));
            Assert.True(cmdlet.ShouldListBySubscription("test*rg", null));
            Assert.False(cmdlet.ShouldListBySubscription("testrg", null));

            Assert.True(cmdlet.ShouldListBySubscription(null, "*"));
            Assert.True(cmdlet.ShouldListBySubscription("*", "*"));
            Assert.True(cmdlet.ShouldListBySubscription("testrg*", "*"));
            Assert.True(cmdlet.ShouldListBySubscription("*testrg*", "*"));
            Assert.True(cmdlet.ShouldListBySubscription("tes*trg", "*"));
            Assert.False(cmdlet.ShouldListBySubscription("testrg", "*"));

            Assert.True(cmdlet.ShouldListBySubscription(null, "testname*"));
            Assert.True(cmdlet.ShouldListBySubscription("*", "testname*"));
            Assert.True(cmdlet.ShouldListBySubscription("t?estrg*", "testname*"));
            Assert.True(cmdlet.ShouldListBySubscription("tes[t]rg*", "testname*"));
            Assert.True(cmdlet.ShouldListBySubscription("test[r]g", "testname*"));
            Assert.False(cmdlet.ShouldListBySubscription("testrg", "testname*"));

            Assert.True(cmdlet.ShouldListBySubscription(null, "*testname*"));
            Assert.True(cmdlet.ShouldListBySubscription("*", "*testname*"));
            Assert.True(cmdlet.ShouldListBySubscription("testrg*", "*testname*"));
            Assert.True(cmdlet.ShouldListBySubscription("*testrg*", "*testname*"));
            Assert.True(cmdlet.ShouldListBySubscription("test*rg", "*testname*"));
            Assert.False(cmdlet.ShouldListBySubscription("testrg", "*testname*"));

            Assert.True(cmdlet.ShouldListBySubscription(null, "testname"));
            Assert.True(cmdlet.ShouldListBySubscription("*", "testname"));
            Assert.True(cmdlet.ShouldListBySubscription("testrg*", "testname"));
            Assert.True(cmdlet.ShouldListBySubscription("*testrg*", "testname"));
            Assert.True(cmdlet.ShouldListBySubscription("test*rg", "testname"));
            Assert.False(cmdlet.ShouldListBySubscription("testrg", "testname"));
        }

        [Fact]
        public void TopLevelWildcardFilterTest()
        {
            WildCardTestCmdlet cmdlet = new WildCardTestCmdlet();

            Assert.Single(cmdlet.TopLevelWildcardFilter("resourcegroup1", "test1", ReturnedResources));
            Assert.Empty(cmdlet.TopLevelWildcardFilter("resourcegroup11", "test1", ReturnedResources));
            Assert.Empty(cmdlet.TopLevelWildcardFilter("1", "test1", ReturnedResources));
            Assert.Empty(cmdlet.TopLevelWildcardFilter("resourcegroup1", "test11", ReturnedResources));
            Assert.Empty(cmdlet.TopLevelWildcardFilter("resourcegroup1", "1", ReturnedResources));

            Assert.Equal(3, cmdlet.TopLevelWildcardFilter("r*g*", "test1", ReturnedResources).Count);
            Assert.Empty(cmdlet.TopLevelWildcardFilter("r*p", "test1", ReturnedResources));
            Assert.Single(cmdlet.TopLevelWildcardFilter("r*1", "test1", ReturnedResources));

            Assert.Equal(6, cmdlet.TopLevelWildcardFilter("resourcegroup1", "*", ReturnedResources).Count);
            Assert.Equal(2, cmdlet.TopLevelWildcardFilter("resourcegroup1", "*1", ReturnedResources).Count);

            Assert.Equal(11, cmdlet.TopLevelWildcardFilter("r*p*", "*", ReturnedResources).Count);
            Assert.Equal(6, cmdlet.TopLevelWildcardFilter("r*1", "*", ReturnedResources).Count);
            Assert.Equal(2, cmdlet.TopLevelWildcardFilter("r*1", "*1", ReturnedResources).Count);
            Assert.Equal(6, cmdlet.TopLevelWildcardFilter("r*1", "t*", ReturnedResources).Count);
        }

        [Fact]
        public void SubResourceWildcardFilterTest()
        {
            WildCardTestCmdlet cmdlet = new WildCardTestCmdlet();

            Assert.Equal(3, cmdlet.SubResourceWildcardFilter("test1", ReturnedResources).Count);
            Assert.Empty(cmdlet.SubResourceWildcardFilter("test11", ReturnedResources));
            Assert.Empty(cmdlet.SubResourceWildcardFilter("1", ReturnedResources));

            Assert.Equal(11, cmdlet.SubResourceWildcardFilter("t*t*", ReturnedResources).Count);
            Assert.Single(cmdlet.SubResourceWildcardFilter("t*t", ReturnedResources));
            Assert.Equal(4, cmdlet.SubResourceWildcardFilter("t*1", ReturnedResources).Count);
        }

        public List<TestResource> ReturnedResources = new List<TestResource>()
        {
            new TestResource("/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/resourcegroup1/providers/Microsoft.CognitiveServices/accounts/test1"),
            new TestResource("/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/resourcegroup1/providers/Microsoft.CognitiveServices/accounts/test2"),
            new TestResource("/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/resourcegroup1/providers/Microsoft.CognitiveServices/accounts/test3"),
            new TestResource("/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/resourcegroup1/providers/Microsoft.CognitiveServices/accounts/testing1"),
            new TestResource("/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/resourcegroup1/providers/Microsoft.CognitiveServices/accounts/testing2"),
            new TestResource("/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/resourcegroup1/providers/Microsoft.CognitiveServices/accounts/testing3"),
            new TestResource("/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/resourcegroup2/providers/Microsoft.CognitiveServices/accounts/test1"),
            new TestResource("/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/resourcegroup2/providers/Microsoft.CognitiveServices/accounts/test2"),
            new TestResource("/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/resourcegroup2/providers/Microsoft.CognitiveServices/accounts/test3"),
            new TestResource("/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/resourcegrouptest/providers/Microsoft.CognitiveServices/accounts/test1"),
            new TestResource("/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/resourcegrouptest/providers/Microsoft.CognitiveServices/accounts/testdifferent")
        };
    }

    public class WildCardTestCmdlet : AzureRMCmdlet
    {
        public WildCardTestCmdlet() { }
    }

    public class TestResource
    {
        public TestResource(string Id)
        {
            this.Id = Id;
        }

        public string Id { get; set; }
    }
}
