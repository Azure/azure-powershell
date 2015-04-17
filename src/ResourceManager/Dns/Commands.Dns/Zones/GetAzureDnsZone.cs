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

using System.Collections;
using System.Management.Automation;
using Microsoft.Azure.Commands.Dns.Models;

namespace Microsoft.Azure.Commands.Dns
{
    /// <summary>
    /// Gets one or more existing zones.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureDnsZone"), OutputType(typeof(DnsZone))]
    public class GetAzureDnsZone : DnsBaseCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The full name of the zone (without a terminating dot).")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The resource group in which the zone exists.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.Name != null)
            {
                WriteObject(this.DnsClient.GetDnsZone(this.Name, this.ResourceGroupName));
            }
            else
            {
                WriteObject(this.DnsClient.ListDnsZones(this.ResourceGroupName));
            }
        }
    }
}
