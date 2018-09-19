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

namespace Microsoft.WindowsAzure.Management.ServiceManagement.Test.FunctionalTests
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.WindowsAzure.Management.Model;
    using Microsoft.WindowsAzure.Management.ServiceManagement.Model;
    using Microsoft.WindowsAzure.Management.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo;
    using Microsoft.WindowsAzure.Management.ServiceManagement.Test.Properties;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Sync.Download;

    [TestClass]
    public class AddAzureVhdTest
    {
        private ServiceManagementCmdletTestHelper vmPowershellCmdlets;
        private WindowsAzureSubscription defaultAzureSubscription;
        private StorageServiceKeyOperationContext storageAccountKey;
        //private string destination;
        //private string patchDestination;
        //private string destinationSasUri;
        //private string patchDestinationSasUri;

        private string perfFile;


        private string blobUrlRoot;
        private TestContext testContextInstance;
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            vmPowershellCmdlets = new ServiceManagementCmdletTestHelper();
            vmPowershellCmdlets.ImportAzurePublishSettingsFile();
            defaultAzureSubscription = vmPowershellCmdlets.SetDefaultAzureSubscription(Resource.DefaultSubscriptionName);
            Assert.AreEqual(Resource.DefaultSubscriptionName, defaultAzureSubscription.SubscriptionName);
            storageAccountKey = vmPowershellCmdlets.GetAzureStorageAccountKey(defaultAzureSubscription.CurrentStorageAccountName);
            Assert.AreEqual(defaultAzureSubscription.CurrentStorageAccountName, storageAccountKey.StorageAccountName);

            //destination = string.Format(@"http://{0}.blob.core.windows.net/vhdstore/{1}", defaultAzureSubscription.CurrentStorageAccountName, Utilities.GetUniqueShortName("PSTestAzureVhd"));
            //patchDestination = string.Format(@"http://{0}.blob.core.windows.net/vhdstore/{1}", defaultAzureSubscription.CurrentStorageAccountName, Utilities.GetUniqueShortName("PSTestAzureVhd"));

            //destinationSasUri = string.Format(@"http://{0}.blob.core.windows.net/vhdstore/{1}", defaultAzureSubscription.CurrentStorageAccountName, Utilities.GetUniqueShortName("PSTestAzureVhd"));
            //patchDestinationSasUri = string.Format(@"http://{0}.blob.core.windows.net/vhdstore/{1}", defaultAzureSubscription.CurrentStorageAccountName, Utilities.GetUniqueShortName("PSTestAzureVhd"));
            //var destinationBlob = new CloudPageBlob(new Uri(destinationSasUri), new StorageCredentials(storageAccountKey.StorageAccountName, storageAccountKey.Primary));
            //var patchDestinationBlob = new CloudPageBlob(new Uri(patchDestinationSasUri), new StorageCredentials(storageAccountKey.StorageAccountName, storageAccountKey.Primary));
            //var policy = new SharedAccessBlobPolicy()
            //{
            //    Permissions =
            //        SharedAccessBlobPermissions.Delete |
            //        SharedAccessBlobPermissions.Read |
            //        SharedAccessBlobPermissions.Write |
            //        SharedAccessBlobPermissions.List,
            //    SharedAccessExpiryTime = DateTime.UtcNow + TimeSpan.FromHours(1)
            //};
            //var destinationBlobToken = destinationBlob.GetSharedAccessSignature(policy);
            //var patchDestinationBlobToken = patchDestinationBlob.GetSharedAccessSignature(policy);
            //destinationSasUri += destinationBlobToken;
            //patchDestinationSasUri += patchDestinationBlobToken;


            blobUrlRoot = string.Format(@"http://{0}.blob.core.windows.net/", defaultAzureSubscription.CurrentStorageAccountName);

            perfFile = "perf.csv";
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\upload_VHD.csv", "upload_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDisk()
        {
            string testName = "UploadDisk";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}.", testName, testStartTime);
            


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(@".\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Set the destination
            string vhdBlobName = string.Format("vhdstore/{0}.vhd", Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, vhdLocalPath.FullName));
            Console.WriteLine("uploading completed: {0}", vhdName);

            // Verify the upload.
            AssertUploadContextAndContentMD5(vhdDestUri, vhdLocalPath, vhdUploadContext);

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);
            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0} {1},{2}", testName, vhdName, (testEndTime - testStartTime).TotalSeconds) });
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\upload_VHD.csv", "upload_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskSasUri()
        {
            string testName = "UploadDiskSasUri";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(@".\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            int i = 0;
            //while ( i = 0; i < 16; i++)
            while (i < 16)
            {
                string destinationSasUri2 = CreateSasUriWithPermission(vhdName, i);
                try
                {
                    Console.WriteLine("uploads {0} to {1}", vhdName, destinationSasUri2);
                    var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(destinationSasUri2, vhdLocalPath.FullName));
                    Console.WriteLine("Finished uploading: {0}", destinationSasUri2);

                    // Verify the upload.
                    AssertUploadContextAndContentMD5(destinationSasUri2, vhdLocalPath, vhdUploadContext);
                    Console.WriteLine("Test success with permission: {0}", i);
                    i++;
                }
                catch (Exception e)
                {
                    if (e.ToString().Contains("already running"))
                    {
                        Console.WriteLine(e.InnerException.Message);
                        continue;
                    }
                    if (i != 3 && i != 7 && i != 11 && i != 15)
                    {
                        Console.WriteLine("Error as expected.  Permission: {0}", i);
                        Console.WriteLine("Error message: {0}", e.InnerException.Message);
                        i++;
                        continue;
                    }
                    else
                    {
                        Assert.Fail("Test failed Permission: {0} \n {1}", i, e.ToString());
                    }
                }
            }

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0} {1},{2}", testName, vhdName, (testEndTime - testStartTime).TotalSeconds) });

        }

        private string CreateSasUriWithPermission(string vhdName, int p)
        {
            // Set the destination
            string vhdBlobName = string.Format("vhdstore/{0}.vhd", Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;


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
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskOverwrite()
        {
            string testName = "UploadDiskOverwrite";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(@".\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Set the destination
            string vhdBlobName = string.Format("vhdstore/{0}.vhd", Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, vhdLocalPath.FullName));
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, vhdLocalPath.FullName, true));
            Console.WriteLine("uploading completed: {0}", vhdName);

            // Verify the upload.
            AssertUploadContextAndContentMD5(vhdDestUri, vhdLocalPath, vhdUploadContext);

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime-testStartTime).TotalSeconds);
            
            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime-testStartTime).TotalSeconds) });

        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskResume()
        {
            string testName = "UploadDiskResume";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(@".\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Set the destination
            string vhdBlobName = string.Format("vhdstore/{0}.vhd", Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            string result = vmPowershellCmdlets.AddAzureVhdStop(new AddAzureVhdCmdletInfo(vhdDestUri, vhdLocalPath.FullName), 500);

            if (result.ToLowerInvariant() == "stopped")
            {
                Console.WriteLine("successfully stopped");

                var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, vhdLocalPath.FullName));
                Console.WriteLine("uploading completed: {0}", vhdName);

                // Verify the upload.
                AssertUploadContextAndContentMD5(vhdDestUri, vhdLocalPath, vhdUploadContext);
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
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskOverwriteSasUri()
        {
            string testName = "UploadDiskOverwriteSasUri";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(@".\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            int i = 0;
            while (i < 16)
            {
                string destinationSasUri2 = CreateSasUriWithPermission(vhdName, i);
                try
                {
                    Console.WriteLine("uploads {0} to {1}", vhdName, destinationSasUri2);
                    vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(destinationSasUri2, vhdLocalPath.FullName));
                    var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(destinationSasUri2, vhdLocalPath.FullName, true));
                    Console.WriteLine("Finished uploading: {0}", destinationSasUri2);

                    // Verify the upload.
                    AssertUploadContextAndContentMD5(destinationSasUri2, vhdLocalPath, vhdUploadContext);
                    Console.WriteLine("Test success with permission: {0}", i);
                    i++;
                }
                catch (Exception e)
                {
                    if (e.ToString().Contains("already running"))
                    {
                        Console.WriteLine(e.InnerException.Message);
                        continue;
                    }
                    if (i != 7 && i != 15)
                    {
                        Console.WriteLine("Error as expected.  Permission: {0}", i);
                        Console.WriteLine("Error message: {0}", e.InnerException.Message);
                        i++;
                        continue;
                    }
                    else
                    {
                        Assert.Fail("Test failed Permission: {0} \n {1}", i, e.ToString());
                    }
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
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskOverwriteNonExist()
        {
            string testName = "UploadDiskOverwriteNonExist";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(@".\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Set the destination
            string vhdBlobName = string.Format("vhdstore/{0}.vhd", Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            //vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, vhdLocalPath.FullName));
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, vhdLocalPath.FullName, true));
            Console.WriteLine("uploading completed: {0}", vhdName);

            // Verify the upload.
            AssertUploadContextAndContentMD5(vhdDestUri, vhdLocalPath, vhdUploadContext);

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });

        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskOverwriteNonExistSasUri()
        {
            string testName = "UploadDiskOverwriteNonExistSasUri";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(@".\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            int i = 0;
            while (i < 16)
            {
                string destinationSasUri2 = CreateSasUriWithPermission(vhdName, i);
                try
                {
                    Console.WriteLine("uploads {0} to {1}", vhdName, destinationSasUri2);
                    //vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(destinationSasUri2, vhdLocalPath.FullName));
                    var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(destinationSasUri2, vhdLocalPath.FullName, true));
                    Console.WriteLine("Finished uploading: {0}", destinationSasUri2);

                    // Verify the upload.
                    AssertUploadContextAndContentMD5(destinationSasUri2, vhdLocalPath, vhdUploadContext);
                    Console.WriteLine("Test success with permission: {0}", i);
                    i++;
                }
                catch (Exception e)
                {
                    if (e.ToString().Contains("already running"))
                    {
                        Console.WriteLine(e.InnerException.Message);
                        continue;
                    }
                    if (i != 7 && i != 15)
                    {
                        Console.WriteLine("Error as expected.  Permission: {0}", i);
                        Console.WriteLine("Error message: {0}", e.InnerException.Message);
                        i++;
                        continue;
                    }
                    else
                    {
                        Assert.Fail("Test failed Permission: {0} \n {1}", i, e.ToString());
                    }
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
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskSecondWithoutOverwrite()
        {
            string testName = "UploadDiskSecondWithoutOverwrite";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(@".\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Set the destination
            string vhdBlobName = string.Format("vhdstore/{0}.vhd", Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, vhdLocalPath.FullName));

            try
            {
                Console.WriteLine("uploads {0} to {1} second times", vhdName, vhdBlobName);
                vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, vhdLocalPath.FullName));
                Assert.Fail("Must have failed!  Test failed for: {0}", vhdLocalPath.FullName);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed as expected while uploading {0} second time without overwrite", vhdLocalPath.Name);
            }

            // Verify the upload.
            AssertUploadContextAndContentMD5(vhdDestUri, vhdLocalPath, vhdUploadContext);

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\overwrite_VHD.csv", "overwrite_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskSecondWithoutOverwriteSasUri()
        {
            string testName = "UploadDiskSecondWithoutOverwriteSasUri";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(@".\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            //int i = 0;
            for (int i = 0; i < 16; i++)
            //while (i < 16)
            {
                string destinationSasUri2 = CreateSasUriWithPermission(vhdName, i);
                try
                {
                    Console.WriteLine("uploads {0} to {1}", vhdName, destinationSasUri2);
                    var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(destinationSasUri2, vhdLocalPath.FullName));

                    try
                    {
                        Console.WriteLine("uploads {0} to {1} second times", vhdName, destinationSasUri2);
                        vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(destinationSasUri2, vhdLocalPath.FullName));
                        Assert.Fail("Must have failed!  Test failed for: {0}", vhdLocalPath.FullName);                        
                    }
                    catch (Exception e)
                    {                        
                        Console.WriteLine("Failed as expected while uploading {0} second time without overwrite: {1}", vhdLocalPath.Name, e.InnerException.Message);

                    }

                    // Verify the upload.
                    AssertUploadContextAndContentMD5(destinationSasUri2, vhdLocalPath, vhdUploadContext);
                    Console.WriteLine("Test success with permission: {0}", i);
                }
                catch (Exception e)
                {
                    if (i != 3 && i != 7 && i != 11 && i != 15)
                    {
                        Console.WriteLine("Error as expected.  Permission: {0}", i);
                        Console.WriteLine("Error message: {0}", e.InnerException.Message);
                        continue;
                    }
                    else
                    {
                        Assert.Fail("Test failed.  Permission: {0}", i);
                    }
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
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\thread_VHD.csv", "thread_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskThreadNumber()
        {
            string testName = "UploadDiskThreadNumber";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(@".\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Set the destination
            string vhdBlobName = string.Format("vhdstore/{0}.vhd", Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, vhdLocalPath.FullName, 16, false));
            Console.WriteLine("uploading completed: {0}", vhdName);

            // Verify the upload.
            AssertUploadContextAndContentMD5(vhdDestUri, vhdLocalPath, vhdUploadContext);

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\thread_VHD.csv", "thread_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskThreadNumberSasUri()
        {
            string testName = "UploadDiskThreadNumberSasUri";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(@".\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            int i = 0;
            //for (int i = 0; i < 16; i++)
            while (i < 16)
            {
                string destinationSasUri2 = CreateSasUriWithPermission(vhdName, i);
                try
                {
                    Console.WriteLine("uploads {0} to {1}", vhdName, destinationSasUri2);
                    var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(destinationSasUri2, vhdLocalPath.FullName, 16, false));
                    Console.WriteLine("uploading completed: {0}", vhdName);

                    // Verify the upload.
                    AssertUploadContextAndContentMD5(destinationSasUri2, vhdLocalPath, vhdUploadContext);
                    Console.WriteLine("Test success with permission: {0}", i);
                    i++;
                }
                catch (Exception e)
                {
                    if (e.ToString().Contains("already running"))
                    {
                        Console.WriteLine(e.InnerException.Message);
                        continue;
                    }
                    if (i != 3 && i != 7 && i != 11 && i != 15)
                    {
                        Console.WriteLine("Error as expected.  Permission: {0}", i);
                        Console.WriteLine("Error message: {0}", e.InnerException.Message);
                        i++;
                        continue;
                    }
                    else
                    {
                        Assert.Fail("Test failed Permission: {0} \n {1}", i, e.ToString());
                    }
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
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\thread_VHD.csv", "thread_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskThreadNumberOverwrite()
        {
            string testName = "UploadDiskThreadNumber";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(@".\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Set the destination
            string vhdBlobName = string.Format("vhdstore/{0}.vhd", Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, vhdLocalPath.FullName));
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, vhdLocalPath.FullName, 16, true));
            Console.WriteLine("uploading completed: {0}", vhdName);

            // Verify the upload.
            AssertUploadContextAndContentMD5(vhdDestUri, vhdLocalPath, vhdUploadContext);

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\thread_VHD.csv", "thread_VHD#csv", DataAccessMethod.Sequential)]
        public void UploadDiskThreadNumberOverwriteSasUri()
        {
            string testName = "UploadDiskThreadNumberSasUri";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(@".\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            for (int i = 0; i < 16; i++)
            {
                string destinationSasUri2 = CreateSasUriWithPermission(vhdName, i);
                try
                {
                    Console.WriteLine("uploads {0} to {1}", vhdName, destinationSasUri2);
                    vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(destinationSasUri2, vhdLocalPath.FullName));
                    Console.WriteLine("uploaded: {0}", vhdName); 
                    var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(destinationSasUri2, vhdLocalPath.FullName, 16, true));
                    Console.WriteLine("uploading overwrite completed: {0}", vhdName);

                    // Verify the upload.
                    AssertUploadContextAndContentMD5(destinationSasUri2, vhdLocalPath, vhdUploadContext);
                    Console.WriteLine("Test success with permission: {0}", i);
                }
                catch (Exception e)
                {
                    if (i != 7 && i != 15)
                    {
                        Console.WriteLine("Error as expected.  Permission: {0}", i);
                        Console.WriteLine("Error message: {0}", e.InnerException.Message);
                        continue;
                    }
                    else
                    {
                        Assert.Fail("Test failed Permission: {0} \n {1}", i, e.ToString());
                    }
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
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\patch_VHD.csv", "patch_VHD#csv", DataAccessMethod.Sequential)]
        public void PatchFirstLevelDifferencingDisk()
        {
            string testName = "PatchFirstLevelDifferencingDisk";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["baseImage"]);
            var vhdLocalPath = new FileInfo(@".\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Set the destination
            string vhdBlobName = string.Format("vhdstore/{0}.vhd", Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            // Start uploading...
            Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, vhdLocalPath.FullName, true));
            Console.WriteLine("uploading completed: {0}", vhdName);

            // Verify the upload.
            AssertUploadContextAndContentMD5(vhdDestUri, vhdLocalPath, vhdUploadContext, false);


            // Choose the vhd file from local machine
            var childVhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var childVhdLocalPath = new FileInfo(@".\" + childVhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", childVhdLocalPath);

            // Set the destination
            string childVhdBlobName = string.Format("vhdstore/{0}.vhd", Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(childVhdName)));
            string childVhdDestUri = blobUrlRoot + childVhdBlobName;

            // Start uploading the child vhd...
            Console.WriteLine("uploads {0} to {1}", childVhdName, childVhdBlobName);
            var patchVhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(childVhdDestUri, childVhdLocalPath.FullName, vhdDestUri));
            Console.WriteLine("uploading completed: {0}", childVhdName);

            // Verify the upload
            AssertUploadContextAndContentMD5(childVhdDestUri, childVhdLocalPath, patchVhdUploadContext);

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\patch_VHD.csv", "patch_VHD#csv", DataAccessMethod.Sequential)]
        public void PatchFirstLevelDifferencingDiskSasUri()
        {
            string testName = "PatchFirstLevelDifferencingDiskSasUri";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the base vhd file from local machine
            var baseVhdName = Convert.ToString(TestContext.DataRow["baseImage"]);
            var baseVhdLocalPath = new FileInfo(@".\" + baseVhdName);
            Assert.IsTrue(File.Exists(baseVhdLocalPath.FullName), "VHD file not exist={0}", baseVhdLocalPath);

            // Choose the child vhd file from the local machine

            var childVhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var childVhdLocalPath = new FileInfo(@".\" + childVhdName);
            Assert.IsTrue(File.Exists(childVhdLocalPath.FullName), "VHD file not exist={0}", childVhdLocalPath);

            for (int i = 0; i < 16; i++)
            {
                string destinationSasUri2 = CreateSasUriWithPermission(baseVhdName, i);
                string destinationSasUri3 = CreateSasUriWithPermission(childVhdName, i);
                try
                {
                    Console.WriteLine("uploads {0} to {1}", baseVhdName, destinationSasUri2);
                    var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(destinationSasUri2, baseVhdLocalPath.FullName, true));
                    Console.WriteLine("uploading completed: {0}", baseVhdName);

                    // Verify the upload.
                    AssertUploadContextAndContentMD5(destinationSasUri2, baseVhdLocalPath, vhdUploadContext, false);


                    Console.WriteLine("uploads {0} to {1}", childVhdName, destinationSasUri3);
                    var patchVhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(destinationSasUri3, childVhdLocalPath.FullName, destinationSasUri2));
                    Console.WriteLine("uploading completed: {0}", childVhdName);

                    // Verify the upload.
                    AssertUploadContextAndContentMD5(destinationSasUri3, childVhdLocalPath, patchVhdUploadContext);
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
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\patch_VHD.csv", "patch_VHD#csv", DataAccessMethod.Sequential)]
        public void PatchSasUriNormalBaseShouldFail()
        {
            string testName = "PatchSasUriNormalBase";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the base vhd file from local machine
            var baseVhdName = Convert.ToString(TestContext.DataRow["baseImage"]);
            var baseVhdLocalPath = new FileInfo(@".\" + baseVhdName);
            Assert.IsTrue(File.Exists(baseVhdLocalPath.FullName), "VHD file not exist={0}", baseVhdLocalPath);

            // Set the destination
            string vhdBlobName = string.Format("vhdstore/{0}.vhd", Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(baseVhdName)));
            string vhdDestUri = blobUrlRoot + vhdBlobName;

            Console.WriteLine("uploads {0} to {1}", baseVhdName, vhdDestUri);
            var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, baseVhdLocalPath.FullName, true));
            Console.WriteLine("uploading the parent vhd completed: {0}", baseVhdName);

            // Choose the child vhd file from the local machine
            var childVhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var childVhdLocalPath = new FileInfo(@".\" + childVhdName);
            Assert.IsTrue(File.Exists(childVhdLocalPath.FullName), "VHD file not exist={0}", childVhdLocalPath);

            for (int i = 0; i < 16; i++)
            {
                string destinationSasUriParent = CreateSasUriWithPermission(baseVhdName, i);
                string destinationSasUriChild = CreateSasUriWithPermission(childVhdName, i);
                try
                {
                    Console.WriteLine("uploads {0} to {1} with patching from {2}", childVhdName, destinationSasUriChild, vhdDestUri);
                    var patchVhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(destinationSasUriChild, childVhdLocalPath.FullName, vhdDestUri));
                    Console.WriteLine("uploading the child vhd completed: {0}", childVhdName);

                    // Verify the upload.
                    AssertUploadContextAndContentMD5(destinationSasUriChild, childVhdLocalPath, patchVhdUploadContext);
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
        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\patch_VHD.csv", "patch_VHD#csv", DataAccessMethod.Sequential)]
        public void PatchNormalSasUriBase()
        {
            string testName = "PatchSasUriNormalBase";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);

            // Choose the base vhd file from local machine
            var baseVhdName = Convert.ToString(TestContext.DataRow["baseImage"]);
            var baseVhdLocalPath = new FileInfo(@".\" + baseVhdName);
            Assert.IsTrue(File.Exists(baseVhdLocalPath.FullName), "VHD file not exist={0}", baseVhdLocalPath);
        
            // Choose the child vhd file from the local machine
            var childVhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var childVhdLocalPath = new FileInfo(@".\" + childVhdName);
            Assert.IsTrue(File.Exists(childVhdLocalPath.FullName), "VHD file not exist={0}", childVhdLocalPath);

            int i = 0;
            while (i < 16)
            {
                string destinationSasUriParent = CreateSasUriWithPermission(baseVhdName, i); // the destination of the parent vhd is a Sas Uri

                // Set the destination of child vhd
                string vhdBlobName = string.Format("vhdstore/{0}.vhd", Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(childVhdName)));
                string vhdDestUri = blobUrlRoot + vhdBlobName;

                try
                {
                    // Upload the parent vhd using Sas Uri
                    Console.WriteLine("uploads {0} to {1}", baseVhdName, destinationSasUriParent);
                    var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(destinationSasUriParent, baseVhdLocalPath.FullName, true));
                    Console.WriteLine("uploading completed: {0}", baseVhdName);

                    // Verify the upload.
                    AssertUploadContextAndContentMD5(destinationSasUriParent, baseVhdLocalPath, vhdUploadContext, false);

                    Console.WriteLine("uploads {0} to {1} with patching from {2}", childVhdName, vhdDestUri, destinationSasUriParent);
                    var patchVhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, childVhdLocalPath.FullName, destinationSasUriParent));
                    Console.WriteLine("uploading the child vhd completed: {0}", childVhdName);

                    // Verify the upload.
                    AssertUploadContextAndContentMD5(vhdDestUri, childVhdLocalPath, patchVhdUploadContext);
                    Console.WriteLine("Test success with permission: {0}", i);
                    i++;
                }
                catch (Exception e)
                {
                    if (i != 3 && i != 7 && i != 11 && i != 15)
                    {
                        Console.WriteLine("Error as expected.  Permission: {0}", i);
                        Console.WriteLine("Error message: {0}", e.InnerException.Message);
                        i++;
                        continue;
                    }
                    else
                    {
                        Assert.Fail("Test failed Permission: {0} \n {1}", i, e.ToString());
                    }                   
                }
            }

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }


        [TestMethod(), TestCategory("Functional"), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Add-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", ".\\thread_VHD.csv", "thread_VHD#csv", DataAccessMethod.Sequential)]
        public void WrongProtocolShouldFail()
        {
            string testName = "WrongProtocolShouldFail";
            DateTime testStartTime = DateTime.Now;
            Console.WriteLine("{0} test starts at {1}", testName, testStartTime);


            // Choose the vhd file from local machine
            var vhdName = Convert.ToString(TestContext.DataRow["vhdName"]);
            var vhdLocalPath = new FileInfo(@".\" + vhdName);
            Assert.IsTrue(File.Exists(vhdLocalPath.FullName), "VHD file not exist={0}", vhdLocalPath);

            // Set the destination
            string vhdBlobName = string.Format("vhdstore/{0}.vhd", Utilities.GetUniqueShortName(Path.GetFileNameWithoutExtension(vhdName)));
            string badUrlRoot = string.Format(@"badprotocolhttp://{0}.blob.core.windows.net/", defaultAzureSubscription.CurrentStorageAccountName);
            string vhdDestUri = badUrlRoot + vhdBlobName;

            DateTime startTime = DateTime.Now;
            try
            {
                // Start uploading...
                Console.WriteLine("uploads {0} to {1}", vhdName, vhdBlobName);
                var vhdUploadContext = vmPowershellCmdlets.AddAzureVhd(new AddAzureVhdCmdletInfo(vhdDestUri, vhdLocalPath.FullName));
                Console.WriteLine("uploading completed: {0}", vhdName);
                Assert.Fail("Should have failed. {0} test failed.", testName);

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


        private void AssertUploadContextAndContentMD5(string destination, FileInfo localFile, VhdUploadContext vhdUploadContext, bool deleteBlob = true)
        {
            AssertUploadContext(destination, localFile, vhdUploadContext);
            BlobUri blobPath;
            Assert.IsTrue(BlobUri.TryParseUri(new Uri(destination), out blobPath));
            AssertContentMD5(blobPath.BlobPath, deleteBlob);
        }

        private void AssertContentMD5(string destination, bool deleteBlob)
        {
            string downloadedFile = DownloadToFile(destination);

            var calculateMd5Hash = CalculateContentMd5(File.OpenRead(downloadedFile));

            BlobUri blobUri2;
            Assert.IsTrue(BlobUri.TryParseUri(new Uri(destination), out blobUri2));
            var blobHandle = new BlobHandle(blobUri2, storageAccountKey.Primary);

            Assert.AreEqual(calculateMd5Hash, blobHandle.Blob.Properties.ContentMD5);

            if (deleteBlob)
            {
                blobHandle.Blob.Delete();
            }
        }

        private void AssertUploadContext(string destination, FileInfo localFile, VhdUploadContext vhdUploadContext)
        {
            Assert.IsNotNull(vhdUploadContext);
            Assert.AreEqual(new Uri(destination), vhdUploadContext.DestinationUri);
            Assert.AreEqual(vhdUploadContext.LocalFilePath.FullName, localFile.FullName);
        }

        private string DownloadToFile(string destination)
        {
            BlobUri blobUri;
            BlobUri.TryParseUri(new Uri(destination), out blobUri);

            var localFilePath = Path.Combine(Path.GetTempPath(), Path.GetTempFileName());
            var downloader = new Downloader(blobUri, storageAccountKey.Primary, localFilePath);
            downloader.Download();
            return localFilePath;
        }

        private static string CalculateContentMd5(Stream stream)
        {
            using (var md5 = MD5.Create())
            {
                using (var bs = new BufferedStream(stream))
                {
                    var md5Hash = md5.ComputeHash(bs);
                    return Convert.ToBase64String(md5Hash);
                }
            }
        }

    }
}