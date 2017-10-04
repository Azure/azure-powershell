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

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Commands.Storage.ScenarioTest.Common;
using Commands.Storage.ScenarioTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MS.Test.Common.MsTestLib;
using StorageTestLib;
using StorageBlob = Microsoft.WindowsAzure.Storage.Blob;

namespace Commands.Storage.ScenarioTest.Functional.Blob
{
    /// <summary>
    /// functional tests for Set-ContainerAcl
    /// </summary>
    [TestClass]
    class SetBlobContent : TestBase
    {
        private static string uploadDirRoot;
        private static List<string> files = new List<string>();

        //TODO upload a already opened read/write file
        [ClassInitialize()]
        public static void ClassInit(TestContext testContext)
        {
            TestBase.TestClassInitialize(testContext);
            uploadDirRoot = Test.Data.Get("UploadDir");
            SetupUploadDir();
        }

        [ClassCleanup()]
        public static void SetBlobContentClassCleanup()
        {
            TestBase.TestClassCleanup();
        }

        /// <summary>
        /// create upload dir and temp files
        /// </summary>
        private static void SetupUploadDir()
        {
            Test.Verbose("Create Upload dir {0}", uploadDirRoot);

            if (!Directory.Exists(uploadDirRoot))
            {
                Directory.CreateDirectory(uploadDirRoot);
            }

            FileUtil.CleanDirectory(uploadDirRoot);

            int minDirDepth = 1, maxDirDepth = 3;
            int dirDepth = random.Next(minDirDepth, maxDirDepth);
            Test.Info("Generate Temp files for Set-AzureStorageBlobContent");
            files = FileUtil.GenerateTempFiles(uploadDirRoot, dirDepth);
            files.Sort();
        }

