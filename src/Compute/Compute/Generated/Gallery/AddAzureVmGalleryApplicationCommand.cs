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

using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using System.Collections.Generic;


namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet("Add", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmGalleryApplication", SupportsShouldProcess = true)]
    [OutputType(typeof(PSVirtualMachine))]
    public class AddAzureVmGalleryApplicationCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The PSVirtualMachine object to add a Gallery Application Reference ID.")]
        public PSVirtualMachine VM { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "VM Gallery Application Object.")]
        public PSVMGalleryApplication GalleryApplication { get; set; }

        [Parameter(
            Mandatory = false)]
        public int Order { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "If true, any failure for any operation in the VmApplication will fail the deployment. Defaults to false if not specified.")]
        public SwitchParameter TreatFailureAsDeploymentFailure { get; set; }

        public override void ExecuteCmdlet()
        {
            if (VM.ApplicationProfile == null)
            {
                VM.ApplicationProfile = new PSApplicationProfile();
            }
            if (VM.ApplicationProfile.GalleryApplications == null)
            {
                VM.ApplicationProfile.GalleryApplications = new List<PSVMGalleryApplication>();
            }

            if (this.IsParameterBound(c => c.Order))
            {
                GalleryApplication.Order = this.Order;
            }

            if (this.TreatFailureAsDeploymentFailure.IsPresent)
            {
                GalleryApplication.TreatFailureAsDeploymentFailure = true;
            }

            VM.ApplicationProfile.GalleryApplications.Add(GalleryApplication);

            WriteObject(VM);
        }
    }
}
