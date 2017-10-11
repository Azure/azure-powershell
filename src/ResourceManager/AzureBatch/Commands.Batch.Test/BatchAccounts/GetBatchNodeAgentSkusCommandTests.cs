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
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test.Accounts
{
    public class GetBatchNodeAgentSkusCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchAccountNodeAgentSkuCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchNodeAgentSkusCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchAccountNodeAgentSkuCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchNodeAgentSkusParametersTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            string[] idsOfNodeAgentSkus = new[] { "batch.node.centos 7", "batch.node.debian 8", "batch.node.opensuse 13.2" };

            // Don't go to the service on an Get NodeAgentSkus call
            AzureOperationResponse<IPage<ProxyModels.NodeAgentSku>, ProxyModels.AccountListNodeAgentSkusHeaders> response =
                BatchTestHelpers.CreateNodeAgentSkuResponse(idsOfNodeAgentSkus);

            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.AccountListNodeAgentSkusOptions,
                AzureOperationResponse<IPage<ProxyModels.NodeAgentSku>, ProxyModels.AccountListNodeAgentSkusHeaders>>(responseToUse: response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSNodeAgentSku> pipeline = new List<PSNodeAgentSku>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSNodeAgentSku>()))
                .Callback<object>(p => pipeline.Add((PSNodeAgentSku)p));

            // Verify no exceptions when required parameter is set
            cmdlet.ExecuteCmdlet();

            Assert.Equal(3, pipeline.Count);
            int nodeAgentCount = 0;
            foreach (PSNodeAgentSku p in pipeline)
            {
                Assert.True(idsOfNodeAgentSkus.Contains(p.Id));
                nodeAgentCount++;
            }
            Assert.Equal(idsOfNodeAgentSkus.Length, nodeAgentCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchNodeAgentSkusWithFilterTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Filter = "osType eq 'linux'";

            string requestFilter = null;

            // Don't go to the service on an Get NodeAgentSkus call
            AzureOperationResponse<IPage<ProxyModels.NodeAgentSku>, ProxyModels.AccountListNodeAgentSkusHeaders> getResponse = BatchTestHelpers.CreateGenericAzureOperationListResponse<ProxyModels.NodeAgentSku, ProxyModels.AccountListNodeAgentSkusHeaders>();
            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<ProxyModels.AccountListNodeAgentSkusOptions, AzureOperationResponse<IPage<ProxyModels.NodeAgentSku>, ProxyModels.AccountListNodeAgentSkusHeaders>>(responseToUse: getResponse);
            ResponseInterceptor responseInterceptor = new ResponseInterceptor((response, request) =>
            {
                ProxyModels.AccountListNodeAgentSkusOptions listNodeAgentSkusOptions = (ProxyModels.AccountListNodeAgentSkusOptions)request.Options;
                requestFilter = listNodeAgentSkusOptions.Filter;

                return Task.FromResult(response);
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor, responseInterceptor };

            // Verify no exceptions when required parameter is set
            cmdlet.ExecuteCmdlet();

            Assert.Equal(cmdlet.Filter, requestFilter);
        }
    }
}
