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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet;
using Microsoft.WindowsAzure.Commands.Storage.Common;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Blob
{
    /// <summary>
    /// unit test for RemoveAzureStorageContainer
    /// </summary>
    [TestClass]
    public class RemoveAzureStorageContainerTest : StorageBlobTestBase
    {
        /// <summary>
        /// faked remove azure container command
        /// </summary>
        internal RemoveAzureStorageContainerCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            command = new RemoveAzureStorageContainerCommand(BlobMock)
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
        public void RemoveContainerWithInvalidContainerNameTest()
        {
            string name = "a*b";
            AssertThrowsAsync<ArgumentException>(() => command.RemoveAzureContainer(InitTaskId, BlobMock, name),
                String.Format(Resources.InvalidContainerName, name));
        }

        [TestMethod]
        public void RemoveContainerForNotExistsContainerTest()
        {
            string name = "test";
            AssertThrowsAsync<ResourceNotFoundException>(() => command.RemoveAzureContainer(InitTaskId, BlobMock, name),
                String.Format(Resources.ContainerNotFound, name));
        }

        [TestMethod]
        public void RemoveContainerCancelledTest()
        {
            AddTestContainers();

            string name = "test";
            MockCmdRunTime.ResetPipelines();
            command.Name = name;
            this.Confirmed = false;
            RunAsyncCommand(() => command.ExecuteCmdlet());
            string result = (string)MockCmdRunTime.VerboseStream.FirstOrDefault();
            Assert.AreEqual(String.Format(Resources.RemoveContainerCancelled, name), result);
        }

        [TestMethod]
        public void RemoveContainerSuccessfullyTest()
        {
            AddTestContainers();

            string name = "test";

            MockCmdRunTime.ResetPipelines();
            command.Name = name;
            this.Confirmed = true;
            RunAsyncCommand(() => command.ExecuteCmdlet());
            string result = (string)MockCmdRunTime.VerboseStream.FirstOrDefault();
            Assert.AreEqual(String.Format(Resources.RemoveContainerSuccessfully, name), result);

            MockCmdRunTime.ResetPipelines();
            name = "text";
            command.Name = name;
            command.Force = true;
            RunAsyncCommand(() => command.ExecuteCmdlet());
            result = (string)MockCmdRunTime.VerboseStream.FirstOrDefault();
            Assert.AreEqual(String.Format(Resources.RemoveContainerSuccessfully, name), result);
        }

        [TestMethod]
        public void ExecuteCommandRemoveContainer()
        {
            string name = "test";
            command.Name = name;
            RunAsyncCommand(() => command.ExecuteCmdlet());
            Assert.AreEqual(String.Format(Resources.ContainerNotFound, name), MockCmdRunTime.ErrorStream[0].Exception.Message);
        }
    }
}
