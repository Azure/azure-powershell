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

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AllVpnServerConfigurationRadiusServerSecret"), OutputType(typeof(PSVpnServerConfiguration))]
    public class GetAzAllVpnServerConfigurationRadiusServerSecretCommand : VpnServerConfigurationBaseCmdlet
    {
        [Alias("ResourceName", "VpnServerConfigurationName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/vpnServerConfigurations", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        public override void Execute()
        {
            base.Execute();

            List<PSRadiusAuthServer> radiusAuthServers = new List<PSRadiusAuthServer>();
            foreach (var radiusAuthServer in this.VpnServerConfigurationClient.ListRadiusSecrets(this.ResourceGroupName, this.Name).Value)
            {
                radiusAuthServers.Add(NetworkResourceManagerProfile.Mapper.Map<PSRadiusAuthServer>(radiusAuthServer));
            }

            WriteObject(radiusAuthServers, true);
        }
    }
}
