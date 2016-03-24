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

using System.IO;
using Commands.Storage.ScenarioTest.Common;
using Commands.Storage.ScenarioTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MS.Test.Common.MsTestLib;
using StorageTestLib;
using StorageBlob = Microsoft.WindowsAzure.Storage.Blob;

namespace Commands.Storage.ScenarioTest.GB18030Test.Blob
{
    /// <summary>
    /// Functional tests for blob content with GB18030 encoding
    /// </summary>
    [TestClass]
    class BlobContentTest : TestBase
    {
        private static string GB18030String = "啊齄丂狛狜隣郎隣兀﨩ˊ▇█〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€㐀㒣㕴㕵㙉㙊䵯䵰䶴䶵啊齄丂狛狜隣郎隣兀﨩ˊ▇█〞〡￤℡㈱‐ー﹡﹢﹫、〓ⅰⅹ⒈€㈠㈩ⅠⅫ！￣ぁんァヶΑ︴АЯаяāɡㄅㄩ─╋︵﹄︻︱︳︴ⅰⅹɑɡ〇〾⿻⺁䜣€㐀㒣㕴㕵㙉㙊䵯䵰䶴䶵㒣㕴㕵㙉㙊䵯䵰䶴䶵㒣㕴㕵㙉㙊䵯䵰abcd";
        private static StorageBlob.BlobType[] blobTypes = { StorageBlob.BlobType.BlockBlob, StorageBlob.BlobType.PageBlob };

        [ClassInitialize()]
        public static void ClassInit(TestContext testContext)
        {
            TestBase.TestClassInitialize(testContext);
        }

        [ClassCleanup()]
        public static void SetBlobContentClassCleanup()
        {
            TestBase.TestClassCleanup();
        }

