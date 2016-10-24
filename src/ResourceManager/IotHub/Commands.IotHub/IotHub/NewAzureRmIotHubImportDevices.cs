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

namespace Microsoft.Azure.Commands.Management.IotHub
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;

    [Cmdlet(VerbsCommon.New, "AzureRmIotHubImportDevices")]
    [OutputType(typeof(JobResponse))]
    public class NewAzureRmIotHubImportDevices : IotHubBaseCmdlet
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Resource Group")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The BlobContainerUri to import from")]
        [ValidateNotNullOrEmpty]
        public string InputBlobContainerUri { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The BlobContainerUri to write output to")]
        [ValidateNotNullOrEmpty]
        public string OutputBlobContainerUri { get; set; }

        public override void ExecuteCmdlet()
        {
            var importDevicesRequest = new PSImportDevicesRequest()
            {
                InputBlobContainerUri = this.InputBlobContainerUri,
                OutputBlobContainerUri = this.OutputBlobContainerUri
            };

            JobResponse jobResponse = this.IotHubClient.IotHubResource.ImportDevices(this.ResourceGroupName, this.Name, IotHubUtils.ToImportDevicesRequest(importDevicesRequest));
            this.WriteObject(IotHubUtils.ToPSIotHubJobResponse(jobResponse), false);
        }
    }
}
