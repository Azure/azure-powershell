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
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Files
{
    public class RemoveBatchNodeFileCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private RemoveBatchNodeFileCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public RemoveBatchNodeFileCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new RemoveBatchNodeFileCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveBatchNodeFileParametersFromComputeNodeTest()
        {
            // Setup cmdlet to skip confirmation popup
            cmdlet.Force = true;
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // Setup cmdlet without required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = null;
            cmdlet.TaskId = null;
            cmdlet.Name = null;
            cmdlet.InputObject = null;

            // Don't go to the service on a Delete NodeFile call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                bool?,
                FileDeleteFromComputeNodeOptions,
                AzureOperationHeaderResponse<FileDeleteFromComputeNodeHeaders>>();

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());

            // Setup compute node parameters
            cmdlet.JobId = null;
            cmdlet.TaskId = null;
            cmdlet.PoolId = "testPool";
            cmdlet.ComputeNodeId = "computeNode-1";
            cmdlet.Name = "stdout.txt";

            // Verify no exceptions occur
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveBatchNodeFileParametersFromTaskTest()
        {
            // Setup cmdlet to skip confirmation popup
            cmdlet.Force = true;
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // Setup cmdlet without required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = null;
            cmdlet.TaskId = null;
            cmdlet.Name = null;
            cmdlet.InputObject = null;

            // Don't go to the service on a Delete NodeFile call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                bool?,
                FileDeleteFromTaskOptions,
                AzureOperationHeaderResponse<FileDeleteFromTaskHeaders>>();

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());

            // Fill required task details
            cmdlet.JobId = "job-1";
            cmdlet.TaskId = "task";
            cmdlet.Name = "stdout.txt";

            // Verify no exceptions occur
            cmdlet.ExecuteCmdlet();
        }
    }
}
