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

namespace Microsoft.Azure.Commands.Resources.Test.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.TestFx;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.ServiceManagement.Common.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using Moq;
    using Xunit;
    using Xunit.Abstractions;
    using Xunit.Sdk;

    public class PolicyAliasTests : RMTestBase
    {
        /// <summary>
        /// An instance of the cmdlet
        /// </summary>
        private readonly GetAzurePolicyAlias cmdlet;

        /// <summary>
        /// A mock of the provider operations
        /// </summary>
        private readonly Mock<IProvidersOperations> providerOperationsMock;

        /// <summary>
        /// A mock of the command runtime
        /// </summary>
        private readonly Mock<ICommandRuntime> commandRuntimeMock;

        public PolicyAliasTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            var resourceManagementClient = new Mock<IResourceManagementClient>();
            this.providerOperationsMock = new Mock<IProvidersOperations>();

            resourceManagementClient
                .SetupGet(client => client.Providers)
                .Returns(() => this.providerOperationsMock.Object);

            this.cmdlet = new GetAzurePolicyAlias { ResourceManagerSdkClient = new ResourceManagerSdkClient(resourceManagementClient.Object) };

            var mockRuntime = new MockCommandRuntime();
            this.commandRuntimeMock = new Mock<ICommandRuntime>();
            this.commandRuntimeMock.Setup(f => f.Host).Returns(mockRuntime.Host);
            this.cmdlet.SetCommandRuntimeMock(this.commandRuntimeMock.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmPolicyAliasByNamespaceNoAliases()
        {
            var providers = new ProviderListBuilder();
            providers.AddProvider("Name1");
            providers.AddProvider("Name2");
            providers.AddProvider("Name3");

            var listResult = providers.List;
            this.SetupAliasListResult(listResult);

            // no args provided, no aliases, so no matching results
            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 0); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // list providers with namespace matching, none have aliases, so no matching results
            this.cmdlet.NamespaceMatch = "name";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 0); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // adding resource type matching shouldn't change the results
            this.cmdlet.ResourceTypeMatch = "resource";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 0); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // only resource type matching shouldn't change the results
            this.cmdlet.NamespaceMatch = null;

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 0); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // repeat with the list available switch, none should come back since none have resource types
            this.cmdlet.ListAvailable = true;

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 0); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmPolicyAliasByNamespace()
        {
            var providers = new ProviderListBuilder();
            providers.AddProvider("Provider1").AddResourceType("ResourceType1").AddAlias("Alias1");
            var resourceType22 = providers.AddProvider("Provider2").AddResourceType("ResourceType2");
            var resourceType33 = providers.AddProvider("Provider12").AddResourceType("ResourceType3");

            var listResult = providers.List;
            this.SetupAliasListResult(listResult);

            // list available should find all 3
            this.cmdlet.ListAvailable = true;

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 3); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // list by provider match first and third provider should match, but only first has an alias
            this.cmdlet.ListAvailable = false;
            this.cmdlet.NamespaceMatch = "1";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 1); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // with aliases on all providers, should match first and third now
            var alias21 = resourceType22.AddAlias("Alias1");
            alias21.AddAliasPath("Properties.Alias1Path");

            var alias22 = resourceType22.AddAlias("Alias2");
            alias22.AddAliasPath("Properties.Alias2Path");

            var alias3 = resourceType33.AddAlias("Alias3");
            alias3.AddAliasPath("Properties.Alias3Path");

            listResult = providers.List;
            this.SetupAliasListResult(listResult);

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 2); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // match resource type that doesn't exist in matching providers, so no results
            this.cmdlet.ResourceTypeMatch = "2";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 0); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // matching all resource types should give 2 result matches
            this.cmdlet.ResourceTypeMatch = "type";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 2); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // resource types in the third provider should give 1 result match
            this.cmdlet.ResourceTypeMatch = "3";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 1); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmPolicyAliasByResourceType()
        {
            var providers = new ProviderListBuilder();
            var provider1 = providers.AddProvider("Provider1");
            provider1.AddResourceType("ResourceType11").AddAlias("Alias22");
            provider1.AddResourceType("ResourceType12").AddAlias("Alias21");
            provider1.AddResourceType("ResourceType21").AddAlias("Alias12");
            provider1.AddResourceType("ResourceType22").AddAlias("Alias11");

            var listResult = providers.List;
            this.SetupAliasListResult(listResult);

            // should match just the second resource type
            this.cmdlet.ResourceTypeMatch = "12";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 1); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // this should match the first 3
            this.cmdlet.ResourceTypeMatch = "1";
            listResult = providers.List;
            this.SetupAliasListResult(listResult);

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 3); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // adding alias match of 11 should eliminate any matches
            this.cmdlet.AliasMatch = "11";
            listResult = providers.List;
            this.SetupAliasListResult(listResult);

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 0); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // removing resource type match should result in one match
            this.cmdlet.ResourceTypeMatch = null;
            listResult = providers.List;
            this.SetupAliasListResult(listResult);

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 1); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // less restrictive alias match should result in 3 matches
            this.cmdlet.AliasMatch = "1";
            listResult = providers.List;
            this.SetupAliasListResult(listResult);

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 3); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmPolicyAliasByAlias()
        {
            var providers = new ProviderListBuilder();
            var resourceType = providers.AddProvider("Provider1").AddResourceType("ResourceType1");
            resourceType.AddAlias("Alias22").AddAliasPath("Properties.Alias22", Enumerable.Empty<string>());
            resourceType.AddAlias("Alias21");
            resourceType.AddAlias("Alias12").AddAliasPath("Properties.Alias12", new[] { "2018-01-01", "2016-01-01" });
            resourceType.AddAlias("Alias11");

            var listResult = providers.List;
            this.SetupAliasListResult(listResult);

            // should match just the second alias
            this.cmdlet.AliasMatch = "12";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 1); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // should match both aliases now
            this.cmdlet.PathMatch = "Properties.Alias22";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 1); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // now should match just the second alias
            this.cmdlet.PathMatch = "Properties.Alias12";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 1); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // add api version, should still match second alias
            this.cmdlet.ApiVersionMatch = "2018";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 1); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // should still match because of alias and path match
            this.cmdlet.ApiVersionMatch = "2017";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 1); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // just the api version match
            this.cmdlet.AliasMatch = null;
            this.cmdlet.PathMatch = null;

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 0); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmPolicyAliasAllParameters()
        {
            var providers = new ProviderListBuilder();
            providers.AddProvider("Provider1");
            providers.AddProvider("Provider2").AddResourceType("ResourceType2");
            providers.AddProvider("Provider3").AddResourceType("ResourceType3", new[] { "ApiVersion3" }).AddAlias("Alias3");
            providers.AddProvider("Provider4").AddResourceType("ResourceType4", new[] { "ApiVersion4" }, new[] { "Location4" }).AddAlias("Alias4");
            providers.AddProvider("Provider5").AddResourceType("ResourceType5").AddAlias("Alias5");
            providers.AddProvider("Provider6").AddResourceType("ResourceType6").AddAlias("Alias6").AddAliasPath("AliasPath6");
            providers.AddProvider("Provider7").AddResourceType("ResourceType7").AddAlias("Alias7").AddAliasPath("AliasPath7", new[] { "ApiVersion7" });

            // Special provider values
            providers.AddProvider("Provider8").AddResourceType("ResourceType8").AddNullAlias();
            providers.AddProvider("Provider9").AddResourceType("ResourceType9").AddNullLocation();
            providers.AddProvider("Provider10").AddResourceType("ResourceType10").AddNullApiVersion();
            providers.AddProvider("Provider11").AddResourceType("ResourceType11").AddAlias("Alias11").AddNullAliasPath();

            var listResult = providers.List;
            this.SetupAliasListResult(listResult);

            // should just match the last one
            this.cmdlet.ApiVersionMatch = "7";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 1); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // should match the last 2
            this.cmdlet.PathMatch = "6";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 2); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // should match the last 3
            this.cmdlet.AliasMatch = "5";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 3); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // should match the last 4
            this.cmdlet.LocationMatch = "4";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 4); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // should match 3 through 6
            this.cmdlet.ApiVersionMatch = "3";

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 4); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();

            // with list all switch match all other providers with resource types (6)
            this.cmdlet.ListAvailable = true;

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 10); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetAzureRmPolicyAliasWithPathMetadata()
        {
            var providers = new ProviderListBuilder();
            var provider = providers.AddProvider("Provider1");
            var resourceTypes = provider.AddResourceType("ResourceType1");
            var alias = resourceTypes.AddAlias("Alias1");
            alias.AddDefaultAliasPathMetadata(AliasPathAttributes.Modifiable, AliasPathTokenType.String);
            alias.AddAliasPath("properties.alias1", new List<string> { "2020-01-01" }, new AliasPathMetadata(AliasPathAttributes.Modifiable, AliasPathTokenType.Object));

            var listResult = providers.List;
            this.SetupAliasListResult(listResult);

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>(), It.IsAny<bool>()))
                .Callback((object obj, bool listAll) => { this.AssertResult(obj, listResult, 1); });

            this.cmdlet.ExecuteCmdlet();
            this.VerifyListCallPatternAndReset();
        }
        /// <summary>
        /// Helper method that sets up the expected result of the alias list cmdlet
        /// </summary>
        /// <param name="providerEnumerable"></param>
        private void SetupAliasListResult(IEnumerable<Provider> providerEnumerable)
        {
            var providerList = providerEnumerable.ToList();

            var pageResponse = new Page<Provider>();
            pageResponse.SetItemValue(providerList);
            using (var response = new AzureOperationResponse<IPage<Provider>> { Body = pageResponse })
            {
                this.providerOperationsMock
                    .Setup(p => p.ListAtTenantScopeWithHttpMessagesAsync(It.IsAny<int?>(), It.IsAny<string>(), null, It.IsAny<CancellationToken>()))
                    .Returns(() => Task.FromResult(response));
            };
        }

        private void AssertResult(object resultObject, IEnumerable<Provider> expectedProvidersEnumerable, int expectedRecords)
        {
            var expectedProviders = expectedProvidersEnumerable.ToList();
            Assert.IsType<List<PsResourceProviderAlias>>(resultObject);
            var actualProviders = (List<PsResourceProviderAlias>)resultObject;
            Assert.NotNull(actualProviders);

            // validate the number of result records
            Assert.Equal(actualProviders.Count, expectedRecords);

            // validate the test is expecting the correct number of records 
            var recordCount = this.ExpectedRecordCount(expectedProviders);
            Assert.Equal(expectedRecords, recordCount);

            // validate each result record is in the expected set
            foreach (var actualProvider in actualProviders)
            {
                // verify the actual namespace is in the expected collection
                var expectedProvider = expectedProviders.SingleOrDefault(item => item.NamespaceProperty.EqualsInsensitively(actualProvider.Namespace));
                Assert.NotNull(expectedProvider);

                // verify the actual resource type is in the expected provider
                var expectedResourceType = expectedProvider.ResourceTypes.SingleOrDefault(item => item.ResourceType.EqualsInsensitively(actualProvider.ResourceType));
                Assert.NotNull(expectedResourceType);

                // verify alias collection
                if (actualProvider.Aliases == null)
                {
                    Assert.Null(expectedResourceType.Aliases);
                    continue;
                }

                // verify the result provider info record has the expected aliases
                foreach (var actualAlias in actualProvider.Aliases)
                {
                    var expectedAlias = expectedResourceType.Aliases.SingleOrDefault(item => item.Name.EqualsInsensitively(actualAlias.Name));
                    Assert.NotNull(expectedAlias);

                    Assert.Equal(expectedAlias.DefaultMetadata?.Attributes, actualAlias.DefaultMetadata?.Attributes);
                    Assert.Equal(expectedAlias.DefaultMetadata?.Type, actualAlias.DefaultMetadata?.Type);

                    // verify paths collection
                    if (actualAlias.Paths == null)
                    {
                        Assert.Null(expectedAlias.Paths);
                        continue;
                    }

                    foreach (var actualPath in actualAlias.Paths)
                    {
                        var expectedPath = expectedAlias.Paths.SingleOrDefault(item => item.Path.EqualsInsensitively(actualPath.Path));
                        Assert.NotNull(expectedPath);

                        Assert.Equal(actualPath.Metadata?.Attributes, expectedPath.Metadata?.Attributes);
                        Assert.Equal(actualPath.Metadata?.Type, expectedPath.Metadata?.Type);

                        // verify API version collection
                        if (actualPath.ApiVersions == null)
                        {
                            Assert.Null(expectedPath.ApiVersions);
                            continue;
                        }

                        foreach (var apiVersion in actualPath.ApiVersions)
                        {
                            Assert.NotNull(expectedPath.ApiVersions.SingleOrDefault(item => item.EqualsInsensitively(apiVersion)));
                        }
                    }
                }
            }
        }

        private int ExpectedRecordCount(List<Provider> expectedProviders)
        {
            var namespaceMatch = this.cmdlet.NamespaceMatch;
            var resourceTypeMatch = this.cmdlet.ResourceTypeMatch;
            var locationMatch = this.cmdlet.LocationMatch;
            var aliasMatch = this.cmdlet.AliasMatch;
            var pathMatch = this.cmdlet.PathMatch;
            var apiVersionMatch = this.cmdlet.ApiVersionMatch;
            var listAvailable = this.cmdlet.ListAvailable;

            bool isMatch(string s1, string s2) => s1.IndexOf(s2, StringComparison.OrdinalIgnoreCase) >= 0;

            int count = 0;
            foreach (var expectedProvider in expectedProviders.Where(p => string.IsNullOrEmpty(namespaceMatch) || isMatch(p.NamespaceProperty, namespaceMatch)))
            {
                foreach (var expectedResourceType in expectedProvider.ResourceTypes.Where(r => string.IsNullOrEmpty(resourceTypeMatch) || isMatch(r.ResourceType, resourceTypeMatch)))
                {
                    if (listAvailable)
                    {
                        count++;
                    }
                    else if (expectedResourceType.Aliases.Coalesce().Any())
                    {
                        if (!string.IsNullOrEmpty(locationMatch) && expectedResourceType.Locations.Coalesce().Any(l => isMatch(l, locationMatch)))
                        {
                            count++;
                        }
                        else if (!string.IsNullOrEmpty(apiVersionMatch) && expectedResourceType.ApiVersions.Coalesce().Any(v => isMatch(v, apiVersionMatch)))
                        {
                            count++;
                        }
                        else if (!string.IsNullOrEmpty(aliasMatch) && expectedResourceType.Aliases.Coalesce().Any(a => isMatch(a.Name, aliasMatch)))
                        {
                            count++;
                        }
                        else if (!string.IsNullOrEmpty(pathMatch) && expectedResourceType.Aliases.Coalesce().Any(a => a.Paths.Coalesce().Any(p => isMatch(p.Path, pathMatch))))
                        {
                            count++;
                        }
                        else if (!string.IsNullOrEmpty(apiVersionMatch) && expectedResourceType.Aliases.Coalesce().Any(a => a.Paths.Coalesce().Any(p => p.ApiVersions.Coalesce().Any(v => isMatch(v, apiVersionMatch)))))
                        {
                            count++;
                        }
                        else if (string.IsNullOrEmpty(locationMatch) && string.IsNullOrEmpty(aliasMatch) && string.IsNullOrEmpty(pathMatch) && string.IsNullOrEmpty(apiVersionMatch))
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Verifies the right call patterns are made
        /// </summary>
        private void VerifyListCallPatternAndReset()
        {
            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>(), It.IsAny<bool>()), Times.Once());
            this.commandRuntimeMock.ResetCalls();
        }
    }
}
