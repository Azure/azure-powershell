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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.Properties;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    public static class CredentialHelper
    {
        private static string EnvironmentPathFormat = "testcredentials-{0}";
        private static string defaultCredentialFile = "default.publishsettings";
        private static string TestEnvironmentVariable = "AZURE_TEST_ENVIRONMENT";
        private static string StorageAccountVariable = "AZURE_STORAGE_ACCOUNT";
        private static string StorageAccountKeyVariable = "AZURE_STORAGE_ACCESS_KEY";
        private static string DefaultStorageAccountVariable = "AZURERT_DEFAULT_STORAGE_ACCOUNT";
        private static string DefaultLocationVariable = "AZURERT_DEFAULT_LOCATION";
        private static string CredentialBlobUriFormat = "https://{0}.blob.core.windows.net";
        
        private static string publishSettingsFile = null;
        private static string defaultSubscriptionName = null;
        private static string defaultSubscriptionId = null;
        private static string location = null;
        private static string defaultStorageName = null;
        private static string currentTestEnvironment = null;
        private static CloudBlobContainer blobContainer;
        private const string VhdFilesContainerName = "vhdfiles";
        private const string toolsContainerName = "tools";

        private static Dictionary<string, string> environment = new Dictionary<string, string>();
        public static Dictionary<string, string> PowerShellVariables { get; private set; }

        public static void GetCredentialInfo(string downloadDirectoryPath)
        {
            Process currentProcess = Process.GetCurrentProcess();
            StringDictionary environment = currentProcess.StartInfo.EnvironmentVariables;
            Assert.IsTrue(environment.ContainsKey(TestEnvironmentVariable),
                string.Format("You must define a test environment using environment variable {0}", TestEnvironmentVariable));
            currentTestEnvironment = environment[TestEnvironmentVariable];
            Assert.IsTrue(environment.ContainsKey(StorageAccountVariable),
                string.Format("You must define a storage account for credential download using environment variable {0}", StorageAccountVariable));
            string storageAccount = environment[StorageAccountVariable];
            Assert.IsTrue(environment.ContainsKey(StorageAccountKeyVariable),
                string.Format("You must define a storage account key for credential download using environment variable {0}", StorageAccountKeyVariable));
            string storageAccountKey = environment[StorageAccountKeyVariable];

            DownloadTestCredentials(currentTestEnvironment, downloadDirectoryPath, 
                string.Format(CredentialBlobUriFormat, storageAccount),
                storageAccount, storageAccountKey);

            DownloadTestVhdsAndPackages(currentTestEnvironment, downloadDirectoryPath,
                string.Format(CredentialBlobUriFormat, storageAccount),
                storageAccount, storageAccountKey);

            if (environment.ContainsKey(DefaultStorageAccountVariable))
            {
                string.Format("Default storage account name define is {0}", DefaultStorageAccountVariable);
                defaultStorageName = environment[DefaultStorageAccountVariable];
            }

            if(environment.ContainsKey(DefaultLocationVariable))
            {
                string.Format("Default location defindde is {0}", DefaultLocationVariable);
                location = environment[DefaultLocationVariable];
            }

            publishSettingsFile = Path.Combine(downloadDirectoryPath, defaultCredentialFile);
            Assert.IsTrue(File.Exists(publishSettingsFile), string.Format("Did not download file {0}", publishSettingsFile));
        }

        private static void DownloadTestCredentials(string testEnvironment, string downloadDirectoryPath, string blobUri, string storageAccount, string storageKey)
        {
            string containerPath = string.Format(EnvironmentPathFormat, testEnvironment);
            StorageCredentials credentials = new StorageCredentials(storageAccount, storageKey);
            CloudBlobClient blobClient = new CloudBlobClient(new Uri(blobUri), credentials);
            blobContainer = blobClient.GetContainerReference(containerPath);
            foreach (IListBlobItem blobItem in blobContainer.ListBlobs())
            {
                ICloudBlob blob = blobClient.GetBlobReferenceFromServer(blobItem.Uri);
                Console.WriteLine("Downloading file {0} from blob Uri {1}", blob.Name, blob.Uri);
                FileStream blobStream = new FileStream(Path.Combine(downloadDirectoryPath, blob.Name), FileMode.Create);
                blob.DownloadToStream(blobStream);
                blobStream.Flush();
                blobStream.Close();
            }
        }

        private static void DownloadTestVhdsAndPackages(string testEnvironment, string downloadDirectoryPath, string blobUri, string storageAccount, string storageKey)
        {
            StorageCredentials credentials = new StorageCredentials(storageAccount, storageKey);
            CloudBlobClient blobClient = new CloudBlobClient(new Uri(blobUri), credentials);
            blobContainer = blobClient.GetContainerReference(VhdFilesContainerName);
            foreach (IListBlobItem blobItem in blobContainer.ListBlobs())
            {
                ICloudBlob blob = blobClient.GetBlobReferenceFromServer(blobItem.Uri);
                Console.WriteLine("Downloading file {0} from blob Uri {1}", blob.Name, blob.Uri);
                FileStream blobStream = new FileStream(Path.Combine(downloadDirectoryPath, blob.Name), FileMode.Create);
                blob.DownloadToStream(blobStream);
                blobStream.Flush();
                blobStream.Close();
            }

            blobContainer = blobClient.GetContainerReference(toolsContainerName);
            foreach (IListBlobItem blobItem in blobContainer.ListBlobs())
            {
                ICloudBlob blob = blobClient.GetBlobReferenceFromServer(blobItem.Uri);
                Console.WriteLine("Downloading file {0} from blob Uri {1}", blob.Name, blob.Uri);
                FileStream blobStream = new FileStream(Path.Combine(downloadDirectoryPath, @"..\..\", blob.Name), FileMode.Create);
                blob.DownloadToStream(blobStream);
                blobStream.Flush();
                blobStream.Close();
            }
        }

        public static void GetTestSettings(string testSettings)
        {
            switch (testSettings)
            {
                case "UseDefaults":
                default:
                    CredentialHelper.GetCredentialInfo(AppDomain.CurrentDomain.BaseDirectory);
                    break;

                case "UseCustom":
                    if (!string.IsNullOrWhiteSpace(Resource.PublishSettingsFile))
                    {
                        publishSettingsFile = Resource.PublishSettingsFile;
                    }
                    else
                    {
                        Assert.IsNotNull(CredentialHelper.PublishSettingsFile);
                    }

                    if (!string.IsNullOrWhiteSpace(Resource.DefaultSubscriptionName))
                    {
                        defaultSubscriptionName = Resource.DefaultSubscriptionName;
                    }
                    if (!string.IsNullOrWhiteSpace(Resource.Location))
                    {
                        location = Resource.Location;
                    }
                    if (!string.IsNullOrWhiteSpace(Resource.DefaultStorageAccountName))
                    {
                        defaultStorageName = Resource.DefaultStorageAccountName;
                    }
                    break;

                case "UseDefaultsandOverride":
                    CredentialHelper.GetCredentialInfo(AppDomain.CurrentDomain.BaseDirectory);

                    if (!string.IsNullOrWhiteSpace(Resource.PublishSettingsFile))
                    {
                        CredentialHelper.PublishSettingsFile = Resource.PublishSettingsFile;
                    }
                    if (!string.IsNullOrWhiteSpace(Resource.DefaultSubscriptionName))
                    {
                        CredentialHelper.DefaultSubscriptionName = Resource.DefaultSubscriptionName;
                    }
                    if (!string.IsNullOrWhiteSpace(Resource.Location))
                    {
                        CredentialHelper.Location = Resource.Location;
                    }
                    if (!string.IsNullOrWhiteSpace(Resource.DefaultStorageAccountName))
                    {
                        CredentialHelper.defaultStorageName = Resource.DefaultStorageAccountName;
                    }

                    break;
            }

            if (!string.IsNullOrWhiteSpace(Resource.Location))
            {
                location = Resource.Location;
            }   
        }

        public static string PublishSettingsFile
        {
            get
            {
                return publishSettingsFile;
            }
            set
            {
                publishSettingsFile = value;
            }
        }

        public static string TestEnvironment
        {
            get
            {
                return currentTestEnvironment;
            }
            set
            {
                currentTestEnvironment = value;
            }
        }

        public static string DefaultSubscriptionName
        {
            get
            {
                return defaultSubscriptionName;
            }
            set
            {
                defaultSubscriptionName = value;
            }
        }

        public static string DefaultSubscriptionId
        {
            get
            {
                return defaultSubscriptionId;
            }
            set
            {
                defaultSubscriptionId = value;
            }
        }

        public static string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        public static string DefaultStorageName
        {
            get
            {
                return defaultStorageName;
            }
            set
            {
                defaultStorageName = value;
            }
        }

        public static void CopyTestData(string srcContainer, string srcBlob, string destContainer, string destBlob = null)
        {
            ServiceManagementCmdletTestHelper vmPowershellCmdlets = new ServiceManagementCmdletTestHelper();
            Process currentProcess = Process.GetCurrentProcess();
            StringDictionary environment = currentProcess.StartInfo.EnvironmentVariables;

            string storageAccount = environment[CredentialHelper.StorageAccountVariable];
            string storageAccountKey = environment[CredentialHelper.StorageAccountKeyVariable];

            // Create a container
            try
            {
                vmPowershellCmdlets.RunPSScript(String.Format("{0}-{1} -Name {2}",
                    VerbsCommon.Get, StorageNouns.Container, destContainer));
            }
            catch
            {
                // Create a container.
                vmPowershellCmdlets.RunPSScript(String.Format("{0}-{1} -Name {2}",
                    VerbsCommon.New, StorageNouns.Container, destContainer));
            }

            // Make SAS Uri for the source blob.
            string srcSasUri = Utilities.GenerateSasUri(CredentialHelper.CredentialBlobUriFormat, storageAccount, storageAccountKey, srcContainer, srcBlob);

            if (string.IsNullOrEmpty(destBlob))
            {
                vmPowershellCmdlets.RunPSScript(string.Format("{0}-{1} -SrcContainer {2} -SrcBlob {3} -DestContainer {4} -Force",
                    VerbsLifecycle.Start, StorageNouns.CopyBlob, srcContainer, srcBlob, destContainer));
                destBlob = srcBlob;
            }
            else
            {
                vmPowershellCmdlets.RunPSScript(string.Format("{0}-{1} -SrcUri \"{2}\" -DestContainer {3} -DestBlob {4} -Force",
                    VerbsLifecycle.Start, StorageNouns.CopyBlob, srcSasUri, destContainer, destBlob));
            }

            for (int i = 0; i < 60; i++)
            {
                var result = vmPowershellCmdlets.CheckCopyBlobStatus(destContainer, destBlob);
                if (result.Status.ToString().Equals("Success"))
                {
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(10 * 1000);
                }
            }
        }
    }
}
