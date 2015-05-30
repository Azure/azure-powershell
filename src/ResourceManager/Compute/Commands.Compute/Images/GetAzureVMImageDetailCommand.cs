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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.Get, ProfileNouns.VirtualMachineImageDetail)]
    [OutputType(typeof(PSVirtualMachineImageDetail))]
    public class GetAzureVMImageDetailCommand : VirtualMachineImageBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true), ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true), ValidateNotNullOrEmpty]
        public string PublisherName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true), ValidateNotNullOrEmpty]
        public string Offer { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true), ValidateNotNullOrEmpty]
        public string Skus { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true), ValidateNotNullOrEmpty]
        public string Version { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            WriteWarning(Properties.Resources.DeprecationOfGetAzureVMImageDetail);

            var parameters = new VirtualMachineImageGetParameters
            {
                Location = Location.Canonicalize(),
                PublisherName = PublisherName,
                Offer = Offer,
                Skus = Skus,
                Version = Version
            };

            VirtualMachineImageGetResponse response = this.VirtualMachineImageClient.Get(parameters);

            var image = new PSVirtualMachineImageDetail
            {
                RequestId = response.RequestId,
                StatusCode = response.StatusCode,
                Id = response.VirtualMachineImage.Id,
                Location = response.VirtualMachineImage.Location,
                Name = response.VirtualMachineImage.Name,
                OSDiskImage = response.VirtualMachineImage.OSDiskImage,
                DataDiskImages = response.VirtualMachineImage.DataDiskImages,
                PurchasePlan = response.VirtualMachineImage.PurchasePlan,
                PublisherName = this.PublisherName,
                Offer = this.Offer,
                Skus = this.Skus,
                Version = this.Version
            };

            WriteObject(image);
        }
    }
}
