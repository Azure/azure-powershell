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

using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsData.Export, "AzureRemoteAppUserDisk", SupportsShouldProcess = true)]
    public class ExportAzureRemoteAppUserDisk : RdsCmdlet
    {
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp source collection name")]
        [ValidatePattern(NameValidatorString)]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Destination azure storage account name")]
        public string DestinationStorageAccountName { get; set; }

        [Parameter(Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Destination azure storage account key")]
        public string DestinationStorageAccountKey { get; set; }

        [Parameter(Mandatory = true,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Destination azure storage account container name")]
        public string DestinationStorageAccountContainerName { get; set; }

        public override void ExecuteCmdlet()
        {
            OperationResultWithTrackingId response = null;

            if (ShouldProcess(CollectionName, "Overwrite existing user disks while exporting user disks of collection"))
            {
                response = CallClient(() => Client.UserDisks.Migrate(CollectionName, DestinationStorageAccountName, DestinationStorageAccountKey, DestinationStorageAccountContainerName, true), Client.UserDisks);
            }
            else
            {
                response = CallClient(() => Client.UserDisks.Migrate(CollectionName, DestinationStorageAccountName, DestinationStorageAccountKey, DestinationStorageAccountContainerName, false), Client.UserDisks);
            }

            if (response != null)
            {
                WriteTrackingId(response);
            }
        }
    }
}