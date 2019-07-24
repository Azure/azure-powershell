using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class PermissiveRecordMatcherUnitTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PermissiveRecordMatcher_ShouldIgnoreApiVersion()
        {
            var testRequestUris = new string[]
            {
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/providers/Microsoft.Sql?api-version=2016-09-01",
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourcegroups/ps8625?api-version=2016-09-01",
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/providers/Microsoft.Sql/virtualClusters?api-version=2015-05-01-preview",
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/ps8625/providers/Microsoft.Network/virtualNetworks/cl_initial?api-version=2018-12-01",
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/ps8625/providers/Microsoft.Sql/managedInstances/ps8807?api-version=2015-05-01-preview",
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/ps8625/providers/Microsoft.Sql/servers/ps8807?api-version=2015-05-01-preview",
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/ps8625/providers/Microsoft.Sql/virtualClusters?api-version=2015-05-01-preview",
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/ps8625/providers/Microsoft.Sql/managedInstances/ps8807/managedDatabases/db1?api-version=2017-03-01-preview",
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/ps8625/providers/Microsoft.Sql/servers/ps8807/databases/testdb?api-version=2017-03-01-preview",
                "/subscriptions/4cac86b0-1e56-48c2-9df2-669a6d2d87c5/providers/Microsoft.Sql/managedInstances",
                "/subscriptions/4cac86b0-1e56-48c2-9df2-669a6d2d87c5/resourceGroups/ps8625/providers/Microsoft.Sql/managedInstances"
            };

            TestShouldIgnoreApiVersion(
                requestUrisToTest: testRequestUris,
                resourcesToIgnore: new string[1]
                {
                    "Microsoft.Sql/managedInstances",
                },
                expectedNumIgnored: 3);

            TestShouldIgnoreApiVersion(
                 requestUrisToTest: testRequestUris,
                 resourcesToIgnore: new string[1]
                 {
                     "Microsoft.Sql/managedInstances/managedDatabases"
                 },
                 expectedNumIgnored: 1);
        }

        private void TestShouldIgnoreApiVersion(
            IEnumerable<string> requestUrisToTest,
            string[] resourcesToIgnore,
            int expectedNumIgnored)
        {
            var numIgnored = 0;
            foreach (var testUri in requestUrisToTest)
            {
                var result = PermissiveRecordMatcherWithApiExclusion.ShouldIgnoreApiVersion(
                    requestUri: testUri,
                    shouldIgnoreGenericResource: false,
                    providersToIgnore: new Dictionary<string, string>(),
                    resourcesToIgnore: resourcesToIgnore,
                    apiVersion: out var apiVersion);

                Assert.Equal(String.Empty, apiVersion);
                if (result) numIgnored++;
            }
            Assert.Equal(expectedNumIgnored, numIgnored);
        }
    }
}
