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

using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.DeploymentEntities;

namespace Microsoft.WindowsAzure.Commands.Websites
{
    [Cmdlet(VerbsLifecycle.Enable, "AzureWebsiteApplicationDiagnostic"), OutputType(typeof(bool))]
    public class EnableAzureWebsiteApplicationDiagnosticCommand : WebsiteContextBaseCmdlet
    {
        private const string FileParameterSetName = "FileParameterSet";

        private const string TableStorageParameterSetName = "TableStorageParameterSet";

        private const string BlobStorageParameterSetName = "BlobStorageParameterSet";

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FileParameterSetName)]
        public SwitchParameter File { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = TableStorageParameterSetName)]
        public SwitchParameter TableStorage { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = BlobStorageParameterSetName)]
        public SwitchParameter BlobStorage { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FileParameterSetName)]
        [Parameter(Mandatory = true, ParameterSetName = TableStorageParameterSetName)]
        [Parameter(Mandatory = true, ParameterSetName = BlobStorageParameterSetName)]
        public LogEntryType LogLevel { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = TableStorageParameterSetName)]
        [Parameter(Mandatory = false, ParameterSetName = BlobStorageParameterSetName)]
        public string StorageAccountName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = TableStorageParameterSetName)]
        public string StorageTableName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = BlobStorageParameterSetName)]
        public string StorageBlobContainerName { get; set; }

        public override void ExecuteCmdlet()
        {
            var properties = new Dictionary<DiagnosticProperties, object>();
            properties[DiagnosticProperties.LogLevel] = LogLevel;

            if (File.IsPresent)
            {
                WebsitesClient.EnableApplicationDiagnostic(Name, WebsiteDiagnosticOutput.FileSystem, properties, Slot);
            }
            else if (TableStorage.IsPresent || BlobStorage.IsPresent)
            {
                if (string.IsNullOrWhiteSpace(StorageAccountName))
                {
                    properties[DiagnosticProperties.StorageAccountName] = Profile.Context.Subscription.GetStorageAccountName();
                }
                else
                {
                    properties[DiagnosticProperties.StorageAccountName] = StorageAccountName;
                }

                if (TableStorage.IsPresent)
                {
                    properties[DiagnosticProperties.StorageTableName] = string.IsNullOrEmpty(StorageTableName)
                        ? "websitesapplogs" + Name.ToLowerInvariant() : StorageTableName.ToLowerInvariant();

                    WebsitesClient.EnableApplicationDiagnostic(Name, WebsiteDiagnosticOutput.StorageTable, properties, Slot);
                }
                else
                {
                    // Blob storage

                    properties[DiagnosticProperties.StorageBlobContainerName] = string.IsNullOrEmpty(StorageBlobContainerName)
                        ? "websitesapplogs-" + Name.ToLowerInvariant() : StorageBlobContainerName.ToLowerInvariant();

                    WebsitesClient.EnableApplicationDiagnostic(Name, WebsiteDiagnosticOutput.StorageBlob, properties, Slot);
                }
            }
            else
            {
                throw new PSArgumentException();
            }

            if (PassThru.IsPresent)
            {
                WriteObject(true);
            }
        }
    }
}
