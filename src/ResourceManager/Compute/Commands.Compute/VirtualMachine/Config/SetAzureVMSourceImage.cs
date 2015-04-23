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
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.Set, ProfileNouns.SourceImage, DefaultParameterSetName = ImageReferenceParameterSet),
    OutputType(typeof(PSVirtualMachine))]
    public class SetAzureVMSourceImageCommand : AzurePSCmdlet
    {
        protected const string ImageReferenceParameterSet = "ImageReferenceParameterSet";
        protected const string SourceImageParameterSet = "SourceImageParameterSet";

        [Alias("VMProfile")]
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMProfile)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Alias("SourceImageName", "ImageName")]
        [Parameter(
            ParameterSetName = SourceImageParameterSet,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMSourceImageName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        [Alias("ImageConfig", "Image")]
        [Parameter(
            ParameterSetName = ImageReferenceParameterSet,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMImageReference)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachineImage ImageReference { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.VM.StorageProfile == null)
            {
                this.VM.StorageProfile = new StorageProfile();
            }

            if (this.ParameterSetName == SourceImageParameterSet)
            {
                this.VM.StorageProfile.SourceImage = string.IsNullOrEmpty(this.Name) ? null :
                    new SourceImageReference
                    {
                        ReferenceUri = this.Name
                    }.Normalize(this.Profile.Context.Subscription.Id.ToString());
            }
            else if (this.ParameterSetName == ImageReferenceParameterSet)
            {
                this.VM.StorageProfile.ImageReference = new ImageReference
                {
                    Publisher = ImageReference.PublisherName,
                    Offer = ImageReference.Offer,
                    Sku = ImageReference.Skus,
                    Version = ImageReference.Version
                };
            }

            WriteObject(this.VM);
        }
    }
}