        /// <summary>
        /// set azure blob content by mutilple files
        /// 8.14	Set-AzureStorageBlobContent
        ///     3.	Upload a list of new blob files
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.SetBlobContent)]
        public void SetBlobContentByMultipleFiles()
        {
            string containerName = Utility.GenNameString("container");
            StorageBlob.CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            try
            {
                List<StorageBlob.IListBlobItem> blobLists = container.ListBlobs(string.Empty, true, StorageBlob.BlobListingDetails.All).ToList();
                Test.Assert(blobLists.Count == 0, string.Format("container {0} should contain {1} blobs, and actually it contain {2} blobs", containerName, 0, blobLists.Count));

                DirectoryInfo rootDir = new DirectoryInfo(uploadDirRoot);

                FileInfo[] rootFiles = rootDir.GetFiles();

                ((PowerShellAgent)agent).AddPipelineScript(string.Format("ls -File -Path {0}", uploadDirRoot));
                Test.Info("Upload files...");
                Test.Assert(agent.SetAzureStorageBlobContent(string.Empty, containerName, StorageBlob.BlobType.BlockBlob), "upload multiple files should be successsed");
                Test.Info("Upload finished...");
                blobLists = container.ListBlobs(string.Empty, true, StorageBlob.BlobListingDetails.All).ToList();
                Test.Assert(blobLists.Count == rootFiles.Count(), string.Format("set-azurestorageblobcontent should upload {0} files, and actually it's {1}", rootFiles.Count(), blobLists.Count));

                StorageBlob.ICloudBlob blob = null;
                for (int i = 0, count = rootFiles.Count(); i < count; i++)
                {
                    blob = blobLists[i] as StorageBlob.ICloudBlob;

                    if (blob == null)
                    {
                        Test.AssertFail("blob can't be null");
                    }

                    Test.Assert(rootFiles[i].Name == blob.Name, string.Format("blob name should be {0}, and actully it's {1}", rootFiles[i].Name, blob.Name));
                    string localMd5 = Helper.GetFileContentMD5(Path.Combine(uploadDirRoot, rootFiles[i].Name));
                    Test.Assert(blob.BlobType == Microsoft.WindowsAzure.Storage.Blob.BlobType.BlockBlob, "blob type should be block blob");
                    Test.Assert(localMd5 == blob.Properties.ContentMD5, string.Format("blob content md5 should be {0}, and actualy it's {1}", localMd5, blob.Properties.ContentMD5));
                }
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// upload files in subdirectory
        /// 8.14	Set-AzureStorageBlobContent positive functional cases.
        ///     4. Upload a block blob file and a page blob file with a subdirectory
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.SetBlobContent)]
        public void SetBlobContentWithSubDirectory()
        {
            DirectoryInfo rootDir = new DirectoryInfo(uploadDirRoot);

            DirectoryInfo[] dirs = rootDir.GetDirectories();

            foreach (DirectoryInfo dir in dirs)
            {
                string containerName = Utility.GenNameString("container");
                StorageBlob.CloudBlobContainer container = blobUtil.CreateContainer(containerName);

                try
                {
                    List<StorageBlob.IListBlobItem> blobLists = container.ListBlobs(string.Empty, true, StorageBlob.BlobListingDetails.All).ToList();
                    Test.Assert(blobLists.Count == 0, string.Format("container {0} should contain {1} blobs, and actually it contain {2} blobs", containerName, 0, blobLists.Count));

                    StorageBlob.BlobType blobType = StorageBlob.BlobType.BlockBlob;

                    if (dir.Name.StartsWith("dirpage"))
                    {
                        blobType = Microsoft.WindowsAzure.Storage.Blob.BlobType.PageBlob;
                    }

                    ((PowerShellAgent)agent).AddPipelineScript(string.Format("ls -File -Recurse -Path {0}", dir.FullName));
                    Test.Info("Upload files...");
                    Test.Assert(agent.SetAzureStorageBlobContent(string.Empty, containerName, blobType), "upload multiple files should be successsed");
                    Test.Info("Upload finished...");

                    blobLists = container.ListBlobs(string.Empty, true, StorageBlob.BlobListingDetails.All).ToList();
                    List<string> dirFiles = files.FindAll(item => item.StartsWith(dir.Name));
                    Test.Assert(blobLists.Count == dirFiles.Count(), string.Format("set-azurestorageblobcontent should upload {0} files, and actually it's {1}", dirFiles.Count(), blobLists.Count));

                    StorageBlob.ICloudBlob blob = null;
                    for (int i = 0, count = dirFiles.Count(); i < count; i++)
                    {
                        blob = blobLists[i] as StorageBlob.ICloudBlob;

                        if (blob == null)
                        {
                            Test.AssertFail("blob can't be null");
                        }

                        string convertedName = blobUtil.ConvertBlobNameToFileName(blob.Name, dir.Name);
                        Test.Assert(dirFiles[i] == convertedName, string.Format("blob name should be {0}, and actully it's {1}", dirFiles[i], convertedName));
                        string localMd5 = Helper.GetFileContentMD5(Path.Combine(uploadDirRoot, dirFiles[i]));
                        Test.Assert(blob.BlobType == blobType, "blob type should be block blob");
                        Test.Assert(localMd5 == blob.Properties.ContentMD5, string.Format("blob content md5 should be {0}, and actualy it's {1}", localMd5, blob.Properties.ContentMD5));
                    }
                }
                finally
                {
                    blobUtil.RemoveContainer(containerName);
                }
            }
        }

        /// <summary>
        /// set blob content with invalid bob name
        /// 8.14	Set-AzureStorageBlobContent negative functional cases
        ///     1. Upload a block blob file and a page blob file with a subdirectory
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.SetBlobContent)]
        public void SetBlobContentWithInvalidBlobName()
        {
            string containerName = Utility.GenNameString("container");
            StorageBlob.CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            try
            {
                int MaxBlobNameLength = 1024;
                string blobName = new string('a', MaxBlobNameLength + 1);

                List<StorageBlob.IListBlobItem> blobLists = container.ListBlobs(string.Empty, true, StorageBlob.BlobListingDetails.All).ToList();
                Test.Assert(blobLists.Count == 0, string.Format("container {0} should contain {1} blobs, and actually it contain {2} blobs", containerName, 0, blobLists.Count));

                Test.Assert(!agent.SetAzureStorageBlobContent(Path.Combine(uploadDirRoot, files[0]), containerName, StorageBlob.BlobType.BlockBlob, blobName), "upload blob with invalid blob name should be failed");
                string expectedErrorMessage = string.Format("Blob name '{0}' is invalid.", blobName);
                ExpectedStartsWithErrorMessage(expectedErrorMessage);
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// set blob content with invalid blob type
        /// 8.14	Set-AzureStorageBlobContent negative functional cases
        ///     6.	Upload a blob file with the same name but with different BlobType
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.SetBlobContent)]
        public void SetBlobContentWithInvalidBlobType()
        {
            string containerName = Utility.GenNameString("container");
            StorageBlob.CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            try
            {
                string blobName = files[0];

                List<StorageBlob.IListBlobItem> blobLists = container.ListBlobs(string.Empty, true, StorageBlob.BlobListingDetails.All).ToList();
                Test.Assert(blobLists.Count == 0, string.Format("container {0} should contain {1} blobs, and actually it contain {2} blobs", containerName, 0, blobLists.Count));

                Test.Assert(agent.SetAzureStorageBlobContent(Path.Combine(uploadDirRoot, files[0]), containerName, StorageBlob.BlobType.BlockBlob, blobName), "upload blob should be successful.");
                blobLists = container.ListBlobs(string.Empty, true, StorageBlob.BlobListingDetails.All).ToList();
                Test.Assert(blobLists.Count == 1, string.Format("container {0} should contain {1} blobs, and actually it contain {2} blobs", containerName, 1, blobLists.Count));
                string convertBlobName = blobUtil.ConvertFileNameToBlobName(blobName);
                Test.Assert(((StorageBlob.ICloudBlob)blobLists[0]).Name == convertBlobName, string.Format("blob name should be {0}, actually it's {1}", convertBlobName, ((StorageBlob.ICloudBlob)blobLists[0]).Name));

                Test.Assert(!agent.SetAzureStorageBlobContent(Path.Combine(uploadDirRoot, files[0]), containerName, StorageBlob.BlobType.PageBlob, blobName), "upload blob should be with invalid blob should be failed.");
                string expectedErrorMessage = string.Format("Blob type mismatched, the current blob type of '{0}' is BlockBlob.", ((StorageBlob.ICloudBlob)blobLists[0]).Name);
                Test.Assert(agent.ErrorMessages[0] == expectedErrorMessage, string.Format("Expect error message: {0} != {1}", expectedErrorMessage, agent.ErrorMessages[0]));
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// upload page blob with invalid file size
        /// 8.14	Set-AzureStorageBlobContent negative functional cases
        ///     8.	Upload a page blob the size of which is not 512*n
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.SetBlobContent)]
        public void SetPageBlobWithInvalidFileSize()
        {
            string fileName = Utility.GenNameString("tinypageblob");
            string filePath = Path.Combine(uploadDirRoot, fileName);
            int fileSize = 480;
            Helper.GenerateTinyFile(filePath, fileSize);
            string containerName = Utility.GenNameString("container");
            StorageBlob.CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            try
            {
                List<StorageBlob.IListBlobItem> blobLists = container.ListBlobs(string.Empty, true, StorageBlob.BlobListingDetails.All).ToList();
                Test.Assert(blobLists.Count == 0, string.Format("container {0} should contain {1} blobs, and actually it contain {2} blobs", containerName, 0, blobLists.Count));
                Test.Assert(!agent.SetAzureStorageBlobContent(filePath, containerName, StorageBlob.BlobType.PageBlob), "upload page blob with invalid file size should be failed.");
                string expectedErrorMessage = "The page blob size must be a multiple of 512 bytes.";
                Test.Assert(agent.ErrorMessages[0].StartsWith(expectedErrorMessage), expectedErrorMessage);
                blobLists = container.ListBlobs(string.Empty, true, StorageBlob.BlobListingDetails.All).ToList();
                Test.Assert(blobLists.Count == 0, string.Format("container {0} should contain {1} blobs, and actually it contain {2} blobs", containerName, 0, blobLists.Count));
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
                FileUtil.RemoveFile(filePath);
            }
        }

        /// <summary>
        /// Set blob content with blob properties
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.SetBlobContent)]
        public void SetBlobContentWithProperties()
        {
            SetBlobContentWithProperties(StorageBlob.BlobType.BlockBlob);
            SetBlobContentWithProperties(StorageBlob.BlobType.PageBlob);
        }

        /// <summary>
        /// set blob content with blob meta data
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.SetBlobContent)]
        public void SetBlobContentWithMetadata()
        {
            SetBlobContentWithMetadata(StorageBlob.BlobType.BlockBlob);
            SetBlobContentWithMetadata(StorageBlob.BlobType.PageBlob);
        }

        /// <summary>
        /// set blob content with blob meta data
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.Function)]
        [TestCategory(PsTag.Blob)]
        [TestCategory(PsTag.SetBlobContent)]
        public void SetBlobContentForEixstsBlobWithoutForce()
        {
            string filePath = FileUtil.GenerateOneTempTestFile();
            StorageBlob.CloudBlobContainer container = blobUtil.CreateContainer();
            string blobName = Utility.GenNameString("blob");
            StorageBlob.ICloudBlob blob = blobUtil.CreateRandomBlob(container, blobName);

            try
            {
                string previousMd5 = blob.Properties.ContentMD5;
                Test.Assert(!agent.SetAzureStorageBlobContent(filePath, container.Name, blob.BlobType, blob.Name, false), "set blob content without force parameter should fail");
                ExpectedContainErrorMessage(ConfirmExceptionMessage);
                blob.FetchAttributes();
                ExpectEqual(previousMd5, blob.Properties.ContentMD5, "content md5");
            }
            finally
            {
                blobUtil.RemoveContainer(container.Name);
                FileUtil.RemoveFile(filePath);
            }
        }

        public void SetBlobContentWithProperties(StorageBlob.BlobType blobType)
        {
            string filePath = FileUtil.GenerateOneTempTestFile();
            StorageBlob.CloudBlobContainer container = blobUtil.CreateContainer();
            Hashtable properties = new Hashtable();
            properties.Add("CacheControl", Utility.GenNameString(string.Empty));
            properties.Add("ContentEncoding", Utility.GenNameString(string.Empty));
            properties.Add("ContentLanguage", Utility.GenNameString(string.Empty));
            properties.Add("ContentMD5", Utility.GenNameString(string.Empty));
            properties.Add("ContentType", Utility.GenNameString(string.Empty));

            try
            {
                Test.Assert(agent.SetAzureStorageBlobContent(filePath, container.Name, blobType, string.Empty, true, -1, properties), "set blob content with property should succeed");
                StorageBlob.ICloudBlob blob = container.GetBlobReferenceFromServer(Path.GetFileName(filePath));
                blob.FetchAttributes();
                ExpectEqual(properties["CacheControl"].ToString(), blob.Properties.CacheControl, "Cache control");
                ExpectEqual(properties["ContentEncoding"].ToString(), blob.Properties.ContentEncoding, "Content Encoding");
                ExpectEqual(properties["ContentLanguage"].ToString(), blob.Properties.ContentLanguage, "Content Language");
                ExpectEqual(properties["ContentMD5"].ToString(), blob.Properties.ContentMD5, "Content MD5");
                ExpectEqual(properties["ContentType"].ToString(), blob.Properties.ContentType, "Content Type");
            }
            finally
            {
                blobUtil.RemoveContainer(container.Name);
                FileUtil.RemoveFile(filePath);
            }
        }

        public void SetBlobContentWithMetadata(StorageBlob.BlobType blobType)
        {
            string filePath = FileUtil.GenerateOneTempTestFile();
            StorageBlob.CloudBlobContainer container = blobUtil.CreateContainer();
            Hashtable metadata = new Hashtable();
            int metaCount = GetRandomTestCount();

            for (int i = 0; i < metaCount; i++)
            {
                string key = Utility.GenRandomAlphabetString();
                string value = Utility.GenNameString(string.Empty);

                if (!metadata.ContainsKey(key))
                {
                    Test.Info(string.Format("Add meta key: {0} value : {1}", key, value));
                    metadata.Add(key, value);
                }
            }

            try
            {
                Test.Assert(agent.SetAzureStorageBlobContent(filePath, container.Name, blobType, string.Empty, true, -1, null, metadata), "set blob content with meta should succeed");
                StorageBlob.ICloudBlob blob = container.GetBlobReferenceFromServer(Path.GetFileName(filePath));
                blob.FetchAttributes();
                ExpectEqual(metadata.Count, blob.Metadata.Count, "meta data count");

                foreach (string key in metadata.Keys)
                {
                    ExpectEqual(metadata[key].ToString(), blob.Metadata[key], "Meta data key " + key);
                }
            }
            finally
            {
                blobUtil.RemoveContainer(container.Name);
                FileUtil.RemoveFile(filePath);
            }
        }
    }
}
