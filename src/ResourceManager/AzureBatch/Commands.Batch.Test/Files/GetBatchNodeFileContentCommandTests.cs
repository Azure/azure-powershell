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
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Files
{
    public class GetBatchNodeFileContentCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchNodeFileContentCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchNodeFileContentCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchNodeFileContentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchNodeFileByTaskParametersTest()
        {
            // Setup cmdlet without required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.JobId = null;
            cmdlet.TaskId = null;
            cmdlet.Name = null;
            cmdlet.InputObject = null;
            cmdlet.DestinationPath = null;

            string fileName = "stdout.txt";

            // Don't go to the service on a Get NodeFile call or Get NodeFile Properties call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeGetFileAndPropertiesFromTaskResponseInterceptor(cmdlet.Name);
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            using (MemoryStream memStream = new MemoryStream())
            {
                // Don't hit the file system during unit tests
                cmdlet.DestinationStream = memStream;

                Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());

                // Fill required task details
                cmdlet.JobId = "job-1";
                cmdlet.TaskId = "task";
                cmdlet.Name = fileName;

                // Verify no exceptions occur
                cmdlet.ExecuteCmdlet();
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchNodeFileByComputeNodeContentParametersTest()
        {
            // Setup cmdlet without required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = null;
            cmdlet.ComputeNodeId = null;
            cmdlet.Name = null;
            cmdlet.InputObject = null;
            cmdlet.DestinationPath = null;

            string fileName = "startup\\stdout.txt";

            // Don't go to the service on a Get NodeFile call or Get NodeFile Properties call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeGetFileAndPropertiesFromComputeNodeResponseInterceptor(cmdlet.Name);
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            using (MemoryStream memStream = new MemoryStream())
            {
                // Don't hit the file system during unit tests
                cmdlet.DestinationStream = memStream;

                Assert.Throws<ArgumentException>(() => cmdlet.ExecuteCmdlet());

                // Fill required compute node details
                cmdlet.PoolId = "pool";
                cmdlet.ComputeNodeId = "computeNode1";
                cmdlet.Name = fileName;

                // Verify no exceptions occur
                cmdlet.ExecuteCmdlet();
            }
        }
    }
}
