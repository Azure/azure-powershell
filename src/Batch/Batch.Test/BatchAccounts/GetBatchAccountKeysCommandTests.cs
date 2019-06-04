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

using Microsoft.Azure.Management.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Accounts
{
    public class GetBatchAccountKeysCommandTests : WindowsAzure.Commands.Test.Utilities.Common.RMTestBase
    {
        private GetBatchAccountKeyCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchAccountKeysCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagement.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagement.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchAccountKeyCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchAccountKeysTest()
        {
            string primaryKey = "pKey";
            string secondaryKey = "sKey";

            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            BatchAccount accountResource = BatchTestHelpers.CreateAccountResource(accountName, resourceGroup);
            BatchAccountContext expected = BatchAccountContext.ConvertAccountResourceToNewAccountContext(accountResource, null);
            expected.PrimaryAccountKey = primaryKey;
            expected.SecondaryAccountKey = secondaryKey;

            batchClientMock.Setup(b => b.GetKeys(resourceGroup, accountName)).Returns(expected);

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(expected), Times.Once());
        }
    }
}
