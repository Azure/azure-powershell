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
// ---------------------------------------------------------------------------------

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Storage.Blob;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Test.Service;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Blob.Cmdlet
{
    [TestClass]
    public class RemoveAzureStorageBlobTest : StorageBlobTestBase
    {
        public RemoveStorageAzureBlobCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            command = new RemoveStorageAzureBlobCommand(BlobMock)
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
        public void ValidatePipelineCloudBlobContainerTest()
        {
            CloudBlobContainer container = null;
            AssertThrows<ArgumentException>(()=>command.ValidatePipelineCloudBlobContainer(container), 
                String.Format(Resources.ObjectCannotBeNull, typeof(CloudBlobContainer).Name));

            container = BlobMock.GetContainerReference("t");
            AssertThrows<ArgumentException>(() => command.ValidatePipelineCloudBlobContainer(container),
                String.Format(Resources.InvalidContainerName, "t"));

            AddTestContainers();
            container = BlobMock.GetContainerReference("text");
            command.ValidatePipelineCloudBlobContainer(container);
        }

        [TestMethod]
        public void ValidatePipelineCloudBlobTest()
        {
            CloudBlockBlob blockBlob = null;
            AssertThrows<ArgumentException>(() => command.ValidatePipelineCloudBlob(blockBlob),
                String.Format(Resources.ObjectCannotBeNull, typeof(CloudBlob).Name));
            string blobUri = "http://127.0.0.1/account/test/";
            blockBlob = new CloudBlockBlob(new Uri(blobUri));
            AssertThrows<ArgumentException>(() => command.ValidatePipelineCloudBlob(blockBlob),
                String.Format(Resources.InvalidBlobName, blockBlob.Name));

            AddTestBlobs();
            string container1Uri = "http://127.0.0.1/account/container1/blob0";
            blockBlob = new CloudBlockBlob(new Uri(container1Uri));
            command.ValidatePipelineCloudBlob(blockBlob);
        }

        [TestMethod]
        public void RemoveAzureBlobByCloudBlobWithInvliadCloudBlob()
        {
            CloudBlockBlob blockBlob = null;
            AssertThrowsAsync<ArgumentException>(() => command.RemoveAzureBlob(InitTaskId, BlobMock, blockBlob, false),
                String.Format(Resources.ObjectCannotBeNull, typeof(CloudBlob).Name));
        }

        [TestMethod]
        public void RemoveAzureBlobByCloudBlobWithNoExistsContainer()
        {
            CloudBlobContainer container = BlobMock.GetContainerReference("test");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("blob");
            AssertThrowsAsync<StorageException>(() => command.RemoveAzureBlob(InitTaskId, BlobMock, blockBlob, false),
                MockStorageBlobManagement.ContainerNotFound);
        }

        [TestMethod]
        public void RemoveAzureBlobByCloudBlobWithNoExistsBlobTest()
        {
            AddTestContainers();
            string blobUri = "http://127.0.0.1/account/test/blob";
            CloudBlockBlob blockBlob = new CloudBlockBlob(new Uri(blobUri));
            AssertThrowsAsync<StorageException>(() => command.RemoveAzureBlob(InitTaskId, BlobMock, blockBlob, false),
                MockStorageBlobManagement.BlobNotFound);
        }

        [TestMethod]
        public void RemoveAzureBlobByCloudBlobSuccessfulyTest()
        {
            AddTestBlobs();
            string blobUri = "http://127.0.0.1/account/container0/blob0";
            CloudBlockBlob blockBlob = new CloudBlockBlob(new Uri(blobUri));
            AssertThrowsAsync<StorageException>(() => command.RemoveAzureBlob(InitTaskId, BlobMock, blockBlob, false),
                MockStorageBlobManagement.BlobNotFound);
            blobUri = "http://127.0.0.1/account/container1/blob0";
            blockBlob = new CloudBlockBlob(new Uri(blobUri));
            RunAsyncCommand(() => command.RemoveAzureBlob(InitTaskId, BlobMock, blockBlob, true).Wait());

            AddTestBlobs();
            RunAsyncCommand(() => command.RemoveAzureBlob(InitTaskId, BlobMock, blockBlob, false).Wait());
            AssertThrowsAsync<StorageException>(() => command.RemoveAzureBlob(InitTaskId, BlobMock, blockBlob, false),
                MockStorageBlobManagement.BlobNotFound);
        }

        [TestMethod]
        public void RemoveAzureBlobByCloudBlobContainerWithInvalidNameTest()
        {
            CloudBlobContainer container = null;
            string blobName = string.Empty;

            AssertThrowsAsync<ArgumentException>(() => command.RemoveAzureBlob(InitTaskId, BlobMock, container, blobName),
                String.Format(Resources.InvalidBlobName, blobName));

            blobName = "a";
            AssertThrowsAsync<ArgumentException>(() => command.RemoveAzureBlob(InitTaskId, BlobMock, container, blobName),
                String.Format(Resources.ObjectCannotBeNull, typeof(CloudBlobContainer).Name));

            string containeruri = "http://127.0.0.1/account/t";
            container = new CloudBlobContainer(new Uri(containeruri));
            AssertThrowsAsync<ArgumentException>(() => command.RemoveAzureBlob(InitTaskId, BlobMock, container, blobName),
                String.Format(Resources.InvalidContainerName, container.Name));
        }

        [TestMethod]
        public void RemoveAzureBlobByCloudBlobContainerWithNotExistsContianerTest()
        {
            string blobName = "blob";
            CloudBlobContainer container = BlobMock.GetContainerReference("test");
            AssertThrowsAsync<ResourceNotFoundException>(() => command.RemoveAzureBlob(InitTaskId, BlobMock, container, blobName),
                String.Format(Resources.BlobNotFound, blobName, container.Name));
        }

        [TestMethod]
        public void RemoveAzureBlobByCloudBlobContainerWithNotExistsBlobTest()
        {
            AddTestContainers();
            CloudBlobContainer container = BlobMock.GetContainerReference("test");
            string blobName = "test";
            AssertThrowsAsync<ResourceNotFoundException>(() => command.RemoveAzureBlob(InitTaskId, BlobMock, container, blobName),
                String.Format(Resources.BlobNotFound, blobName, container.Name));
        }

        [TestMethod]
        public void RemoveAzureBlobByCloudBlobContainerSuccessfullyTest()
        {
            AddTestBlobs();
            CloudBlobContainer container = BlobMock.GetContainerReference("container1");
            string blobName = "blob0";
            RunAsyncCommand(() => command.RemoveAzureBlob(InitTaskId, BlobMock, container, blobName).Wait());
            AssertThrowsAsync<ResourceNotFoundException>(() => command.RemoveAzureBlob(InitTaskId, BlobMock, container, blobName),
                String.Format(Resources.BlobNotFound, blobName, "container1"));
        }

        [TestMethod]
        public void RemoveAzureBlobByNameWithInvalidNameTest()
        {
            string containerName = string.Empty;
            string blobName = string.Empty;
            AssertThrowsAsync<ArgumentException>(() => command.RemoveAzureBlob(InitTaskId, BlobMock, containerName, blobName),
                String.Format(Resources.InvalidBlobName, blobName));
            blobName = "abcd";
            AssertThrowsAsync<ArgumentException>(() => command.RemoveAzureBlob(InitTaskId, BlobMock, containerName, blobName),
                String.Format(Resources.InvalidContainerName, containerName));
        }

        [TestMethod]
        public void RemoveAzureBlobByNameTest()
        {
            AddTestBlobs();
            string containerName = "container1";
            string blobName = "blob0";
            RunAsyncCommand(() => command.RemoveAzureBlob(InitTaskId, BlobMock, containerName, blobName).Wait());
            AssertThrowsAsync<ResourceNotFoundException>(() => command.RemoveAzureBlob(InitTaskId, BlobMock, containerName, blobName),
                String.Format(Resources.BlobNotFound, blobName, containerName));
        }

        [TestMethod]
        public void ExecuteCommandRemoveBlobTest()
        {
            AddTestBlobs();
            string containerName = "container20";
            string blobName = "blob0";
            command.Container = containerName;
            command.Blob = blobName;
            RunAsyncCommand(() => command.ExecuteCmdlet());
            string result = (string)MockCmdRunTime.VerboseStream.FirstOrDefault();
            Assert.AreEqual(String.Format(Resources.RemoveBlobSuccessfully, blobName, containerName), result);
            RunAsyncCommand(() => command.ExecuteCmdlet());
            Assert.AreEqual(String.Format(Resources.BlobNotFound, blobName, containerName), 
                MockCmdRunTime.ErrorStream[0].Exception.Message);
        }
    }
}
