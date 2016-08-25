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

namespace Microsoft.Azure.Commands.Batch.Test.ComputeNodeUsers
{
    public class SetBatchComputeNodeUserCommandTests
    {
        private SetBatchComputeNodeUserCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public SetBatchComputeNodeUserCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new SetBatchComputeNodeUserCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetBatchComputeNodeUserParametersTest()
        {
            // Setup cmdlet without the required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.PoolId = "testPool";
            cmdlet.ComputeNodeId = "computeNode1";

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Name = "testUser";

            // Don't go to the service on an Update ComputeNodeUser call
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor<
                NodeUpdateUserParameter,
                ComputeNodeUpdateUserOptions,
                AzureOperationHeaderResponse<ComputeNodeUpdateUserHeaders>>();

            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameters are set
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetBatchComputeNodeUserRequestTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolId = "testPool";
            cmdlet.ComputeNodeId = "computeNode1";
            cmdlet.Name = "testUser";
            cmdlet.Password = "Password1234";
            cmdlet.ExpiryTime = DateTime.Now.AddDays(1);

            string requestPassword = null;
            DateTime requestExpiryTime = DateTime.Now;

            // Don't go to the service on an Update ComputeNodeUser call
            Action<BatchRequest<NodeUpdateUserParameter, ComputeNodeUpdateUserOptions, AzureOperationHeaderResponse<ComputeNodeUpdateUserHeaders>>> extractUserUpdateParametersAction =
                (request) =>
                {
                    requestPassword = request.Parameters.Password;
                    requestExpiryTime = request.Parameters.ExpiryTime.GetValueOrDefault();
                };
            RequestInterceptor interceptor = BatchTestHelpers.CreateFakeServiceResponseInterceptor(requestAction: extractUserUpdateParametersAction);
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            cmdlet.ExecuteCmdlet();

            // Verify the request parameters match expectations
            Assert.Equal(cmdlet.Password, requestPassword);
            Assert.Equal(cmdlet.ExpiryTime, requestExpiryTime);
        }
    }
}
