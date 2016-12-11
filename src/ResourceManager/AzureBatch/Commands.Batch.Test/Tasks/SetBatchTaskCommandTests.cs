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
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;
using ProxyModels = Microsoft.Azure.Batch.Protocol.Models;

namespace Microsoft.Azure.Commands.Batch.Test.Tasks
{
    public class SetBatchTaskCommandTests
    {
        private SetBatchTaskCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public SetBatchTaskCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new SetBatchTaskCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetBatchTaskParametersTest()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Task = new PSCloudTask(BatchTestHelpers.CreateFakeBoundTask(context));

            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.TaskConstraints,
                ProxyModels.TaskUpdateOptions,
                AzureOperationHeaderResponse<ProxyModels.TaskUpdateHeaders>>();

            cmdlet.AdditionalBehaviors = new BatchClientBehavior[] { interceptor };

            // Verify that no exceptions occur
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetBatchTaskParametersGetPassedToRequestTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            cmdlet.Task = new PSCloudTask(BatchTestHelpers.CreateFakeBoundTask(context));

            // Update task
            cmdlet.Task.Constraints = new PSTaskConstraints(TimeSpan.FromHours(1), TimeSpan.FromDays(2), 5);

            ProxyModels.TaskConstraints requestParameters = null;

            // Store the request parameters
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                ProxyModels.TaskConstraints,
                ProxyModels.TaskUpdateOptions,
                AzureOperationHeaderResponse<ProxyModels.TaskUpdateHeaders>>(requestAction: (r) =>
                {
                    requestParameters = r.Parameters;
                });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };
            cmdlet.ExecuteCmdlet();

            // Verify the request parameters match the cmdlet parameters
            Assert.Equal(cmdlet.Task.Constraints.MaxTaskRetryCount, requestParameters.MaxTaskRetryCount);
            Assert.Equal(cmdlet.Task.Constraints.MaxWallClockTime, requestParameters.MaxWallClockTime);
            Assert.Equal(cmdlet.Task.Constraints.RetentionTime, requestParameters.RetentionTime);
        }
    }
}
