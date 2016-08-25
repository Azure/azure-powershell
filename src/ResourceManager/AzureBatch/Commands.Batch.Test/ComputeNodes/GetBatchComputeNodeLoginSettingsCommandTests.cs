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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Batch.Protocol.Models;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.ComputeNodes
{
    public class GetBatchComputeNodeLoginSettingsCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchComputeNodeRemoteLoginSettingsCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchComputeNodeLoginSettingsCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchComputeNodeRemoteLoginSettingsCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchComputeNodeLoginSettingsNullParametersTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = null;
            cmdlet.ComputeNodeId = null;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchComputeNodeLoginSettingsParametersTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = "testIaasPool";
            cmdlet.ComputeNodeId = "computeNode01";

            string ipAddress = "104.214.75.220";

            // Don't go to the service on an Get RemoteLoginSettings call
            AzureOperationResponse<ComputeNodeGetRemoteLoginSettingsResult, ComputeNodeGetRemoteLoginSettingsHeaders> response =
                BatchTestHelpers.CreateRemoteLoginSettingsGetResponse(ipAddress);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ComputeNodeGetRemoteLoginSettingsOptions,
                AzureOperationResponse<ComputeNodeGetRemoteLoginSettingsResult, ComputeNodeGetRemoteLoginSettingsHeaders>>(responseToUse: response);
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            PSRemoteLoginSettings loginSettings = null;
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSRemoteLoginSettings>()))
                .Callback<object>(p => loginSettings = (PSRemoteLoginSettings)p);

            // Verify no exceptions when required parameter is set
            cmdlet.ExecuteCmdlet();

            Assert.Equal(ipAddress, loginSettings.IPAddress);
        }
    }
}
