﻿// ----------------------------------------------------------------------------------
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
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Storage.Cmdlet;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Storage.Blob;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Blob
{
    /// <summary>
    /// unit test for SetAzureStorageContainer
    /// </summary>
    public class SetAzureStorageContainerAclTest : StorageBlobTestBase
    {
        public SetAzureStorageContainerAclCommand command = null;

        public SetAzureStorageContainerAclTest()
        {
            command = new SetAzureStorageContainerAclCommand(BlobMock)
            {
                CommandRuntime = MockCmdRunTime
            };
            CurrentBlobCmd = command;
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetContainerAclWithInvalidContainerNameTest()
        {
            string name = "a";
            BlobContainerPublicAccessType accessLevel = BlobContainerPublicAccessType.Off;
            AssertThrowsAsync<ArgumentException>(() => command.SetContainerAcl(InitTaskId, BlobMock, name, accessLevel), String.Format(Resources.InvalidContainerName, name));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetContainerAclForNotExistContainer()
        {
            string name = "test";
            BlobContainerPublicAccessType accessLevel = BlobContainerPublicAccessType.Off;
            AssertThrowsAsync<ResourceNotFoundException>(() => command.SetContainerAcl(InitTaskId, BlobMock, name, accessLevel), String.Format(Resources.ContainerNotFound, name));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetContainerAclSucessfullyTest()
        {
            AddTestContainers();
            command.PassThru = true;

            string name = "test";
            BlobContainerPublicAccessType accessLevel = BlobContainerPublicAccessType.Off;

            MockCmdRunTime.ResetPipelines();
            command.Name = name;
            RunAsyncCommand(() => command.ExecuteCmdlet());
            AzureStorageContainer container = (AzureStorageContainer)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.Equal(BlobContainerPublicAccessType.Off, container.PublicAccess);

            MockCmdRunTime.ResetPipelines();
            name = "publicoff";
            accessLevel = BlobContainerPublicAccessType.Blob;
            command.Name = name;
            command.Permission = accessLevel;
            RunAsyncCommand(() => command.ExecuteCmdlet());
            container = (AzureStorageContainer)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.Equal(BlobContainerPublicAccessType.Blob, container.PublicAccess);

            MockCmdRunTime.ResetPipelines();
            name = "publicblob";
            accessLevel = BlobContainerPublicAccessType.Container;
            command.Name = name;
            command.Permission = accessLevel;
            RunAsyncCommand(() => command.ExecuteCmdlet());
            container = (AzureStorageContainer)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.Equal(BlobContainerPublicAccessType.Container, container.PublicAccess);

            MockCmdRunTime.ResetPipelines();
            name = "publiccontainer";
            accessLevel = BlobContainerPublicAccessType.Off;
            command.Name = name;
            command.Permission = accessLevel;
            RunAsyncCommand(() => command.ExecuteCmdlet());
            container = (AzureStorageContainer)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.Equal(BlobContainerPublicAccessType.Off, container.PublicAccess);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExecuteCommandSetContainerAclTest()
        {
            AddTestContainers();
            command.Name = "publicblob";
            command.Permission = BlobContainerPublicAccessType.Container;
            command.PassThru = true;
            RunAsyncCommand(() => command.ExecuteCmdlet());
            AzureStorageContainer container = (AzureStorageContainer)MockCmdRunTime.OutputPipeline.FirstOrDefault();
            Assert.Equal(BlobContainerPublicAccessType.Container, container.PublicAccess);
        }
    }
}
