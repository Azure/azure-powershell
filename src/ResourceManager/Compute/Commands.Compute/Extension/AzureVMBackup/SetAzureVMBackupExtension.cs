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
using Microsoft.Azure.Commands.Compute.Extension.AzureVMBackup;
using Microsoft.Azure.Commands.Compute.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    [Cmdlet(
        VerbsCommon.Set,
        ProfileNouns.AzureVMBackupExtension)]
    [OutputType(typeof(PSAzureOperationResponse))]
    public class SetAzureVMBackupExtension : VirtualMachineExtensionBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           Position = 0,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine name.")]
        [ValidateNotNullOrEmpty]
        public string VMName { get; set; }

        [Alias("ExtensionName")]
        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The extension name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The tag for this backup.")]
        public string Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            AzureVMBackupExtensionUtil azureBackupExtensionUtil = new AzureVMBackupExtensionUtil();

            AzureVMBackupConfig vmConfig = new AzureVMBackupConfig();
            vmConfig.ResourceGroupName = ResourceGroupName;
            vmConfig.VMName = this.VMName;
            vmConfig.ExtensionName = this.Name;
            vmConfig.VirtualMachineExtensionType = VirtualMachineExtensionType;

            azureBackupExtensionUtil.CreateSnapshotForDisks(vmConfig, Tag, this);
        }
    }
}
