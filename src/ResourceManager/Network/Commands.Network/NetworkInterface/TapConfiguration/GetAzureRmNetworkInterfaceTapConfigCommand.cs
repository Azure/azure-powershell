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
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkInterfaceTapConfig"), OutputType(typeof(PSNetworkInterfaceTapConfiguration))]
    public partial class GetAzureRmNetworkInterfaceTapConfigCommand : NetworkInterfaceTapConfigBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The Network Interface name.")]
        [ValidateNotNullOrEmpty]
        public string NetworkInterfaceName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of the specific tap configuration.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!string.IsNullOrEmpty(this.Name))
            {
                var vnet = this.GetNetworkInterfaceTapConfiguration(this.ResourceGroupName, this.NetworkInterfaceName, this.Name);

                WriteObject(vnet);
            }
            else
            {
                // Uncomments this when GetEnumerator operation works on NetworkInterfaceTapConfig
                //var tapConfigList = this.NetworkInterfaceTapClient.ListWithHttpMessagesAsync(this.ResourceGroupName, this.NetworkInterfaceName).GetAwaiter().GetResult();

                //var psTapConfigs = new List<PSNetworkInterfaceTapConfiguration>();
                //foreach (var tapConfig in tapConfigList)
                //{
                //    var psTapConfig = this.ToPSNetworkInterfaceTapConfiguration(tapConfig);
                //    psTapConfig.ResourceGroupName = this.ResourceGroupName;
                //    psTapConfig.NetworkInterfaceName = this.NetworkInterfaceName;
                //    psTapConfigs.Add(psTapConfig);
                //}

                var networkInterface = this.GetNetworkInterface(this.ResourceGroupName, this.NetworkInterfaceName);
                var psTapConfigs = new List<PSNetworkInterfaceTapConfiguration>();
                if (networkInterface != null)
                {
                    psTapConfigs = networkInterface.TapConfigurations;
                }

                WriteObject(psTapConfigs, true);
            }
        }
    }
}
