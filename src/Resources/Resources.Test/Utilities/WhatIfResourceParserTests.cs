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

namespace Microsoft.Azure.Commands.Resources.Test.Utilities
{
    using ResourceManager.Cmdlets.Utilities;
    using System;
    using Xunit;

    public class WhatIfResourceParserTests
    {
        [Fact]
        public void ParseResourceId_WithSubscriptionLevelProvider_ReturnsSubscriptionScope()
        {
            Guid subscriptionId = Guid.NewGuid();
            Guid roleAssignmentId = Guid.NewGuid();

            (string scope, string relativePath) = WhatIfResourceIdParser.ParseResourceId(
                $"/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/roleAssignment/{roleAssignmentId}");

            Assert.Equal($"/subscriptions/{subscriptionId}", scope);
            Assert.Equal($"Microsoft.Authorization/roleAssignment/{roleAssignmentId}", relativePath);
        }

        [Fact]
        public void ParseResourceId_WithResourceScopeLevelProvider_ReturnsResourceGroupScope()
        {
            Guid subscriptionId = Guid.NewGuid();

            (string scope, string relativePath) = WhatIfResourceIdParser.ParseResourceId(
                $"/subscriptions/{subscriptionId}/resourceGroups/test-what-if-rg/providers/Microsoft.Sql/servers/TestServer");

            Assert.Equal($"/subscriptions/{subscriptionId}/resourceGroups/test-what-if-rg", scope);
            Assert.Equal("Microsoft.Sql/servers/TestServer", relativePath);
        }

        [Fact]
        public void ParseResourceId_ResourceGroupAsResource_ReturnsSubscriptionScope()
        {
            Guid subscriptionId = Guid.NewGuid();

            (string scope, string relativePath) = WhatIfResourceIdParser.ParseResourceId(
                $"/subscriptions/{subscriptionId}/resourceGroups/test-what-if-rg");

            Assert.Equal($"/subscriptions/{subscriptionId}", scope);
            Assert.Equal("/resourceGroups/test-what-if-rg", relativePath);
        }
    }
}
