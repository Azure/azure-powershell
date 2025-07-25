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

using System.Management.Automation;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Batch.Test.ApplicationPackages
{
    public class GetBatchApplicationPackageCommandTests : RMTestBase
    {
        private GetBatchApplicationPackageCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchApplicationPackageCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchApplicationPackageCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchApplicationPackageTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
            string applicationName = "test";
            string applicationVersion = "foo";

            PSApplicationPackage expected = new PSApplicationPackage() { Name = applicationVersion };
            batchClientMock.Setup(b => b.GetApplicationPackage(resourceGroup, accountName, applicationName, applicationVersion)).Returns(expected);

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationName = applicationName;
            cmdlet.ApplicationVersion = applicationVersion;

            cmdlet.ExecuteCmdlet();

            commandRuntimeMock.Verify(r => r.WriteObject(expected), Times.Once());
        }
    }
}