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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.Sync.Download;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Storage;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.StorageServices
{
    [Cmdlet(VerbsData.Save, "AzureVhd"), OutputType(typeof (VhdDownloadContext))]
    public class SaveAzureVhdCommand : ServiceManagementBaseCmdlet
    {
        private const int DefaultNumberOfUploaderThreads = 8;
        
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "Vhd", HelpMessage = "Uri to blob")]
        [ValidateNotNullOrEmpty]
        [Alias("src")]
        public Uri Source
        {
            get;
            set;
        }

        [Parameter(Position = 2, Mandatory = true, ParameterSetName = "Vhd", HelpMessage = "Local path of the vhd file")]
        [ValidateNotNullOrEmpty]
        [Alias("lf")]
        public FileInfo LocalFilePath
        {
            get;
            set;
        }

        private int numberOfThreads = DefaultNumberOfUploaderThreads;

        [Parameter(Position = 3, Mandatory = false, ParameterSetName = "Vhd", HelpMessage = "Number of downloader threads")]
        [ValidateNotNullOrEmpty]
        [ValidateRange(1, 64)]
        [Alias("th")]
        public int NumberOfThreads
        {
            get { return this.numberOfThreads; }
            set { this.numberOfThreads = value; }
        }

        [Parameter(Position = 4, Mandatory = false, ParameterSetName = "Vhd", HelpMessage = "Key of the storage account")]
        [ValidateNotNullOrEmpty]
        [Alias("sk")]
        public string StorageKey
        {
            get;
            set;
        }

        [Parameter(Position = 5, Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = "Vhd", HelpMessage = "Delete the local file if already exists")]
        [ValidateNotNullOrEmpty]
        [Alias("o")]
        public SwitchParameter OverWrite
        {
            get;
            set;
        }

        protected override void OnProcessRecord()
        {
            BlobUri blobUri;
            if(!BlobUri.TryParseUri(Source, out blobUri))
            {
                throw new ArgumentOutOfRangeException("Source", Source.ToString());
            }

            var storageKey = this.StorageKey;
            if(this.StorageKey == null)
            {
                var storageService = this.StorageClient.StorageAccounts.Get(blobUri.StorageAccountName);
                if (storageService != null)
                {
                    var storageKeys = this.StorageClient.StorageAccounts.GetKeys(storageService.StorageAccount.Name);
                    storageKey = storageKeys.PrimaryKey;
                }
            }

            var downloaderParameters = new DownloaderParameters
            {
                BlobUri = blobUri,
                LocalFilePath = LocalFilePath.FullName,
                ConnectionLimit = NumberOfThreads,
                StorageAccountKey = storageKey,
                ValidateFreeDiskSpace = true,
                OverWrite = OverWrite
            };

            var vhdDownloadContext = VhdDownloaderModel.Download(downloaderParameters, this);
            WriteObject(vhdDownloadContext);
        }
    }
}