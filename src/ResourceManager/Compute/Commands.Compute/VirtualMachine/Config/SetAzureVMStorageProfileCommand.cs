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
    /// <summary>
    /// Creates a new resource.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.Storage),
    OutputType(
        typeof(PSVirtualMachine))]
    public class SetAzureVMStorageProfileCommand : AzurePSCmdlet
    {
        protected const string OSDiskNameParamSet = "OSDiskName";
        protected const string SourceImageNameParamSet = "SourceImageName";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMProfile)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VMProfile { get; set; }

        [Parameter(
            ParameterSetName = SourceImageNameParamSet,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMVHDContainer)]
        [ValidateNotNullOrEmpty]
        public string VHDContainer { get; set; }

        [Parameter(
            ParameterSetName = SourceImageNameParamSet,
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMSourceImageName)]
        [ValidateNotNullOrEmpty]
        public string SourceImageName { get; set; }

        [Parameter(
            ParameterSetName = OSDiskNameParamSet,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskName)]
        [ValidateNotNullOrEmpty]
        public string OSDiskName { get; set; }

        [Parameter(
            ParameterSetName = OSDiskNameParamSet,
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMOSDiskVhdUri)]
        [ValidateNotNullOrEmpty]
        public string OSDiskVHDUri { get; set; }

        public override void ExecuteCmdlet()
        {
            var storageProfile = new StorageProfile
            {
                SourceImage = string.IsNullOrEmpty(this.SourceImageName) ? null :
                              new SourceImageReference
                              {
                                  ReferenceUri = this.SourceImageName
                              }.Normalize(this.CurrentContext.Subscription.Id.ToString()),
                OSDisk = !string.IsNullOrEmpty(this.SourceImageName) ? null : new OSDisk
                {
                    Caching = CachingType.ReadWrite,
                    Name = this.OSDiskName,
                    VirtualHardDisk = new VirtualHardDisk
                    {
                        Uri = this.OSDiskVHDUri
                    }
                },
                DataDisks = null,
                DestinationVhdsContainer = string.IsNullOrEmpty(this.VHDContainer) ? null : new Uri(this.VHDContainer)
            };

            this.VMProfile.StorageProfile = storageProfile;

            WriteObject(this.VMProfile);
        }
    }
}
