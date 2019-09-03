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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkInterfaceTapConfig", DefaultParameterSetName = "SetByResource", SupportsShouldProcess = true), OutputType(typeof(PSNetworkInterface))]
    public partial class SetAzureRmNetworkInterfaceTapConfigCommand : NetworkInterfaceTapConfigBase
    {
        [Parameter(
           Mandatory = true,
           ValueFromPipeline = true,
           HelpMessage = "The NetworkInterface Tap configuration")]
        public PSNetworkInterfaceTapConfiguration NetworkInterfaceTapConfig { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();


            if (NetworkInterfaceTapConfig != null)
            {
                // If ExpressRouteCrossConnection object is provided
                ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, NetworkInterfaceTapConfig.Name),
                Properties.Resources.CreatingResourceMessage,
                NetworkInterfaceTapConfig.Name,
                () =>
                {
                    if (!this.IsNetworkInterfaceTapPresent(this.NetworkInterfaceTapConfig.ResourceGroupName, this.NetworkInterfaceTapConfig.NetworkInterfaceName, this.NetworkInterfaceTapConfig.Name))
                    {
                        throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
                    }

                    // Map to the sdk object
                    var tapConfigModel = NetworkResourceManagerProfile.Mapper.Map<MNM.NetworkInterfaceTapConfiguration>(this.NetworkInterfaceTapConfig);

                    // Execute the Create VirtualNetwork call
                    this.NetworkInterfaceTapClient.CreateOrUpdate(this.NetworkInterfaceTapConfig.ResourceGroupName, this.NetworkInterfaceTapConfig.NetworkInterfaceName, this.NetworkInterfaceTapConfig.Name, tapConfigModel);
                    var getTapconfig = this.GetNetworkInterfaceTapConfiguration(this.NetworkInterfaceTapConfig.ResourceGroupName, this.NetworkInterfaceTapConfig.NetworkInterfaceName, this.NetworkInterfaceTapConfig.Name);

                    WriteObject(getTapconfig);
                });
            }
        }
    }
}
