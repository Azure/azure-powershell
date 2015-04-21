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
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.SourceImage),
    OutputType(
        typeof(PSVirtualMachine))]
    public class SetAzureVMSourceImageCommand : AzurePSCmdlet
    {
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
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMSourceImageName)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.VM.StorageProfile == null)
            {
                this.VM.StorageProfile = new StorageProfile();
            }

            this.VM.StorageProfile.SourceImage = string.IsNullOrEmpty(this.Name) ? null :
                new SourceImageReference
                {
                    ReferenceUri = this.Name
                }.Normalize(this.Profile.Context.Subscription.Id.ToString());

            WriteObject(this.VM);
        }
    }
}
