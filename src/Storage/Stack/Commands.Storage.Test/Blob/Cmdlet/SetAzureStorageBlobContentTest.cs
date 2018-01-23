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
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Commands.Test.Utilities.Common;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Model.Contract;
    using Model.ResourceModel;
    using Storage.Blob;
    using Storage.Common;

    [TestClass]
    public class SetAzureBlobContentTest : StorageBlobTestBase
    {
        internal FakeSetAzureBlobContentCommand command = null;

        [TestInitialize]
        public void InitCommand()
        {
            command = new FakeSetAzureBlobContentCommand(BlobMock)
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
        public void OnStartTest()
        {
            ProgressRecord pr = null;
            command.OnTaskStart(pr);
            pr = new ProgressRecord(0, "a", "b");
            pr.PercentComplete = 10;
            command.OnTaskStart(pr);
            Assert.AreEqual(0, pr.PercentComplete);
        }

        [TestMethod]
        public void OnProgressTest()
        {
            ProgressRecord pr = null;
            command.OnTaskProgress(pr, 0.0, 0.0);
            pr = new ProgressRecord(0, "a", "b");
            pr.PercentComplete = 10;
            command.OnTaskProgress(pr, 5.6, 12.3);
            Assert.AreEqual(12, pr.PercentComplete);
            command.OnTaskProgress(pr, 5.6, 12.8);
            Assert.AreEqual(12, pr.PercentComplete);
            command.OnTaskProgress(pr, 5.6, 11);
            Assert.AreEqual(11, pr.PercentComplete);
            command.OnTaskProgress(pr, 5.6, 12.8);
            Assert.AreEqual(12, pr.PercentComplete);
            command.OnTaskProgress(pr, 5.6, 5);
            Assert.AreEqual(5, pr.PercentComplete);
        }

        [TestMethod]
        public void OnFinishTest()
        {
            ProgressRecord pr = null;
            ArgumentException e = new ArgumentException("test");
            command.OnTaskFinish(pr, null);
            pr = new ProgressRecord(0, "a", "b");
            command.OnTaskFinish(pr, null);
            Assert.AreEqual(100, pr.PercentComplete);
            Assert.AreEqual(String.Format(Resources.TransmitSuccessfully), pr.StatusDescription);
            command.OnTaskFinish(pr, e);
            Assert.AreEqual(100, pr.PercentComplete);
            Assert.AreEqual(String.Format(Resources.TransmitFailed, e.Message), pr.StatusDescription);
        }

        [TestMethod]
        public void GetFullSendFilePathTest()
        {
            string fileName = "";
            AssertThrows<ArgumentException>(()=>command.GetFullSendFilePath(fileName));
            fileName = @"c:\Windows\System32";
            Assert.IsTrue(String.IsNullOrEmpty(command.GetFullSendFilePath(fileName)));
            fileName = @"c:\WindowsXXXXX\System32XX\xxxxx";
            AssertThrows<ArgumentException>(() => command.GetFullSendFilePath(fileName),
                String.Format(Resources.FileNotFound, fileName));
        }

        [TestMethod]
        public void SetAzureBlobContentByNameTest()
        {
            string fileName = string.Empty;
            string containerName = string.Empty;
            string blobName = string.Empty;
            AssertThrows<ArgumentException>(() => command.SetAzureBlobContent(fileName, containerName, blobName));
            fileName = @"abcxx\xxxxabc";
            AssertThrows<ArgumentException>(() => command.SetAzureBlobContent(fileName, containerName, blobName));
            fileName = @"c:\Windows\System32\cmd.exe";
            AssertThrows<ArgumentException>(() => command.SetAzureBlobContent(fileName, containerName, blobName),
                String.Format(Resources.InvalidContainerName, containerName));
            containerName = "test";
            AssertThrows<ResourceNotFoundException>(() => command.SetAzureBlobContent(fileName, containerName, blobName),
                String.Format(Resources.ContainerNotFound, containerName));
            AddTestContainers();
            command.SetAzureBlobContent(fileName, containerName, blobName);
        }

        [TestMethod]
        public void SetAzureBlobContentByContianerTest()
        {
            string fileName = string.Empty;
            string containerName = string.Empty;
            string blobName = string.Empty;
            CloudBlobContainer container = null;
            AssertThrows<ArgumentException>(() => command.SetAzureBlobContent(fileName, container, blobName));
            fileName = @"c:\Windows\System32\cmd.exe";
            container = BlobMock.GetContainerReference(containerName);
            AssertThrows<ArgumentException>(() => command.SetAzureBlobContent(fileName, container, blobName),
                String.Format(Resources.InvalidContainerName, container.Name));
            AddTestContainers();
            container = BlobMock.GetContainerReference("test");
            command.SetAzureBlobContent(fileName, container, blobName);
            command.BlobType = "page";
            command.SetAzureBlobContent(fileName, container, blobName);
        }

        [TestMethod]
        public void Upload2BlobTest()
        {
            command.Upload2Blob(string.Empty, null);
        }

        [TestMethod]
        public void SetAzureBlobContentByContainerWithDirectoryTest()
        {
            string fileName = ".";
            ICloudBlob blob = null;
            Assert.IsNull(command.SetAzureBlobContent(fileName, blob, false));
        }

        [TestMethod]
        public void SetAzureBlobContentByContainerWithInvalidICloudBlobTest()
        {
            ICloudBlob blob = null;
            string fileName = @"c:\Windows\System32\cmd.exe";
            AssertThrows<ArgumentException>(() => command.SetAzureBlobContent(fileName, blob, false),
                String.Format(Resources.ObjectCannotBeNull, typeof(ICloudBlob).Name));
        }

        [TestMethod]
        public void SetAzureBlobContentByContainerWithInvalidNameTest()
        {
            ICloudBlob blob = null;
            string fileName = @"c:\Windows\System32\cmd.exe";
            string bloburi = "http://127.0.0.1/account/test/";
            blob = new CloudPageBlob(new Uri(bloburi));
            AssertThrows<ArgumentException>(() => command.SetAzureBlobContent(fileName, blob, false),
                String.Format(Resources.InvalidBlobName, blob.Name));
        }

        [TestMethod]
        public void SetAzureBlobContentByContainerWithNotExistsContainerTest()
        {
            string fileName = @"c:\Windows\System32\cmd.exe";
            CloudBlobContainer container = BlobMock.GetContainerReference("test");
            CloudPageBlob blob = container.GetPageBlobReference("blob8");
            AssertThrows<ResourceNotFoundException>(() => command.SetAzureBlobContent(fileName, blob, false),
                String.Format(Resources.ContainerNotFound, "test"));
        }

        [TestMethod]
        public void SetAzureBlobContentByContainerWithMismatchBlobTypeTest()
        {
            AddTestBlobs();
            string bloburi = "http://127.0.0.1/account/container20/blob8";
            CloudPageBlob blob = new CloudPageBlob(new Uri(bloburi));
            string fileName = @"c:\Windows\System32\cmd.exe";
            AssertThrows<ArgumentException>(() => command.SetAzureBlobContent(fileName, blob, false),
                String.Format(Resources.BlobTypeMismatch, blob.Name, BlobType.BlockBlob));
        }

        [TestMethod]
        public void SetAzureBlobContentByContainerWithoutConfirmationTest()
        {
            AddTestBlobs();

            string fileName = @"c:\Windows\System32\cmd.exe";
            string bloburi = "http://127.0.0.1/account/container20/blob9";
            ICloudBlob blob = new CloudBlockBlob(new Uri(bloburi));
            AzureStorageBlob azureBlob = command.SetAzureBlobContent(fileName, blob, false);
            Assert.IsNull(azureBlob);
        }

        [TestMethod]
        public void SetAzureBlobContentByContainerSuccessfullyTest()
        {
            AddTestBlobs();

            string fileName = @"c:\Windows\System32\cmd.exe";
            string bloburi = "http://127.0.0.1/account/container20/blob9";
            ICloudBlob blob = new CloudBlockBlob(new Uri(bloburi));
            command.Confirm = true;
            AzureStorageBlob azureBlob = command.SetAzureBlobContent(fileName, blob, false);

            Assert.AreEqual("blob9", azureBlob.Name);

            command.Force = true;
            azureBlob = command.SetAzureBlobContent(fileName, blob, false);
            Assert.AreEqual("blob9", azureBlob.Name);
        }

        [TestMethod]
        public void ExecuteCommandSetBlobContentTest()
        {
            AddTestContainers();
            string fileName = @"c:\Windows\System32\cmd.exe";
            string containerName = "test";
            string blobName = "";
            command.File = fileName;
            command.Container = containerName;
            command.Blob = blobName;
            command.ExecuteCmdlet();
            AzureStorageBlob azureblob = (AzureStorageBlob)((MockCommandRuntime)command.CommandRuntime).OutputPipeline.FirstOrDefault();
            Assert.AreEqual("cmd.exe", azureblob.Name);
        }
    }

    internal class FakeSetAzureBlobContentCommand : SetAzureBlobContentCommand
    {
        public bool Exception = false;
        public bool Confirm = false;

        public FakeSetAzureBlobContentCommand(IStorageBlobManagement channel)
        {
            Channel = channel;
        }

        internal override bool ConfirmOverwrite(string tips = null)
        {
            return Confirm;
        }
        
        internal override void Upload2Blob(string filePath, ICloudBlob blob)
        {
            ProgressRecord pr = new ProgressRecord(0, "a", "b");
            OnTaskStart(pr);
            OnTaskProgress(pr, 1, 10.5);
            OnTaskFinish(pr, null);
            if (Exception)
            {
                throw new ArgumentException("FakeSetAzureBlobContentCommand");
            }
        }
    }
}
