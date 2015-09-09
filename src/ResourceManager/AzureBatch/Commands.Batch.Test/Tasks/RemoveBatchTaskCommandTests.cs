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
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Batch.Protocol.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Tasks
{
    public class RemoveBatchTaskCommandTests
    {
        private RemoveBatchTaskCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public RemoveBatchTaskCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new RemoveBatchTaskCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveBatchTaskParametersTest()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            // Setup cmdlet to skip confirmation popup
            cmdlet.Force = true;
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.JobId = "job-1";
            cmdlet.Id = "testTask";

            // Don't go to the service on a Delete CloudTask call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<CloudTaskDeleteParameters, CloudTaskDeleteResponse> request =
                (BatchRequest<CloudTaskDeleteParameters, CloudTaskDeleteResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    CloudTaskDeleteResponse response = new CloudTaskDeleteResponse();
                    Task<CloudTaskDeleteResponse> task = Task.FromResult(response);
                    return task;
                };
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameters are set
            cmdlet.ExecuteCmdlet();
        }
    }
}
