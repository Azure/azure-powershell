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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Commands.Storage.ScenarioTest.Common;
using Commands.Storage.ScenarioTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Storage.Blob;
using MS.Test.Common.MsTestLib;
using StorageTestLib;

namespace Commands.Storage.ScenarioTest.Functional.Blob
{
    /// <summary>
    /// functional tests for Set-ContainerAcl
    /// </summary>
    [TestClass]
    class GetBlobContent: TestBase
    {
        //TODO add invalid md5sum for page blob
        private static string downloadDirRoot;

        private string ContainerName = string.Empty;
        private string BlobName = string.Empty;
        private ICloudBlob Blob = null;
        private CloudBlobContainer Container = null;

        [ClassInitialize()]
        public static void ClassInit(TestContext testContext)
        {
            TestBase.TestClassInitialize(testContext);
            downloadDirRoot = Test.Data.Get("DownloadDir");
            SetupDownloadDir();
        }

        [ClassCleanup()]
        public static void GetBlobContentClassCleanup()
        {
            TestBase.TestClassCleanup();
        }

        public override void OnTestSetup()
        {
            FileUtil.CleanDirectory(downloadDirRoot);
        }

        /// <summary>
        /// create download dir
        /// </summary>
        private static void SetupDownloadDir()
        {
            if (!Directory.Exists(downloadDirRoot))
            {
                Directory.CreateDirectory(downloadDirRoot);
            }

            FileUtil.CleanDirectory(downloadDirRoot);
        }

        /// <summary>
        /// create a random container with a random blob
        /// </summary>
        private void SetupTestContainerAndBlob()
        {
            string fileName = Utility.GenNameString("download");
            string filePath = Path.Combine(downloadDirRoot, fileName);
            int minFileSize = 1;
            int maxFileSize = 5;
            int fileSize = random.Next(minFileSize, maxFileSize);
            Helper.GenerateRandomTestFile(filePath, fileSize);

            ContainerName = Utility.GenNameString("container");
            BlobName = Utility.GenNameString("blob");
            CloudBlobContainer container = blobUtil.CreateContainer(ContainerName);
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(BlobName);
            // Create or overwrite the "myblob" blob with contents from a local file.
            using (var fileStream = System.IO.File.OpenRead(filePath))
            {
                blockBlob.UploadFromStream(fileStream);
            }

            File.Delete(filePath);
            blockBlob.FetchAttributes();
            Blob = blockBlob;
            Container = container;
        }

        /// <summary>
        /// clean test container and blob
        /// </summary>
        private void CleanupTestContainerAndBlob()
        {
            blobUtil.RemoveContainer(ContainerName);
            FileUtil.CleanDirectory(downloadDirRoot);
            ContainerName = string.Empty;
            BlobName = string.Empty;
            Blob = null;
            Container = null;
        }

