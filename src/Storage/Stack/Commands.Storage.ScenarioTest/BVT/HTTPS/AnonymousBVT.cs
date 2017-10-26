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
using System.Collections.ObjectModel;
using System.IO;
using Commands.Storage.ScenarioTest.Common;
using Commands.Storage.ScenarioTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MS.Test.Common.MsTestLib;
using StorageTestLib;
using StorageBlob = Microsoft.WindowsAzure.Storage.Blob;

namespace Commands.Storage.ScenarioTest.BVT.HTTPS
{
    /// <summary>
    /// bvt cases for anonymous storage account
    /// </summary>
    [TestClass]
    class AnonymousBVT : TestBase
    {
        protected static string downloadDirRoot;

        private static string ContainerPrefix = "anonymousbvt";
        protected static string StorageAccountName;
        protected static string StorageEndPoint;
        protected static bool useHttps;

        [ClassInitialize()]
        public static void AnonymousBVTClassInitialize(TestContext testContext)
        {
            TestBase.TestClassInitialize(testContext);
            CLICommonBVT.SaveAndCleanSubScriptionAndEnvConnectionString();
            StorageAccountName = Test.Data.Get("StorageAccountName");
            StorageEndPoint = Test.Data.Get("StorageEndPoint").Trim();
            useHttps = true;
            PowerShellAgent.SetAnonymousStorageContext(StorageAccountName, useHttps, StorageEndPoint);
            downloadDirRoot = Test.Data.Get("DownloadDir");
            SetupDownloadDir();
        }

        [ClassCleanup()]
        public static void AnonymousBVTClassCleanup()
        {
            FileUtil.CleanDirectory(downloadDirRoot);
            CLICommonBVT.RestoreSubScriptionAndEnvConnectionString();
            TestBase.TestClassCleanup();
        }

        /// <summary>
        /// create download dir
        /// </summary>
        //TODO remove code redundancy
        protected static void SetupDownloadDir()
        {
            if (!Directory.Exists(downloadDirRoot))
            {
                Directory.CreateDirectory(downloadDirRoot);
            }

            FileUtil.CleanDirectory(downloadDirRoot);
        }

