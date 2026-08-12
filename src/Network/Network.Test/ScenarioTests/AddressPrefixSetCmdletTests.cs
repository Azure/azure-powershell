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

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.Network.Test.ScenarioTests;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Commands.Network.Test.ScenarioTests
{
    public class AddressPrefixSetCmdletTests : NetworkTestRunner
    {
        private const string ResourceGroupName = "test-rg";
        private const string ApplicationSecurityGroupName = "test-asg";
        private const string AddressPrefixSetName = "test-prefix-set";
        private const string AddressPrefixSetId =
            "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.Network/applicationSecurityGroups/test-asg/addressPrefixSets/test-prefix-set";

        private readonly Mock<IAddressPrefixSetsOperations> addressPrefixSets = new Mock<IAddressPrefixSetsOperations>();
        private readonly Mock<IApplicationSecurityGroupsOperations> applicationSecurityGroups = new Mock<IApplicationSecurityGroupsOperations>();
        private readonly Mock<INetworkManagementClient> networkManagementClient = new Mock<INetworkManagementClient>();

        public AddressPrefixSetCmdletTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
            this.networkManagementClient.SetupGet(client => client.AddressPrefixSets).Returns(this.addressPrefixSets.Object);
            this.networkManagementClient.SetupGet(client => client.ApplicationSecurityGroups).Returns(this.applicationSecurityGroups.Object);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void GetAddressPrefixSetReturnsRequestedResource()
        {
            var expected = CreateSdkAddressPrefixSet(new[] { "10.0.0.0/16" });
            this.addressPrefixSets
                .Setup(client => client.GetWithHttpMessagesAsync(
                    ResourceGroupName,
                    ApplicationSecurityGroupName,
                    AddressPrefixSetName,
                    It.IsAny<Dictionary<string, List<string>>>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AzureOperationResponse<AddressPrefixSet> { Body = expected });

            var runtime = new MockCommandRuntime();
            var command = this.CreateCommand<GetAzureRmAddressPrefixSetCommand>(runtime);
            command.ResourceGroupName = ResourceGroupName;
            command.ApplicationSecurityGroupName = ApplicationSecurityGroupName;
            command.Name = AddressPrefixSetName;

            command.Execute();

            var result = Assert.IsType<PSAddressPrefixSet>(Assert.Single(runtime.OutputPipeline));
            Assert.Equal(AddressPrefixSetId, result.Id);
            Assert.Equal(AddressPrefixSetName, result.Name);
            Assert.Equal("10.0.0.0/16", Assert.Single(result.AddressPrefixes));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void NewAddressPrefixSetCreatesResource()
        {
            AddressPrefixSet request = null;
            var prefixes = new[] { "10.0.0.0/16", "2001:db8::/32" };
            this.applicationSecurityGroups
                .Setup(client => client.GetWithHttpMessagesAsync(
                    ResourceGroupName,
                    ApplicationSecurityGroupName,
                    It.IsAny<Dictionary<string, List<string>>>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AzureOperationResponse<ApplicationSecurityGroup>
                {
                    Body = new ApplicationSecurityGroup()
                });
            this.addressPrefixSets
                .Setup(client => client.CreateOrUpdateWithHttpMessagesAsync(
                    ResourceGroupName,
                    ApplicationSecurityGroupName,
                    AddressPrefixSetName,
                    It.IsAny<AddressPrefixSet>(),
                    It.IsAny<Dictionary<string, List<string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, string, string, AddressPrefixSet, Dictionary<string, List<string>>, CancellationToken>(
                    (_, _, _, resource, _, _) => request = resource)
                .ReturnsAsync(() => new AzureOperationResponse<AddressPrefixSet>
                {
                    Body = CreateSdkAddressPrefixSet(request.Properties.AddressPrefixes)
                });

            var runtime = new MockCommandRuntime();
            var command = this.CreateCommand<NewAzureRmAddressPrefixSetCommand>(runtime);
            command.ResourceGroupName = ResourceGroupName;
            command.ApplicationSecurityGroupName = ApplicationSecurityGroupName;
            command.Name = AddressPrefixSetName;
            command.AddressPrefix = prefixes;

            command.Execute();

            Assert.Equal(prefixes, request.Properties.AddressPrefixes);
            var result = Assert.IsType<PSAddressPrefixSet>(Assert.Single(runtime.OutputPipeline));
            Assert.Equal(prefixes, result.AddressPrefixes);
            this.applicationSecurityGroups.VerifyAll();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void SetAddressPrefixSetUpdatesResourceById()
        {
            AddressPrefixSet request = null;
            var prefixes = new[] { "10.1.0.0/16" };
            this.addressPrefixSets
                .Setup(client => client.CreateOrUpdateWithHttpMessagesAsync(
                    ResourceGroupName,
                    ApplicationSecurityGroupName,
                    AddressPrefixSetName,
                    It.IsAny<AddressPrefixSet>(),
                    It.IsAny<Dictionary<string, List<string>>>(),
                    It.IsAny<CancellationToken>()))
                .Callback<string, string, string, AddressPrefixSet, Dictionary<string, List<string>>, CancellationToken>(
                    (_, _, _, resource, _, _) => request = resource)
                .ReturnsAsync(() => new AzureOperationResponse<AddressPrefixSet>
                {
                    Body = CreateSdkAddressPrefixSet(request.Properties.AddressPrefixes)
                });

            var runtime = new MockCommandRuntime();
            var command = this.CreateCommand<SetAzureRmAddressPrefixSetCommand>(runtime);
            command.ResourceId = AddressPrefixSetId;
            command.AddressPrefix = prefixes;

            command.Execute();

            Assert.Equal(ResourceGroupName, command.ResourceGroupName);
            Assert.Equal(ApplicationSecurityGroupName, command.ApplicationSecurityGroupName);
            Assert.Equal(AddressPrefixSetName, command.Name);
            Assert.Equal(prefixes, request.Properties.AddressPrefixes);
            Assert.IsType<PSAddressPrefixSet>(Assert.Single(runtime.OutputPipeline));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Owner, NrpTeamAlias.nsgdev)]
        public void RemoveAddressPrefixSetDeletesResourceByIdAndReturnsTrue()
        {
            this.addressPrefixSets
                .Setup(client => client.DeleteWithHttpMessagesAsync(
                    ResourceGroupName,
                    ApplicationSecurityGroupName,
                    AddressPrefixSetName,
                    It.IsAny<Dictionary<string, List<string>>>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AzureOperationResponse());

            var runtime = new MockCommandRuntime();
            var command = this.CreateCommand<RemoveAzureRmAddressPrefixSetCommand>(runtime);
            command.ResourceId = AddressPrefixSetId;
            command.Force = true;
            command.PassThru = true;

            command.Execute();

            Assert.Equal(ResourceGroupName, command.ResourceGroupName);
            Assert.Equal(ApplicationSecurityGroupName, command.ApplicationSecurityGroupName);
            Assert.Equal(AddressPrefixSetName, command.Name);
            Assert.True(Assert.IsType<bool>(Assert.Single(runtime.OutputPipeline)));
            this.addressPrefixSets.VerifyAll();
        }

        private static AddressPrefixSet CreateSdkAddressPrefixSet(IEnumerable<string> prefixes)
        {
            return new AddressPrefixSet(
                AddressPrefixSetId,
                AddressPrefixSetName,
                "Microsoft.Network/applicationSecurityGroups/addressPrefixSets",
                "etag",
                new AddressPrefixSetPropertiesFormat(prefixes.ToList(), "Succeeded"));
        }

        private T CreateCommand<T>(MockCommandRuntime runtime)
            where T : AddressPrefixSetBaseCmdlet, new()
        {
            return new T
            {
                CommandRuntime = runtime,
                NetworkClient = new NetworkClient(this.networkManagementClient.Object)
            };
        }
    }
}
