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
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    public class AzureLoadBalancerRuleConfigBase : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the load balancer rule")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
           ParameterSetName = "SetByResourceId",
           HelpMessage = "ID of the FrontendIpConfiguration")]
        [ValidateNotNullOrEmpty]
        public string FrontendIpConfigurationId { get; set; }

        [Parameter(
            ParameterSetName = "SetByResourceId",
            HelpMessage = "ID of the BackendAddressPool")]
        [ValidateNotNullOrEmpty]
        public string BackendAddressPoolId { get; set; }

        [Parameter(
            ParameterSetName = "SetByResourceId",
            HelpMessage = "ID of the Probe")]
        [ValidateNotNullOrEmpty]
        public string ProbeId { get; set; }

        [Parameter(
              ParameterSetName = "SetByResource",
              HelpMessage = "Frontend Ip config")]
        [ValidateNotNullOrEmpty]
        public PSFrontendIPConfiguration FrontendIpConfiguration { get; set; }

        [Parameter(
             ParameterSetName = "SetByResource",
             HelpMessage = "The list of frontend Ip config")]
        public PSBackendAddressPool BackendAddressPool { get; set; }

        [Parameter(
             ParameterSetName = "SetByResource",
             HelpMessage = "The list of frontend Ip config")]
        public PSProbe Probe { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The transport protocol for the external endpoint.")]
        [ValidateSet(MNM.TransportProtocol.Tcp, MNM.TransportProtocol.Udp, IgnoreCase = true)]
        public string Protocol { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The frontend port")]
        public int FrontendPort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The frontend port")]
        public int BackendPort { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "IdleTimeoutInMinutes")]
        public int IdleTimeoutInMinutes { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The distribution type of the load balancer.")]
        [ValidateSet(
            "Default",
            "SourceIP",
            "SourceIPProtocol",
            IgnoreCase = true)]
        public string LoadDistribution { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "EnableFloatingIP")]
        public SwitchParameter EnableFloatingIP { get; set; }

        public override void Execute()
        {
            

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResource))
            {
                if (this.BackendAddressPool != null)
                {
                    this.BackendAddressPoolId = this.BackendAddressPool.Id;
                }

                if (this.Probe != null)
                {
                    this.ProbeId = this.Probe.Id;
                }

                if (this.FrontendIpConfiguration != null)
                {
                    this.FrontendIpConfigurationId = this.FrontendIpConfiguration.Id;
                }
            }
        }
    }
}
