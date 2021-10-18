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

using Microsoft.Azure.Commands.Batch;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Xunit;
using Xunit.Abstractions;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Subscriptions
{
    public class GetSupportedVirtualMachineSkusTests : RMTestBase
    {
        private GetSupportedVirtualMachineSkusCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetSupportedVirtualMachineSkusTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetSupportedVirtualMachineSkusCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSupportedSkus()
        {
            string location = "westus";

            var skus = CreateSkus();
            batchClientMock.Setup(client => client.GetSupportedVirtualMachineSkus(location, default, default)).Returns(skus);

            cmdlet.Location = location;
            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(skus, true), Times.Once());
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetSupportedSkusWithODataParameters()
        {
            string location = "westus";

            var skus = CreateSkus();
            batchClientMock.Setup(client => client.GetSupportedVirtualMachineSkus(location, 3, "testfilter")).Returns(skus);

            cmdlet.Location = location;
            cmdlet.MaxResults = 3;
            cmdlet.Filter = "testfilter";
            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(skus, true), Times.Once());
        }

        private List<PSSupportedSku> CreateSkus()
        {
            List<PSSupportedSku> skus = new List<PSSupportedSku>()
            {
                new PSSupportedSku("testsku1", "testfamily", new List<PSSkuCapability>()
                {
                    new PSSkuCapability("cap1", "val1"),
                    new PSSkuCapability("cap2", "val2")
                }),
                new PSSupportedSku("testsku2", "testfamily", new List<PSSkuCapability>()
                {
                    new PSSkuCapability("cap1", "val1"),
                }),
                new PSSupportedSku("testsku3", "testfamily", new List<PSSkuCapability>()
                {
                    new PSSkuCapability("cap1", "val1"),
                    new PSSkuCapability("cap2", "val2"),
                    new PSSkuCapability("cap2", "val2")
                }),
                new PSSupportedSku("testsku4", "testfamily", new List<PSSkuCapability>()
                {
                    new PSSkuCapability("cap1", "val1"),
                }),
            };

            return skus;
        }
    }
}