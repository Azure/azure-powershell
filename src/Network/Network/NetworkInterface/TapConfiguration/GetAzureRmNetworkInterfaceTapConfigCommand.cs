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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkInterfaceTapConfig", SupportsShouldProcess = true, DefaultParameterSetName = "GetByNameParameterSet"), OutputType(typeof(PSNetworkInterfaceTapConfiguration))]
    public partial class GetAzureRmNetworkInterfaceTapConfigCommand : NetworkInterfaceTapConfigBase
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = "GetByNameParameterSet",
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
           Mandatory = true,
           ParameterSetName = "GetByNameParameterSet",
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The Network Interface name.")]
        [ValidateNotNullOrEmpty]
        public string NetworkInterfaceName { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = "GetByNameParameterSet",
            HelpMessage = "Name of the specific tap configuration.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }


        [Parameter(
            Mandatory = true,
            ParameterSetName = "GetByResourceIdParameterSet",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Equals("GetByResourceIdParameterSet", StringComparison.OrdinalIgnoreCase))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.NetworkInterfaceName = resourceIdentifier.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
                this.Name = resourceIdentifier.ResourceName;
            }

            if (ShouldGetByName(ResourceGroupName, Name))
            {
                var tapConfig = this.GetNetworkInterfaceTapConfiguration(this.ResourceGroupName, this.NetworkInterfaceName, this.Name);

                WriteObject(tapConfig);
            }
            else
            {
                var networkInterface = this.GetNetworkInterface(this.ResourceGroupName, this.NetworkInterfaceName);
                var psTapConfigs = new List<PSNetworkInterfaceTapConfiguration>();
                if (networkInterface != null)
                {
                    psTapConfigs = networkInterface.TapConfigurations;
                }

                WriteObject(SubResourceWildcardFilter(Name, psTapConfigs), true);
            }
        }
    }
}
