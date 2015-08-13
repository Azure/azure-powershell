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
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Pools
{
    public class EnableBatchAutoScaleCommandTests
    {
        private EnableBatchAutoScaleCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public EnableBatchAutoScaleCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new EnableBatchAutoScaleCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAutoScaleParametersTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.Id = null;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.Id = "testPool";

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.AutoScaleFormula = "formula";

            // Don't go to the service on an Enable AutoScale call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<CloudPoolEnableAutoScaleParameters, CloudPoolEnableAutoScaleResponse> request =
                (BatchRequest<CloudPoolEnableAutoScaleParameters, CloudPoolEnableAutoScaleResponse>)baseRequest;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    CloudPoolEnableAutoScaleResponse response = new CloudPoolEnableAutoScaleResponse();
                    Task<CloudPoolEnableAutoScaleResponse> task = Task.FromResult(response);
                    return task;
                };
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Verify no exceptions when required parameter is set
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableAutoScaleRequestTest()
        {
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;

            string formula = "$TargetDedicated=2";
            string requestFormula = null;

            cmdlet.Id = "testPool";
            cmdlet.AutoScaleFormula = formula;

            // Don't go to the service on an Enable AutoScale call
            RequestInterceptor interceptor = new RequestInterceptor((baseRequest) =>
            {
                BatchRequest<CloudPoolEnableAutoScaleParameters, CloudPoolEnableAutoScaleResponse> request =
                (BatchRequest<CloudPoolEnableAutoScaleParameters, CloudPoolEnableAutoScaleResponse>)baseRequest;

                requestFormula = request.TypedParameters.AutoScaleFormula;

                request.ServiceRequestFunc = (cancellationToken) =>
                {
                    CloudPoolEnableAutoScaleResponse response = new CloudPoolEnableAutoScaleResponse();
                    Task<CloudPoolEnableAutoScaleResponse> task = Task.FromResult(response);
                    return task;
                };
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            cmdlet.ExecuteCmdlet();

            // Verify that the autoscale formula was properly set on the outgoing request
            Assert.Equal(formula, requestFormula);
        }
    }
}
