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

namespace Microsoft.Azure.Commands.PrivateDns.Zones
{
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.PrivateDns.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    /// <summary>
    /// Gets one or more existing zones.
    /// </summary>
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PrivateDnsZone", DefaultParameterSetName = ParameterSetDefault), OutputType(typeof(PSPrivateDnsZone))]
    public class GetAzurePrivateDnsZone : PrivateDnsBaseCmdlet
    {
        private const string ParameterSetDefault = "Default";

        [Parameter(Mandatory = false, ParameterSetName = ParameterSetDefault, HelpMessage = "The resource group in which the private zone exists.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ParameterSetDefault, HelpMessage = "The full name of the private zone (without a terminating dot).")]
        [ResourceNameCompleter("Microsoft.Network/privateDnsZones", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                if (this.Name.EndsWith("."))
                {
                    this.Name = this.Name.TrimEnd('.');
                    this.WriteWarning(
                        $"Modifying Private DNS zone name to remove terminating '.'. Private Zone name used is \"{this.Name}\".");
                }

                if (!string.IsNullOrEmpty(this.ResourceGroupName))
                {
                    this.WriteObject(this.PrivateDnsClient.GetPrivateDnsZone(this.Name, this.ResourceGroupName));
                }
                else
                {
                    var zones = this.PrivateDnsClient.ListPrivateDnsZonesInSubscription();
                    var resultZones = new List<PSPrivateDnsZone>();
                    foreach (var zone in zones)
                    {
                        if (zone.Name.Equals(this.Name))
                        {
                            resultZones.Add(zone);
                        }
                    }

                    this.WriteObject(resultZones, true);
                }
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                this.WriteObject(this.PrivateDnsClient.ListPrivateDnsZonesInResourceGroup(this.ResourceGroupName), true);
            }
            else
            {
                this.WriteObject(this.PrivateDnsClient.ListPrivateDnsZonesInSubscription(), true);
            }
        }
    }
}
