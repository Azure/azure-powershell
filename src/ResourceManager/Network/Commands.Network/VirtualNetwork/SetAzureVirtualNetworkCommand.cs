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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [CmdletOutputBreakingChange(typeof(PSVirtualNetwork), DeprecatedOutputProperties = new string[] { "EnableVmProtection" })]
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetwork"), OutputType(typeof(PSVirtualNetwork))]
    public class SetAzureVirtualNetworkCommand : VirtualNetworkBaseCmdlet
    {        
        [CmdletParameterBreakingChange("VirtualNetwork", ChangeDescription = "The EnableVMProtection property for the parameter Virtualnetwork is no longer supported. Setting this property has no impact. This property will be removed in a future release. Please remove it from your scripts")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtualNetwork")]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!this.IsVirtualNetworkPresent(this.VirtualNetwork.ResourceGroupName, this.VirtualNetwork.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var vnetModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetwork>(this.VirtualNetwork);
            vnetModel.Tags = TagsConversionHelper.CreateTagDictionary(this.VirtualNetwork.Tag, validate: true);

            // Execute the Create VirtualNetwork call
            this.VirtualNetworkClient.CreateOrUpdate(this.VirtualNetwork.ResourceGroupName, this.VirtualNetwork.Name, vnetModel);

            var getVirtualNetwork = this.GetVirtualNetwork(this.VirtualNetwork.ResourceGroupName, this.VirtualNetwork.Name);
            WriteObject(getVirtualNetwork);
        }
    }
}
