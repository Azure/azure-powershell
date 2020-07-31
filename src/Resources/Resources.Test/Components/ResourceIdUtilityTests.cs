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

namespace Microsoft.Azure.Commands.Resources.Test.Components
{
    using System;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Xunit;

    public class ResourceIdUtilityTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SplitResourceId_TenantLevelId_ReturnsTenantScopeAndRelativeId()
        {
            Guid roleAssignmentId = Guid.NewGuid();
            string resourceId = $"/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentId}";
            
            (string scope, string relativeResourceId) = ResourceIdUtility.SplitResourceId(resourceId);

            Assert.Equal($"/", scope);
            Assert.Equal($"Microsoft.Authorization/roleAssignments/{roleAssignmentId}", relativeResourceId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SplitResourceId_ManagementGroupAsResource_ReturnsTenantScopeAndManagementGroupId()
        {
            const string resourceId = "/providers/Microsoft.Management/myManagementGroup";

            (string scope, string relativeResourceId) = ResourceIdUtility.SplitResourceId(resourceId);

            Assert.Equal($"/", scope);
            Assert.Equal($"Microsoft.Management/myManagementGroup", relativeResourceId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SplitResourceId_ManagementGroupLevelId_ReturnsManagementGroupScopeAndRelativeId()
        {
            Guid roleAssignmentId = Guid.NewGuid();
            string resourceId = $"/providers/Microsoft.Management/ManagementGroups/myManagementGroup/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentId}";

            (string scope, string relativeResourceId) = ResourceIdUtility.SplitResourceId(resourceId);

            Assert.Equal($"/providers/Microsoft.Management/ManagementGroups/myManagementGroup", scope);
            Assert.Equal($"Microsoft.Authorization/roleAssignments/{roleAssignmentId}", relativeResourceId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SplitResourceId_SubscriptionLevelId_ReturnsSubscriptionScopeAndRelativeId()
        {
            Guid subscriptionId = Guid.NewGuid();
            Guid roleAssignmentId = Guid.NewGuid();
            string resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentId}";

            (string scope, string relativeResourceId) = ResourceIdUtility.SplitResourceId(resourceId);

            Assert.Equal($"/subscriptions/{subscriptionId}", scope);
            Assert.Equal($"Microsoft.Authorization/roleAssignments/{roleAssignmentId}", relativeResourceId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SplitResourceId_ResourceGroupLevelId_ReturnsResourceGroupScopeAndRelativeId()
        {
            Guid subscriptionId = Guid.NewGuid();
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/test-what-if-rg/providers/Microsoft.Sql/servers/TestServer";

            (string scope, string relativeResourceId) = ResourceIdUtility.SplitResourceId(resourceId);

            Assert.Equal($"/subscriptions/{subscriptionId}/resourceGroups/test-what-if-rg", scope);
            Assert.Equal("Microsoft.Sql/servers/TestServer", relativeResourceId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SplitResourceId_ResourceGroupAsResource_ReturnsSubscriptionScopeAndResourceGroupId()
        {
            Guid subscriptionId = Guid.NewGuid();
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/test-what-if-rg";

            (string scope, string relativeResourceId) = ResourceIdUtility.SplitResourceId(resourceId);

            Assert.Equal($"/subscriptions/{subscriptionId}", scope);
            Assert.Equal("resourceGroups/test-what-if-rg", relativeResourceId);
        }
    }
}
