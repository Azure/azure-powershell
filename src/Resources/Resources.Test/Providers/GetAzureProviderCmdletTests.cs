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
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.Azure.ServiceManagement.Common.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
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
        /// A mock of the NewResourceManagerSdkClient
        /// </summary>
        private readonly Mock<NewResourceManagerSdkClient> newResourcesClientMock;

        /// <summary>
        /// A mock of the ISubscriptionsOperations
        /// </summary>
        private readonly Mock<Management.ResourceManager.ISubscriptionsOperations> subscriptionsOperationsMock;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAzureProviderCmdletTests"/> class.
        /// </summary>
        public GetAzureProviderCmdletTests(ITestOutputHelper output)
        {
            this.newResourcesClientMock = new Mock<NewResourceManagerSdkClient>();
            this.subscriptionsOperationsMock = new Mock<Management.ResourceManager.ISubscriptionsOperations>();
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            var subscriptionClient = new Mock<Management.ResourceManager.ISubscriptionClient>();

            subscriptionClient
                .SetupGet(client => client.Subscriptions)
                .Returns(() => this.subscriptionsOperationsMock.Object);

            this.commandRuntimeMock = new Mock<ICommandRuntime>();
            this.cmdlet = new GetAzureProviderCmdletTest
            {
                NewResourceManagerSdkClient = newResourcesClientMock.Object,
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
                            ResourceType = ResourceTypeName,
                        }
                    }),
                unregisteredProvider,
            };

            this.newResourcesClientMock
                .Setup(f => f.ListResourceProviders(null, true))
                .Returns(listResult);

            var locationList = new List<Management.ResourceManager.Models.Location>
            {
                new Management.ResourceManager.Models.Location(name: "southus", displayName: "South US")
            };

            var pagableLocations = new Management.ResourceManager.Models.Page<Management.ResourceManager.Models.Location>();
            pagableLocations.SetItemValue(locationList);
            var locationsResult = new AzureOperationResponse<IPage<Management.ResourceManager.Models.Location>>()
            {
                Body = pagableLocations
            };
            this.subscriptionsOperationsMock
                .Setup(f => f.ListLocationsWithHttpMessagesAsync(It.IsAny<string>(), null, null, It.IsAny<System.Threading.CancellationToken>()))
                .Returns(() => System.Threading.Tasks.Task.FromResult(locationsResult));


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

            this.newResourcesClientMock
                .Setup(f => f.ListResourceProviders(UnregisteredProviderNamespace, true))
                .Returns(new List<Provider> { unregisteredProvider });

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
              });

            this.cmdlet.ExecuteCmdlet();

            this.VerifyListCallPatternAndReset();
        }

        /// <summary>
        /// Resets the calls on the mocks
        /// </summary>
        private void ResetCalls()
        {
            this.newResourcesClientMock.Invocations.Clear();
            this.commandRuntimeMock.Invocations.Clear();
        }

        /// <summary>
        /// Verifies the right call patterns are made for a Get (single provider) operation
        /// </summary>
        private void VerifyGetCallPatternAndReset()
        {
            this.newResourcesClientMock.Verify(f => f.ListResourceProviders(It.IsAny<string>(), It.IsAny<bool>()), Times.AtLeastOnce());
            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>(), It.IsAny<bool>()), Times.Once());
            this.ResetCalls();
        }

        /// <summary>
        /// Verifies the right call patterns are made for a List operation
        /// </summary>
        private void VerifyListCallPatternAndReset()
        {
            this.newResourcesClientMock.Verify(f => f.ListResourceProviders(null, It.IsAny<bool>()), Times.AtLeastOnce());
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
