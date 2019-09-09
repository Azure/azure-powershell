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

using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Subscriptions
{
    public class GetBatchLocationQuotasCommandTests : RMTestBase
    {
        private GetBatchLocationQuotaCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchLocationQuotasCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchLocationQuotaCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchLocationQuotasTest()
        {
            List<PSBatchLocationQuotas> pipelineOutput = new List<PSBatchLocationQuotas>();

            // Return a pre-built object when the command is issued.
            string location = "westus";
            PSBatchLocationQuotas quotas = new PSBatchLocationQuotas(location, new BatchLocationQuota(accountQuota: 5));
            batchClientMock.Setup(b => b.GetLocationQuotas(location)).Returns(quotas);

            cmdlet.Location = location;
            cmdlet.ExecuteCmdlet();

            // Verify the returned object was written to the pipeline.
            commandRuntimeMock.Verify(r => r.WriteObject(quotas), Times.Once());
        }
    }
}
