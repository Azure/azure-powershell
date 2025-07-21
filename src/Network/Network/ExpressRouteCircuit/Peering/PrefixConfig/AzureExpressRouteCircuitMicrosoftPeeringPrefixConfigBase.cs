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
    using System.Management.Automation;
    using System.Net;

    public class AzureExpressRouteCircuitMicrosoftPeeringPrefixConfigBase : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "PeerAddressType")]
        [ValidateSet(
           IPv4,
           IPv6,
           IgnoreCase = true)]
        public string PeerAddressType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Prefix")]
        [ValidateNotNullOrEmpty]
        public string Prefix { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "ValidationId")]
        [ValidateNotNullOrEmpty]
        public string ValidationId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Signature")]
        [ValidateNotNullOrEmpty]
        public string Signature { get; set; }

        public override void Execute()
        {
            this.Prefix = this.Prefix.Trim();
            IPAddress ipAddress;
            try
            {
                ipAddress = IPAddress.Parse(Prefix.Split('/')[0]);
            }
            catch
            {
                throw new PSArgumentException("Invalid Prefix");
            }

            if (PeerAddressType == IPv4 && ipAddress.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
            {
                throw new PSArgumentException("Invalid Prefix");
            }
            else if (PeerAddressType == IPv6 && ipAddress.AddressFamily != System.Net.Sockets.AddressFamily.InterNetworkV6)
            {
                throw new PSArgumentException("Invalid Prefix");
            }
        }
    }
}