        [TestMethod]
        [TestCategory(Tag.BVT)]
        public void ListContainerWithContianerPermission()
        {
            string containerName = Utility.GenNameString(ContainerPrefix);
            StorageBlob.CloudBlobContainer container = blobUtil.CreateContainer(containerName, StorageBlob.BlobContainerPublicAccessType.Container);

            try
            {
                Test.Assert(agent.GetAzureStorageContainer(containerName), Utility.GenComparisonData("GetAzureStorageContainer", true));

                Dictionary<string, object> dic = Utility.GenComparisonData(StorageObjectType.Container, containerName);

                Collection<Dictionary<string, object>> comp = new Collection<Dictionary<string, object>> { dic };
                //remove the permssion information for anonymous storage account
                CloudBlobUtil.PackContainerCompareData(container, dic);
                dic["PublicAccess"] = null;
                dic["Permission"] = null;
                // Verification for returned values
                agent.OutputValidation(comp);

                //check the http or https usage
                StorageBlob.CloudBlobContainer retrievedContainer = (StorageBlob.CloudBlobContainer)agent.Output[0]["CloudBlobContainer"]; ;
                string uri = retrievedContainer.Uri.ToString();
                string uriPrefix = string.Empty;

                if (useHttps)
                {
                    uriPrefix = "https";
                }
                else
                {
                    uriPrefix = "http";
                }

                Test.Assert(uri.ToString().StartsWith(uriPrefix), string.Format("The prefix of container uri should be {0}, actually it's {1}", uriPrefix, uri));
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// list blobs when container's public access level is public
        /// </summary>
        [TestMethod]
        [TestCategory(Tag.BVT)]
        public void ListBlobsWithBlobPermission()
        {
            string containerName = Utility.GenNameString(ContainerPrefix);
            StorageBlob.CloudBlobContainer container = blobUtil.CreateContainer(containerName, StorageBlob.BlobContainerPublicAccessType.Blob);

            try
            {
                string pageBlobName = Utility.GenNameString("pageblob");
                string blockBlobName = Utility.GenNameString("blockblob");
                StorageBlob.ICloudBlob blockBlob = blobUtil.CreateBlockBlob(container, blockBlobName);
                StorageBlob.ICloudBlob pageBlob = blobUtil.CreatePageBlob(container, pageBlobName);

                Test.Assert(agent.GetAzureStorageBlob(blockBlobName, containerName), Utility.GenComparisonData("Get-AzureStorageBlob", true));
                agent.OutputValidation(new List<StorageBlob.ICloudBlob> { blockBlob });
                Test.Assert(agent.GetAzureStorageBlob(pageBlobName, containerName), Utility.GenComparisonData("Get-AzureStorageBlob", true));
                agent.OutputValidation(new List<StorageBlob.ICloudBlob> { pageBlob });
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// download blob when container's public access level is container
        /// </summary>
        [TestMethod]
        [TestCategory(Tag.BVT)]
        public void GetBlobContentWithContainerPermission()
        {
            string containerName = Utility.GenNameString(ContainerPrefix);
            StorageBlob.CloudBlobContainer container = blobUtil.CreateContainer(containerName, StorageBlob.BlobContainerPublicAccessType.Container);

            try
            {
                DownloadBlobFromContainerTest(container);
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// download blob when container's public access level is blob
        /// </summary>
        [TestMethod]
        [TestCategory(Tag.BVT)]
        public void GetBlobContentWithBlobPermission()
        {
            string containerName = Utility.GenNameString(ContainerPrefix);
            StorageBlob.CloudBlobContainer container = blobUtil.CreateContainer(containerName, StorageBlob.BlobContainerPublicAccessType.Blob);

            try
            {
                DownloadBlobFromContainerTest(container);
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }

        /// <summary>
        /// download test in specified container
        /// </summary>
        /// <param name="container">CloudBlobContainer object</param>
        private void DownloadBlobFromContainerTest(StorageBlob.CloudBlobContainer container)
        {
            DownloadBlobFromContainer(container, StorageBlob.BlobType.BlockBlob);
            DownloadBlobFromContainer(container, StorageBlob.BlobType.PageBlob);
        }

        /// <summary>
        /// download specified blob
        /// </summary>
        /// <param name="container"></param>
        /// <param name="blob"></param>
        private void DownloadBlobFromContainer(StorageBlob.CloudBlobContainer container, StorageBlob.BlobType type)
        {
            string blobName = Utility.GenNameString("blob");
            StorageBlob.ICloudBlob blob = blobUtil.CreateBlob(container, blobName, type);

            string filePath = Path.Combine(downloadDirRoot, blob.Name);
            Test.Assert(agent.GetAzureStorageBlobContent(blob.Name, filePath, container.Name, true), "download blob should be successful");
            string localMd5 = Helper.GetFileContentMD5(filePath);
            Test.Assert(localMd5 == blob.Properties.ContentMD5, string.Format("local content md5 should be {0}, and actualy it's {1}", blob.Properties.ContentMD5, localMd5));
            agent.OutputValidation(new List<StorageBlob.ICloudBlob> { blob });
        }

        [TestMethod()]
        [TestCategory(Tag.BVT)]
        public void MakeSureBvtUsingAnonymousContext()
        {
            //TODO EnvKey is not empty since we called SaveAndCleanSubScriptionAndEnvConnectionString when initializing
            string key = System.Environment.GetEnvironmentVariable(CLICommonBVT.EnvKey);
            Test.Assert(string.IsNullOrEmpty(key), string.Format("env connection string {0} should be null or empty", key));
            Test.Assert(PowerShellAgent.Context != null, "PowerShell context should be not null when running bvt against Anonymous storage account");
        }

        /// <summary>
        /// Anonymous storage context should work with specified end point
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.BVT)]
        public void AnonymousContextWithEndPoint()
        {
            string containerName = Utility.GenNameString(ContainerPrefix);
            StorageBlob.CloudBlobContainer container = blobUtil.CreateContainer(containerName, StorageBlob.BlobContainerPublicAccessType.Blob);

            try
            {
                string pageBlobName = Utility.GenNameString("pageblob");
                string blockBlobName = Utility.GenNameString("blockblob");
                StorageBlob.ICloudBlob blockBlob = blobUtil.CreateBlockBlob(container, blockBlobName);
                StorageBlob.ICloudBlob pageBlob = blobUtil.CreatePageBlob(container, pageBlobName);

                agent.UseContextParam = false;
                string cmd = string.Format("new-azurestoragecontext -StorageAccountName {0} " +
                    "-Anonymous -EndPoint {1}", StorageAccountName, StorageEndPoint);
                ((PowerShellAgent)agent).AddPipelineScript(cmd);
                Test.Assert(agent.GetAzureStorageBlob(blockBlobName, containerName), Utility.GenComparisonData("Get-AzureStorageBlob", true));
                agent.OutputValidation(new List<StorageBlob.ICloudBlob> { blockBlob });
                ((PowerShellAgent)agent).AddPipelineScript(cmd);
                Test.Assert(agent.GetAzureStorageBlob(pageBlobName, containerName), Utility.GenComparisonData("Get-AzureStorageBlob", true));
                agent.OutputValidation(new List<StorageBlob.ICloudBlob> { pageBlob });
            }
            finally
            {
                blobUtil.RemoveContainer(containerName);
            }
        }
    }
}
