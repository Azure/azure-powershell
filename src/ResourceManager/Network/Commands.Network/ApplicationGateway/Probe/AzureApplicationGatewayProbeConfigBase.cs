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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureApplicationGatewayProbeConfigBase : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "Name of the probe")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Protocol used to send probe")]
        [ValidateSet("Http", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Protocol { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "Host name to send probe to")]
        [ValidateNotNullOrEmpty]
        public string HostName { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "Relative path of probe. Valid path starts from '/'. Probe is sent to <Protocol>://<host>:<port><path>")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "Probe interval in seconds. This is the time interval between two consecutive probes")]
        [ValidateNotNullOrEmpty]
        public uint Interval { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "Probe timeout in seconds. Probe marked as failed if valid response is not received with this timeout period")]
        [ValidateNotNullOrEmpty]
        public uint Timeout { get; set; }

        [Parameter(
           Mandatory = true,
           HelpMessage = "Probe  retry count. Backend server is marked down after consecutive probe failure count reaches UnhealthyThreshold")]
        [ValidateNotNullOrEmpty]
        public uint UnhealthyThreshold { get; set; }

        public PSApplicationGatewayProbe NewObject()
        {
            var probe = new PSApplicationGatewayProbe();
            probe.Name = this.Name;
            probe.Protocol = this.Protocol;
            probe.Host = this.HostName;
            probe.Path = this.Path;
            probe.Interval = this.Interval;
            probe.Timeout = this.Timeout;
            probe.UnhealthyThreshold = this.UnhealthyThreshold;

            probe.Id =
                ApplicationGatewayChildResourceHelper.GetResourceNotSetId(
                    this.NetworkClient.NetworkManagementClient.SubscriptionId,
                    Microsoft.Azure.Commands.Network.Properties.Resources.ApplicationGatewayProbeName,
                    this.Name);

            return probe;
        }
    }
}
