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
using Microsoft.WindowsAzure.Commands.Sync.Download;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class SaveAzureVhdTest : AzureVhdTest
    {
          
        private BlobHandle blobHandle;
        static bool deleteUploadedBlob = false;
        private const string vhdName = "temp.vhd";
        private static string vhdBlobLocation;

        [ClassInitialize]        
        public static void ClassInit(TestContext context)
        {
            //SetTestSettings();

            if (defaultAzureSubscription.Equals(null))
            {
                Assert.Inconclusive("No Subscription is selected!");
            }

            vhdBlobLocation = string.Format("{0}{1}/{2}", blobUrlRoot, vhdContainerName, vhdName);

            if (string.IsNullOrEmpty(localFile))
            {
                try
                {
                    //CredentialHelper.CopyTestData(testDataContainer, osVhdName, vhdContainerName, vhdName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    Assert.Inconclusive("No vhd exists for Save-AzureVhd tests!");
                }
            }
            else
            {
                try
                {
                    vmPowershellCmdlets.AddAzureVhd(new FileInfo(localFile), vhdBlobLocation);
                }
                catch (Exception e)
                {
                    if (e.ToString().Contains("already exists"))
                    {
                        // Use the already uploaded vhd.
                        Console.WriteLine("Using already uploaded blob..");
                    }
                    else
                    {
                        Assert.Inconclusive("No vhd exists for Save-AzureVhd tests!");
                    }
                }
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            pass = true;
            testStartTime = DateTime.Now;
            storageAccountKey = vmPowershellCmdlets.GetAzureStorageAccountKey(defaultAzureSubscription.CurrentStorageAccountName);  

            // Set the source blob
            blobHandle = Utilities.GetBlobHandle(vhdBlobLocation, storageAccountKey.Primary);            
        }
                
     
        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Save-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\download_VHD.csv", "download_VHD#csv", DataAccessMethod.Sequential)]
        public void SaveAzureVhdThreadNumberTest()
        {
            testName = MethodBase.GetCurrentMethod().Name;
            StartTest(testName, testStartTime);

            // Choose the vhd path in your local machine            
            string vhdName = Convert.ToString(TestContext.DataRow["vhdLocalPath"]) + Utilities.GetUniqueShortName();
            FileInfo vhdLocalPath = new FileInfo(vhdName);

            DateTime start = DateTime.Now;
            // Download with 2 threads and verify it.
            SaveVhdAndAssertContent(blobHandle, vhdLocalPath, 2, false, true);
            TimeSpan duration = DateTime.Now - start;

            // Choose the vhd path in your local machine            
            string vhdName2 = Convert.ToString(TestContext.DataRow["vhdLocalPath"]) + Utilities.GetUniqueShortName();
            FileInfo vhdLocalPath2 = new FileInfo(vhdName2);

            // Download with 16 threads and verify it.
            start = DateTime.Now;
            SaveVhdAndAssertContent(blobHandle, vhdLocalPath2, 16, false, true);
            //Assert.IsTrue(DateTime.Now - start < duration, "16 threads took longer!");
            if (DateTime.Now - start > duration)
            {
                Console.WriteLine("16 threads took longer than 2 threads!");
            }


            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }



        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Save-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\download_VHD.csv", "download_VHD#csv", DataAccessMethod.Sequential)]
        public void SaveAzureVhdStorageKeyTest()
        {

            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);
 
            // Choose the vhd path in your local machine            
            string vhdName = Convert.ToString(TestContext.DataRow["vhdLocalPath"]) + Utilities.GetUniqueShortName();
            FileInfo vhdLocalPath = new FileInfo(vhdName);

            // Download with a secondary storage key and verify it.
            SaveVhdAndAssertContent(blobHandle, vhdLocalPath, storageAccountKey.Secondary, false, true);
                        
            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }

        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Save-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\download_VHD.csv", "download_VHD#csv", DataAccessMethod.Sequential)]
        public void SaveAzureVhdOverwriteTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the vhd path in your local machine
            string vhdName = Convert.ToString(TestContext.DataRow["vhdLocalPath"]);// +Utilities.GetUniqueShortName();
            FileInfo vhdLocalPath = new FileInfo(Utilities.GetUniqueShortName(vhdName));

            // Download and verify it.
            SaveVhdAndAssertContent(blobHandle, vhdLocalPath, false, false);

            // Download with overwrite and verify it.
            SaveVhdAndAssertContent(blobHandle, vhdLocalPath, true, false, false);

            // Try to download without overwrite.
            try
            {
                SaveVhdAndAssertContent(blobHandle, vhdLocalPath, false, true);
                Console.WriteLine("This is negative test.  Should have failed!");
                pass = false;                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception as expected: {0}", e.ToString());

            }

            //DateTime testEndTime = DateTime.Now;
            //Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);
            //Console.WriteLine("Duration of the test pass: {0} seconds", (testEndTime - testStartTime).TotalSeconds);

            //System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }

        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Save-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\download_VHD.csv", "download_VHD#csv", DataAccessMethod.Sequential)]
        public void SaveAzureVhdAllTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);       

            // Choose the vhd path in your local machine            
            string vhdName = Convert.ToString(TestContext.DataRow["vhdLocalPath"]) +Utilities.GetUniqueShortName();
            FileInfo vhdLocalPath = new FileInfo(vhdName);

            // Download and verify it.
            SaveVhdAndAssertContent(blobHandle, vhdLocalPath, 16, storageAccountKey.Secondary, true, false, true);

            // Download with overwrite and verify it.
            SaveVhdAndAssertContent(blobHandle, vhdLocalPath, 32, storageAccountKey.Primary, true, false, true);

            DateTime testEndTime = DateTime.Now;
            Console.WriteLine("{0} test passed at {1}.", testName, testEndTime);            

            //System.IO.File.AppendAllLines(perfFile, new string[] { String.Format("{0},{1}", testName, (testEndTime - testStartTime).TotalSeconds) });
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Save-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\download_VHD.csv", "download_VHD#csv", DataAccessMethod.Sequential)]
        [Ignore]
        public void SaveAzureVhdResumeTest()
        {
            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Choose the vhd path in your local machine            
            string vhdName = Convert.ToString(TestContext.DataRow["vhdLocalPath"]) + Utilities.GetUniqueShortName();
            FileInfo vhdLocalPath = new FileInfo(vhdName);
            Assert.IsFalse(File.Exists(vhdLocalPath.FullName), "VHD file already exist={0}", vhdLocalPath);
           
            // Start uploading and stop after 5 seconds...
            Console.WriteLine("downloading {0} to {1}", vhdBlobLocation, vhdLocalPath);
            string result = vmPowershellCmdlets.SaveAzureVhdStop(blobHandle.Blob.Uri, vhdLocalPath, null, null, false, 5000);

            if (result.ToLowerInvariant() == "stopped")
            {
                Console.WriteLine("successfully stopped");


                SaveVhdAndAssertContent(blobHandle, vhdLocalPath, false, true);                                
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


        [TestMethod(), TestCategory(Category.Functional), TestProperty("Feature", "IAAS"), Priority(1), Owner("hylee"), Description("Test the cmdlet (Save-AzureVhd)")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\Resources\\wrongPara_VHD.csv", "wrongPara_VHD#csv", DataAccessMethod.Sequential)]
        public void SaveAzureVhdWrongParameterTest()
        {

            StartTest(MethodBase.GetCurrentMethod().Name, testStartTime);

            // Set the source blob
            string vhdBlobLocation = blobUrlRoot + Convert.ToString(TestContext.DataRow["vhdBlobLocation"]);
            string vhdName = Convert.ToString(TestContext.DataRow["vhdLocalPath"]);
            string numThreadstr = Convert.ToString(TestContext.DataRow["numThread"]);
            int? numThread = String.IsNullOrWhiteSpace(numThreadstr) ? (int?) null : Int32.Parse(numThreadstr);
            string storageKeystr = Convert.ToString(TestContext.DataRow["storageKey"]);
            string storageKey = String.IsNullOrWhiteSpace(storageKeystr) ? (string)null : storageKeystr;

            // Download and verify it.
            try
            {
                vmPowershellCmdlets.SaveAzureVhd(new Uri(vhdBlobLocation), new FileInfo(vhdName), numThread, storageKey, false);
                Console.WriteLine("This is negative test.  Should have failed!");
                pass = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred as expected.  Exception: {0}", e.ToString());
            }  
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            Console.WriteLine("Test {0}", pass ? "passed" : "failed");            
        }
        [ClassCleanup]
        public static void ClassClean()
        {
            if (deleteUploadedBlob)
            {
                Utilities.GetBlobHandle(vhdBlobLocation, storageAccountKey.Primary).Blob.Delete();                
            }
        }
    }
}