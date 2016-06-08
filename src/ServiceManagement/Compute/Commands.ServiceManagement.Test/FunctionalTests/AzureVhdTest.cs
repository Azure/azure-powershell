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

using System;
using System.IO;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Sync.Download;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class AzureVhdTest : ServiceManagementTest
    {
        protected bool deleteLocalFileIfFailed = true;
        protected bool deleteLocalFileIfPassed = true;
        protected string perfFile = "perf.csv";

        protected void SaveVhdAndAssertContent(BlobHandle destination, FileInfo localFile, int? numThread, string storageKey, bool overwrite, bool deleteBlob, bool deleteLocal)
        {
            try
            {
                Console.WriteLine("Downloading a VHD from {0} to {1}...", destination.Blob.Uri.ToString(), localFile.FullName);
                DateTime startTime = DateTime.Now;
                VhdDownloadContext result = vmPowershellCmdlets.SaveAzureVhd(destination.Blob.Uri, localFile, numThread, storageKey, overwrite);
                Console.WriteLine("Downloading completed in {0} seconds.", (DateTime.Now - startTime).TotalSeconds);

                string calculateMd5Hash = CalculateContentMd5(File.OpenRead(result.LocalFilePath.FullName));

                Assert.IsTrue(VerifyMD5hash(destination, calculateMd5Hash));

                if (deleteBlob)
                {
                    destination.Blob.Delete();
                }

                if (deleteLocalFileIfPassed && deleteLocal)
                {
                    File.Delete(localFile.FullName);
                }
            }
            catch (Exception e)
            {
                if (deleteLocalFileIfFailed && deleteLocal)
                {
                    File.Delete(localFile.FullName);
                }
                Assert.Fail(e.InnerException.ToString());
            }
        }

        protected void SaveVhdAndAssertContent(BlobHandle destination, FileInfo localFile, bool deleteBlob, bool deleteLocal)
        {
            SaveVhdAndAssertContent(destination, localFile, null, null, false, deleteBlob, deleteLocal);
        }

        protected void SaveVhdAndAssertContent(BlobHandle destination, FileInfo localFile, int? numThread, bool deleteBlob, bool deleteLocal)
        {
            SaveVhdAndAssertContent(destination, localFile, numThread, null, false, deleteBlob, deleteLocal);
        }

        protected void SaveVhdAndAssertContent(BlobHandle destination, FileInfo localFile, string storageKey, bool deleteBlob, bool deleteLocal)
        {
            SaveVhdAndAssertContent(destination, localFile, null, storageKey, false, deleteBlob, deleteLocal);
        }

        protected void SaveVhdAndAssertContent(BlobHandle destination, FileInfo localFile, bool overwrite, bool deleteBlob, bool deleteLocal)
        {
            SaveVhdAndAssertContent(destination, localFile, null, null, overwrite, deleteBlob, deleteLocal);
        }
       

        private static string CalculateContentMd5(Stream stream)
        {
            using (var md5 = MD5.Create())
            {
                using (var bufferdStream = new BufferedStream(stream))
                {
                    var md5Hash = md5.ComputeHash(bufferdStream);
                    return Convert.ToBase64String(md5Hash);
                }
            }
        }

        protected bool VerifyMD5hash(BlobHandle blobHandle, string md5hash)
        {
            string blobMd5 = blobHandle.Blob.Properties.ContentMD5;
            Console.WriteLine("MD5 hash of the local file: {0}", md5hash);
            if (string.IsNullOrEmpty(blobMd5))
            {
                Console.WriteLine("The blob does not have MD5 value!!!");
                return false;
            }
            else
            {
                Console.WriteLine("MD5 hash of blob, {0}, is {1}.", blobHandle.Blob.Uri.ToString(), blobMd5);
                return String.Equals(blobMd5, md5hash);
            }
        }

        protected void AssertUploadContextAndContentMD5UsingSaveVhd
            (string destination, FileInfo localFile, VhdUploadContext vhdUploadContext, string md5hash, bool deleteBlob = true, bool deleteLocal = true)
        {
            AssertUploadContext(destination, localFile, vhdUploadContext);

            FileInfo downloadFile = new FileInfo(localFile.FullName + "_download.vhd");

            BlobHandle blobHandle = getBlobHandle(destination);

            Assert.IsTrue(VerifyMD5hash(blobHandle, md5hash));
            SaveVhdAndAssertContent(blobHandle, downloadFile, true, deleteBlob, deleteLocal);
        }

        protected BlobHandle getBlobHandle(string blob)
        {
            BlobUri blobPath;
            Assert.IsTrue(BlobUri.TryParseUri(new Uri(blob), out blobPath));
            return new BlobHandle(blobPath, storageAccountKey.Primary);
        }

        protected void AssertUploadContext(string destination, FileInfo localFile, VhdUploadContext vhdUploadContext)
        {
            Assert.IsNotNull(vhdUploadContext);
            Assert.AreEqual(new Uri(destination), vhdUploadContext.DestinationUri);
            Assert.IsTrue(string.Compare(vhdUploadContext.LocalFilePath.FullName, localFile.FullName, StringComparison.InvariantCultureIgnoreCase) == 0);
        }
    }
}