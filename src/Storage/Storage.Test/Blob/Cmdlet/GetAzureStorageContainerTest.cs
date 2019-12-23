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
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Storage.Blob.Cmdlet;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Blob.Cmdlet
{
    /// <summary>
    /// Unit test for get azure storage container cmdlet
    /// </summary>
    [TestClass]
    public class GetAzureStorageContainerTest : StorageBlobTestBase
    {
        /// <summary>
        /// Get azure storage container command
        /// </summary>
        private GetAzureStorageContainerCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            command = new GetAzureStorageContainerCommand(BlobMock)
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
        public void ListContainersByNameWithInvalidNameTest()
        {
            string invalidName = "a";
            AssertThrows<ArgumentException>(() => command.ListContainersByName(invalidName).ToList(),
                String.Format(Resources.InvalidContainerName, invalidName));
            invalidName = "xx%%d";
            AssertThrows<ArgumentException>(() => command.ListContainersByName(invalidName).ToList(),
                String.Format(Resources.InvalidContainerName, invalidName));
        }

        [TestMethod]
        public void ListContainersByNameWithContainerNameTest()
        {
            AddTestContainers();
            IEnumerable<Tuple<CloudBlobContainer, BlobContinuationToken>> containerList = command.ListContainersByName("text");
            Assert.AreEqual(1, containerList.Count());
            Assert.AreEqual("text", containerList.First().Item1.Name);
        }

        [TestMethod]
        public void ListContainersByNameWithNotExistingContainerTest()
        {
            string notExistingName = "abcdefg";
            AssertThrows<ResourceNotFoundException>(() => command.ListContainersByName(notExistingName).ToList(),
                String.Format(Resources.ContainerNotFound, notExistingName));
        }

        [TestMethod]
        public void ListContainerByPrefixWithInvalidPrefixTest()
        {
            MockCmdRunTime.ResetPipelines();
            string prefix = "?";
            AssertThrows<ArgumentException>(() => RunAsyncCommand(() => command.ListContainersByPrefix(prefix).ToList()), String.Format(Resources.InvalidContainerName, prefix));
        }

        [TestMethod]
        public void PackCloudBlobContainerWithAclTest()
        {
            RunAsyncCommand(() => command.PackCloudBlobContainerWithAcl(null));
            Assert.IsFalse(MockCmdRunTime.OutputPipeline.Any());

            RunAsyncCommand(() => command.PackCloudBlobContainerWithAcl(BlobMock.ContainerAndTokenList));
            Assert.IsFalse(MockCmdRunTime.OutputPipeline.Any());

            AddTestContainers();
            RunAsyncCommand(() => command.PackCloudBlobContainerWithAcl(BlobMock.ContainerAndTokenList));
            Assert.AreEqual(5, MockCmdRunTime.OutputPipeline.Count());
        }

        [TestMethod]
        public void ExecuteCommandGetContainerTest()
        {
            AddTestContainers();
            command.Name = "test";
            RunAsyncCommand(() => command.ExecuteCmdlet());
            Assert.AreEqual(1, MockCmdRunTime.OutputPipeline.Count);
        }
    }
}
