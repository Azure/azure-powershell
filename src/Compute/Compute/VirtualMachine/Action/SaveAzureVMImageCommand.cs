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
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Save", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMImage", DefaultParameterSetName = ResourceGroupNameParameterSet)]
    [OutputType(typeof(PSComputeLongRunningOperation))]
    public class SaveAzureVMImageCommand : VirtualMachineActionBaseCmdlet
    {
        [Alias("VMName")]
        [Parameter(
           Mandatory = true,
           Position = 1,
           ParameterSetName = ResourceGroupNameParameterSet,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The virtual machine name.")]
        [ResourceNameCompleter("Microsoft.Compute/virtualMachines", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 2,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The Destination Container Name.")]
        [ValidateNotNullOrEmpty]
        public string DestinationContainerName { get; set; }

        [Alias("VirtualHardDiskNamePrefix")]
        [Parameter(
           Mandatory = true,
           Position = 3,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The Virtual Hard Disk Name Prefix.")]
        [ValidateNotNullOrEmpty]
        public string VHDNamePrefix { get; set; }

        [Parameter(
           Position = 4,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "To Overwrite.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Overwrite { get; set; }

        [Parameter(
           Position = 5,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The file path in which the template of the captured image is stored")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            ExecuteClientAction(() =>
            {
                if (!string.IsNullOrEmpty(Id) && string.IsNullOrEmpty(Name))
                {
                    ResourceIdentifier parsedId = new ResourceIdentifier(Id);
                    this.ResourceGroupName = parsedId.ResourceGroupName;
                    this.Name = parsedId.ResourceName;
                }

                var parameters = new VirtualMachineCaptureParameters
                {
                    DestinationContainerName = DestinationContainerName,
                    OverwriteVhds = Overwrite.IsPresent,
                    VhdPrefix = VHDNamePrefix
                };

                var op = this.VirtualMachineClient.CaptureWithHttpMessagesAsync(
                    this.ResourceGroupName,
                    this.Name,
                    parameters).GetAwaiter().GetResult();

                var result = ComputeAutoMapperProfile.Mapper.Map<PSComputeLongRunningOperation>(op);
                result.StartTime = this.StartTime;
                result.EndTime = DateTime.Now;
                if (!string.IsNullOrWhiteSpace(this.Path))
                {
                    File.WriteAllText(ResolveUserPath(this.Path), op.Body.Resources[0].ToString());
                }
                WriteObject(result);
            });
        }
    }
}
