using Microsoft.Azure.Commands.TestFx.Recorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Microsoft.Azure.Commands.Sql.Test.UnitTests
{
    public class PermissiveRecordMatcherWithResourceApiExclusionUnitTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PermissiveRecordMatcherWithResourceApiExclusion_ContainsIgnoredProvider()
        {
            var testRequestUris = new string[]
            {
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/providers/Microsoft.Sql?api-version=2016-09-01",
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourcegroups/ps8625?api-version=2016-09-01",

                // - The above uris should be ignored
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/providers/Microsoft.Sql/virtualClusters?api-version=2015-05-01-preview",
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/ps8625/providers/Microsoft.Sql/virtualClusters?api-version=2015-05-01-preview",

                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/ps8625/providers/Microsoft.Network/virtualNetworks/cl_initial?api-version=2018-12-01",

                "/subscriptions/4cac86b0-1e56-48c2-9df2-669a6d2d87c5/providers/Microsoft.Sql/managedInstances",
                "/subscriptions/4cac86b0-1e56-48c2-9df2-669a6d2d87c5/resourceGroups/ps8625/providers/Microsoft.Sql/managedInstances",
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/ps8625/providers/Microsoft.Sql/managedInstances/ps8807?api-version=2015-05-01-preview",
                "/subscriptions/cca24ec8-99b5-4aa7-9ff6-486e886f304c/resourceGroups/cl_one/providers/Microsoft.Sql/managedInstances/dc-cmdlet-serverps8052?api-version=2018-06-01-preview",

                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/ps8625/providers/Microsoft.Sql/managedInstances/ps8807/managedDatabases/db1?api-version=2017-03-01-preview",
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/ps8625/providers/Microsoft.Sql/servers/ps8807?api-version=2015-05-01-preview",
                "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/ps8625/providers/Microsoft.Sql/servers/ps8807/databases/testdb?api-version=2017-03-01-preview",
            };

            TestContainsIgnoredProvider(
                requestUrisToTest: testRequestUris,
                resourcesToIgnore: null,
                expectedNumIgnored: 0);

            TestContainsIgnoredProvider(
                requestUrisToTest: testRequestUris,
                resourcesToIgnore: new string[1]
                {
                    "Microsoft.Sql/managedInstances",
                },
                expectedNumIgnored: 4);

            var len = testRequestUris.Count();
            TestContainsIgnoredProvider(
                 requestUrisToTest: testRequestUris,
                 resourcesToIgnore: new string[6]
                 {
                     "Microsoft.Network/virtualNetworks",
                     "Microsoft.Sql/virtualClusters",
                     "Microsoft.Sql/managedInstances",
                     "Microsoft.Sql/managedInstances/managedDatabases",
                     "Microsoft.Sql/servers",
                     "Microsoft.Sql/servers/databases"
                 },
                 expectedNumIgnored: 10);
        }

        private void TestContainsIgnoredProvider(
            IEnumerable<string> requestUrisToTest,
            string[] resourcesToIgnore,
            int expectedNumIgnored)
        {
            var numIgnored = 0;
            foreach (var testUri in requestUrisToTest)
            {
                var result = PermissiveRecordMatcherWithResourceApiExclusion.ContainsIgnoredProvider(
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
