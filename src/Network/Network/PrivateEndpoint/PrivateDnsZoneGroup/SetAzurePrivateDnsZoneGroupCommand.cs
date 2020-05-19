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
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsZoneGroup", SupportsShouldProcess = true), OutputType(typeof(PSPrivateDnsZoneGroup))]
    public class SetAzurePrivateDnsZoneGroupCommand : PrivateDnsZoneGroupBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the private endpoint.")]
        [ValidateNotNullOrEmpty]
        public virtual string PrivateEndpointName { get; set; }

        [Alias("PrivateDnsZoneGroupName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the private dns zone group.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }
        
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A collection of private dns zone configurations of the private dns zone group.")]
        public virtual List<PSPrivateDnsZoneConfig> PrivateDnsZoneConfig { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            var group = CreatePSPrivateDnsZoneGroup();
            WriteObject(group);
        }

        private PSPrivateDnsZoneGroup CreatePSPrivateDnsZoneGroup()
        {
            var psPrivateDnsZoneGroup = new PSPrivateDnsZoneGroup
            {
                Name = Name,
                PrivateDnsZoneConfigs = PrivateDnsZoneConfig
            };

            var peModel = NetworkResourceManagerProfile.Mapper.Map<PrivateDnsZoneGroup>(psPrivateDnsZoneGroup);
            var privateDnsZoneGroup = this.PrivateDnsZoneGroupClient.CreateOrUpdate(ResourceGroupName, PrivateEndpointName, Name, peModel);
            return ToPsPrivateDnsZoneGroup(privateDnsZoneGroup);
        }
    }
}
