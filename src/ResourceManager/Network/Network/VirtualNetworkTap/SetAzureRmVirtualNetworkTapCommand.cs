// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Net;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{

    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkTap", SupportsShouldProcess = true), OutputType(typeof(PSVirtualNetworkTap))]
    public class SetAzureVirtualNetworkTapCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtual network tap")]
        public PSVirtualNetworkTap VirtualNetworkTap { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.VirtualNetworkTaps.Get(this.VirtualNetworkTap.ResourceGroupName, this.VirtualNetworkTap.Name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    present = false;
                }
                else
                {
                    throw;
                }
            }

            if(!present)
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var vVirtualNetworkTapModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualNetworkTap>(this.VirtualNetworkTap);
            vVirtualNetworkTapModel.Tags = TagsConversionHelper.CreateTagDictionary(this.VirtualNetworkTap.Tag, validate: true);

            // Execute the PUT VirtualNetworkTap call
            this.NetworkClient.NetworkManagementClient.VirtualNetworkTaps.CreateOrUpdate(this.VirtualNetworkTap.ResourceGroupName, this.VirtualNetworkTap.Name, vVirtualNetworkTapModel);

            var getVirtualNetworkTap = this.NetworkClient.NetworkManagementClient.VirtualNetworkTaps.Get(this.VirtualNetworkTap.ResourceGroupName, this.VirtualNetworkTap.Name);
            var psVirtualNetworkTap = NetworkResourceManagerProfile.Mapper.Map<PSVirtualNetworkTap>(getVirtualNetworkTap);
            psVirtualNetworkTap.ResourceGroupName = this.VirtualNetworkTap.ResourceGroupName;
            psVirtualNetworkTap.Tag = TagsConversionHelper.CreateTagHashtable(getVirtualNetworkTap.Tags);
            WriteObject(psVirtualNetworkTap, true);
        }
    }
}
