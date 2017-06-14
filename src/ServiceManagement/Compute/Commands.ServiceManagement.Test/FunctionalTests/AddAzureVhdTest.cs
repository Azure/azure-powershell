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
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class AddAzureVhdTest : AzureVhdTest
    {

        [TestInitialize]
        public void Initialize()
        {
            if (defaultAzureSubscription.Equals(null))
            {
                Assert.Inconclusive("No Subscription is selected!");
            }

            pass = true;
            testStartTime = DateTime.Now;
            storageAccountKey = vmPowershellCmdlets.GetAzureStorageAccountKey(defaultAzureSubscription.CurrentStorageAccountName);
        }

        /// <summary>
        /// UploadDisk:
        /// </summary>
        [TestMethod(), TestCategory(Category.Upload), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\upload_VHD.csv", "upload_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDisk()
        {

            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the vhd file from local machine
            string vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            FileInfo vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);


            // Set the destination
            string vhdBlobName = string.Format("{0}/{1}.vhd", vhdContainerName, Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, vhdDestUri);
            Console.WriteLine("uploading completed: {0}", vhdName);

            // Verify the upload.
            AssertUploadContextAndContentMD5UsingSaveVhd(vhdDestUri, vhdLocalPath, vhdUploadContext, md5hash);

            pass = true;
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Upload), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskOverwrite()
        {
            testName = MethodBase.GetCurrentMethod().Name;
            StartTest(testName, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);


            // Set the destination
            string vhdBlobName = string.Format("{0}/{1}.vhd", vhdContainerName, Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, vhdDestUri);
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, vhdDestUri, true);
            Console.WriteLine("uploading completed: {0}", vhdName);

            // Verify the upload.
            AssertUploadContextAndContentMD5UsingSaveVhd(vhdDestUri, vhdLocalPath, vhdUploadContext, md5hash);

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime-testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime-testStartTime).TotalSeconds) });

        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Upload), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        [Ignore]
        public void UploadDiskResume()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);


            // Set the destination
            string vhdBlobName = string.Format("{0}/{1}.vhd", vhdContainerName, Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            string result = vmPowershellCmdlets.AddAzureVhdStop(vhdLocalPath, vhdDestUri, 500);

            if (result.ToLowerInvariant() == "stopped")
            {
                Console.WriteLine("successfully stopped");

                var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, vhdDestUri);
                Console.WriteLine("uploading completed: {0}", vhdName);

                // Verify the upload.
                AssertUploadContextAndContentMD5UsingSaveVhd(vhdDestUri, vhdLocalPath, vhdUploadContext, md5hash);
            }
            else
            {
                Console.WriteLine("didn't stop!");
            }

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Upload), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskOverwriteNonExist()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);


            // Set the destination
            string vhdBlobName = string.Format("{0}/{1}.vhd", vhdContainerName, Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            //vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, vhdLocalPath.FullName));
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, vhdDestUri, true);
            Console.WriteLine("uploading completed: {0}", vhdName);

            // Verify the upload.
            AssertUploadContextAndContentMD5UsingSaveVhd(vhdDestUri, vhdLocalPath, vhdUploadContext, md5hash);

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });

        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Upload), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskSecondWithoutOverwrite()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);


            // Set the destination
            string vhdBlobName = string.Format("{0}/{1}.vhd", vhdContainerName, Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, vhdDestUri);

            try
            {
                Console.WriteLine("uploads {0} to {1} second times", vhdName, vhdBlobName);
                vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, vhdDestUri);
                pass = false;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed as expected while uploading {0} second time without overwrite", vhdLocalPath.Name);
            }

            // Verify the upload.
            AssertUploadContextAndContentMD5UsingSaveVhd(vhdDestUri, vhdLocalPath, vhdUploadContext, md5hash);

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Upload), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\thread_VHD.csv", "thread_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskThreadNumber()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);


            // Set the destination
            string vhdBlobName = string.Format("{0}/{1}.vhd", vhdContainerName, Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, vhdDestUri, 16);
            Console.WriteLine("uploading completed: {0}", vhdName);

            // Verify the upload.
            AssertUploadContextAndContentMD5UsingSaveVhd(vhdDestUri, vhdLocalPath, vhdUploadContext, md5hash);

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Upload), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\thread_VHD.csv", "thread_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskThreadNumberOverwrite()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);


            // Set the destination
            string vhdBlobName = string.Format("{0}/{1}.vhd", vhdContainerName, Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, vhdDestUri);
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, vhdDestUri, 16, true);
            Console.WriteLine("uploading completed: {0}", vhdName);

            // Verify the upload.
            AssertUploadContextAndContentMD5UsingSaveVhd(vhdDestUri, vhdLocalPath, vhdUploadContext, md5hash);

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }

        /// <summary>
        ///
        /// </summary>
        [TestMethod(), TestCategory(Category.Upload), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\patch_VHD.csv", "patch_VHD#csv", DataAccessMethod.Sequential)]
        public void PatchFirstLevelDifferencingDisk()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["baseImage"]);
            var vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);
            string md5hashBase = Convert.ToString(TestContext.DataRow["MD5hashBase"]);


            // Set the destination
            string vhdBlobName = string.Format("{0}/{1}.vhd", vhdContainerName, Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, vhdDestUri,true);
            Console.WriteLine("uploading completed: {0}", vhdName);

            // Verify the upload.
            AssertUploadContextAndContentMD5UsingSaveVhd(vhdDestUri, vhdLocalPath, vhdUploadContext, md5hashBase, false);


            // Choose the vhd file from local machine
            var childVhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var childVhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + childVhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", childVhdLocalPath);

            // Set the destination
            string childVhdBlobName = string.Format("{0}/{1}.vhd", vhdContainerName, Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(childVhdName)));
            string childVhdDestUri = blobUrlRoot + childVhdBlobName;

            // Start uploading the child vhd...
            Console.WriteLine("uploads {0} to {1}", childVhdName, childVhdBlobName);
            var patchVhdUploadContext = vmPowershellCmdlets.AddAzureVhd(childVhdLocalPath, childVhdDestUri, vhdDestUri);
            Console.WriteLine("uploading completed: {0}", childVhdName);

            // Verify the upload
            AssertUploadContextAndContentMD5UsingSaveVhd(childVhdDestUri, childVhdLocalPath, patchVhdUploadContext, md5hash);

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }

        [TestMethod(), TestCategory(Category.Upload), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\thread_VHD.csv", "thread_VHD#csv", DataAccessMethod.Sequential)]
        public void WrongProtocolShouldFail()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Set the destination
            string vhdBlobName = string.Format("{0}/{1}.vhd", vhdContainerName, Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string badUrlRoot = string.Format(@"badprotocolhttp://{0}.blob.core.windows.net/", defaultAzureSubscription.CurrentStorageAccountName);
            string vhdDestUri = badUrlRoot + vhdBlobName;

            DateTime startTime = DateTime.Now;
            try
            {
                // Start uploading...
                Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
                var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, vhdDestUri);
                Console.WriteLine("uploading completed: {0}", vhdName);
                pass = false;

            }
            catch (Exception e)
            {
                TimeSpan duration = DateTime.Now - startTime;
                Console.WriteLine("error message: {0}", e);
                Console.WriteLine("{0} test passed after {1} seconds", testName, duration.Seconds);

                DateTime testEndTime = DateTime.Now;
                Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
                Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

                System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
            }
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            Console.WriteLine("Test {0}", pass ? "passed" : "failed");
        }
    }
}
