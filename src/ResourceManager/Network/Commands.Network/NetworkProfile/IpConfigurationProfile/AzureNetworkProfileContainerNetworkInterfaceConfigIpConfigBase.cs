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

using Microsoft.Azure.Commands.Network.Models;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureNetworkProfileContainerNetworkInterfaceConfigIpConfigBase : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of the container network interface configuration ip configuration")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "SubnetId")]
        [ValidateNotNullOrEmpty]
        public virtual string SubnetId { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "SetByResource",
            HelpMessage = "Subnet")]
        public virtual PSSubnet Subnet { get; set; }

        public override void Execute()
        {
            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (this.Subnet != null)
                {
                    this.SubnetId = this.Subnet.Id;
                }
            }
        }
    }
}
