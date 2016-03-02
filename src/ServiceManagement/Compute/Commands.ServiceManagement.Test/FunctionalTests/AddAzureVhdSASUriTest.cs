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
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class AddAzureVhdSASUriTest : AzureVhdTest
    {

        [TestInitialize]
        public void Initialize()
        {
            SetTestSettings();

            if (defaultAzureSubscription.Equals(null))
            {
                Assert.Inconclusive("No Subscription is selected!");
            }

            pass = false;
            testStartTime = DateTime.Now;
            storageAccountKey = vmPowershellCmdlets.GetAzureStorageAccountKey(defaultAzureSubscription.CurrentStorageAccountName);

            try
            {
                vmPowershellCmdlets.RunPSScript("Get-AzureStorageContainer -Name " + vhdContainerName);
            }
            catch
            {
                // Create a container.
                vmPowershellCmdlets.RunPSScript("New-AzureStorageContainer -Name " + vhdContainerName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory(Category.Upload), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\upload_VHD.csv", "upload_VHD#csv", DataAccessMethod.Sequential)]        
        public void UploadDiskSasUri()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);

            int i = 0;            
            while (i < 16)
            {
                if (!isReadWritePermission(i))
                {
                    i++; // Skip negative tests due to BUG: https://github.com/Azure/azure-sdk-tools/issues/2956
                }
                else
                {
                    string destinationSasUri2 = CreateSasUriWithPermission(vhdName, i);
                    try
                    {
                        Console.WriteLine("uploads {0} to {1}", vhdName, destinationSasUri2);
                        vmPowershellCmdlets.RemoveAzureSubscriptions();
                        var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, destinationSasUri2);
                        ReImportSubscription();
                        Console.WriteLine("Finished uploading: {0}", destinationSasUri2);

                        // Verify the upload.
                        AssertUploadContextAndContentMD5UsingSaveVhd(destinationSasUri2, vhdLocalPath, vhdUploadContext, md5hash);
                        Console.WriteLine("Test success with permission: {0}", i);
                        i++;
                    }
                    catch (Exception e)
                    {
                        continueIfNotReadWrite(e, ref i);
                        continue;
                    }
                }
            }

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0} {1},{2}", testName, vhdName, (testEndTime - testStartTime).TotalSeconds) });
            pass = true;
        }

        private string CreateSasUriWithPermission(string vhdName, int p)
        {
            // Set the destination
            string vhdBlobName = string.Format("{0}/{1}.vhd", vhdContainerName, Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string httpsBlobUrlRoot = string.Format("https:{0}", blobUrlRoot.Substring(blobUrlRoot.IndexOf('/')));
            string vhdDestUri = httpsBlobUrlRoot + vhdBlobName;

            var destinationBlob2 = new CloudPageBlob(new Uri(vhdDestUri), new StorageCredentials(storageAccountKey.StorageAccountName, storageAccountKey.Primary));
            var policy2 = new SharedAccessBlobPolicy()
            {
                Permissions = (SharedAccessBlobPermissions)p,
                SharedAccessExpiryTime = DateTime.UtcNow + TimeSpan.FromHours(1)
            };
            var destinationBlobToken2 = destinationBlob2.GetSharedAccessSignature(policy2);
            vhdDestUri += destinationBlobToken2;
            return vhdDestUri;
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory(Category.Upload), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskOverwriteSasUri()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);


            int i = 0;
            while (i < 16)
            {
                if (!isReadWriteDeletePermission(i))
                {
                    i++; // Skip negative tests due to BUG: https://github.com/Azure/azure-sdk-tools/issues/2956
                }
                else
                {
                    string destinationSasUri2 = CreateSasUriWithPermission(vhdName, i);
                    try
                    {
                        Console.WriteLine("uploads {0} to {1}", vhdName, destinationSasUri2);

                        vmPowershellCmdlets.RemoveAzureSubscriptions();
                        vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, destinationSasUri2);
                        var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, destinationSasUri2, true);
                        ReImportSubscription();
                        Console.WriteLine("Finished uploading: {0}", destinationSasUri2);

                        // Verify the upload.
                        AssertUploadContextAndContentMD5UsingSaveVhd(destinationSasUri2, vhdLocalPath, vhdUploadContext, md5hash);
                        Console.WriteLine("Test success with permission: {0}", i);
                        i++;
                    }
                    catch (Exception e)
                    {
                        continueIfNotReadWriteDelete(e, ref i);
                        continue;
                    }
                }
            }

            DateTime testEndTime = DateTime.Now;
            pass = true;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory(Category.Upload), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskOverwriteNonExistSasUri()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);


            int i = 0;
            while (i < 16)
            {
                if (!isReadWriteDeletePermission(i))
                {
                    i++; // Skip negative tests due to BUG: https://github.com/Azure/azure-sdk-tools/issues/2956
                }
                else
                {
                    string destinationSasUri2 = CreateSasUriWithPermission(vhdName, i);
                    try
                    {
                        Console.WriteLine("uploads {0} to {1}", vhdName, destinationSasUri2);
                        vmPowershellCmdlets.RemoveAzureSubscriptions();
                        var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, destinationSasUri2, true);
                        ReImportSubscription();
                        Console.WriteLine("Finished uploading: {0}", destinationSasUri2);

                        // Verify the upload.
                        AssertUploadContextAndContentMD5UsingSaveVhd(destinationSasUri2, vhdLocalPath, vhdUploadContext, md5hash);
                        Console.WriteLine("Test success with permission: {0}", i);
                        i++;
                    }
                    catch (Exception e)
                    {
                        continueIfNotReadWriteDelete(e, ref i);
                        continue;
                    }
                }
            }

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
            pass = true;
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory(Category.Upload), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskSecondWithoutOverwriteSasUri()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);

            for (int i = 0; i < 16; i++)            
            {
                if (isReadWritePermission(i)) // Otherwise, skip negative tests due to BUG: https://github.com/Azure/azure-sdk-tools/issues/2956
                {
                    string destinationSasUri2 = CreateSasUriWithPermission(vhdName, i);
                    try
                    {
                        Console.WriteLine("uploads {0} to {1}", vhdName, destinationSasUri2);
                        vmPowershellCmdlets.RemoveAzureSubscriptions();
                        var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, destinationSasUri2);

                        try
                        {
                            Console.WriteLine("uploads {0} to {1} second times", vhdName, destinationSasUri2);
                            vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, destinationSasUri2);
                            pass = false;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Failed as expected while uploading {0} second time without overwrite: {1}", vhdLocalPath.Name, e.InnerException.Message);

                        }

                        // Verify the upload.
                        ReImportSubscription();
                        AssertUploadContextAndContentMD5UsingSaveVhd(destinationSasUri2, vhdLocalPath, vhdUploadContext, md5hash);
                        Console.WriteLine("Test success with permission: {0}", i);
                    }
                    catch (Exception e)
                    {
                        continueIfNotReadWrite(e, ref i);
                        continue;
                    }
                }
            }

            pass = true;
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
        public void UploadDiskThreadNumberSasUri()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);

            int i = 0;            
            while (i < 16)
            {
                if (!isReadWritePermission(i))
                {
                    i++; // Skip negative tests due to BUG: https://github.com/Azure/azure-sdk-tools/issues/2956
                }
                else
                {
                    string destinationSasUri2 = CreateSasUriWithPermission(vhdName, i);
                    try
                    {
                        Console.WriteLine("uploads {0} to {1}", vhdName, destinationSasUri2);
                        vmPowershellCmdlets.RemoveAzureSubscriptions();
                        var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, destinationSasUri2, 16);
                        ReImportSubscription();
                        Console.WriteLine("uploading completed: {0}", vhdName);

                        // Verify the upload.
                        AssertUploadContextAndContentMD5UsingSaveVhd(destinationSasUri2, vhdLocalPath, vhdUploadContext, md5hash);
                        Console.WriteLine("Test success with permission: {0}", i);
                        i++;
                    }
                    catch (Exception e)
                    {
                        continueIfNotReadWrite(e, ref i);
                        continue;
                    }
                }
            }

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
            pass = true;
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory(Category.Upload), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\thread_VHD.csv", "thread_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskThreadNumberOverwriteSasUri()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);


            for (int i = 0; i < 16; i++)
            {
                if (!isReadWriteDeletePermission(i)) // Otherwise, skip negative tests due to BUG: https://github.com/Azure/azure-sdk-tools/issues/2956
                {
                    string destinationSasUri2 = CreateSasUriWithPermission(vhdName, i);
                    try
                    {
                        Console.WriteLine("uploads {0} to {1}", vhdName, destinationSasUri2);
                        vmPowershellCmdlets.RemoveAzureSubscriptions();
                        vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, destinationSasUri2);
                        Console.WriteLine("uploaded: {0}", vhdName);
                        var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(vhdLocalPath, destinationSasUri2, 16, true);
                        Console.WriteLine("uploading overwrite completed: {0}", vhdName);

                        // Verify the upload.
                        ReImportSubscription();
                        AssertUploadContextAndContentMD5UsingSaveVhd(destinationSasUri2, vhdLocalPath, vhdUploadContext, md5hash);
                        Console.WriteLine("Test success with permission: {0}", i);
                    }
                    catch (Exception e)
                    {
                        continueIfNotReadWriteDelete(e, ref i);
                        continue;
                    }
                }
            }

            pass = true;
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
        [Ignore] // BUG: https://github.com/Azure/azure-sdk-tools/issues/2956
        public void PatchFirstLevelDifferencingDiskSasUri()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the base vhd file from local machine
            var baseVhdName = Convert.ToString(TestContext.DataRow["baseImage"]);
            var baseVhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + baseVhdName);
            Assert.IsTrue(File.Exists(baseVhdLocalPath.FullName), "VHD file not exist={0}", baseVhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);
            string md5hashBase = Convert.ToString(TestContext.DataRow["MD5hashBase"]);

            // Choose the child vhd file from the local machine

            var childVhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var childVhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + childVhdName);
            Assert.IsTrue(File.Exists(childVhdLocalPath.FullName), "VHD file not exist={0}", childVhdLocalPath);

            for (int i = 0; i < 16; i++)
            {
                string destinationSasUri2 = CreateSasUriWithPermission(baseVhdName, i);
                string destinationSasUri3 = CreateSasUriWithPermission(childVhdName, i);
                try
                {
                    Console.WriteLine("uploads {0} to {1}", baseVhdName, destinationSasUri2);
                    vmPowershellCmdlets.RemoveAzureSubscriptions();
                    var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(baseVhdLocalPath, destinationSasUri2, true);
                    Console.WriteLine("uploading completed: {0}", baseVhdName);

                    // Verify the upload.
                    ReImportSubscription();
                    AssertUploadContextAndContentMD5UsingSaveVhd(destinationSasUri2, baseVhdLocalPath, vhdUploadContext, md5hashBase, false);


                    Console.WriteLine("uploads {0} to {1}", childVhdName, destinationSasUri3);
                    vmPowershellCmdlets.RemoveAzureSubscriptions();
                    var patchVhdUploadContext = vmPowershellCmdlets.AddAzureVhd(childVhdLocalPath, destinationSasUri3, destinationSasUri2);
                    Console.WriteLine("uploading completed: {0}", childVhdName);

                    // Verify the upload.
                    ReImportSubscription();
                    AssertUploadContextAndContentMD5UsingSaveVhd(destinationSasUri3, childVhdLocalPath, patchVhdUploadContext, md5hash);
                    Console.WriteLine("Test success with permission: {0}", i);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error as expected.  Permission: {0}", i);
                    Console.WriteLine("Error message: {0}", e.InnerException.Message);
                    continue;                    
                }
            }

            pass = true;
            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }

        /// <summary>
        /// This test is ignored until patching scenario is available for SAS Uri.
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\patch_VHD.csv", "patch_VHD#csv", DataAccessMethod.Sequential)]
        [Ignore]
        public void PatchSasUriNormalBaseShouldFail()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the base vhd file from local machine
            var baseVhdName = Convert.ToString(TestContext.DataRow["baseImage"]);
            var baseVhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + baseVhdName);
            Assert.IsTrue(File.Exists(baseVhdLocalPath.FullName), "VHD file not exist={0}", baseVhdLocalPath);

            // Set the destination
            string vhdBlobName = string.Format("{0}/{1}.vhd", vhdContainerName, Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(baseVhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);
            string md5hashBase = Convert.ToString(TestContext.DataRow["MD5hashBase"]);


            Console.WriteLine("uploads {0} to {1}", baseVhdName, vhdDestUri);
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(baseVhdLocalPath, vhdDestUri, true);
            Console.WriteLine("uploading the parent vhd completed: {0}", baseVhdName);

            // Choose the child vhd file from the local machine
            var childVhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var childVhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + childVhdName);
            Assert.IsTrue(File.Exists(childVhdLocalPath.FullName), "VHD file not exist={0}", childVhdLocalPath);

            for (int i = 0; i < 16; i++)
            {
                string destinationSasUriParent = CreateSasUriWithPermission(baseVhdName, i);
                string destinationSasUriChild = CreateSasUriWithPermission(childVhdName, i);
                try
                {
                    Console.WriteLine("uploads {0} to {1} with patching from {2}", childVhdName, destinationSasUriChild, vhdDestUri);
                    var patchVhdUploadContext = vmPowershellCmdlets.AddAzureVhd(childVhdLocalPath, destinationSasUriChild, vhdDestUri);
                    Console.WriteLine("uploading the child vhd completed: {0}", childVhdName);

                    // Verify the upload.
                    AssertUploadContextAndContentMD5UsingSaveVhd(destinationSasUriChild, childVhdLocalPath, patchVhdUploadContext, md5hash);
                    Console.WriteLine("Test success with permission: {0}", i);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error as expected.  Permission: {0}", i);
                    Console.WriteLine("Error message: {0}", e.InnerException.Message);
                    continue;
                }
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
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\patch_VHD.csv", "patch_VHD#csv", DataAccessMethod.Sequential)]
        public void PatchNormalSasUriBase()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the base vhd file from local machine
            var baseVhdName = Convert.ToString(TestContext.DataRow["baseImage"]);
            var baseVhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + baseVhdName);
            Assert.IsTrue(File.Exists(baseVhdLocalPath.FullName), "VHD file not exist={0}", baseVhdLocalPath);

            // Get the pre-calculated MD5 hash of the fixed vhd that was converted from the original vhd.
            string md5hash = Convert.ToString(TestContext.DataRow["MD5hash"]);
            string md5hashBase = Convert.ToString(TestContext.DataRow["MD5hashBase"]);

        
            // Choose the child vhd file from the local machine
            var childVhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var childVhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + childVhdName);
            Assert.IsTrue(File.Exists(childVhdLocalPath.FullName), "VHD file not exist={0}", childVhdLocalPath);

            int i = 0;
            while (i < 16)
            {
                if (!isReadWritePermission(i))
                {
                    i++; // Skip negative tests due to BUG: https://github.com/Azure/azure-sdk-tools/issues/2956
                }
                else
                {
                    string destinationSasUriParent = CreateSasUriWithPermission(baseVhdName, i); // the destination of the parent vhd is a Sas Uri

                    // Set the destination of child vhd
                    string vhdBlobName = string.Format("{0}/{1}.vhd", vhdContainerName, Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(childVhdName)));
                    string vhdDestUri = blobUrlRoot + vhdBlobName;

                    try
                    {
                        // Upload the parent vhd using Sas Uri
                        Console.WriteLine("uploads {0} to {1}", baseVhdName, destinationSasUriParent);
                        vmPowershellCmdlets.RemoveAzureSubscriptions();
                        var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(baseVhdLocalPath, destinationSasUriParent, true);
                        Console.WriteLine("uploading completed: {0}", baseVhdName);

                        // Verify the upload.
                        ReImportSubscription();
                        AssertUploadContextAndContentMD5UsingSaveVhd(destinationSasUriParent, baseVhdLocalPath, vhdUploadContext, md5hashBase, false);

                        Console.WriteLine("uploads {0} to {1} with patching from {2}", childVhdName, vhdDestUri, destinationSasUriParent);
                        var patchVhdUploadContext = vmPowershellCmdlets.AddAzureVhd(childVhdLocalPath, vhdDestUri, destinationSasUriParent);
                        Console.WriteLine("uploading the child vhd completed: {0}", childVhdName);

                        // Verify the upload.
                        AssertUploadContextAndContentMD5UsingSaveVhd(vhdDestUri, childVhdLocalPath, patchVhdUploadContext, md5hash);
                        Console.WriteLine("Test success with permission: {0}", i);
                        i++;
                    }
                    catch (Exception e)
                    {
                        continueIfNotReadWrite(e, ref i);
                        continue;
                    }
                }
            }

            pass = true;
            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            Console.WriteLine("Test {0}", pass ? "passed" : "failed");
            ReImportSubscription();
        }

        private bool checkPermission(int i, int j)
        {
            return (i & j) == j;
        }

        private bool isReadWritePermission(int i)
        {
            return checkPermission(i,(int)(SharedAccessBlobPermissions.Read ^ SharedAccessBlobPermissions.Write));
        }

        private bool isReadWriteDeletePermission(int i)
        {
            return checkPermission(i,
                (int)(SharedAccessBlobPermissions.Read ^ SharedAccessBlobPermissions.Write ^ SharedAccessBlobPermissions.Delete));
        }
        private void continueIfNotReadWrite(Exception e, ref int i)
        {
            if (e.ToString().Contains("already running"))
            {
                Console.WriteLine(e.ToString());
            }
            else if (!isReadWritePermission(i))
            {
                Console.WriteLine("Error as expected.  Permission: {0}", i);
                Console.WriteLine("Error message: {0}", e.InnerException.Message);
                i++;
            }
            else
            {
                Assert.Fail("Test failed Permission: {0} \n {1}", i, e.ToString());
            }
        }

        private void continueIfNotReadWriteDelete(Exception e, ref int i)
        {
            if (e.ToString().Contains("already running"))
            {
                Console.WriteLine(e.ToString());
            }
            else if (!isReadWriteDeletePermission(i))
            {
                Console.WriteLine("Error as expected.  Permission: {0}", i);
                Console.WriteLine("Error message: {0}", e.InnerException.Message);
                i++;
            }
            else
            {
                Assert.Fail("Test failed Permission: {0} \n {1}", i, e.ToString());
            }
        }
    }
}