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

using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsZoneConfig", DefaultParameterSetName = "List"), OutputType(typeof(PSPrivateDnsZoneConfig))]
    public class GetAzurePrivateDnsZoneConfigCommand : PrivateDnsZoneGroupBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.", ParameterSetName = "List")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.", ParameterSetName = "GetByName")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the private endpoint.", ParameterSetName = "List")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the private endpoint.", ParameterSetName = "GetByName")]
        [ValidateNotNullOrEmpty]
        public string PrivateEndpointName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the private dns zone group.", ParameterSetName = "List")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the private dns zone group.", ParameterSetName = "GetByName")]
        [ValidateNotNullOrEmpty]
        public string PrivateDnsZoneGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the private dns zone configuration.", ParameterSetName = "GetByName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();
            var zoneGroup = this.GetPrivateDnsZoneGroup(this.ResourceGroupName, this.PrivateEndpointName, this.PrivateDnsZoneGroupName);
            if (MyInvocation.BoundParameters.ContainsKey("Name"))
            {
                foreach(PSPrivateDnsZoneConfig config in zoneGroup.PrivateDnsZoneConfigs)
                {
                    if(Name.Equals(config.Name)) {
                        WriteObject(config);
                    }
                }
            } else
            {
                WriteObject(zoneGroup.PrivateDnsZoneConfigs);
            }
        }

    }
}
