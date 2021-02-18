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

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Management.Automation;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Applications
{
    public class SetBatchApplicationCommandTests
    {
        private SetBatchApplicationCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public SetBatchApplicationCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new SetBatchApplicationCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateBatchApplicationTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
<<<<<<< HEAD
            string applicationId = "applicationId";
=======
            string applicationName = "applicationName";
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            string displayName = "name";
            string defaultVersion = "version";

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
<<<<<<< HEAD
            cmdlet.ApplicationId = applicationId;
=======
            cmdlet.ApplicationName = applicationName;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            cmdlet.AllowUpdates = true;
            cmdlet.DefaultVersion = defaultVersion;
            cmdlet.DisplayName = displayName;

            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cmdlet.ExecuteCmdlet();

<<<<<<< HEAD
            batchClientMock.Verify(b => b.UpdateApplication(resourceGroup, accountName, applicationId, true, defaultVersion, displayName), Times.Once());
=======
            batchClientMock.Verify(b => b.UpdateApplication(resourceGroup, accountName, applicationName, true, defaultVersion, displayName), Times.Once());
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateBatchApplicationAllowUpdatesOnlyTest()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
<<<<<<< HEAD
            string applicationId = "applicationId";

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationId = applicationId;
=======
            string applicationName = "applicationName";

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationName = applicationName;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            cmdlet.AllowUpdates = true;

            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cmdlet.ExecuteCmdlet();

<<<<<<< HEAD
            batchClientMock.Verify(b => b.UpdateApplication(resourceGroup, accountName, applicationId, true, null, null), Times.Once());
=======
            batchClientMock.Verify(b => b.UpdateApplication(resourceGroup, accountName, applicationName, true, null, null), Times.Once());
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateBatchApplicationDefault()
        {
            string accountName = "account01";
            string resourceGroup = "resourceGroup";
<<<<<<< HEAD
            string applicationId = "applicationId";

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationId = applicationId;
=======
            string applicationName = "applicationName";

            cmdlet.AccountName = accountName;
            cmdlet.ResourceGroupName = resourceGroup;
            cmdlet.ApplicationName = applicationName;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cmdlet.ExecuteCmdlet();

<<<<<<< HEAD
            batchClientMock.Verify(b => b.UpdateApplication(resourceGroup, accountName, applicationId, null, null, null), Times.Once());
=======
            batchClientMock.Verify(b => b.UpdateApplication(resourceGroup, accountName, applicationName, null, null, null), Times.Once());
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
        }
    }
}