        /// <summary>
        /// GB18030 compliance test for upload blob cmdlet
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.GB18030)]
        [TestCategory(Tag.Function)]
        public void UploadBlobTestGB()
        {
            for (int i = 0; i < blobTypes.Length; ++i)
            {
                UploadBlobTestGB(new PowerShellAgent(), blobTypes[i]);                
            }
        }

        /// <summary>
        /// GB18030 compliance test for download blob cmdlet
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.GB18030)]
        [TestCategory(Tag.Function)]
        public void DownloadBlobTestGB()
        {
            for (int i = 0; i < blobTypes.Length; ++i)
            {
                DownloadBlobTestGB(new PowerShellAgent(), blobTypes[i]);
            }
        }

        /// <summary>
        /// GB18030 compliance test for copy blob cmdlet
        /// </summary>
        [TestMethod()]
        [TestCategory(Tag.GB18030)]
        [TestCategory(Tag.Function)]
        public void CopyBlobTestGB()
        {
            for (int i = 0; i < blobTypes.Length; ++i)
            {
                CopyBlobTestGB(new PowerShellAgent(), blobTypes[i]);
            }
        }

        internal void UploadBlobTestGB(Agent agent, StorageBlob.BlobType blobType)
        {
            string uploadFilePath = @".\" + Utility.GenNameString("gbupload");
            string containerName = Utility.GenNameString("gbupload-");
            string blobName = Path.GetFileName(uploadFilePath);

            // create the container
            StorageBlob.CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            // Generate a 512 bytes file which contains GB18030 characters
            File.WriteAllText(uploadFilePath, GB18030String);

            try
            {
                //--------------Upload operation--------------
                Test.Assert(agent.SetAzureStorageBlobContent(uploadFilePath, containerName, blobType), 
                    Utility.GenComparisonData("SendAzureStorageBlob", true));

                StorageBlob.ICloudBlob blob = CloudBlobUtil.GetBlob(container, blobName, blobType);
                Test.Assert(blob != null && blob.Exists(), "blob " + blobName + " should exist!");

                // Check MD5
                string localMd5 = Helper.GetFileContentMD5(uploadFilePath);
                blob.FetchAttributes();
                Test.Assert(localMd5 == blob.Properties.ContentMD5, 
                    string.Format("blob content md5 should be {0}, and actualy it's {1}", localMd5, blob.Properties.ContentMD5));
            }
            finally
            {
                // cleanup
                container.DeleteIfExists();
                File.Delete(uploadFilePath);
            }
        }

        internal void DownloadBlobTestGB(Agent agent, StorageBlob.BlobType blobType)
        {
            string uploadFilePath = @".\" + Utility.GenNameString("gbupload");
            string downloadFilePath = @".\" + Utility.GenNameString("gbdownload");
            string containerName = Utility.GenNameString("gbupload-");
            string blobName = Path.GetFileName(uploadFilePath);

            // create the container
            StorageBlob.CloudBlobContainer container = blobUtil.CreateContainer(containerName);

            // Generate a 512 bytes file which contains GB18030 characters
            File.WriteAllText(uploadFilePath, GB18030String);

            try
            {
                // create source blob
                StorageBlob.ICloudBlob blob = CloudBlobUtil.GetBlob(container, blobName, blobType);

                // upload file data
                using (var fileStream = System.IO.File.OpenRead(uploadFilePath))
                {
                    blob.UploadFromStream(fileStream);
                }

                //--------------Download operation--------------
                Test.Assert(agent.GetAzureStorageBlobContent(blobName, downloadFilePath, containerName, true), "download blob should be successful");

                // Check MD5
                string localMd5 = Helper.GetFileContentMD5(downloadFilePath);
                string uploadMd5 = Helper.GetFileContentMD5(uploadFilePath);
                blob.FetchAttributes();
                Test.Assert(localMd5 == uploadMd5, string.Format("blob content md5 should be {0}, and actualy it's {1}", localMd5, uploadMd5));
            }
            finally
            {
                // cleanup
                container.DeleteIfExists();
                File.Delete(uploadFilePath);
                File.Delete(downloadFilePath);
            }
        }

        internal void CopyBlobTestGB(Agent agent, StorageBlob.BlobType blobType)
        {
            string uploadFilePath = @".\" + Utility.GenNameString("gbupload");
            string srcContainerName = Utility.GenNameString("gbupload-", 15);
            string destContainerName = Utility.GenNameString("gbupload-", 15);
            string blobName = Path.GetFileName(uploadFilePath);

            // create the container
            StorageBlob.CloudBlobContainer srcContainer = blobUtil.CreateContainer(srcContainerName);
            StorageBlob.CloudBlobContainer destContainer = blobUtil.CreateContainer(destContainerName);

            // Generate a 512 bytes file which contains GB18030 characters
            File.WriteAllText(uploadFilePath, GB18030String);

            string localMd5 = Helper.GetFileContentMD5(uploadFilePath);

            try
            {
                // create source blob
                StorageBlob.ICloudBlob blob = CloudBlobUtil.GetBlob(srcContainer, blobName, blobType);

                // upload file data
                using (var fileStream = System.IO.File.OpenRead(uploadFilePath))
                {
                    blob.UploadFromStream(fileStream);
                    // need to set MD5 as for page blob, it won't set MD5 automatically
                    blob.Properties.ContentMD5 = localMd5;
                    blob.SetProperties();
                }

                //--------------Copy blob operation--------------
                Test.Assert(agent.StartAzureStorageBlobCopy(srcContainerName, blobName, destContainerName, blobName), Utility.GenComparisonData("Start copy blob using blob name", true));

                // Get destination blob
                blob = CloudBlobUtil.GetBlob(destContainer, blobName, blobType);

                // Check MD5               
                blob.FetchAttributes();
                Test.Assert(localMd5 == blob.Properties.ContentMD5,
                    string.Format("blob content md5 should be {0}, and actualy it's {1}", localMd5, blob.Properties.ContentMD5));
            }
            finally
            {
                // cleanup
                srcContainer.DeleteIfExists();
                destContainer.DeleteIfExists();
                File.Delete(uploadFilePath);
            }
        }
    }
}
