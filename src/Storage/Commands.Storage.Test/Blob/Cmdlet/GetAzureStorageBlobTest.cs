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

namespace Microsoft.WindowsAzure.Commands.Storage.Test.Blob.Cmdlet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Commands.Test.Utilities.Common;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Model.ResourceModel;
    using Storage.Blob.Cmdlet;
    using Storage.Common;

    [TestClass]
    public class GetAzureStorageBlobTest : StorageBlobTestBase
    {
        public GetAzureStorageBlobCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            command = new GetAzureStorageBlobCommand(BlobMock)
                {
                    CommandRuntime = new MockCommandRuntime()
                };
        }

        [TestCleanup]
        public void CleanCommand()
        {
            command = null;
        }

        [TestMethod]
        public void GetCloudBlobContainerByNameWithInvalidNameTest()
        {
            string name = string.Empty;
            AssertThrows<ArgumentException>(() => command.GetCloudBlobContainerByName(name),
                String.Format(Resources.InvalidContainerName, name));

            name = "a";
            AssertThrows<ArgumentException>(() => command.GetCloudBlobContainerByName(name),
                String.Format(Resources.InvalidContainerName, name));

            name = "abcde*-";
            AssertThrows<ArgumentException>(() => command.GetCloudBlobContainerByName(name),
                String.Format(Resources.InvalidContainerName, name));
        }

        [TestMethod]
        public void GetCloudBlobContainerByNameWithNoExistsContainerTest()
        {
            string name = "test";
            AssertThrows<ArgumentException>(() => command.GetCloudBlobContainerByName(name),
                String.Format(Resources.ContainerNotFound, name));
        }

        [TestMethod]
        public void GetCloudBlobContainerByNameSuccessfullyTest()
        {
            AddTestContainers();

            string name = "test";
            CloudBlobContainer container = command.GetCloudBlobContainerByName(name);
            Assert.AreEqual(name, container.Name);
        }

        [TestMethod]
        public void ListBlobsByNameWithEmptyContainerTest()
        {
            AddTestContainers();

            string containerName = "test";
            string blobName = "";
            List<IListBlobItem> blobList = command.ListBlobsByName(containerName, blobName).ToList();
            Assert.AreEqual(0, blobList.Count);

            containerName = "test";
            blobName = "*";
            blobList = command.ListBlobsByName(containerName, blobName).ToList();
            Assert.AreEqual(0, blobList.Count);

            containerName = "test";
            blobName = "blob";
            AssertThrows<ResourceNotFoundException>(()=> command.ListBlobsByName(containerName, blobName).ToList(),
                String.Format(Resources.BlobNotFound, blobName, containerName));
        }

        [TestMethod]
        public void ListBlobsByNameWithInvalidBlobNameTest()
        {
            AddTestContainers();
            string containerName = "test";
            string blobName = new String('a', 1025);
            AssertThrows<ArgumentException>(() => command.ListBlobsByName(containerName, blobName).ToList(),
                String.Format(Resources.InvalidBlobName, blobName));
        }

        [TestMethod]
        public void ListBlobsByNameWithWildCardTest()
        {
            AddTestBlobs();

            string containerName = "container1";
            string blobName = "blob*";
            List<IListBlobItem> blobList = command.ListBlobsByName(containerName, blobName).ToList();
            Assert.AreEqual(1, blobList.Count);
            Assert.AreEqual("blob0", ((ICloudBlob)blobList[0]).Name);

            containerName = "container20";
            blobName = "*1?";
            blobList = command.ListBlobsByName(containerName, blobName).ToList();
            Assert.AreEqual(10, blobList.Count);
            ICloudBlob blob = (ICloudBlob)blobList[0];
            Assert.IsTrue(blob.Name.StartsWith("blob1") && blob.Name.Length == "blob1".Length + 1);
        }

        [TestMethod]
        public void ListBlobsByNameSuccessfullyTest()
        {
            AddTestBlobs();
            string containerName = "container1";
            string blobName = "blob0";
            List<IListBlobItem> blobList = command.ListBlobsByName(containerName, blobName).ToList();
            Assert.AreEqual(1, blobList.Count);
            Assert.AreEqual("blob0", ((ICloudBlob)blobList[0]).Name);

            containerName = "container20";
            blobName = String.Empty;
            blobList = command.ListBlobsByName(containerName, blobName).ToList();
            Assert.AreEqual(20, blobList.Count);
        }

        [TestMethod]
        public void ListBlobsByPrefixWithInvalidPrefixTest()
        {
            string containerName = string.Empty;
            string prefix = string.Empty;
            AssertThrows<ArgumentException>(() => command.ListBlobsByPrefix(containerName, prefix),
                String.Format(Resources.InvalidContainerName, containerName));

            containerName = "test";
            AssertThrows<ArgumentException>(() => command.ListBlobsByPrefix(containerName, prefix),
                String.Format(Resources.ContainerNotFound, containerName));
        }

        [TestMethod]
        public void ListBlobsByPrefixWithEmptyContainerTest()
        {
            AddTestContainers();
            string containerName = "test";
            string prefix = "1";

            List<IListBlobItem> blobList = command.ListBlobsByPrefix(containerName, prefix).ToList();
            Assert.AreEqual(0, blobList.Count);
        }

        [TestMethod]
        public void ListBlobsByPrefixSuccessfullyTest()
        {
            AddTestBlobs();
            
            string containerName = "container0";
            string prefix = "blob";
            List<IListBlobItem> blobList = command.ListBlobsByPrefix(containerName, prefix).ToList();
            Assert.AreEqual(0, blobList.Count);

            containerName = "container1";
            prefix = "blob";
            blobList = command.ListBlobsByPrefix(containerName, prefix).ToList();
            Assert.AreEqual(1, blobList.Count);
            ICloudBlob blob = (ICloudBlob)blobList[0];
            Assert.AreEqual("blob0", blob.Name);

            containerName = "container1";
            prefix = "blob0";
            blobList = command.ListBlobsByPrefix(containerName, prefix).ToList();
            Assert.AreEqual(1, blobList.Count);
            blob = (ICloudBlob) blobList[0];
            Assert.AreEqual("blob0", blob.Name);

            containerName = "container1";
            prefix = "blob01";
            blobList = command.ListBlobsByPrefix(containerName, prefix).ToList();
            Assert.AreEqual(0, blobList.Count);

            ((MockCommandRuntime)command.CommandRuntime).ResetPipelines();
            containerName = "container20";
            prefix = "blob1";
            blobList = command.ListBlobsByPrefix(containerName, prefix).ToList();
            Assert.AreEqual(11, blobList.Count);
            blob = (ICloudBlob) blobList[0];
            Assert.IsTrue(blob.Name.StartsWith("blob1"));
        }

        [TestMethod]
        public void WriteBlobsWithContext()
        {
            List<ICloudBlob> blobList = null;
            ((MockCommandRuntime)command.CommandRuntime).ResetPipelines();
            command.WriteBlobsWithContext(blobList);
            Assert.AreEqual(0, ((MockCommandRuntime)command.CommandRuntime).OutputPipeline.Count);

            blobList = new List<ICloudBlob>();
            ((MockCommandRuntime)command.CommandRuntime).ResetPipelines();
            command.WriteBlobsWithContext(blobList);
            Assert.AreEqual(0, ((MockCommandRuntime)command.CommandRuntime).OutputPipeline.Count);

            AddTestBlobs();
            blobList = BlobMock.ContainerBlobs["container20"];
            ((MockCommandRuntime)command.CommandRuntime).ResetPipelines();
            command.WriteBlobsWithContext(blobList);
            Assert.AreEqual(20, ((MockCommandRuntime)command.CommandRuntime).OutputPipeline.Count);
        }

        [TestMethod]
        public void ExecuteCommandGetAzureBlob()
        { 
            AddTestBlobs();

            ((MockCommandRuntime)command.CommandRuntime).ResetPipelines();
            command.Container = "container1";
            command.Blob = "blob*";
            command.ExecuteCmdlet();
            Assert.AreEqual(1, ((MockCommandRuntime)command.CommandRuntime).OutputPipeline.Count);
            AzureStorageBlob blob = (AzureStorageBlob)((MockCommandRuntime)command.CommandRuntime).OutputPipeline.FirstOrDefault();
            Assert.AreEqual("blob0", blob.Name);

            ((MockCommandRuntime)command.CommandRuntime).ResetPipelines();
            command.Container = "container20";
            command.Blob = "blob12";
            command.ExecuteCmdlet();
            Assert.AreEqual(1, ((MockCommandRuntime)command.CommandRuntime).OutputPipeline.Count);
            blob = (AzureStorageBlob)((MockCommandRuntime)command.CommandRuntime).OutputPipeline.FirstOrDefault();
            Assert.AreEqual("blob12", blob.Name);

            ((MockCommandRuntime)command.CommandRuntime).ResetPipelines();
            command.Container = "container20";
            command.Blob = "*";
            command.ExecuteCmdlet();
            Assert.AreEqual(20, ((MockCommandRuntime)command.CommandRuntime).OutputPipeline.Count);
        }
    }
}
