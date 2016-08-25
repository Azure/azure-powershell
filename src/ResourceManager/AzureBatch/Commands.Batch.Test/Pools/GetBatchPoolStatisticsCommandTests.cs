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
    public class GetBatchPoolStatisticsCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchPoolStatisticsCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchPoolStatisticsCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchPoolStatisticsCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchPoolStatisticsTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            double avgCPUPercentage = 10;
            DateTime startTime = DateTime.UtcNow;

            AzureOperationResponse<
                ProxyModels.PoolStatistics,
                ProxyModels.PoolGetAllPoolsLifetimeStatisticsHeaders> response =
                BatchTestHelpers.CreatePoolStatisticsResponse(avgCPUPercentage, startTime);

            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.PoolGetAllPoolsLifetimeStatisticsOptions,
                AzureOperationResponse<ProxyModels.PoolStatistics, ProxyModels.PoolGetAllPoolsLifetimeStatisticsHeaders>>(responseToUse: response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a variable that can be examined later
            PSPoolStatistics statistics = null;
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSPoolStatistics>())).Callback<object>(c => statistics = (PSPoolStatistics)c);

            cmdlet.ExecuteCmdlet();

            Assert.NotNull(statistics);
            Assert.Equal(startTime, statistics.UsageStatistics.StartTime);
            Assert.Equal(avgCPUPercentage, statistics.ResourceStatistics.AverageCpuPercentage);
        }
    }
}
