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
using System;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApplicationGatewayProbeConfig"), OutputType(typeof(PSApplicationGateway))]
    public class UpdateAzureApplicationGatewayProbeConfigCommand : AzureApplicationGatewayProbeConfigBase
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Protocol used to send probe")]
        [ValidateSet("Http", "Https", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public override string Protocol { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Relative path of probe. Valid path starts from '/'. Probe is sent to <Protocol>://<host>:<port><path>")]
        [ValidateNotNullOrEmpty]
        public override string Path { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Probe interval in seconds. This is the time interval between two consecutive probes")]
        [ValidateNotNullOrEmpty]
        public override int Interval { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period")]
        [ValidateNotNullOrEmpty]
        public override int Timeout { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Probe retry count. Backend server is marked down after consecutive probe failure count reaches UnhealthyThreshold")]
        [ValidateNotNullOrEmpty]
        public override int UnhealthyThreshold { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var probe = this.ApplicationGateway.Probes.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

            if (probe == null)
            {
                throw new ArgumentException("Probe with the specified name does not exist");
            }

            if (!string.IsNullOrEmpty(this.Protocol))
            {
                probe.Protocol = this.Protocol;
            }

            if (!string.IsNullOrEmpty(this.HostName))
            {
                probe.Host = this.HostName;
            }

            if (!string.IsNullOrEmpty(this.Path))
            {
                probe.Path = this.Path;
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(this.Interval)))
            {
                probe.Interval = this.Interval;
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(this.Timeout)))
            {
                probe.Timeout = this.Timeout;
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(this.UnhealthyThreshold)))
            {
                probe.UnhealthyThreshold = this.UnhealthyThreshold;
            }

            if (this.PickHostNameFromBackendHttpSettings.IsPresent)
            {
                probe.PickHostNameFromBackendHttpSettings = true;
            }

            if (MyInvocation.BoundParameters.ContainsKey(nameof(this.MinServers)))
            {
                probe.MinServers = this.MinServers;
            }

            if (this.Match != null)
            {
                probe.Match = this.Match;
            }

            WriteObject(this.ApplicationGateway);
        }
    }
}
