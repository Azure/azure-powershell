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
    using Microsoft.Azure.Commands.Resources.Models;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using WindowsAzure.Commands.Test.Utilities.Common;
    using Xunit;

    /// <summary>
    /// Tests the AzureProvider cmdlets
    /// </summary>
    public class UnregisterAzureProviderCmdletTests : RMTestBase
    {
        /// <summary>
        /// An instance of the cmdlet
        /// </summary>
        private readonly UnregisterAzureProviderCmdlet cmdlet;

        /// <summary>
        /// A mock of the client
        /// </summary>
        private readonly Mock<IProvidersOperations> providerOperationsMock;

        /// <summary>
        /// A mock of the command runtime
        /// </summary>
        private readonly Mock<ICommandRuntime> commandRuntimeMock;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAzureProviderCmdletTests"/> class.
        /// </summary>
        public UnregisterAzureProviderCmdletTests()
        {
            this.providerOperationsMock = new Mock<IProvidersOperations>();
            var resourceManagementClient = new Mock<IResourceManagementClient>();

            resourceManagementClient
                .SetupGet(client => client.Providers)
                .Returns(() => this.providerOperationsMock.Object);

            this.commandRuntimeMock = new Mock<ICommandRuntime>();

            this.commandRuntimeMock
                .Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            this.cmdlet = new UnregisterAzureProviderCmdlet
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourceManagerSdkClient = new ResourceManagerSdkClient
                {
                    ResourceManagementClient = resourceManagementClient.Object
                }
            };
        }

        /// <summary>
        /// Validates all Unregister-AzureRmResourceProvider scenarios
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UnregisterResourceProviderTests()
        {
            const string ProviderName = "Providers.Test";

            var provider = new Provider
            {
                NamespaceProperty = ProviderName,
                RegistrationState = ResourcesClient.RegisteredStateName,
                ResourceTypes = new[]
                {
                    new ProviderResourceType
                    {
                        Locations = new[] {"West US", "East US"},
                        ResourceType = "TestResource2"
                    }
                }
            };

            this.providerOperationsMock
                .Setup(client => client.UnregisterAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Callback((string providerName, CancellationToken ignored) =>
                        Assert.Equal(ProviderName, providerName, StringComparer.InvariantCultureIgnoreCase))
                .Returns(() => Task.FromResult(provider));

            this.providerOperationsMock
              .Setup(f => f.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
              .Returns(() => Task.FromResult(provider));

            this.cmdlet.Force = true;

            this.cmdlet.ProviderNamespace = ProviderName;

            // 1. Unregister succeeds
            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>()))
                .Callback((object obj) =>
                {
                    Assert.IsType<PSResourceProvider>(obj);
                    var providerResult = (PSResourceProvider)obj;
                    Assert.Equal(ProviderName, providerResult.ProviderNamespace, StringComparer.InvariantCultureIgnoreCase);
                });

            this.cmdlet.ExecuteCmdlet();

            this.VerifyCallPatternAndReset(succeeded: true);

            try
            {
                this.cmdlet.ExecuteCmdlet();
                Assert.False(true, "The cmdlet succeeded when it should have failed.");
            }
            catch (KeyNotFoundException)
            {
                this.VerifyCallPatternAndReset(succeeded: false);
            }
        }

        /// <summary>
        /// Verifies the right call patterns are made
        /// </summary>
        private void VerifyCallPatternAndReset(bool succeeded)
        {
            this.providerOperationsMock.Verify(f => f.UnregisterAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()), Times.Once());
            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>()), succeeded ? Times.Once() : Times.Never());

            this.providerOperationsMock.ResetCalls();
            this.commandRuntimeMock.ResetCalls();
        }
    }
}
