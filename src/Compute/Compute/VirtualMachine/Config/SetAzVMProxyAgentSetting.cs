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


using System;
using System.Collections.Generic;
using System.Text;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VMProxyAgentSetting"), OutputType(typeof(PSVirtualMachine))]
    public class SetAzureVMProxySetting : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Alias("VirtualMachine")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "PSVirtualMachine object created from New-AzVMConfig.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Specifies whether Metadata Security Protocol(ProxyAgent) feature should be enabled or not.")]
        public bool? EnableProxyAgent { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Specifies the Wire Server endpoint execution mode while creating the virtual machine or virtual machine scale set. In Audit mode, the system acts as if it is enforcing the access control policy, including emitting access denial entries in the logs but it does not actually deny any requests to host endpoints. In Enforce mode, the system will enforce the access control and it is the recommended mode of operation.")]
        [PSArgumentCompleter("Audit", "Enforce", "Disabled")]
        public string WireServerMode { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the InVMAccessControlProfileVersion resource id in the Wire Server endpoint. Format of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/galleries/{galleryName}/inVMAccessControlProfiles/{profile}/versions/{version}")]
        public string WireServerProfile{ get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Specifies the IMDS endpoint execution mode. In Audit mode, the system acts as if it is enforcing the access control policy, including emitting access denial entries in the logs but it does not actually deny any requests to host endpoints. In Enforce mode, the system will enforce the access control and it is the recommended mode of operation.")]
        [PSArgumentCompleter("Audit", "Enforce", "Disabled")]
        public string ImdsMode { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the InVMAccessControlProfileVersion resource id in the IMDS enpoint. Format of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/galleries/{galleryName}/inVMAccessControlProfiles/{profile}/versions/{version}")]
        public string ImdsProfile { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Increase the value of this parameter allows users to reset the key used for securing communication channel between guest and host.")]
        public int? KeyIncarnationId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.VM.SecurityProfile == null)
            {
                this.VM.SecurityProfile = new SecurityProfile();
            }
            this.VM.SecurityProfile.ProxyAgentSettings = new ProxyAgentSettings
            {
                Enabled = this.EnableProxyAgent,
                WireServer = (this.WireServerMode == null && this.WireServerProfile == null ? null : new HostEndpointSettings()
                {
                    Mode = this.WireServerMode,
                    InVMAccessControlProfileReferenceId = this.WireServerProfile
                }),
                Imds = (this.ImdsMode == null && this.ImdsProfile == null ? null : new HostEndpointSettings()
                {
                    Mode = this.ImdsMode,
                    InVMAccessControlProfileReferenceId = this.ImdsProfile
                }),
                KeyIncarnationId = this.KeyIncarnationId
            };

            WriteObject(this.VM);
        }
    }

}