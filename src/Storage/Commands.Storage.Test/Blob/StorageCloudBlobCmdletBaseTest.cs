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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Blob
{
    [TestClass]
    public class StorageCloudBlobCmdletBaseTest : StorageBlobTestBase
    {
        /// <summary>
        /// StorageCloudBlobCmdletBase command
        /// </summary>
        public StorageCloudBlobCmdletBase command = null;

        [TestInitialize]
        public void InitCommand()
        {
            command = new StorageCloudBlobCmdletBase(BlobMock)
            {
                Context = new AzureStorageContext(CloudStorageAccount.DevelopmentStorageAccount),
                CommandRuntime = MockCmdRunTime
            };
        }

        [TestCleanup]
        public void CleanCommand()
        {
            command = null;
        }

        [TestMethod]
        public void ValidatePipelineCloudBlobWithNullTest()
        {
            AssertThrows<ArgumentException>(() => command.ValidatePipelineCloudBlob(null), String.Format(Resources.ObjectCannotBeNull, typeof(CloudBlob).Name));
        }

        [TestMethod]
        public void ValidatePipelineCloudBlobWithInvalidBlobNameTest()
        {
            CloudBlockBlob blob = new CloudBlockBlob(new Uri("http://127.0.0.1/account/container/"));
            AssertThrows<ArgumentException>(() => command.ValidatePipelineCloudBlob(blob), String.Format(Resources.InvalidBlobName, blob.Name));
        }

        [TestMethod]
        public void ValidatePipelineCloudBlobSuccessfullyTest()
        {
            AddTestBlobs();

            CloudBlockBlob blob = new CloudBlockBlob(new Uri("http://127.0.0.1/account/container1/blob0"));
            command.ValidatePipelineCloudBlob(blob);
        }

        [TestMethod]
        public void ValidatePipelineCloudBlobContainerWithNullObjectTest()
        {
            AssertThrows<ArgumentException>(() => command.ValidatePipelineCloudBlobContainer(null), String.Format(Resources.ObjectCannotBeNull, typeof(CloudBlobContainer).Name));
        }

        [TestMethod]
        public void ValidatePipelineCloudBlobContainerWithInvalidNameTest()
        {
            string uri = "http://127.0.0.1/account/t";
            CloudBlobContainer container = new CloudBlobContainer(new Uri(uri));
            AssertThrows<ArgumentException>(() => command.ValidatePipelineCloudBlobContainer(container), String.Format(Resources.InvalidContainerName, container.Name));
        }

        [TestMethod]
        public void ValidatePipelineCloudBlobContainerSuccessfullyTest()
        {
            AddTestContainers();
            string testUri = "http://127.0.0.1/account/test";
            CloudBlobContainer container = new CloudBlobContainer(new Uri(testUri));
            command.ValidatePipelineCloudBlobContainer(container);
        }
    }
}
