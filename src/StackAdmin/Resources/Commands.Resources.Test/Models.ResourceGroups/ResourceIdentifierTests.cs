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

using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Resources.Test.Models
{
    public class ResourceIdentifierTests
    {
        public ResourceIdentifierTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IdentifierIsConstructedFromProvidedValues()
        {
            ResourceIdentifier id = new ResourceIdentifier();
            id.Subscription = "abc123";
            id.ResourceGroupName = "group1";
            id.ResourceType = "Microsoft.Test/servers/db";
            id.ParentResource = "servers/r12345sql";
            id.ResourceName = "r45678db";

            Assert.Equal("/subscriptions/abc123/resourceGroups/group1/providers/Microsoft.Test/servers/r12345sql/db/r45678db", id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IdentifierIsConstructedWithoutParent()
        {
            ResourceIdentifier id = new ResourceIdentifier();
            id.Subscription = "abc123";
            id.ResourceGroupName = "group1";
            id.ResourceType = "Microsoft.Test/db";
            id.ResourceName = "r45678db";

            Assert.Equal("/subscriptions/abc123/resourceGroups/group1/providers/Microsoft.Test/db/r45678db", id.ToString());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IdentifierIsConstructedWithMissingParameters()
        {
            ResourceIdentifier id = new ResourceIdentifier();

            Assert.True(string.IsNullOrEmpty(id.ToString()));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IdentifierIsParsedFromShortId()
        {
            ResourceIdentifier id = new ResourceIdentifier("/subscriptions/abc123/resourceGroups/group1/providers/Microsoft.Test/db/r45678db");
            Assert.Equal("abc123", id.Subscription);
            Assert.Equal("group1", id.ResourceGroupName);
            Assert.Equal("Microsoft.Test/db", id.ResourceType);
            Assert.Null(id.ParentResource);
            Assert.Equal("r45678db", id.ResourceName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IdentifierIsParsedFromLongId()
        {
            ResourceIdentifier id = new ResourceIdentifier("/subscriptions/abc123/resourceGroups/group1/providers/Microsoft.Test/servers/r12345sql/db/r45678db");
            Assert.Equal("abc123", id.Subscription);
            Assert.Equal("group1", id.ResourceGroupName);
            Assert.Equal("Microsoft.Test/servers/db", id.ResourceType);
            Assert.Equal("servers/r12345sql", id.ParentResource);
            Assert.Equal("r45678db", id.ResourceName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IdentifierIsParsedFromVeryLongId()
        {
            ResourceIdentifier id = new ResourceIdentifier("/subscriptions/abc123/resourceGroups/group1/providers/Microsoft.Test/servers/r12345sql/subserver/r5555/db/r45678db");
            Assert.Equal("abc123", id.Subscription);
            Assert.Equal("group1", id.ResourceGroupName);
            Assert.Equal("Microsoft.Test/servers/subserver/db", id.ResourceType);
            Assert.Equal("servers/r12345sql/subserver/r5555", id.ParentResource);
            Assert.Equal("r45678db", id.ResourceName);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IdentifierThrowsExceptionFromInvalidId()
        {
            Assert.Throws<ArgumentException>(() => new ResourceIdentifier("/subscriptions/abc123/resourceGroups/group1"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IdentifierParsedIsSkippedWithEmptyId()
        {
            ResourceIdentifier id = new ResourceIdentifier(null);
            Assert.Null(id.Subscription);
            Assert.Null(id.ResourceGroupName);
            Assert.Null(id.ResourceType);
            Assert.Null(id.ParentResource);
            Assert.Null(id.ResourceName);

            id = new ResourceIdentifier("");
            Assert.Null(id.Subscription);
            Assert.Null(id.ResourceGroupName);
            Assert.Null(id.ResourceType);
            Assert.Null(id.ParentResource);
            Assert.Null(id.ResourceName);
        }
    }
}
