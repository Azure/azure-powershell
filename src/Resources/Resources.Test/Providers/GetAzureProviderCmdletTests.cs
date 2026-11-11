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

namespace Microsoft.Azure.Commands.Resources.Test
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.TestFx;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.ServiceManagement.Common.Models;
    using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using Moq;
    using Rest.Azure;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;
    using Xunit.Abstractions;
    /// <summary>
    /// Tests the AzureProvider cmdlets
    /// </summary>
    public class GetAzureProviderCmdletTests : RMTestBase
    {
        /// <summary>
        /// An instance of the cmdlet
        /// </summary>
        private readonly GetAzureProviderCmdletTest cmdlet;

        /// <summary>
        /// A mock of the command runtime
        /// </summary>
        private readonly Mock<ICommandRuntime> commandRuntimeMock;
        private MockCommandRuntime mockRuntime;

        /// <summary>
        /// A mock of the IProvidersOperations
        /// </summary>
        private readonly Mock<IProvidersOperations> providerOperationsMock;

        /// <summary>
        /// A mock of the ISubscriptionsOperations
        /// </summary>
        private readonly Mock<Management.ResourceManager.ISubscriptionsOperations> subscriptionsOperationsMock;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAzureProviderCmdletTests"/> class.
        /// </summary>
        public GetAzureProviderCmdletTests(ITestOutputHelper output)
        {
            this.providerOperationsMock = new Mock<IProvidersOperations>();
            this.subscriptionsOperationsMock = new Mock<Management.ResourceManager.ISubscriptionsOperations>();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            var resourceManagementClient = new Mock<Microsoft.Azure.Management.ResourceManager.IResourceManagementClient>();
            var subscriptionClient = new Mock<Management.ResourceManager.ISubscriptionClient>();

            resourceManagementClient
                .SetupGet(client => client.Providers)
                .Returns(() => this.providerOperationsMock.Object);

            subscriptionClient
                .SetupGet(client => client.Subscriptions)
                .Returns(() => this.subscriptionsOperationsMock.Object);

            this.commandRuntimeMock = new Mock<ICommandRuntime>();
            this.cmdlet = new GetAzureProviderCmdletTest
            {
                //CommandRuntime = commandRuntimeMock.Object,
                ResourceManagerSdkClient = new ResourceManagerSdkClient(resourceManagementClient.Object),
                SubscriptionSdkClient = new SubscriptionSdkClient(subscriptionClient.Object)
            };
            PSCmdletExtensions.SetCommandRuntimeMock(cmdlet, commandRuntimeMock.Object);
            mockRuntime = new MockCommandRuntime();
            commandRuntimeMock.Setup(f => f.Host).Returns(mockRuntime.Host);
        }

        /// <summary>
        /// Validates all Get-AzureRmResourceProvider parameter combinations
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsResourceProviderTests()
        {
            //setup return values
            const string RegisteredProviderNamespace = "Providers.Test1";
            const string UnregisteredProviderNamespace = "Providers.Test2";

            const string ResourceTypeName = "TestResource1";

            var unregisteredProvider = new Provider(
                namespaceProperty: UnregisteredProviderNamespace,
                registrationState: "Unregistered",
                resourceTypes: new[]
                {
                    new ProviderResourceType
                    {
                        Locations = new[] {"West US", "East US", "South US"},
                        ResourceType = "TestResource2"
                    }
                });

            var listResult = new List<Provider>()
            {
                new Provider(
                    namespaceProperty: RegisteredProviderNamespace,
                    registrationState: ResourceManagerSdkClient.RegisteredStateName,
                    resourceTypes: new[]
                    {
                        new ProviderResourceType
                        {
                            Locations = new[] { "West US", "East US" },
                            //Name = ResourceTypeName,
                        }
                    }),
                unregisteredProvider,
            };
            var pagableResult = new Page<Provider>();
            pagableResult.SetItemValue<Provider>(listResult);
            var result = new AzureOperationResponse<IPage<Provider>>()
            {
                Body = pagableResult
            };
            this.providerOperationsMock
                .Setup(f => f.ListWithHttpMessagesAsync(null, null, null, It.IsAny<CancellationToken>()))
                .Returns(() => Task.FromResult(result));

            var locationList = new List<Management.ResourceManager.Models.Location>
            {
                new Management.ResourceManager.Models.Location(name: "southus", displayName: "South US")
            };
            var pagableLocations = new Page<Management.ResourceManager.Models.Location>();
            pagableLocations.SetItemValue<Management.ResourceManager.Models.Location>(locationList);
            var locationsResult = new AzureOperationResponse<IEnumerable<Management.ResourceManager.Models.Location>>()
            {
                Body = pagableLocations
            };
            this.subscriptionsOperationsMock
                .Setup(f => f.ListLocationsWithHttpMessagesAsync(It.IsAny<string>(), null, null, It.IsAny<CancellationToken>()))
                .Returns(() => Task.FromResult(locationsResult));


            // 1. List only registered providers
            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>()))
                .Callback((object obj) =>
                {
                    Assert.IsType<PSResourceProvider[]>(obj);

                    var providers = (PSResourceProvider[])obj;
                    Assert.Single(providers);

                    var provider = providers.Single();
                    Assert.Equal(RegisteredProviderNamespace, provider.ProviderNamespace);
                    Assert.Equal(ResourceManagerSdkClient.RegisteredStateName, provider.RegistrationState);

                    Assert.Single(provider.ResourceTypes);

                    var resourceType = provider.ResourceTypes.Single();
                    Assert.Equal(ResourceTypeName, resourceType.ResourceTypeName);
                    Assert.Equal(2, resourceType.Locations.Length);
                });

            this.cmdlet.ParameterSetOverride = GetAzureProviderCmdlet.ListAvailableParameterSet;

            this.cmdlet.ExecuteCmdlet();

            this.VerifyListCallPatternAndReset();

            // 2. List all providers
            this.cmdlet.ListAvailable = true;

            this.commandRuntimeMock
              .Setup(m => m.WriteObject(It.IsAny<object>()))
              .Callback((object obj) =>
              {
                  Assert.IsType<PSResourceProvider[]>(obj);
                  var providers = (PSResourceProvider[])obj;
                  Assert.Equal(2, providers.Length);
              });

            this.cmdlet.ExecuteCmdlet();

            this.VerifyListCallPatternAndReset();

            // 3. List a single provider by name
            this.cmdlet.ProviderNamespace = new string[] { UnregisteredProviderNamespace };
            this.cmdlet.MyInvocation.BoundParameters.Add("ProviderNamespace", new string[] { UnregisteredProviderNamespace });

            this.providerOperationsMock
              .Setup(f => f.GetWithHttpMessagesAsync(It.IsAny<string>(), null, null, It.IsAny<CancellationToken>()))
              .Returns((Task.FromResult(new AzureOperationResponse<Provider>()
              {
                  Body = unregisteredProvider
              })));

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>()))
                .Callback((object obj) =>
                {
                    Assert.IsType<PSResourceProvider[]>(obj);

                    var providers = (PSResourceProvider[])obj;
                    Assert.Single(providers);

                    var provider = providers.Single();
                    Assert.Equal(UnregisteredProviderNamespace, provider.ProviderNamespace);
                });

            this.cmdlet.ParameterSetOverride = GetAzureProviderCmdlet.IndividualProviderParameterSet;

            this.cmdlet.ExecuteCmdlet();

            this.VerifyGetCallPatternAndReset();
            this.cmdlet.MyInvocation.BoundParameters.Remove("ProviderNamespace");

            // 4. List only registered providers with location
            this.cmdlet.Location = "South US";
            this.cmdlet.ListAvailable = false;
            this.cmdlet.ProviderNamespace = null;

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>()))
                .Callback((object obj) =>
                {
                    Assert.IsType<PSResourceProvider[]>(obj);

                    var providers = (PSResourceProvider[])obj;
                    Assert.Empty(providers);
                });

            this.cmdlet.ParameterSetOverride = GetAzureProviderCmdlet.ListAvailableParameterSet;

            this.cmdlet.ExecuteCmdlet();

            this.VerifyListCallPatternAndReset();

            // 5. List all providers
            this.cmdlet.ListAvailable = true;
            this.cmdlet.Location = "South US";
            this.cmdlet.ProviderNamespace = null;

            this.commandRuntimeMock
              .Setup(m => m.WriteObject(It.IsAny<object>()))
              .Callback((object obj) =>
              {
                  var providers = (PSResourceProvider[])obj;
                  Assert.Empty(providers);

                  var provider = providers.Single();
                  Assert.Equal(UnregisteredProviderNamespace, provider.ProviderNamespace);

                  Assert.Single(provider.ResourceTypes);

                  var resourceType = provider.ResourceTypes.Single();
                  Assert.Equal(ResourceTypeName, resourceType.ResourceTypeName);
              });

            this.cmdlet.ExecuteCmdlet();

            this.VerifyListCallPatternAndReset();
        }

        [Theory]
        [InlineData("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Compute/virtualMachines/testVM", "Microsoft.Compute")]
        [InlineData("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Sql/servers/server1/databases/db1", "Microsoft.Sql")]
        [InlineData("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Compute/virtualMachines/testVM/providers/Microsoft.Authorization/locks/testLock", "Microsoft.Authorization")]
        [InlineData("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/Microsoft.Compute/virtualMachines/testVM/providers/Microsoft.Authorization/locks/testLock/providers/Microsoft.Insights/diagnosticSettings/diagnostic1", "Microsoft.Insights")]
        [InlineData("/providers/Microsoft.Management/managementGroups/testGroup/providers/Microsoft.Authorization/roleAssignments/assignment1", "Microsoft.Authorization")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetsResourceProviderByResourceId(string resourceId, string expectedProviderNamespace)
        {
            var provider = new Provider(
                namespaceProperty: expectedProviderNamespace,
                registrationState: ResourceManagerSdkClient.RegisteredStateName,
                resourceTypes: new[]
                {
                    new ProviderResourceType
                    {
                        ResourceType = "testResources",
                        Locations = new[] { "West US" }
                    }
                });

            var page = new Page<Provider>();
            page.SetItemValue<Provider>(new List<Provider> { provider });
            this.providerOperationsMock
                .Setup(f => f.ListWithHttpMessagesAsync(null, null, null, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new AzureOperationResponse<IPage<Provider>> { Body = page }));
            this.providerOperationsMock
                .Setup(f => f.GetWithHttpMessagesAsync(expectedProviderNamespace, null, null, It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new AzureOperationResponse<Provider> { Body = provider }));

            this.cmdlet.ResourceId = new[] { resourceId };
            this.cmdlet.MyInvocation.BoundParameters.Add("ResourceId", this.cmdlet.ResourceId);
            this.cmdlet.ParameterSetOverride = GetAzureProviderCmdlet.ResourceIdParameterSet;

            this.cmdlet.ExecuteCmdlet();

            this.providerOperationsMock.Verify(
                f => f.GetWithHttpMessagesAsync(expectedProviderNamespace, null, null, It.IsAny<CancellationToken>()),
                Times.Once());
            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>(), It.IsAny<bool>()), Times.Once());
        }

        [Theory]
        [InlineData("not-a-resource-id")]
        [InlineData("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG")]
        [InlineData("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/testRG/providers/")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RejectsInvalidResourceIdBeforeCallingAzure(string resourceId)
        {
            this.cmdlet.ResourceId = new[] { resourceId };
            this.cmdlet.MyInvocation.BoundParameters.Add("ResourceId", this.cmdlet.ResourceId);
            this.cmdlet.ParameterSetOverride = GetAzureProviderCmdlet.ResourceIdParameterSet;

            Assert.Throws<System.ArgumentException>(() => this.cmdlet.ExecuteCmdlet());

            this.providerOperationsMock.Verify(
                f => f.ListWithHttpMessagesAsync(null, null, null, It.IsAny<CancellationToken>()),
                Times.Never());
            this.providerOperationsMock.Verify(
                f => f.GetWithHttpMessagesAsync(It.IsAny<string>(), null, null, It.IsAny<CancellationToken>()),
                Times.Never());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ResourceIdDoesNotBindFromPipeline()
        {
            var parameter = typeof(GetAzureProviderCmdlet)
                .GetProperty(nameof(GetAzureProviderCmdlet.ResourceId))
                .GetCustomAttributes(typeof(ParameterAttribute), true)
                .Cast<ParameterAttribute>()
                .Single();

            Assert.False(parameter.ValueFromPipeline);
            Assert.False(parameter.ValueFromPipelineByPropertyName);
        }

        /// <summary>
        /// Resets the calls on the mocks
        /// </summary>
        private void ResetCalls()
        {
            this.providerOperationsMock.Invocations.Clear();
            this.commandRuntimeMock.Invocations.Clear();
        }

        /// <summary>
        /// Verifies the right call patterns are made
        /// </summary>
        private void VerifyGetCallPatternAndReset()
        {
            this.providerOperationsMock.Verify(f => f.GetWithHttpMessagesAsync(It.IsAny<string>(), null, null, It.IsAny<CancellationToken>()), Times.Once());
            this.providerOperationsMock.Verify(f => f.ListWithHttpMessagesAsync(null, null, null, It.IsAny<CancellationToken>()), Times.Once());
            this.providerOperationsMock.Verify(f => f.ListNextWithHttpMessagesAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>()), Times.Never);
            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>(), It.IsAny<bool>()), Times.Once());
            this.ResetCalls();
        }

        /// <summary>
        /// Verifies the right call patterns are made
        /// </summary>
        private void VerifyListCallPatternAndReset()
        {
            this.providerOperationsMock.Verify(f => f.ListWithHttpMessagesAsync(null, null, null, It.IsAny<CancellationToken>()), Times.Once());
            this.providerOperationsMock.Verify(f => f.ListNextWithHttpMessagesAsync(It.IsAny<string>(), null, It.IsAny<CancellationToken>()), Times.Never());
            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>(), It.IsAny<bool>()), Times.Once());

            this.ResetCalls();
        }

        /// <summary>
        /// Helper class that enables setting the parameter set name
        /// </summary>
        private class GetAzureProviderCmdletTest : GetAzureProviderCmdlet
        {
            /// <summary>
            /// Sets the parameter set name to return
            /// </summary>
            public string ParameterSetOverride { private get; set; }

            /// <summary>
            /// Determines the parameter set name based on the <see cref="ParameterSetOverride"/> property
            /// </summary>
            public override string DetermineParameterSetName()
            {
                return this.ParameterSetOverride;
            }
        }
    }
}
