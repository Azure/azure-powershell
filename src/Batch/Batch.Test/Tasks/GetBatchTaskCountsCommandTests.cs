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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test.Tasks
{
    public class GetBatchTaskCountsCommandTests : RMTestBase
    {
        private GetBatchTaskCountCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchTaskCountsCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchTaskCountCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchTaskCountsTest()
        {
            // Setup cmdlet to get task counts by job id
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = "job-1";

            const int requiredSlots = 2;
            const int active = 3;
            const int running = 5;
            const int succeeded = 2;
            const int failed = 1;

            // Build a TaskCounts instead of querying the service on a Get TaskCounts call
            AzureOperationResponse<ProxyModels.TaskCountsResult, ProxyModels.JobGetTaskCountsHeaders> response =
                BatchTestHelpers.CreateTaskCountsGetResponse(requiredSlots, active, running, succeeded, failed);

            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.JobGetTaskCountsOptions,
                AzureOperationResponse<ProxyModels.TaskCountsResult, ProxyModels.JobGetTaskCountsHeaders>>(response);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            PSTaskCounts taskCounts = null;
            commandRuntimeMock
                .Setup(r => r.WriteObject(It.IsAny<PSTaskCounts>()))
                .Callback<object>(p => {
                    taskCounts = (PSTaskCounts)p;
                });

            cmdlet.ExecuteCmdlet();

            Assert.Equal(3, taskCounts.Active);
            Assert.Equal(5, taskCounts.Running);
            Assert.Equal(3, taskCounts.Completed);
            Assert.Equal(2, taskCounts.Succeeded);
            Assert.Equal(1, taskCounts.Failed);
        }
    }
}