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
        public void ParseResourceId_WithSubscriptionLevelId_ReturnsSubscriptionScope()
        {
            Guid subscriptionId = Guid.NewGuid();
            Guid roleAssignmentId = Guid.NewGuid();

            (string scope, string relativeResourceId) = ResourceIdUtility.ParseResourceId(
                $"/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/roleAssignment/{roleAssignmentId}");

            Assert.Equal($"/subscriptions/{subscriptionId}", scope);
            Assert.Equal($"Microsoft.Authorization/roleAssignment/{roleAssignmentId}", relativeResourceId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ParseResourceId_WithResourceScopeLevelId_ReturnsResourceGroupScope()
        {
            Guid subscriptionId = Guid.NewGuid();

            (string scope, string relativeResourceId) = ResourceIdUtility.ParseResourceId(
                $"/subscriptions/{subscriptionId}/resourceGroups/test-what-if-rg/providers/Microsoft.Sql/servers/TestServer");

            Assert.Equal($"/subscriptions/{subscriptionId}/resourceGroups/test-what-if-rg", scope);
            Assert.Equal("Microsoft.Sql/servers/TestServer", relativeResourceId);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ParseResourceId_WithResourceGroupAsResource_ReturnsSubscriptionScope()
        {
            Guid subscriptionId = Guid.NewGuid();

            (string scope, string relativeResourceId) = ResourceIdUtility.ParseResourceId(
                $"/subscriptions/{subscriptionId}/resourceGroups/test-what-if-rg");

            Assert.Equal($"/subscriptions/{subscriptionId}", scope);
            Assert.Equal("resourceGroups/test-what-if-rg", relativeResourceId);
        }
    }
}
