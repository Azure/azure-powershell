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
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Batch.Protocol.Models;
using Microsoft.Azure.Commands.Batch.Models;
using Xunit;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Tasks
{
    public class NewBatchTaskCommandTests
    {
        private NewBatchTaskCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public NewBatchTaskCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new NewBatchTaskCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchTaskParametersTest()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.JobId = "job-1";

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Id = "testTask";

            // Don't go to the service on an Add CloudTask call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.TaskAddParameter,
                ProxyModels.TaskAddOptions,
                AzureOperationHeaderResponse<ProxyModels.TaskAddHeaders>>();
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameters are set
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewBatchTaskCollectionParametersTest()
        {
            string commandLine = "cmd /c dir /s";

            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.JobId = "job-collection";

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            string[] taskIds = new[] {"simple1", "simple2"};
            PSCloudTask expected1 = new PSCloudTask(taskIds[0], commandLine);
            PSCloudTask expected2 = new PSCloudTask(taskIds[1], commandLine);

            cmdlet.Tasks = new PSCloudTask[] {expected1, expected2};

            IList<TaskAddParameter> requestCollection = null;

            Action<BatchRequest<
                IList<TaskAddParameter>,
                TaskAddCollectionOptions,
                AzureOperationResponse<TaskAddCollectionResult, TaskAddCollectionHeaders>>> extractCollection =
                (request) =>
                {
                    requestCollection = request.Parameters;
                };

            // Don't go to the service on an Add Task Collection call
            AzureOperationResponse<TaskAddCollectionResult, TaskAddCollectionHeaders> response =
                BatchTestHelpers.CreateTaskCollectionResponse(cmdlet.Tasks);

            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor(responseToUse: response, requestAction: extractCollection);

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameters are set
            cmdlet.ExecuteCmdlet();

            Assert.Equal(2, requestCollection.Count);
            foreach (var task in requestCollection)
            {
                Assert.True(taskIds.Contains(task.Id));
            }
        }
    }
}
