﻿// ----------------------------------------------------------------------------------
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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Azure.Common.Authentication.Models;
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
            vmPowershellCmdlets = new ServiceManagementCmdletTestHelper();
            CredentialHelper.GetTestSettings(Resource.TestSettings);

            vmPowershellCmdlets.RemoveAzureSubscriptions();
            if (vmPowershellCmdlets.GetAzureEnvironment("ussouth").Count > 0)
            {
                Console.WriteLine("Removing ussouth environment...");
                vmPowershellCmdlets.RunPSScript("Remove-AzureEnvironment -Name ussouth -Force");
            }

            List<AzureEnvironment> environments =  vmPowershellCmdlets.GetAzureEnvironment();
            var serviceManagementUrl = GetServiceManagementUrl(CredentialHelper.PublishSettingsFile);

            foreach (var env in environments)
            {
                var envServiceManagementUrl = (string) env.Endpoints[AzureEnvironment.Endpoint.ServiceManagement];
                if (!string.IsNullOrEmpty(envServiceManagementUrl))
                {
                    if (envServiceManagementUrl.Equals(serviceManagementUrl))
                    {
                        currentEnvName = env.Name;
                        var curEnv = vmPowershellCmdlets.GetAzureEnvironment(currentEnvName)[0];
                        Console.WriteLine("Using the existing environment: {0}", currentEnvName);
                        Console.WriteLine("PublichSettingsFileUrl: {0}", curEnv.GetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl));
                        Console.WriteLine("ServiceManagement: {0}", curEnv.GetEndpoint(AzureEnvironment.Endpoint.ServiceManagement));
                        Console.WriteLine("ManagementPortalUrl: {0}", curEnv.GetEndpoint(AzureEnvironment.Endpoint.ManagementPortalUrl));
                        Console.WriteLine("ActiveDirectory: {0}", curEnv.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectory));
                        Console.WriteLine("ActiveDirectoryServiceEndpointResourceId: {0}", curEnv.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId));
                        Console.WriteLine("ResourceManager: {0}", curEnv.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager));
                        Console.WriteLine("Gallery: {0}", curEnv.GetEndpoint(AzureEnvironment.Endpoint.Gallery));
                        Console.WriteLine("Graph: {0}", curEnv.GetEndpoint(AzureEnvironment.Endpoint.Graph));
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
                    prodEnv.GetEndpoint(AzureEnvironment.Endpoint.PublishSettingsFileUrl),
                    serviceManagementUrl,
                    prodEnv.GetEndpoint(AzureEnvironment.Endpoint.ManagementPortalUrl),
                    prodEnv.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectory),
                    prodEnv.GetEndpoint(AzureEnvironment.Endpoint.ActiveDirectoryServiceEndpointResourceId),
                    prodEnv.GetEndpoint(AzureEnvironment.Endpoint.ResourceManager),
                    prodEnv.GetEndpoint(AzureEnvironment.Endpoint.Gallery),
                    prodEnv.GetEndpoint(AzureEnvironment.Endpoint.Graph)));

                vmPowershellCmdlets.ImportAzurePublishSettingsFile(CredentialHelper.PublishSettingsFile, TempEnvName);
            }
            else
            {
                Console.WriteLine("Using existing environment... : {0}", currentEnvName);
                vmPowershellCmdlets.ImportAzurePublishSettingsFile(CredentialHelper.PublishSettingsFile, currentEnvName);
            }

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
            vmPowershellCmdlets.SetDefaultAzureSubscription(CredentialHelper.DefaultSubscriptionName);
            vmPowershellCmdlets.SetAzureSubscription(defaultAzureSubscription.SubscriptionName, defaultAzureSubscription.SubscriptionId, defaultAzureSubscription.CurrentStorageAccountName);
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
