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
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Blob
{
    [TestClass]
    public class NewAzureStorageContainerTest : StorageBlobTestBase
    {
        public NewAzureStorageContainerCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {            
            command = new NewAzureStorageContainerCommand(BlobMock)
            {
                CommandRuntime = MockCmdRunTime
            };
            CurrentBlobCmd = command;
        }

        [TestCleanup]
        public void CleanCommand()
        {
            command = null;
        }

        [TestMethod]
        public void CreateContainerWithInvalidContainerNameTest()
        {
            string name = String.Empty;
            BlobContainerPublicAccessType accesslevel = BlobContainerPublicAccessType.Off;

            AssertThrowsAsync<ArgumentException>(() => command.CreateAzureContainer(InitTaskId, BlobMock, name, accesslevel),
                String.Format(Resources.InvalidContainerName, name));

            name = "a";
            AssertThrowsAsync<ArgumentException>(() => command.CreateAzureContainer(InitTaskId, BlobMock, name, accesslevel),
                String.Format(Resources.InvalidContainerName, name));

            name = "&*(";
            AssertThrowsAsync<ArgumentException>(() => command.CreateAzureContainer(InitTaskId, BlobMock, name, accesslevel),
                String.Format(Resources.InvalidContainerName, name));
        }

        [TestMethod]
        public void CreateContainerForAlreadyExistsContainerTest()
        {
            AddTestContainers();
            string name = "text";
            BlobContainerPublicAccessType accesslevel = BlobContainerPublicAccessType.Off;

            AssertThrowsAsync<ResourceAlreadyExistException>(() => command.CreateAzureContainer(InitTaskId, BlobMock, name, accesslevel),
                String.Format(Resources.ContainerAlreadyExists, name));
        }

        [TestMethod]
        public void CreateContainerSuccessfullyTest()
        {
            string name = String.Empty;
            BlobContainerPublicAccessType accesslevel = BlobContainerPublicAccessType.Off;

            MockCmdRunTime.ResetPipelines();
            name = "test";
            command.Name = name;
            RunAsyncCommand(() => command.ExecuteCmdlet());
            AzureStorageContainer container = (AzureStorageContainer)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.AreEqual("test", container.Name);

            MockCmdRunTime.ResetPipelines();
            AssertThrowsAsync<ResourceAlreadyExistException>(() => command.CreateAzureContainer(InitTaskId, BlobMock, name, accesslevel),
                String.Format(Resources.ContainerAlreadyExists, name));
        }

        [TestMethod]
        public void ExcuteCommandNewContainerTest()
        {
            string name = "containername";
            command.Name = name;
            RunAsyncCommand(() => command.ExecuteCmdlet());
            AzureStorageContainer container = (AzureStorageContainer)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.AreEqual(name, container.Name);
        }
    }
}
