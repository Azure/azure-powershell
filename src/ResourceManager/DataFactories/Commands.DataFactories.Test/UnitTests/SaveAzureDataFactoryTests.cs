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

using Microsoft.Azure.Commands.DataFactories;
using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Test;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.DataFactory
{
    public class SaveDataFactoryRunLogTests : DataFactoryUnitTestBase
    {
        private SaveAzureDataFactoryLog _cmdlet;

        private string _dataSliceRunId;

        public SaveDataFactoryRunLogTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor.AddToContext(new Azure.ServiceManagemenet.Common.Models.XunitTracingInterceptor(output));
            base.SetupTest();

            this._dataSliceRunId = Guid.NewGuid().ToString();

            this._cmdlet = new SaveAzureDataFactoryLog()
            {
                CommandRuntime = this.commandRuntimeMock.Object,
                DataFactoryClient = this.dataFactoriesClientMock.Object,
                ResourceGroupName = ResourceGroupName,
                DataFactoryName = DataFactoryName,
                Id = this._dataSliceRunId,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanSaveDataFactoryRunLog()
        {
            Uri sharedAccessSignature =
                new Uri(@"https://fakeaccount.blob.core.windows.net/sascontainer?sv=2012-02-12");
            PSRunLogInfo runLogInfo = new PSRunLogInfo(sharedAccessSignature);
            Assert.Equal("?sv=2012-02-12", runLogInfo.SasToken);
            Assert.Equal(@"https://fakeaccount.blob.core.windows.net/sascontainer?sv=2012-02-12", runLogInfo.SasUri);
            Assert.Equal("fakeaccount", runLogInfo.StorageAccountName);
            Assert.Equal("sascontainer", runLogInfo.Container);

            dataFactoriesClientMock.Setup(
                f =>
                    f.CreatePSDataFactory(
                        It.Is<CreatePSDataFactoryParameters>(
                            parameters =>
                                parameters.ResourceGroupName == ResourceGroupName &&
                                parameters.DataFactoryName == DataFactoryName &&
                                parameters.Location == Location)))
                .CallBase()
                .Verifiable();

            // Arrange
            this.dataFactoriesClientMock.Setup(
                f =>
                f.GetDataSliceRunLogsSharedAccessSignature(ResourceGroupName, DataFactoryName, this._dataSliceRunId))
                .Returns(sharedAccessSignature);

            this.dataFactoriesClientMock.Setup(
                f =>
                f.DownloadFileToBlob(
                    It.Is<BlobDownloadParameters>(
                            parameters =>
                                parameters.SasUri == sharedAccessSignature &&
                                parameters.Directory == @"c:\")));

            // Action
            this._cmdlet.ExecuteCmdlet();

            // Assert
            this.dataFactoriesClientMock.Verify(
                f =>
                f.GetDataSliceRunLogsSharedAccessSignature(ResourceGroupName, DataFactoryName, this._dataSliceRunId),
                Times.Once());
        }
    }
}