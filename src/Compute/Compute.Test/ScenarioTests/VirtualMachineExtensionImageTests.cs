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

using Microsoft.Azure.Commands.Compute;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class VirtualMachineExtensionImageTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureVMExtensionImageCommand_ExpandParameterAllowsOnlyProperties()
        {
            var expandProperty = typeof(GetAzureVMExtensionImageCommand).GetProperty("Expand");

            Assert.NotNull(expandProperty);
            var validateSetAttribute = Assert.Single(expandProperty.GetCustomAttributes(typeof(ValidateSetAttribute), inherit: false).Cast<ValidateSetAttribute>());
            Assert.Equal(new[] { "Properties" }, validateSetAttribute.ValidValues);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureVMExtensionImageCommand_ForwardsExpandAndMapsListMetadata()
        {
            const string publisherName = "Microsoft.Compute";
            const string extensionType = "CustomScriptExtension";
            var extensionImageOperations = new Mock<IVirtualMachineExtensionImagesOperations>();
            var computeManagementClient = new Mock<IComputeManagementClient>();
            var commandRuntime = new Mock<ICommandRuntime>();
            var response = new AzureOperationResponse<IList<VirtualMachineExtensionImage>>
            {
                Body = new List<VirtualMachineExtensionImage>
                {
                    new VirtualMachineExtensionImage(
                        location: "eastus",
                        name: "1.10.15",
                        releaseCategory: "SecurityFix",
                        urgencyLevel: "Emergency",
                        runProfile: "LongRunning")
                },
                Response = new HttpResponseMessage(HttpStatusCode.OK)
            };

            computeManagementClient
                .SetupGet(client => client.VirtualMachineExtensionImages)
                .Returns(extensionImageOperations.Object);
            extensionImageOperations
                .Setup(client => client.ListVersionsWithHttpMessagesAsync(
                    "eastus",
                    publisherName,
                    extensionType,
                    null,
                    null,
                    null,
                    "properties",
                    null,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response));

            commandRuntime
                .Setup(runtime => runtime.WriteObject(It.IsAny<object>(), true))
                .Callback((object output, bool _) =>
                {
                    var image = Assert.Single(((IEnumerable<PSVirtualMachineExtensionImage>)output).ToList());
                    Assert.Equal("1.10.15", image.Version);
                    Assert.Equal("SecurityFix", image.ReleaseCategory);
                    Assert.Equal("Emergency", image.UrgencyLevel);
                    Assert.Equal("LongRunning", image.RunProfile);
                });

            var cmdlet = new GetAzureVMExtensionImageCommand
            {
                CommandRuntime = commandRuntime.Object,
                ComputeClient = new ComputeClient(computeManagementClient.Object),
                Location = "East US",
                PublisherName = publisherName,
                Type = extensionType,
                Expand = "Properties"
            };

            cmdlet.ExecuteCmdlet();

            extensionImageOperations.VerifyAll();
            commandRuntime.Verify(runtime => runtime.WriteObject(It.IsAny<object>(), true), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureVMExtensionImageCommand_MapsExactVersionMetadata()
        {
            const string publisherName = "Microsoft.Compute";
            const string extensionType = "CustomScriptExtension";
            const string version = "1.10.15";
            var featureMetadata = new ExtensionFeatureMetadata();
            var extensionImageOperations = new Mock<IVirtualMachineExtensionImagesOperations>();
            var computeManagementClient = new Mock<IComputeManagementClient>();
            var commandRuntime = new Mock<ICommandRuntime>();
            var response = new AzureOperationResponse<VirtualMachineExtensionImage>
            {
                Body = new VirtualMachineExtensionImage(
                    location: "eastus",
                    name: version,
                    releaseCategory: "SecurityFix",
                    urgencyLevel: "Emergency",
                    runProfile: "LongRunning",
                    releaseNotes: "Fixed a critical bug in the extension handler.",
                    extensionFeatureMetadata: featureMetadata),
                Response = new HttpResponseMessage(HttpStatusCode.OK)
            };

            computeManagementClient
                .SetupGet(client => client.VirtualMachineExtensionImages)
                .Returns(extensionImageOperations.Object);
            extensionImageOperations
                .Setup(client => client.GetWithHttpMessagesAsync(
                    "eastus",
                    publisherName,
                    extensionType,
                    version,
                    null,
                    It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response));

            commandRuntime
                .Setup(runtime => runtime.WriteObject(It.IsAny<object>()))
                .Callback((object output) =>
                {
                    var image = Assert.IsType<PSVirtualMachineExtensionImageDetails>(output);
                    Assert.Equal(version, image.Version);
                    Assert.Equal("Fixed a critical bug in the extension handler.", image.ReleaseNotes);
                    Assert.Equal("SecurityFix", image.ReleaseCategory);
                    Assert.Equal("Emergency", image.UrgencyLevel);
                    Assert.Equal("LongRunning", image.RunProfile);
                    Assert.Same(featureMetadata, image.ExtensionFeatureMetadata);
                });

            var cmdlet = new GetAzureVMExtensionImageCommand
            {
                CommandRuntime = commandRuntime.Object,
                ComputeClient = new ComputeClient(computeManagementClient.Object),
                Location = "East US",
                PublisherName = publisherName,
                Type = extensionType,
                Version = version
            };

            cmdlet.ExecuteCmdlet();

            extensionImageOperations.VerifyAll();
            commandRuntime.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Once());
        }
    }
}
