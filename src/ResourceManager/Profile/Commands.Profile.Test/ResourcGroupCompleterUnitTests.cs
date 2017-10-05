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

using Microsoft.Azure.Commands.ResourceManager.Common.TabCompletion;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class ResourceGroupCompleterUnitTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReturnsEmptyListWhenNoResourceGroupsExist()
        {
            IList<string> resourceGroupsReturned = new List<string>();

            Assert.Equal(ResourceGroupCompleterAttribute.GetResourceGroups(resourceGroupsReturned, null), new string[] { });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void OneResourceGroupNoDefault()
        {
            IList<string> resourceGroupsReturned = new List<string>();
            resourceGroupsReturned.Add("test1");

            Assert.Equal(ResourceGroupCompleterAttribute.GetResourceGroups(resourceGroupsReturned, null), new string[] { "test1" });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void OneResourceGroupWithDefault()
        {
            IList<string> resourceGroupsReturned = new List<string>();
            resourceGroupsReturned.Add("test1");

            Assert.Equal(ResourceGroupCompleterAttribute.GetResourceGroups(resourceGroupsReturned, "test1"), new string[] { "test1" });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void OneResourceGroupWithInvalidDefault()
        {
            IList<string> resourceGroupsReturned = new List<string>();
            resourceGroupsReturned.Add("test1");

            Assert.Equal(ResourceGroupCompleterAttribute.GetResourceGroups(resourceGroupsReturned, "invalidDefault"), new string[] { "test1" });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultipleResourceGroupsNoDefault()
        {
            IList<string> resourceGroupsReturned = new List<string>();
            resourceGroupsReturned.Add("test1");
            resourceGroupsReturned.Add("test2");
            resourceGroupsReturned.Add("test3");
            resourceGroupsReturned.Add("test4");

            Assert.Equal(ResourceGroupCompleterAttribute.GetResourceGroups(resourceGroupsReturned, null), new string[] { "test1", "test2", "test3", "test4" });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MultipleResourceGroupsWithDefault()
        {
            IList<string> resourceGroupsReturned = new List<string>();
            resourceGroupsReturned.Add("test1");
            resourceGroupsReturned.Add("test2");
            resourceGroupsReturned.Add("test3");
            resourceGroupsReturned.Add("test4");

            Assert.Equal(ResourceGroupCompleterAttribute.GetResourceGroups(resourceGroupsReturned, "test3"), new string[] { "test3", "test1", "test2", "test4" });
        }
    }
}