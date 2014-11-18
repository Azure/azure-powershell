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

namespace WindowsAzurePowerShell.Test.Commands
{
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using System;
    using System.IO;
    using System.Management.Automation;

    /// <summary>
    /// This cmdlet creates a new Windows Azure PowerShell test environment.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "AzureTestEnvironment"), OutputType(typeof(bool))]
    public class NewAzureTestEnvironmentCommand : PSCmdlet
    {
        const string StorageAccountCredentialsParameterSetName = "StorageAccountCredentialsParameterSet";

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = StorageAccountCredentialsParameterSetName, HelpMessage = "Name of storage account that will hold the test credentials")]
        public string StorageAccountName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = StorageAccountCredentialsParameterSetName, HelpMessage = "The key of the storage account")]
        public string StorageAccountKey { get; set; }

        [Parameter(Position = 2, Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = StorageAccountCredentialsParameterSetName, HelpMessage = "The test environment name")]
        public string Name { get; set; }

        [Parameter(Position = 3, Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = StorageAccountCredentialsParameterSetName, HelpMessage = "Path to publish settings file that will be used to access the test subscription")]
        [ValidatePath()]
        public string PublishSettingsFile { get; set; }

        [Parameter(Position = 4, Mandatory = false, ValueFromPipelineByPropertyName = false,
            ParameterSetName = StorageAccountCredentialsParameterSetName, HelpMessage = "Path to powershell variables that tests will have access to")]
        [ValidatePath()]
        public string PowerShellVariablesFile { get; set; }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = false,
            ParameterSetName = StorageAccountCredentialsParameterSetName, HelpMessage = "Path to environment variables that tests will have access to")]
        [ValidatePath()]
        public string EnvironmentVariablesFile { get; set; }

        protected override void ProcessRecord()
        {
            StorageCredentials creds = new StorageCredentials(StorageAccountName, StorageAccountKey);
            CloudStorageAccount account = new CloudStorageAccount(creds, false);
            CloudBlobClient blobClient = account.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(string.Format("testcredentials-{0}", Name));

            if (container.Exists())
            {
                throw new Exception("The test container already exists, please remove it before executing this cmdlet");
            }

            container.Create();
            CreateBlockBlob(container, PublishSettingsFile, "default.publishsettings");
            CreateBlockBlob(container, PowerShellVariablesFile, "variables.yml");
            CreateBlockBlob(container, EnvironmentVariablesFile, "environment.yml");

            WriteObject(true);
        }

        private void CreateBlockBlob(CloudBlobContainer container, string artifactPath, string name)
        {
            CloudBlockBlob blob = container.GetBlockBlobReference(name);
            string artifactResolvedPath = string.Empty;
            Stream contentStream = new MemoryStream();

            if (!string.IsNullOrEmpty(artifactPath))
            {
                artifactResolvedPath = SessionState.Path.GetResolvedPSPathFromPSPath(artifactPath)[0].Path;
                contentStream = File.OpenRead(artifactResolvedPath);
            }

            blob.UploadFromStream(contentStream);
            contentStream.Dispose();
        }
    }
}