        /// <summary>
        /// get blob content by container name and blob name
        /// 8.15	Get-AzureStorageBlobContent positive function cases
        ///     3.	Download an existing blob file using the container name specified by the param
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlobContent)]
        public void GetBlobContentByName()
        {
            SetupTestContainerAndBlob();

            try
            {
                string destFileName = Utility.GenNameString("download");
                string destFilePath = Path.Combine(downloadDirRoot, destFileName);
                Test.Assert(agent.GetAzureStorageBlobContent(BlobName, destFilePath, ContainerName, true), "download blob should be successful");
                string localMd5 = Helper.GetFileContentMD5(destFilePath);
                Test.Assert(localMd5 == Blob.Properties.ContentMD5, string.Format("blob content md5 should be {0}, and actualy it's {1}", localMd5, Blob.Properties.ContentMD5));
            }
            finally
            {
                CleanupTestContainerAndBlob();
            }
        }

        /// <summary>
        /// get blob content by container pipeline
        /// 8.15	Get-AzureStorageBlobContent positive function cases
        ///     4.	Download an existing blob file using the container object retrieved by Get-AzureContainer
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlobContent)]
        public void GetBlobContentByContainerPipeline()
        {
            SetupTestContainerAndBlob();

            try
            {
                string destFileName = Utility.GenNameString("download");
                string destFilePath = Path.Combine(downloadDirRoot, destFileName);

                ((PowerShellAgent)agent).AddPipelineScript(string.Format("Get-AzureStorageContainer {0}", ContainerName));
                Test.Assert(agent.GetAzureStorageBlobContent(BlobName, destFilePath, string.Empty, true), "download blob should be successful");
                string localMd5 = Helper.GetFileContentMD5(destFilePath);
                Test.Assert(localMd5 == Blob.Properties.ContentMD5, string.Format("blob content md5 should be {0}, and actualy it's {1}", localMd5, Blob.Properties.ContentMD5));
            }
            finally
            {
                CleanupTestContainerAndBlob();
            }
        }

        /// <summary>
        /// get blob content by container pipeline
        /// 8.15	Get-AzureStorageBlobContent positive function cases
        ///     5.	Download a block blob file and a page blob file with a subdirectory
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlobContent)]
        public void GetBlobContentInSubDirectory()
        {
            string ContainerName = Utility.GenNameString("container");
            FileUtil.CleanDirectory(downloadDirRoot);
            List<string> files = FileUtil.GenerateTempFiles(downloadDirRoot, 2);
            files.Sort();

            CloudBlobContainer Container = blobUtil.CreateContainer(ContainerName);

            try
            {
                foreach (string file in files)
                {
                    string filePath = Path.Combine(downloadDirRoot, file);
                    string blobName = string.Empty;
                    using (var fileStream = System.IO.File.OpenRead(filePath))
                    {
                        blobName = file;
                        CloudBlockBlob blockBlob = Container.GetBlockBlobReference(blobName);
                        blockBlob.UploadFromStream(fileStream);
                    }
                }

                List<IListBlobItem> blobLists = Container.ListBlobs(string.Empty, true, BlobListingDetails.All).ToList();
                Test.Assert(blobLists.Count == files.Count, string.Format("container {0} should contain {1} blobs, and actually it contain {2} blobs", ContainerName, files.Count, blobLists.Count));

                FileUtil.CleanDirectory(downloadDirRoot);

                ((PowerShellAgent)agent).AddPipelineScript(string.Format("Get-AzureStorageContainer {0}", ContainerName));
                ((PowerShellAgent)agent).AddPipelineScript("Get-AzureStorageBlob");
                Test.Assert(agent.GetAzureStorageBlobContent(string.Empty, downloadDirRoot, string.Empty, true), "download blob should be successful");
                Test.Assert(agent.Output.Count == files.Count, "Get-AzureStroageBlobContent should download {0} blobs, and actully it's {1}", files.Count, agent.Output.Count);

                for (int i = 0, count = files.Count(); i < count; i++)
                {
                    string path = Path.Combine(downloadDirRoot, files[i]);
                    ICloudBlob blob = blobLists[i] as ICloudBlob;
                    if (!File.Exists(path))
                    {
                        Test.AssertFail(string.Format("local file '{0}' doesn't exist.", path));
                    }

                    string localMd5 = Helper.GetFileContentMD5(path);
                    string convertedName = blobUtil.ConvertBlobNameToFileName(blob.Name, string.Empty);
                    Test.Assert(files[i] == convertedName, string.Format("converted blob name should be {0}, actually it's {1}", files[i], convertedName));
                    Test.Assert(localMd5 == blob.Properties.ContentMD5, string.Format("blob content md5 should be {0}, and actualy it's {1}", localMd5, blob.Properties.ContentMD5));
                }
            }
            finally
            {
                FileUtil.CleanDirectory(downloadDirRoot);
                blobUtil.RemoveContainer(ContainerName);
            }
        }

        /// <summary>
        /// get blob content by container pipeline
        /// 8.15 Get-AzureStorageBlobContent positive function cases
        ///    6. Validate that all the blob snapshots can be downloaded
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlobContent)]
        public void GetBlobContentFromSnapshot()
        {
            SetupTestContainerAndBlob();

            try
            {
                List<ICloudBlob> blobs = new List<ICloudBlob>();
                int minSnapshot = 1;
                int maxSnapshot = 5;
                int snapshotCount = random.Next(minSnapshot, maxSnapshot);

                for (int i = 0; i < snapshotCount; i++)
                {
                    ICloudBlob blob = ((CloudBlockBlob)Blob).CreateSnapshot();
                    blobs.Add(blob);
                }

                blobs.Add(Blob);

                List<IListBlobItem> blobLists = Container.ListBlobs(string.Empty, true, BlobListingDetails.All).ToList();
                Test.Assert(blobLists.Count == blobs.Count, string.Format("container {0} should contain {1} blobs, and actually it contain {2} blobs", ContainerName, blobs.Count, blobLists.Count));

                FileUtil.CleanDirectory(downloadDirRoot);

                ((PowerShellAgent)agent).AddPipelineScript(string.Format("Get-AzureStorageContainer {0}", ContainerName));
                ((PowerShellAgent)agent).AddPipelineScript("Get-AzureStorageBlob");
                Test.Assert(agent.GetAzureStorageBlobContent(string.Empty, downloadDirRoot, string.Empty, true), "download blob should be successful");
                Test.Assert(agent.Output.Count == blobs.Count, "Get-AzureStroageBlobContent should download {0} blobs, and actully it's {1}", blobs.Count, agent.Output.Count);

                for (int i = 0, count = blobs.Count(); i < count; i++)
                {
                    ICloudBlob blob = blobLists[i] as ICloudBlob;
                    string path = Path.Combine(downloadDirRoot, blobUtil.ConvertBlobNameToFileName(blob.Name, string.Empty, blob.SnapshotTime));

                    Test.Assert(File.Exists(path), string.Format("local file '{0}' should exists after downloading.", path));

                    string localMd5 = Helper.GetFileContentMD5(path);
                    string convertedName = blobUtil.ConvertBlobNameToFileName(blob.Name, string.Empty);
                    Test.Assert(localMd5 == blob.Properties.ContentMD5, string.Format("blob content md5 should be {0}, and actualy it's {1}", localMd5, blob.Properties.ContentMD5));
                }
            }
            finally
            {
                FileUtil.CleanDirectory(downloadDirRoot);
                CleanupTestContainerAndBlob();
            }
        }

        /// <summary>
        /// download a not existing blob
        /// </summary>
        /// 8.15 Get-AzureStorageBlobContent negative function cases
        ///    1.	Download a non-existing blob file
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlobContent)]
        public void GetBlobContentWithNotExistsBlob()
        {
            SetupTestContainerAndBlob();

            try
            {
                string notExistingBlobName = Utility.GenNameString("notexisting");
                DirectoryInfo dir = new DirectoryInfo(downloadDirRoot);
                int filesCountBeforeDowloading = dir.GetFiles().Count();
                Test.Assert(!agent.GetAzureStorageBlobContent(notExistingBlobName, downloadDirRoot, ContainerName, true), "download not existing blob should be failed");
                string expectedErrorMessage = string.Format("Can not find blob '{0}' in container '{1}'.", notExistingBlobName, ContainerName);
                Test.Assert(agent.ErrorMessages[0] == expectedErrorMessage, agent.ErrorMessages[0]);
                int filesCountAfterDowloading = dir.GetFiles().Count();
                Test.Assert(filesCountBeforeDowloading == filesCountAfterDowloading, "the files count should be equal after a failed downloading");
            }
            finally
            {
                CleanupTestContainerAndBlob();
            }
        }

        /// <summary>
        /// download a not existing blob
        /// </summary>
        /// 8.15 Get-AzureStorageBlobContent negative function cases
        ///    3. Download a blob file with an invalid container name or container object
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.GetBlobContent)]
        public void GetBlobContentWithNotExistsContainer()
        {
            string containerName = Utility.GenNameString("notexistingcontainer");
            string blobName = Utility.GenNameString("blob");
            DirectoryInfo dir = new DirectoryInfo(downloadDirRoot);
            int filesCountBeforeDowloading = dir.GetFiles().Count();
            Test.Assert(!agent.GetAzureStorageBlobContent(blobName, downloadDirRoot, containerName, true), "download blob from not existing container should be failed");
            //TODO seems the error is not our expected
            string expectedErrorMessage = string.Format("Can not find blob '{0}' in container '{1}'.", blobName, containerName);
            Test.Assert(agent.ErrorMessages[0] == expectedErrorMessage, agent.ErrorMessages[0]);
            int filesCountAfterDowloading = dir.GetFiles().Count();
            Test.Assert(filesCountBeforeDowloading == filesCountAfterDowloading, "the files count should be equal after a failed downloading");
        }
    }
}
