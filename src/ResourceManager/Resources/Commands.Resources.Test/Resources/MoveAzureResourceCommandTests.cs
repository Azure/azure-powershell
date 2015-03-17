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

using Microsoft.Azure.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.Resources.Test
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.Resources.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Moq;
    using Xunit;

    /// <summary>
    /// Tests the Move-AzureResource cmdlet
    /// </summary>
    public class MoveAzureResourceCommandTests
    {
        /// <summary>
        /// An instance of the cmdlet
        /// </summary>
        private readonly MoveAzureResourceCommand cmdlet;

        /// <summary>
        /// A mock of the client
        /// </summary>
        private readonly Mock<IResourceOperations> resourceOperationsMock;

        /// <summary>
        /// A mock of the command runtime
        /// </summary>
        private readonly Mock<ICommandRuntime> commandRuntimeMock;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAzureProviderCmdletTests"/> class.
        /// </summary>
        public MoveAzureResourceCommandTests()
        {
            this.resourceOperationsMock = new Mock<IResourceOperations>();
            var resourceManagementClient = new Mock<IResourceManagementClient>();

            resourceManagementClient
                .SetupGet(client => client.Resources)
                .Returns(() => this.resourceOperationsMock.Object);

            this.commandRuntimeMock = new Mock<ICommandRuntime>();

            this.commandRuntimeMock
                .Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() => true);

            var profile = new AzureProfile();
            var account = new AzureAccount { Id = "mockAccount", Type = AzureAccount.AccountType.User };
            var subscription1 = new AzureSubscription
            {
                Account = "mockAccount",
                Environment = EnvironmentName.AzureCloud,
                Id = new Guid("13ffca9d-bfdd-4502-983b-7a6459a14a52"),
                Name = "mockSubscription"
            };
            profile.Accounts.Add(account.Id, account);
            profile.Subscriptions.Add(subscription1.Id, subscription1);
            profile.DefaultSubscription = subscription1;

            this.cmdlet = new MoveAzureResourceCommand
            {
                Profile = profile,
                CommandRuntime = commandRuntimeMock.Object,
                ResourcesClient = new ResourcesClient
                {
                    ResourceManagementClient = resourceManagementClient.Object
                }
            };
        }

        /// <summary>
        /// Validates all Move-AzureResource scenarios
        /// </summary>
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MoveResourceTests()
        {
            const string SourceResourceGroupName = "rg1";
            const string TargetResourceGroupName = "target";

            var cmdletOutput = true;

            var moveResult = new AzureOperationResponse
            {
                RequestId = Guid.Empty.ToString(),
                StatusCode = HttpStatusCode.Accepted,
            };

            var resourcesToMove = new[]
            {
                "/subscriptions/13ffca9d-bfdd-4502-983b-7a6459a14a52/resourceGroups/rg1/providers/Providers.Test/ResourceType1/resource1",
            };

            this.resourceOperationsMock
                .Setup(client => client.MoveResourcesAsync(It.IsAny<string>(), It.IsAny<ResourcesMoveInfo>(), It.IsAny<CancellationToken>()))
                .Callback((string sourceResourceGroupName, ResourcesMoveInfo resourceMoveInfo, CancellationToken ignored) =>
                    {
                        Assert.NotNull(resourceMoveInfo);
                        Assert.Equal("/subscriptions/13ffca9d-bfdd-4502-983b-7a6459a14a52/resourceGroups/" + TargetResourceGroupName, resourceMoveInfo.TargetResourceGroup, StringComparer.InvariantCultureIgnoreCase);
                        Assert.True(resourceMoveInfo.Resources.Count == resourcesToMove.Length &&  resourceMoveInfo.Resources.All(resource => resourcesToMove.Any(resourceToMove => string.Equals(resourceToMove, resource, StringComparison.InvariantCultureIgnoreCase))));
                        Assert.Equal(SourceResourceGroupName, sourceResourceGroupName, StringComparer.InvariantCultureIgnoreCase);
                    })
                .Returns(() => Task.FromResult(moveResult));

            this.commandRuntimeMock
                .Setup(m => m.WriteObject(It.IsAny<object>()))
                .Callback((object value) =>
                {
                    Assert.IsType<bool>(value);
                    Assert.Equal(cmdletOutput, (bool)value);
                });

            this.cmdlet.PassThru = true;
            this.cmdlet.Force = true;

            this.cmdlet.DestinationResourceGroupName = TargetResourceGroupName;

            // move one resource to a resource group
            this.cmdlet.ResourceId = resourcesToMove;
            this.cmdlet.ExecuteCmdlet();

            this.VerifyCallPatternAndReset();

            // move several resources into a resource group
            this.cmdlet.PassThru = false;
            resourcesToMove = new[]
            {
                "/subscriptions/13ffca9d-bfdd-4502-983b-7a6459a14a52/resourceGroups/rg1/providers/Providers.Test/ResourceType1/resource1",
                "/subscriptions/13ffca9d-bfdd-4502-983b-7a6459a14a52/resourceGroups/rg1/providers/Providers.Test/ResourceType1/resource2",
                "/subscriptions/13ffca9d-bfdd-4502-983b-7a6459a14a52/resourceGroups/rg1/providers/Providers.Test/ResourceType2/resource1",
                "/subscriptions/13ffca9d-bfdd-4502-983b-7a6459a14a52/resourceGroups/rg1/providers/Providers.Test/ResourceType2/resource2",
            };

            this.cmdlet.ResourceId = resourcesToMove;

            this.cmdlet.ExecuteCmdlet();

            this.VerifyCallPatternAndReset();

            // move several resources from different resource groups into a resource group
            resourcesToMove = new[]
            {
                "/subscriptions/13ffca9d-bfdd-4502-983b-7a6459a14a52/resourceGroups/rg1/providers/Providers.Test/ResourceType1/resource1",
                "/subscriptions/13ffca9d-bfdd-4502-983b-7a6459a14a52/resourceGroups/rg2/providers/Providers.Test/ResourceType1/resource1",
            };

            this.cmdlet.ResourceId = resourcesToMove;

            try
            {
                this.cmdlet.ExecuteCmdlet();
                Assert.False(true, "The cmdlet succeeded when it should have failed.");
            }
            catch (PSArgumentException)
            {
                this.VerifyCallPatternAndReset(started: false);
            }

            // invalid resource id - whitespace string
            resourcesToMove = new[]
            {
                "     ",
            };

            this.cmdlet.ResourceId = resourcesToMove;

            try
            {
                this.cmdlet.ExecuteCmdlet();
                Assert.False(true, "The cmdlet succeeded when it should have failed.");
            }
            catch (PSArgumentException)
            {
                this.VerifyCallPatternAndReset(started: false);
            }

            // invalid resource id - tenant resource
            resourcesToMove = new[]
            {
                "/subscriptions/13ffca9d-bfdd-4502-983b-7a6459a14a52/providers/Providers.Test/ResourceType1/resource1",
            };

            this.cmdlet.ResourceId = resourcesToMove;

            // invalid resource id
            resourcesToMove = new[]
            {
                "/subs/13ffca9d-bfdd-4502-983b-7a6459a14a52/rrg/rg1/prov/Providers.Test/ResourceType1/resource1",
            };

            try
            {
                this.cmdlet.ExecuteCmdlet();
                Assert.False(true, "The cmdlet succeeded when it should have failed.");
            }
            catch (PSArgumentException)
            {
                this.VerifyCallPatternAndReset(started: false);
            }
        }

        /// <summary>
        /// Verifies the right call patterns are made
        /// </summary>
        private void VerifyCallPatternAndReset(bool started = true)
        {
            this.resourceOperationsMock.Verify(f => f.MoveResourcesAsync(It.IsAny<string>(), It.IsAny<ResourcesMoveInfo>(), It.IsAny<CancellationToken>()), started ? Times.Once() : Times.Never());
            this.commandRuntimeMock.Verify(f => f.WriteObject(It.IsAny<object>()), this.cmdlet.PassThru ? Times.Once() : Times.Never());

            this.resourceOperationsMock.ResetCalls();
            this.commandRuntimeMock.ResetCalls();
        }
    }
}
