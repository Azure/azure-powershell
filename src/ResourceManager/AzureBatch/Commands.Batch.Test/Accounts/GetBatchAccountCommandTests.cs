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
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using System.Collections.Generic;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Accounts
{
    public class GetBatchAccountCommandTests : RMTestBase
    {
        private GetBatchAccountCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchAccountCommandTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchAccountCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchAccountsTest()
        {
            List<BatchAccountContext> pipelineOutput = new List<BatchAccountContext>();

            string accountName01 = "account01";
            string resourceGroup = "resourceGroup";
            AccountResource accountResource01 = BatchTestHelpers.CreateAccountResource(accountName01, resourceGroup);
            string accountName02 = "account02";
            AccountResource accountResource02 = BatchTestHelpers.CreateAccountResource(accountName02, resourceGroup);
            BatchAccountContext expected01 = BatchAccountContext.ConvertAccountResourceToNewAccountContext(accountResource01);
            BatchAccountContext expected02 = BatchAccountContext.ConvertAccountResourceToNewAccountContext(accountResource02);

            batchClientMock.Setup(b => b.ListAccounts(null, resourceGroup)).Returns(new List<BatchAccountContext>() { expected01, expected02 });

            cmdlet.AccountName = null;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.Tag = null;

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(expected01), Times.Once());
            commandRuntimeMock.Verify(r => r.WriteObject(expected02), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchAccountTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            AccountResource accountResource = BatchTestHelpers.CreateAccountResource(accountName, resourceGroup);
            BatchAccountContext expected = BatchAccountContext.ConvertAccountResourceToNewAccountContext(accountResource);
            batchClientMock.Setup(b => b.GetAccount(resourceGroup, accountName)).Returns(expected);

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(expected), Times.Once());
        }
    }
}
