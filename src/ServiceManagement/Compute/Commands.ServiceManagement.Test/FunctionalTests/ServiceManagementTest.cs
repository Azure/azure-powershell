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

using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Profile.Models;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.Properties;
using Microsoft.WindowsAzure.Commands.Sync.Download;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

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
        protected const string osVhdName = "os.vhd";

        protected const string WinRmEndpointName = "PowerShell";
        protected const string RdpEndpointName = "RemoteDesktop";
        protected const string TempEnvName = "tempEnv";

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
        protected static string currentEnvName = null;

        protected bool pass;
        protected string testName;
        protected DateTime testStartTime;

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

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            SetTestSettings();
        }

        [AssemblyCleanup]
        public static void CleanUpAssembly()
        {
            if (string.IsNullOrEmpty(currentEnvName))
            {
                vmPowershellCmdlets.RunPSScript(string.Format("Remove-AzureEnvironment -Name {0} -Force", TempEnvName));
            }
        }

        public static void SetDefaultStorage()
        {
            if (!string.IsNullOrEmpty(GetDefaultStorage(CredentialHelper.DefaultStorageName, CredentialHelper.Location)))
            {
                vmPowershellCmdlets.SelectAzureSubscription(defaultAzureSubscription.SubscriptionId);
                defaultAzureSubscription = vmPowershellCmdlets.SetAzureSubscription(defaultAzureSubscription.SubscriptionId, CredentialHelper.DefaultStorageName);
                defaultAzureSubscription.CurrentStorageAccountName = CredentialHelper.DefaultStorageName;
                storageAccountKey = vmPowershellCmdlets.GetAzureStorageAccountKey(CredentialHelper.DefaultStorageName);
                Assert.AreEqual(CredentialHelper.DefaultStorageName, storageAccountKey.StorageAccountName);
                blobUrlRoot = (vmPowershellCmdlets.GetAzureStorageAccount(CredentialHelper.DefaultStorageName)[0].Endpoints.ToArray())[0];
            }
            else
            {
                Console.WriteLine("Unable to get the default storage account");
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

        private static string GetSubscriptionId(string publishSettingsFile)
        {
            try
            {
                XDocument psf = XDocument.Load(publishSettingsFile);
                XElement pubData = psf.Descendants().FirstOrDefault();
                XElement pubProfile = pubData.Elements().ToList()[0];
                return pubProfile.Element("Subscription").Attribute("Id").Value;
            }
            catch
            {
                Console.WriteLine("Error occurred during getting subscription Id from publish settings file...");
                throw;
            }
        }

        private static string GetServiceManagementUrl(string publishSettingsFile)
        {
            try
            {
                XDocument psf = XDocument.Load(publishSettingsFile);
                XElement pubData = psf.Descendants().FirstOrDefault();
                XElement pubProfile = pubData.Elements().ToList()[0];
                XAttribute urlattr = pubProfile.Attribute("Url");
                string url = string.Empty;
                if (urlattr != null)
                {
                    url = urlattr.Value;
                }
                else
                {
                    var subscriptions = pubProfile.Elements("Subscription").ToList();
                    if (subscriptions.Any())
                    {
                        url = subscriptions[0].Attribute("ServiceManagementUrl").Value;
                    }
                }
                return url;
            }
            catch
            {
                Console.WriteLine("Error occurred during loading publish settings file...");
                return null;
            }
        }

        public static void SetTestSettings()
        {
            // Please remove this line once all tests are done
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                delegate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                    System.Security.Cryptography.X509Certificates.X509Chain chain,
                    System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true; // **** Always accept
                };

            vmPowershellCmdlets = new ServiceManagementCmdletTestHelper();
            CredentialHelper.GetTestSettings(Resource.TestSettings);

            vmPowershellCmdlets.RemoveAzureSubscriptions();
            var ussouthEnv = vmPowershellCmdlets.GetAzureEnvironment("ussouth");
            if (ussouthEnv != null && ussouthEnv.Count > 0)
            {
                Console.WriteLine("Removing ussouth environment...");
                vmPowershellCmdlets.RunPSScript("Remove-AzureEnvironment -Name ussouth -Force");
            }

            List<PSAzureEnvironment> environments = vmPowershellCmdlets.GetAzureEnvironment();
            var serviceManagementUrl = GetServiceManagementUrl(CredentialHelper.PublishSettingsFile);
            var subscriptionId = GetSubscriptionId(CredentialHelper.PublishSettingsFile);

            foreach (var env in environments)
            {
                if (!string.IsNullOrEmpty(env.ServiceManagementUrl))
                {
                    if (env.ServiceManagementUrl.Equals(serviceManagementUrl))
                    {
                        currentEnvName = env.Name;
                        var curEnv = vmPowershellCmdlets.GetAzureEnvironment(currentEnvName)[0];
                        Console.WriteLine("Using the existing environment: {0}", currentEnvName);
                        Console.WriteLine("PublichSettingsFileUrl: {0}", curEnv.PublishSettingsFileUrl);
                        Console.WriteLine("ServiceManagement: {0}", curEnv.ServiceManagementUrl);
                        Console.WriteLine("ManagementPortalUrl: {0}", curEnv.ManagementPortalUrl);
                        Console.WriteLine("ActiveDirectory: {0}", curEnv.ActiveDirectoryAuthority);
                        Console.WriteLine("ActiveDirectoryServiceEndpointResourceId: {0}", curEnv.ActiveDirectoryServiceEndpointResourceId);
                        Console.WriteLine("ResourceManager: {0}", curEnv.ResourceManagerUrl);
                        Console.WriteLine("Gallery: {0}", curEnv.GalleryUrl);
                        Console.WriteLine("Graph: {0}", curEnv.GalleryUrl);
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(currentEnvName))
            {
                Console.WriteLine("Creating new environment... : {0}", TempEnvName);
                var prodEnv = vmPowershellCmdlets.GetAzureEnvironment("AzureCloud")[0];
                vmPowershellCmdlets.RunPSScript(string.Format(
                    @"Add-AzureEnvironment -Name {0} `
                    -PublishSettingsFileUrl {1} `
                    -ServiceEndpoint {2} `
                    -ManagementPortalUrl {3} `
                    -ActiveDirectoryEndpoint {4} `
                    -ActiveDirectoryServiceEndpointResourceId {5} `
                    -ResourceManagerEndpoint {6} `
                    -GalleryEndpoint {7} `
                    -GraphEndpoint {8}",
                    TempEnvName,
                    prodEnv.PublishSettingsFileUrl,
                    serviceManagementUrl,
                    prodEnv.ManagementPortalUrl,
                    prodEnv.ActiveDirectoryAuthority,
                    prodEnv.ActiveDirectoryServiceEndpointResourceId,
                    prodEnv.ResourceManagerUrl,
                    prodEnv.GalleryUrl,
                    prodEnv.GalleryUrl));

                vmPowershellCmdlets.ImportAzurePublishSettingsFile(CredentialHelper.PublishSettingsFile, TempEnvName);
            }
            else
            {
                Console.WriteLine("Using existing environment... : {0}", currentEnvName);
                vmPowershellCmdlets.ImportAzurePublishSettingsFile(CredentialHelper.PublishSettingsFile, currentEnvName);
            }

            var firstSub = vmPowershellCmdlets.GetAzureSubscription(subscriptionId);
            vmPowershellCmdlets.SelectAzureSubscription(firstSub.SubscriptionId);
            defaultAzureSubscription = vmPowershellCmdlets.GetCurrentAzureSubscription();
            CredentialHelper.DefaultSubscriptionName = defaultAzureSubscription.SubscriptionName;

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
            string subId = defaultAzureSubscription.SubscriptionId;
            string endPoint = defaultAzureSubscription.ServiceEndpoint;
            Console.WriteLine("{0} test starts at {1} for subscription {2} and endpoint {3}", testname, testStartTime, subId, endPoint);
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
                        Thread.Sleep(TimeSpan.FromSeconds(intervalSecond));
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
            vmPowershellCmdlets.SetDefaultAzureSubscription(defaultAzureSubscription.SubscriptionId);
            vmPowershellCmdlets.SetAzureSubscription(defaultAzureSubscription.SubscriptionId, defaultAzureSubscription.CurrentStorageAccountName);
        }

        protected static void CleanupService(string svcName)
        {
            Utilities.TryAndIgnore(() => vmPowershellCmdlets.RemoveAzureService(svcName, true), "does not exist");
        }

        protected void VerifyRDP(string serviceName, string rdpPath)
        {
            Console.WriteLine("Fetching Azure VM RDP file");
            vmPowershellCmdlets.GetAzureRemoteDesktopFile("WebRole1_IN_0", serviceName, rdpPath, false);
            Console.WriteLine("Azure VM RDP file downloaded.");
        }

        protected string UploadVhdFile()
        {
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

            return vhdDestUri;
        }
    }
}
