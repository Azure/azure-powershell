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
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.WindowsAzure.Commands.ScenarioTest.Common
{
    public class TestCredentialHelper
    {
        public static string EnvironmentPathFormat = "testcredentials-{0}";
        public static string EnvironmentVariableFile = "environment.yml";
        public static string PowerShellVariableFile = "variables.yml";
        public static string DefaultCredentialFile = "default.publishsettings";
        public static string WindowsAzureProfileFile = "WindowsAzureProfile.xml";
        public static string TestEnvironmentVariable = "AZURE_TEST_ENVIRONMENT";
        public static string StorageAccountVariable = "AZURE_STORAGE_ACCOUNT";
        public static string StorageAccountKeyVariable = "AZURE_STORAGE_ACCESS_KEY";
        public static string CredentialBlobUriFormat = "https://{0}.blob.core.windows.net";

        private string downloadDirectoryPath = null;
        private Dictionary<string, string> environment = new Dictionary<string, string>();
        public Dictionary<string, string> PowerShellVariables { get; private set; }

        public TestCredentialHelper(string downloadPath)
        {
            string environmentFile = Path.Combine(downloadPath, EnvironmentVariableFile);
            string variableFile = Path.Combine(downloadPath, PowerShellVariableFile);
            this.downloadDirectoryPath = downloadPath;
            PowerShellVariables = new Dictionary<string, string>();
            if (!File.Exists(environmentFile))
            {
                Process currentProcess = Process.GetCurrentProcess();
                StringDictionary environment = currentProcess.StartInfo.EnvironmentVariables;
                Assert.IsTrue(environment.ContainsKey(TestEnvironmentVariable),
                    string.Format("You must define a test environment using environment variable {0}", TestEnvironmentVariable));
                string testEnvironment = environment[TestEnvironmentVariable];
                Assert.IsTrue(environment.ContainsKey(StorageAccountVariable),
                    string.Format("You must define a storage account for credential download using environment variable {0}", StorageAccountVariable));
                string storageAccount = environment[StorageAccountVariable];
                Assert.IsTrue(environment.ContainsKey(StorageAccountKeyVariable),
                    string.Format("You must define a storage account key for credential download using environment variable {0}", StorageAccountKeyVariable));
                string storageAccountKey = environment[StorageAccountKeyVariable];
                DownloadTestCredentials(environment[TestEnvironmentVariable],
                    downloadPath, string.Format(CredentialBlobUriFormat, storageAccount),
                    storageAccount, environment[StorageAccountKeyVariable]);
                Assert.IsTrue(File.Exists(environmentFile), string.Format("Did not download file {0}", environmentFile));
                Assert.IsTrue(File.Exists(variableFile), string.Format("Did not download file {0}", variableFile));
            }
            
            AddPowerShellVariables(variableFile);
            AddEnvironmentVariables(environmentFile);
        }

        public void SetupPowerShellEnvironment(System.Management.Automation.PowerShell powerShell)
        {
            this.SetupPowerShellEnvironment(powerShell, DefaultCredentialFile, WindowsAzureProfileFile);
        }

        public void SetupPowerShellEnvironment(System.Management.Automation.PowerShell powerShell, string credentials, string profile)
        {
            powerShell.RemoveCredentials();
            string profileFile = Path.Combine(this.downloadDirectoryPath, profile);

            if (File.Exists(profileFile))
            {
                string dest = Path.Combine(AzurePowerShell.ProfileDirectory, profile);
                powerShell.AddScript(string.Format("Copy-Item -Path '{0}' -Destination '{1}' -Force", profileFile, dest));
                powerShell.AddScript("[Microsoft.WindowsAzure.Commands.Utilities.Common.AzureProfile]::Instance.Load()");
            }
            else
            {
                string credentialFile = Path.Combine(this.downloadDirectoryPath, credentials);
                Assert.IsTrue(File.Exists(credentialFile), string.Format("Did not download file {0}", credentialFile));
                Console.WriteLine("Using default.PublishSettings for setting up credentials");
                powerShell.ImportCredentials(credentialFile);
            }

            foreach (string key in this.environment.Keys) powerShell.AddEnvironmentVariable(key, environment[key]);
            foreach (string key in this.PowerShellVariables.Keys) powerShell.SetVariable(key, PowerShellVariables[key]);
        }

        public static void ImportCredentails(System.Management.Automation.PowerShell powerShell, string credentialFile)
        {
            powerShell.RemoveCredentials();
            powerShell.ImportCredentials(credentialFile);
        }

        public static void DownloadTestCredentials(string testEnvironment, string downloadDirectoryPath, string blobUri, string storageAccount, string storageKey)
        {
            string containerPath = string.Format(EnvironmentPathFormat, testEnvironment);
            StorageCredentials credentials = new StorageCredentials(storageAccount, storageKey);
            CloudBlobClient blobClient = new CloudBlobClient(new Uri(blobUri), credentials);
            CloudBlobContainer container = blobClient.GetContainerReference(containerPath);
            foreach (IListBlobItem blobItem in container.ListBlobs())
            {
                ICloudBlob blob = blobClient.GetBlobReferenceFromServer(blobItem.Uri);
                Console.WriteLine("Downloading file {0} from blob Uri {1}", blob.Name, blob.Uri);
                FileStream blobStream = new FileStream(Path.Combine(downloadDirectoryPath, blob.Name), FileMode.Create);
                blob.DownloadToStream(blobStream);
                blobStream.Flush();
                blobStream.Close();
            }
        }

        public void AddEnvironmentVariables(string environmentPath)
        {
            LoadYmlSettingsFile(environmentPath, (x, y) => this.environment[x] = y);
        }

        public void AddPowerShellVariables(string powerShellVariablePath)
        {
            LoadYmlSettingsFile(powerShellVariablePath, (x, y) => this.PowerShellVariables[x] = y);
        }

        private static void LoadYmlSettingsFile(string filePath, Action<string, string> settingAction)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string currentLine = null;
                do
                {
                    currentLine = reader.ReadLine();
                    if (!string.IsNullOrEmpty(currentLine))
                    {
                        Regex lineFormat = new Regex(@":*\s+");
                        string[] values = lineFormat.Split(currentLine, 2);
                        if (values != null && values.Length > 1)
                        {
                            settingAction(values[0], values[1]);
                        }
                    }
                }
                while (currentLine != null);
            }
        }
    }
}
