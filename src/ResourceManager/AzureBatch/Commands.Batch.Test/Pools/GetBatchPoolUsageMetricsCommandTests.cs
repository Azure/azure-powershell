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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test.Pools
{
    public class GetBatchPoolUsageMetricsCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchPoolUsageMetrics cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchPoolUsageMetricsCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchPoolUsageMetrics()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchPoolUsageODataTest()
        {
            int year = 2013;
            int month = 4;
            int day = 1;

            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.StartTime = new DateTime(year, month, day, 0, 0, 0);
            cmdlet.EndTime = new DateTime(year, month, day, 1, 0, 0);

            string[] poolIds = new[] { "p1", "p2" };
            DateTime[] startTimes = new[] { new DateTime(year, month, day, 0, 0, 0), new DateTime(year, month, day, 0, 30, 0) };
            DateTime[] endTimes = new[] { new DateTime(year, month, day, 0, 30, 0), new DateTime(year, month, day, 1, 0, 0) };

            AzureOperationResponse<IPage<ProxyModels.PoolUsageMetrics>, ProxyModels.PoolListPoolUsageMetricsHeaders> response =
                BatchTestHelpers.CreatePoolListUsageMetricsResponse(poolIds, startTimes, endTimes);

            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.PoolListPoolUsageMetricsOptions,
                AzureOperationResponse<IPage<ProxyModels.PoolUsageMetrics>, ProxyModels.PoolListPoolUsageMetricsHeaders>>(responseToUse: response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSPoolUsageMetrics> pipeline = new List<PSPoolUsageMetrics>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSPoolUsageMetrics>()))
                .Callback<object>(p => pipeline.Add((PSPoolUsageMetrics)p));

            // Verify no exceptions when required parameter is set
            cmdlet.ExecuteCmdlet();

            Assert.Equal(2, pipeline.Count);
            int poolUsageCount = 0;
            foreach (PSPoolUsageMetrics p in pipeline)
            {
                Assert.True(poolIds.Contains(p.PoolId));
                poolUsageCount++;
            }

            Assert.Equal(poolIds.Length, poolUsageCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchPoolUsageWithFilter()
        {
            int year = 2013;
            int month = 4;
            int day = 1;

            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Filter = "poolId lt 'p2'";

            string requestFilter = null;
            string[] poolIds = new[] { "p1" };
            DateTime[] startTimes = new[] { new DateTime(year, month, day, 0, 0, 0) };
            DateTime[] endTimes = new[] { new DateTime(year, month, day, 0, 30, 0) };

            AzureOperationResponse<IPage<ProxyModels.PoolUsageMetrics>, ProxyModels.PoolListPoolUsageMetricsHeaders> response =
                BatchTestHelpers.CreatePoolListUsageMetricsResponse(poolIds, startTimes, endTimes);

            // Don't go to the service on an Get PoolUsageMetrics call
            RequestInterceptor requestInterceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.PoolListPoolUsageMetricsOptions,
                AzureOperationResponse<IPage<ProxyModels.PoolUsageMetrics>, ProxyModels.PoolListPoolUsageMetricsHeaders>>(responseToUse: response);

            ResponseInterceptor responseInterceptor = new ResponseInterceptor((responseToUse, request) =>
            {
                ProxyModels.PoolListPoolUsageMetricsOptions options = (ProxyModels.PoolListPoolUsageMetricsOptions)request.Options;
                requestFilter = options.Filter;

                return Task.FromResult(responseToUse);
            });

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { requestInterceptor, responseInterceptor };

            // Verify no exceptions when required parameter is set
            cmdlet.ExecuteCmdlet();

            Assert.Equal(cmdlet.Filter, requestFilter);
        }
    }
}
