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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Management.Compute.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMSourceImage", DefaultParameterSetName = ImageReferenceSkuParameterSet),OutputType(typeof(PSVirtualMachine))]
    public class SetAzureVMSourceImageCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        protected const string ImageReferenceSkuParameterSet = "ImageReferenceSkuParameterSet";
        protected const string ImageReferenceIdParameterSet = "ImageReferenceIdParameterSet";

        [Alias("VMProfile")]
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(ParameterSetName = ImageReferenceSkuParameterSet, Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string PublisherName { get; set; }

        [Parameter(ParameterSetName = ImageReferenceSkuParameterSet, Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Offer { get; set; }

        [Parameter(ParameterSetName = ImageReferenceSkuParameterSet, Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Skus { get; set; }

        [Parameter(ParameterSetName = ImageReferenceSkuParameterSet, Mandatory = true, Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(ParameterSetName = ImageReferenceIdParameterSet, Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.VM.StorageProfile == null)
            {
                this.VM.StorageProfile = new StorageProfile();
            }

            if (ParameterSetName.Equals(ImageReferenceSkuParameterSet))
            {
                this.VM.StorageProfile.ImageReference = new ImageReference
                {
                    Publisher = PublisherName,
                    Offer = Offer,
                    Sku = Skus,
                    Version = Version
                };
            }
            else
            {
                this.VM.StorageProfile.ImageReference = new ImageReference
                {
                    Id = this.Id
                };
            }

            WriteObject(this.VM);
        }
    }
}
