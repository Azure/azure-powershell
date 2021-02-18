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

<<<<<<< HEAD
=======
using Microsoft.Azure.Commands.HDInsight.Models.Management;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using Microsoft.Azure.Management.HDInsight.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.HDInsight.Test
{
    public class GetPropertiesTests : HDInsightTestBase
    {
        private GetAzureHDInsightPropertiesCommand cmdlet;

        public GetPropertiesTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            base.SetupTestsForManagement();

            cmdlet = new GetAzureHDInsightPropertiesCommand
            {
                CommandRuntime = commandRuntimeMock.Object,
                HDInsightManagementClient = hdinsightManagementMock.Object,
                Location = Location
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanGetProperties()
        {
            var features = new string[] { "feature1", "feature2" };
            var versions = new Dictionary<string, VersionsCapability> { { "key", new VersionsCapability() } };
            var vm = new Dictionary<string, VmSizesCapability> { { "key1", new VmSizesCapability() } };
            var regions = new Dictionary<string, RegionsCapability> { { "eastus", new RegionsCapability() } };
<<<<<<< HEAD
            var propertiesResponse = new CapabilitiesResponse
=======
            var capabilitiesResult = new CapabilitiesResult
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            {
                Features = features,
                Versions = versions,
                VmSizes = vm,
                Regions = regions
            };
<<<<<<< HEAD
            hdinsightManagementMock.Setup(c => c.GetCapabilities(Location))
                .Returns(propertiesResponse)
=======

            var propertiesResponse = new AzureHDInsightCapabilities(capabilitiesResult);

            hdinsightManagementMock.Setup(c => c.GetProperties(Location))
                .Returns(capabilitiesResult)
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                .Verifiable();

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.VerifyAll();
            commandRuntimeMock.Verify(
                f =>
                    f.WriteObject(
<<<<<<< HEAD
                        It.Is<CapabilitiesResponse>(
                            resp =>
                                resp.Features == features && resp.Regions == regions &&
                                resp.Versions == versions && resp.VmSizes == vm)),
=======
                        It.Is<AzureHDInsightCapabilities>(
                            resp =>
                                resp.Features == propertiesResponse.Features
                                && resp.Regions["eastus"].Available == propertiesResponse.Regions["eastus"].Available
                                && resp.Versions.Count == propertiesResponse.Versions.Count 
                                && resp.VmSizes["key1"].Available == propertiesResponse.VmSizes["key1"].Available), true),
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
                Times.Once);
        }
    }
}
