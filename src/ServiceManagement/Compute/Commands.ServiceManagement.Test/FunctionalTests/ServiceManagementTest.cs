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
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.Properties;
using Microsoft.WindowsAzure.Commands.Sync.Download;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    [TestClass]
    public class ServiceManagementTest
    {
        protected const string BadRequestException = "BadRequest";
        protected const string ConflictErrorException = "ConflictError";
        protected const string ResourceNotFoundException = "ResourceNotFound";

        protected const string serviceNamePrefix = "PSTestService";
        protected const string vmNamePrefix = "PSTestVM";
        protected const string password = "p@ssw0rd";
        protected const string username = "pstestuser";
        protected static string localFile = Resource.Vhd;
        protected static string vnetConfigFilePath = Directory.GetCurrentDirectory() + "\\vnetconfig.netcfg";
        protected const string testDataContainer = "testdata";
        protected const string osVhdName = "oneGBFixedWS2008R2.vhd";

        protected const string WinRmEndpointName = "PowerShell";
        protected const string RdpEndpointName = "RemoteDesktop";

        // Test cleanup settings
        protected const bool deleteDefaultStorageAccount = false; // Temporarily set to false
        protected bool cleanupIfPassed = true;
        protected bool cleanupIfFailed = true;
        protected const string vhdContainerName = "vhdstore";

        protected static ServiceManagementCmdletTestHelper vmPowershellCmdlets;
        protected static PSAzureSubscriptionExtended defaultAzureSubscription;
        protected static StorageServiceKeyOperationContext storageAccountKey;
        protected static string blobUrlRoot;

        protected static string locationName;
        protected static string imageName;

        protected bool pass;
        protected string testName;
        protected DateTime testStartTime;

        private TestContext testContextInstance;

        private const string VhdFilesContainerName = "vhdfiles";
        private static readonly string[] VhdFiles = new[]
            {
                "dynamic_50.vhd", "dynamic_50_child01.vhd", "dynamic_50_child02.vhd",
                "fixed_50.vhd", "fixed_50_child01.vhd", "fixed_50_child02.vhd"
            };

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

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            SetTestSettings();
        }

        public static void SetDefaultStorage()
        {
            if (!string.IsNullOrEmpty(GetDefaultStorage(CredentialHelper.DefaultStorageName, CredentialHelper.Location)))
            {
                defaultAzureSubscription = vmPowershellCmdlets.SetAzureSubscription(defaultAzureSubscription.SubscriptionName, defaultAzureSubscription.SubscriptionId, CredentialHelper.DefaultStorageName);
                vmPowershellCmdlets.SelectAzureSubscription(defaultAzureSubscription.SubscriptionName, true);
                storageAccountKey = vmPowershellCmdlets.GetAzureStorageAccountKey(defaultAzureSubscription.CurrentStorageAccountName);
                Assert.AreEqual(defaultAzureSubscription.CurrentStorageAccountName, storageAccountKey.StorageAccountName);
                blobUrlRoot = (vmPowershellCmdlets.GetAzureStorageAccount(defaultAzureSubscription.CurrentStorageAccountName)[0].Endpoints.ToArray())[0];
            }
            else
            {
                Console.WriteLine("Unable to get the default storege account");
            }
        }

        private static string GetDefaultStorage(string storageName, string locName)
        {
            Collection<StorageServicePropertiesOperationContext> storageAccounts = vmPowershellCmdlets.GetAzureStorageAccount(null);
            foreach (var storageAccount in storageAccounts)
            {
                if (storageAccount.StorageAccountName == storageName)
                {
                    return storageAccount.StorageAccountName;
                }
            }

            var account = vmPowershellCmdlets.NewAzureStorageAccount(storageName, locName);
            if (account.StorageAccountName == storageName)
            {
                return account.StorageAccountName;
            }

            return null;
        }

        private static string GetSubscriptionName(string publishSettingsFile)
        {
            try
            {
                XDocument psf = XDocument.Load(publishSettingsFile);
                XElement pubData = psf.Descendants().FirstOrDefault();
                XElement pubProfile = pubData.Elements().ToList()[0];
                XElement sub = pubProfile.Elements().ToList()[0];
                string subName = sub.Attribute("Name").Value;
                Console.WriteLine("Getting subscription: {0}", subName);

                return subName;
            }
            catch
            {
                Console.WriteLine("Error occurred during loading publish settings file...");
                return null;
            }
        }

        public static void SetTestSettings()
        {
            vmPowershellCmdlets = new ServiceManagementCmdletTestHelper();
            CredentialHelper.GetTestSettings(Resource.TestSettings);

            vmPowershellCmdlets.RemoveAzureSubscriptions();
            vmPowershellCmdlets.ImportAzurePublishSettingsFile(CredentialHelper.PublishSettingsFile);
            var firstSub = vmPowershellCmdlets.GetAzureSubscription().First();
            vmPowershellCmdlets.SelectAzureSubscription(firstSub.SubscriptionName);

            if (string.IsNullOrEmpty(CredentialHelper.DefaultSubscriptionName))
            {
                defaultAzureSubscription = vmPowershellCmdlets.GetCurrentAzureSubscription();
                if (string.IsNullOrEmpty(Resource.DefaultSubscriptionName))
                {
                    CredentialHelper.DefaultSubscriptionName = defaultAzureSubscription.SubscriptionName;
                }
            }
            else
            {
                defaultAzureSubscription = vmPowershellCmdlets.SetDefaultAzureSubscription(CredentialHelper.DefaultSubscriptionName);
            }

            locationName = vmPowershellCmdlets.GetAzureLocationName(new[] { CredentialHelper.Location }); // Get-AzureLocation

            if (String.IsNullOrEmpty(locationName))
            {
                Console.WriteLine("No location is selected!");
            }
            Console.WriteLine("Location Name: {0}", locationName);

            if (defaultAzureSubscription.CurrentStorageAccountName == null && !string.IsNullOrEmpty(CredentialHelper.DefaultStorageName))
            {
                SetDefaultStorage();
            }

            try
            {
                imageName = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false); // Get-AzureVMImage
            }
            catch
            {
                Console.WriteLine("Error occurred during Get-AzureVMImageName... imageName is not set.");
            }

            try
            {
                DownloadVhds();
            }
            catch
            {
                Console.WriteLine("Error occurred during downloading vhds...");
            }

            if (String.IsNullOrEmpty(imageName))
            {
                Console.WriteLine("No image is selected!");
            }
            else
            {
                Console.WriteLine("Image Name: {0}", imageName);
            }
        }

        protected void StartTest(string testname, DateTime testStartTime)
        {
            Console.WriteLine("{0} test starts at {1}", testname, testStartTime);
        }

        [AssemblyCleanup]
        public static void CleanUpAssembly()
        {
            vmPowershellCmdlets = new ServiceManagementCmdletTestHelper();

            try
            {
                // Cleaning up affinity groups
                var affGroup = vmPowershellCmdlets.GetAzureAffinityGroup();
                if (affGroup.Count > 0)
                {
                    foreach (var aff in affGroup)
                    {
                        try
                        {
                            vmPowershellCmdlets.RemoveAzureAffinityGroup(aff.Name);
                        }
                        catch (Exception e)
                        {
                            if (e.ToString().Contains(BadRequestException))
                            {
                                Console.WriteLine("Affinity Group, {0}, is not deleted.", aff.Name);
                            }
                        }
                    }
                }

                // Cleaning up virtual disks
                if (defaultAzureSubscription != null)
                {
                    Retry(String.Format("Get-AzureDisk | Where {{$_.DiskName.Contains(\"{0}\")}} | Remove-AzureDisk -DeleteVhd", serviceNamePrefix), "in use");
                    if (deleteDefaultStorageAccount)
                    {
                        //vmPowershellCmdlets.RemoveAzureStorageAccount(defaultAzureSubscription.CurrentStorageAccountName);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error occurred during cleaning up..");
            }
        }

        private static void Retry(string cmdlet, string message, int maxTry = 1, int intervalSecond = 10)
        {

            ServiceManagementCmdletTestHelper pscmdlet = new ServiceManagementCmdletTestHelper();

            for (int i = 0; i < maxTry; i++)
            {
                try
                {
                    pscmdlet.RunPSScript(cmdlet);
                    break;
                }
                catch (Exception e)
                {
                    if (i == maxTry)
                    {
                        Console.WriteLine("Max try reached.  Couldn't perform within the given time.");
                    }
                    if (e.ToString().Contains(message))
                    {
                        //Thread.Sleep(intervalSecond * 1000);
                        continue;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        protected static void ReImportSubscription()
        {
            // Re-import the subscription.
            vmPowershellCmdlets.ImportAzurePublishSettingsFile();
            vmPowershellCmdlets.SetDefaultAzureSubscription(CredentialHelper.DefaultSubscriptionName);
            vmPowershellCmdlets.SetAzureSubscription(defaultAzureSubscription.SubscriptionName, defaultAzureSubscription.SubscriptionId, defaultAzureSubscription.CurrentStorageAccountName);
        }

        protected static void CleanupService(string svcName)
        {
            Utilities.TryAndIgnore(() => vmPowershellCmdlets.RemoveAzureService(svcName, true), "does not exist");
        }

        protected static void DownloadVhds()
        {
            storageAccountKey = vmPowershellCmdlets.GetAzureStorageAccountKey(defaultAzureSubscription.CurrentStorageAccountName);

            foreach (var vhdFile in VhdFiles)
            {
                string vhdBlobLocation = string.Format("{0}{1}/{2}", blobUrlRoot, VhdFilesContainerName, vhdFile);

                var vhdLocalPath = new FileInfo(Directory.GetCurrentDirectory() + "\\" + vhdFile);

                if (!File.Exists(vhdLocalPath.FullName))
                {
                    // Set the source blob
                    BlobHandle blobHandle = Utilities.GetBlobHandle(vhdBlobLocation, storageAccountKey.Primary);

                    SaveVhd(blobHandle, vhdLocalPath, storageAccountKey.Primary);
                }
            }
        }

        protected static void SaveVhd(BlobHandle destination, FileInfo locFile, string storageKey, int? numThread = null, bool overwrite = false)
        {
            try
            {
                Console.WriteLine("Downloading a VHD from {0} to {1}...", destination.Blob.Uri.ToString(), locFile.FullName);
                DateTime startTime = DateTime.Now;
                vmPowershellCmdlets.SaveAzureVhd(destination.Blob.Uri, locFile, numThread, storageKey, overwrite);
                Console.WriteLine("Downloading completed in {0} seconds.", (DateTime.Now - startTime).TotalSeconds);
            }
            catch (Exception e)
            {
                Assert.Fail(e.InnerException.ToString());
            }
        }

        protected void VerifyRDP(string serviceName, string rdpPath)
        {
            Utilities.GetDeploymentAndWaitForReady(serviceName, DeploymentSlotType.Production, 10, 600);

            vmPowershellCmdlets.GetAzureRemoteDesktopFile("WebRole1_IN_0", serviceName, rdpPath, false);

            string dns;

            using (var stream = new StreamReader(rdpPath))
            {
                string firstLine = stream.ReadLine();
                dns = Utilities.FindSubstring(firstLine, ':', 2);
            }

            Assert.IsTrue((Utilities.RDPtestPaaS(dns, "WebRole1", 0, username, password, true)), "Cannot RDP to the instance!!");
        }
    }
}
