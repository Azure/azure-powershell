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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.WindowsAzure.Commands.Sync.Download;
using System;
using System.IO;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.StorageServices
{
    [Cmdlet(VerbsData.Save, ProfileNouns.Vhd), OutputType(typeof(VhdDownloadContext))]
    public class SaveAzureVhdCommand : ComputeClientBaseCmdlet
    {
        private const int DefaultNumberOfUploaderThreads = 8;
        private const string ResourceGroupParameterSet = "ResourceGroupParameterSetName";
        private const string StorageKeyParameterSet = "StorageKeyParameterSetName";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ResourceGroupParameterSet,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = StorageKeyParameterSet,
            HelpMessage = "Key of the storage account")]
        [ValidateNotNullOrEmpty]
        [Alias("sk")]
        public string StorageKey { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Uri to blob")]
        [ValidateNotNullOrEmpty]
        [Alias("src", "Source")]
        public Uri SourceUri { get; set; }

        [Parameter(
            Position = 2,
            Mandatory = true,
            HelpMessage = "Local path of the vhd file")]
        [ValidateNotNullOrEmpty]
        [Alias("lf")]
        public FileInfo LocalFilePath { get; set; }

        private int numberOfThreads = DefaultNumberOfUploaderThreads;

        [Parameter(
            Position = 3,
            Mandatory = false,
            HelpMessage = "Number of downloader threads")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(1, 64)]
        [Alias("th")]
        public int NumberOfThreads
        {
            get { return this.numberOfThreads; }
            set { this.numberOfThreads = value; }
        }

        [Parameter(
            Position = 4,
            Mandatory = false,
            HelpMessage = "Delete the local file if already exists")]
        [ValidateNotNullOrEmpty]
        [Alias("o")]
        public SwitchParameter OverWrite { get; set; }

        public override void ExecuteCmdlet()
        {
            var result = DownloadFromBlobUri(
                this,
                this.SourceUri,
                this.LocalFilePath,
                this.StorageKey,
                this.ResourceGroupName,
                this.NumberOfThreads,
                this.OverWrite);
            WriteObject(result);
        }


        private VhdDownloadContext DownloadFromBlobUri(
            ComputeClientBaseCmdlet cmdlet,
            Uri sourceUri,
            FileInfo localFileInfo,
            string storagekey,
            string resourceGroupName,
            int numThreads,
            bool overwrite)
        {
            BlobUri blobUri;
            if (!BlobUri.TryParseUri(sourceUri, out blobUri))
            {
                throw new ArgumentOutOfRangeException("Source", sourceUri.ToString());
            }

            if (storagekey == null)
            {
                var storageClient = AzureSession.ClientFactory.CreateArmClient<StorageManagementClient>(
                        DefaultProfile.Context, AzureEnvironment.Endpoint.ResourceManager);


                var storageService = storageClient.StorageAccounts.GetProperties(resourceGroupName, blobUri.StorageAccountName);
                if (storageService != null)
                {
                    var storageKeys = storageClient.StorageAccounts.ListKeys(resourceGroupName, storageService.Name);
                    storagekey = storageKeys.Key1;
                }
            }

            var downloaderParameters = new DownloaderParameters
            {
                BlobUri = blobUri,
                LocalFilePath = localFileInfo.FullName,
                ConnectionLimit = numThreads,
                StorageAccountKey = storagekey,
                ValidateFreeDiskSpace = true,
                OverWrite = overwrite
            };

            return VhdDownloaderModel.Download(downloaderParameters, cmdlet);
        }
    }
}
