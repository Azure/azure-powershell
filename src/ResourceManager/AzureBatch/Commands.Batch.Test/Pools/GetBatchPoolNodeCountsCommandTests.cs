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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test.Pools
{
    public class GetBatchPoolNodeCountsCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchPoolNodeCountsCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchPoolNodeCountsCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(
                new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchPoolNodeCountsCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WhenGetBatchPoolNodeCountsCommandIsCalledWithoutFilter_ShouldReturnAllPools()
        {
            // Setup cmdlet to get a pool by id
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            var poolNodeCounts1 = new ProxyModels.PoolNodeCounts()
            {
                PoolId = "Pool1",
                Dedicated = new ProxyModels.NodeCounts(
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10,
                    11,
                    12,
                    78), // Total
                LowPriority = new ProxyModels.NodeCounts(
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10,
                    11,
                    12,
                    78) // Total
            };

            var poolNodeCounts2 = new ProxyModels.PoolNodeCounts()
            {
                PoolId = "Pool2",
                Dedicated = new ProxyModels.NodeCounts(
                    11,
                    12,
                    13,
                    14,
                    15,
                    16,
                    17,
                    18,
                    19,
                    20,
                    21,
                    22,
                    198), // Total
                LowPriority = new ProxyModels.NodeCounts(
                    11,
                    12,
                    13,
                    14,
                    15,
                    16,
                    17,
                    18,
                    19,
                    20,
                    21,
                    22,
                    198) // Total
            };

            // Simulate node state counts for two pools are returned
            var poolsNodeCounts = new List<ProxyModels.PoolNodeCounts>()
            {
                poolNodeCounts1,
                poolNodeCounts2
            };

            // Build a TaskCounts instead of querying the service on a Get TaskCounts call
            AzureOperationResponse<IPage<ProxyModels.PoolNodeCounts>, ProxyModels.AccountListPoolNodeCountsHeaders> response =
                BatchTestHelpers.CreatePoolNodeCountsGetResponse(poolsNodeCounts);
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.AccountListPoolNodeCountsOptions,
                AzureOperationResponse<IPage<ProxyModels.PoolNodeCounts>, ProxyModels.AccountListPoolNodeCountsHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            List<PSPoolNodeCounts> psPoolsNodeCounts = new List<PSPoolNodeCounts>();
            commandRuntimeMock.Setup(r =>
                    r.WriteObject(It.IsAny<PSPoolNodeCounts>()))
                .Callback<object>(p => psPoolsNodeCounts.Add((PSPoolNodeCounts)p));

            cmdlet.ExecuteCmdlet();

            var psPoolNodeCounts1 = psPoolsNodeCounts.FirstOrDefault(c => c.PoolId == "Pool1");

            var psPoolNodeCounts2 = psPoolsNodeCounts.FirstOrDefault(c => c.PoolId == "Pool2");

            Assert.NotNull(psPoolNodeCounts1);
            Assert.NotNull(psPoolNodeCounts2);

            var comparer = new PoolNodeCountsObjectComparer();

            Assert.True(comparer.AreEqual(poolNodeCounts1, psPoolNodeCounts1));
            Assert.True(comparer.AreEqual(poolNodeCounts2, psPoolNodeCounts2));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WhenGetBatchPoolNodeCountsCommandIsCalledWithPoolIdOption_ShouldHonorPoolIdFilter()
        {
            const string poolId = "Pool1";
            // Setup cmdlet to list pools using an OData filter
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = poolId;

            string requestFilter = null;

            AzureOperationResponse<IPage<ProxyModels.PoolNodeCounts>, ProxyModels.AccountListPoolNodeCountsHeaders> fakeResponse = 
                BatchTestHelpers.CreateGenericAzureOperationListResponse<ProxyModels.PoolNodeCounts, ProxyModels.AccountListPoolNodeCountsHeaders>();

            Action<BatchRequest<ProxyModels.AccountListPoolNodeCountsOptions, AzureOperationResponse<IPage<ProxyModels.PoolNodeCounts>, ProxyModels.AccountListPoolNodeCountsHeaders>>> requestAction =
                (request) =>
                {
                    ProxyModels.AccountListPoolNodeCountsOptions options = (ProxyModels.AccountListPoolNodeCountsOptions)request.Options;
                    requestFilter = options.Filter;
                };

            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor(
                responseToUse: fakeResponse, requestAction: requestAction);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(requestFilter, $"(poolId eq '{poolId}')");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WhenGetBatchPoolNodeCountsCommandIsCalledWithCloudPoolOption_ShouldHonorPoolFilter()
        {
            // Setup cmdlet to list pools using an OData filter
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();

            PSCloudPool fakeCloudPool = new PSCloudPool(BatchTestHelpers.CreateFakeBoundPool(context));
            cmdlet.BatchContext = context;
            cmdlet.Pool = fakeCloudPool;

            string requestFilter = null;

            AzureOperationResponse<IPage<ProxyModels.PoolNodeCounts>, ProxyModels.AccountListPoolNodeCountsHeaders> fakeResponse =
                BatchTestHelpers.CreateGenericAzureOperationListResponse<ProxyModels.PoolNodeCounts, ProxyModels.AccountListPoolNodeCountsHeaders>();

            Action<BatchRequest<ProxyModels.AccountListPoolNodeCountsOptions, AzureOperationResponse<IPage<ProxyModels.PoolNodeCounts>, ProxyModels.AccountListPoolNodeCountsHeaders>>> requestAction =
                (request) =>
                {
                    ProxyModels.AccountListPoolNodeCountsOptions options = (ProxyModels.AccountListPoolNodeCountsOptions)request.Options;
                    requestFilter = options.Filter;
                };

            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor(
                responseToUse: fakeResponse, requestAction: requestAction);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor };

            cmdlet.ExecuteCmdlet();

            Assert.Equal(requestFilter, $"(poolId eq '{fakeCloudPool.Id}')");
        }

        public class PoolNodeCountsObjectComparer
        {
            private IEnumerable<PropertyInfo> poolNodeCountsPropertInfos;
            private IEnumerable<PropertyInfo> psPoolNodeCountsPropertInfos;

            public PoolNodeCountsObjectComparer()
            {
                this.poolNodeCountsPropertInfos =
                    typeof(ProxyModels.PoolNodeCounts).GetProperties(BindingFlags.Public | BindingFlags.GetProperty);
                this.psPoolNodeCountsPropertInfos =
                    typeof(PSPoolNodeCounts).GetProperties(BindingFlags.Public | BindingFlags.GetProperty);
            }

            public bool AreEqual(ProxyModels.PoolNodeCounts poolNodeCounts, PSPoolNodeCounts psPoolNodeCounts)
            {
                foreach (var pi in this.poolNodeCountsPropertInfos)
                {
                    var poolNodeCountsValue = pi.GetValue(poolNodeCounts);
                    var psPoolNodeCountsValue = this.psPoolNodeCountsPropertInfos.First(psPi => psPi.Name == pi.Name).GetValue(psPoolNodeCounts);

                    if (poolNodeCountsValue != psPoolNodeCountsValue)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
