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

namespace Microsoft.Azure.Commands.TrafficManager.Test.UnitTests
{
    using Microsoft.Azure.Commands.TrafficManager.Utilities;
    using Microsoft.Rest.Azure;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using ServiceManagement.Common.Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using WindowsAzure.Commands.Test.Utilities.Common;
    using Xunit;
    using Xunit.Abstractions;

    public class TrafficManagerClientTests : RMTestBase
    {
        public TrafficManagerClientTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListPaged_ReturnsItemsFromAllPages()
        {
            var requestedPageLinks = new List<string>();
            var pages = new Dictionary<string, IPage<string>>
            {
                { "page-2", new MockPage<string>(new[] { "profile-3" }, "page-3") },
                { "page-3", new MockPage<string>(new[] { "profile-4" }) }
            };

            IList<string> result = TrafficManagerClient.ListPaged(
                () => new MockPage<string>(new[] { "profile-1", "profile-2" }, "page-2"),
                nextPageLink =>
                {
                    requestedPageLinks.Add(nextPageLink);
                    return pages[nextPageLink];
                });

            Assert.Equal(
                new[] { "profile-1", "profile-2", "profile-3", "profile-4" },
                result);
            Assert.Equal(new[] { "page-2", "page-3" }, requestedPageLinks);
        }

        private sealed class MockPage<T> : IPage<T>
        {
            private readonly IList<T> items;

            public MockPage(IEnumerable<T> items, string nextPageLink = null)
            {
                this.items = items.ToList();
                this.NextPageLink = nextPageLink;
            }

            public string NextPageLink { get; }

            public IEnumerator<T> GetEnumerator()
            {
                return this.items.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }
    }
}
