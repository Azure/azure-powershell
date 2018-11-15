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
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Setup the network interface.
    /// </summary>
#if NETSTANDARD
    [CmdletOutputBreakingChange(typeof(PSVirtualMachineIdentity), DeprecatedOutputProperties = new string[] { "IdentityIds" })]
#endif
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMNetworkInterface",SupportsShouldProcess = true),OutputType(typeof(PSVirtualMachine))]
    public class RemoveAzureVMNetworkInterfaceCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
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

        [Alias("Id", "NicIds")]
        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.VMNetworkInterfaceID)]
        [ValidateNotNullOrEmpty]
        public string[] NetworkInterfaceIDs { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess("NetworkInterface", VerbsCommon.Remove))
            {
                var networkProfile = this.VM.NetworkProfile;

                if (NetworkInterfaceIDs == null)
                {
                    networkProfile.NetworkInterfaces.Clear();
                }
                else
                {
                    foreach (var id in this.NetworkInterfaceIDs)
                    {
                        if (networkProfile != null &&
                            networkProfile.NetworkInterfaces != null &&
                            networkProfile.NetworkInterfaces.Any(nic =>
                                string.Equals(nic.Id, id, StringComparison.OrdinalIgnoreCase)))
                        {
                            var nicReference = networkProfile.NetworkInterfaces.First(nic => string.Equals(nic.Id, id, StringComparison.OrdinalIgnoreCase));
                            networkProfile.NetworkInterfaces.Remove(nicReference);
                        }
                    }
                }

                this.VM.NetworkProfile = networkProfile;

                WriteObject(this.VM);
            }
        }
    }
}
