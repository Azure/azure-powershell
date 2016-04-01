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

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Protocol;

using Microsoft.Azure.Commands.Batch.Pools;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Accounts
{
    public class GetBatchNodeAgentSkusCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchAccountNodeAgentSkusCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchNodeAgentSkusCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchAccountNodeAgentSkusCommand()
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

            // Don't go to the service on an Get NodeAgentSkus call
            AzureOperationResponse<IPage<ProxyModels.NodeAgentSku>, ProxyModels.AccountListNodeAgentSkusHeaders> response = BatchTestHelpers.CreateGenericAzureOperationListResponse<ProxyModels.NodeAgentSku, ProxyModels.AccountListNodeAgentSkusHeaders>();
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<ProxyModels.AccountListNodeAgentSkusOptions, AzureOperationResponse<IPage<ProxyModels.NodeAgentSku>, ProxyModels.AccountListNodeAgentSkusHeaders>>(responseToUse: response);
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameter is set
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchNodeAgentSkusWithFilterTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Filter = "osType eq 'Linux'";

            string requestFilter = null;

            // Don't go to the service on an Get NodeAgentSkus call
            AzureOperationResponse<IPage<ProxyModels.NodeAgentSku>, ProxyModels.AccountListNodeAgentSkusHeaders> getResponse = BatchTestHelpers.CreateGenericAzureOperationListResponse<ProxyModels.NodeAgentSku, ProxyModels.AccountListNodeAgentSkusHeaders>();
            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<ProxyModels.AccountListNodeAgentSkusOptions, AzureOperationResponse<IPage<ProxyModels.NodeAgentSku>, ProxyModels.AccountListNodeAgentSkusHeaders>>(responseToUse: getResponse);
            ResponseInterceptor responseInterceptor = new ResponseInterceptor((response, request) =>
            {
                ProxyModels.AccountListNodeAgentSkusOptions listNodeAgentSkusOptions = (ProxyModels.AccountListNodeAgentSkusOptions) request.Options;
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
