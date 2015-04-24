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

using System;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using AutoMapper;
using Microsoft.WindowsAzure.Commands.ServiceManagement;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Management.Compute;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Endpoints
{
    using NSM = Management.Compute.Models;
    using PVM = Model;

    [Cmdlet(VerbsCommon.Set, "AzureLoadBalancedEndpoint", DefaultParameterSetName = SetAzureLoadBalancedEndpoint.DefaultProbeParameterSet), OutputType(typeof(ManagementOperationContext))]
    public class SetAzureLoadBalancedEndpoint : IaaSDeploymentManagementCmdletBase
    {
        public const string DefaultProbeParameterSet = "DefaultProbe";
        public const string TCPProbeParameterSet = "TCPProbe";
        public const string HTTPProbeParameterSet = "HTTPProbe";
                
        [Parameter(Mandatory = true, HelpMessage = "Load balancer set name.")]
        [ValidateNotNullOrEmpty]
        public string LBSetName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Endpoint protocol.")]
        [ValidateSet("TCP", "UDP", IgnoreCase = true)]
        public string Protocol { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Private port.")]
        public int LocalPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Public port.")]
        public int PublicPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enable Direct Server Return")]
        public bool DirectServerReturn { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "ACLs to specify with the endpoint.")]
        [ValidateNotNull]
        public PVM.NetworkAclObject ACL { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetAzureLoadBalancedEndpoint.TCPProbeParameterSet, HelpMessage = "Should a TCP probe should be used.")]
        public SwitchParameter ProbeProtocolTCP { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetAzureLoadBalancedEndpoint.HTTPProbeParameterSet, HelpMessage = "Should a HTTP probe should be used.")]
        public SwitchParameter ProbeProtocolHTTP { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = SetAzureLoadBalancedEndpoint.HTTPProbeParameterSet, HelpMessage = "Relative path to the HTTP probe.")]
        [ValidateNotNullOrEmpty]
        public string ProbePath { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SetAzureLoadBalancedEndpoint.TCPProbeParameterSet, HelpMessage = "Probe port.")]
        [Parameter(Mandatory = false, ParameterSetName = SetAzureLoadBalancedEndpoint.HTTPProbeParameterSet, HelpMessage = "Probe port.")]
        public int ProbePort { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SetAzureLoadBalancedEndpoint.TCPProbeParameterSet, HelpMessage = "Probe interval in seconds.")]
        [Parameter(Mandatory = false, ParameterSetName = SetAzureLoadBalancedEndpoint.HTTPProbeParameterSet, HelpMessage = "Probe interval in seconds.")]
        public int ProbeIntervalInSeconds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = SetAzureLoadBalancedEndpoint.TCPProbeParameterSet, HelpMessage = "Probe timeout in seconds.")]
        [Parameter(Mandatory = false, ParameterSetName = SetAzureLoadBalancedEndpoint.HTTPProbeParameterSet, HelpMessage = "Probe timeout in seconds.")]
        public int ProbeTimeoutInSeconds { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Internal Load Balancer Name.")]
        public string InternalLoadBalancerName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Idle Timeout.")]
        [ValidateNotNullOrEmpty]
        public int IdleTimeoutInMinutes { get; set; }

        [Parameter(HelpMessage = "LoadBalancerDistribution.")]
        [ValidateSet("sourceIP", "sourceIPProtocol", "none", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string LoadBalancerDistribution { get; set; }

        [Parameter(HelpMessage = "The Virtual IP Name of the Virtual IP on which the endpoint is to be added.")]
        [ValidateNotNullOrEmpty]
        public string VirtualIPName { get; set; }

        protected override void ExecuteCommand()
        {
            ServiceManagementProfile.Initialize();

            base.ExecuteCommand();
            if (string.IsNullOrEmpty(this.ServiceName) || this.CurrentDeploymentNewSM == null)
            {
                return;
            }

            var endpoint = this.GetEndpoint();
            if(endpoint == null)
            {
                this.ThrowTerminatingError(
                    new ErrorRecord(
                        new InvalidOperationException(
                            string.Format(
                                CultureInfo.InvariantCulture, 
                                Resources.EndpointsCannotBeFoundWithGivenLBSetName, 
                                this.LBSetName)),
                        string.Empty,
                        ErrorCategory.InvalidData,
                        null));
            }

            this.UpdateEndpointProperties(endpoint);
            
            var endpointList = new PVM.LoadBalancedEndpointList();
            endpointList.Add(endpoint);

            var endPointParams = new NSM.VirtualMachineUpdateLoadBalancedSetParameters
            {
                //TODO: AutoMapper doesn't seem to work for this conversion.
                //LoadBalancedEndpoints = Mapper.Map<IList<VirtualMachineUpdateLoadBalancedSetParameters.InputEndpoint>>(endpointList)
                LoadBalancedEndpoints = new int[1].Select(e => new NSM.VirtualMachineUpdateLoadBalancedSetParameters.InputEndpoint
                {
                    EnableDirectServerReturn = endpoint.EnableDirectServerReturn,
                    LoadBalancedEndpointSetName = endpoint.LoadBalancedEndpointSetName,
                    LoadBalancerProbe = endpoint.LoadBalancerProbe == null ? null : new NSM.LoadBalancerProbe
                    {
                        IntervalInSeconds = endpoint.LoadBalancerProbe.IntervalInSeconds,
                        Path = endpoint.LoadBalancerProbe.Path,
                        Port = endpoint.LoadBalancerProbe.Port,
                        Protocol = (NSM.LoadBalancerProbeTransportProtocol)Enum.Parse(typeof(NSM.LoadBalancerProbeTransportProtocol), endpoint.LoadBalancerProbe.Protocol, true),
                        TimeoutInSeconds = endpoint.LoadBalancerProbe.TimeoutInSeconds
                    },
                    LocalPort = endpoint.LocalPort,
                    Name = endpoint.Name,
                    Port = endpoint.Port,
                    Protocol = endpoint.Protocol,
                    Rules = endpoint.EndpointAccessControlList == null ? null : endpoint.EndpointAccessControlList.Rules == null ? null : endpoint.EndpointAccessControlList.Rules.Select(r => new NSM.AccessControlListRule
                    {
                        Action = r.Action,
                        Description = r.Description,
                        Order = r.Order,
                        RemoteSubnet = r.RemoteSubnet
                    }).ToList(),
                    VirtualIPAddress = endpoint.Vip,
                    LoadBalancerName = this.InternalLoadBalancerName,
                    IdleTimeoutInMinutes = endpoint.IdleTimeoutInMinutes,
                    LoadBalancerDistribution = endpoint.LoadBalancerDistribution,
                    VirtualIPName = endpoint.VirtualIPName,
                }).ToList()
            };

            this.ExecuteClientActionNewSM(
                null,
                this.CommandRuntime.ToString(),
                () => this.ComputeClient.VirtualMachines.UpdateLoadBalancedEndpointSet(this.ServiceName, this.CurrentDeploymentNewSM.Name, endPointParams));
        }

        private PVM.InputEndpoint GetEndpoint()
        {
            var r = from role in this.CurrentDeploymentNewSM.Roles
                    // TODO: NetworkConfigurationSet's string value should be 'NetworkConfiguration' instead of 'NetworkConfigurationSet'
                    // https://github.com/WindowsAzure/azure-sdk-for-net-pr/issues/293
                    //from networkConfig in role.ConfigurationSets.Where(c => c.ConfigurationSetType == ConfigurationSetTypes.NetworkConfigurationSet)
                    from networkConfig in role.ConfigurationSets.Where(c => c.ConfigurationSetType == "NetworkConfiguration")
                    where networkConfig.InputEndpoints != null
                    from endpoint in networkConfig.InputEndpoints
                    where !string.IsNullOrEmpty(endpoint.LoadBalancedEndpointSetName)
                      && endpoint.LoadBalancedEndpointSetName.Equals(this.LBSetName, StringComparison.InvariantCultureIgnoreCase)
                    select endpoint;

            return Mapper.Map<NSM.InputEndpoint, PVM.InputEndpoint>(r.FirstOrDefault());
        }

        private void UpdateEndpointProperties(PVM.InputEndpoint endpoint)
        {
            if (this.ParameterSpecified("Protocol"))
            {
                endpoint.Protocol = this.Protocol;
            }

            if (this.ParameterSpecified("LocalPort"))
            {
                if (!this.ParameterSpecified("ProbePort")
                    && endpoint.LoadBalancerProbe != null
                    && endpoint.LocalPort == endpoint.LoadBalancerProbe.Port)
                {
                    endpoint.LoadBalancerProbe.Port = this.LocalPort;
                }

                endpoint.LocalPort = this.LocalPort;
            }

            if (this.ParameterSpecified("PublicPort"))
            {
                endpoint.Port = this.PublicPort;
            }

            if (this.ParameterSpecified("IdleTimeoutInMinutes"))
            {
                endpoint.IdleTimeoutInMinutes = this.IdleTimeoutInMinutes;
            }

            if (this.ParameterSpecified("LoadBalancerDistribution"))
            {
                endpoint.LoadBalancerDistribution = this.LoadBalancerDistribution;
            }

            if (this.ParameterSpecified("VirtualIPName"))
            {
                endpoint.VirtualIPName = this.VirtualIPName;
            }

            if (this.ParameterSpecified("DirectServerReturn"))
            {
                endpoint.EnableDirectServerReturn = this.DirectServerReturn;
            }

            if (this.ParameterSpecified("ACL"))
            {
                endpoint.EndpointAccessControlList = this.ACL;
            }

            if (this.ParameterSetName == SetAzureLoadBalancedEndpoint.HTTPProbeParameterSet
                || this.ParameterSetName == SetAzureLoadBalancedEndpoint.TCPProbeParameterSet)
            {
                if (endpoint.LoadBalancerProbe == null)
                {
                    endpoint.LoadBalancerProbe = new PVM.LoadBalancerProbe();
                    if (!this.ParameterSpecified("ProbePort"))
                    {
                        endpoint.LoadBalancerProbe.Port = endpoint.LocalPort;
                    }
                }

                if (this.ParameterSpecified("ProbePort"))
                {
                    endpoint.LoadBalancerProbe.Port = this.ProbePort;
                }

                if (this.ParameterSpecified("ProbeIntervalInSeconds"))
                {
                    endpoint.LoadBalancerProbe.IntervalInSeconds = this.ProbeIntervalInSeconds;
                }

                if (this.ParameterSpecified("ProbeTimeoutInSeconds"))
                {
                    endpoint.LoadBalancerProbe.TimeoutInSeconds = this.ProbeTimeoutInSeconds;
                }

                if (this.ParameterSetName == SetAzureLoadBalancedEndpoint.HTTPProbeParameterSet)
                {
                    endpoint.LoadBalancerProbe.Protocol = "http";
                    endpoint.LoadBalancerProbe.Path = this.ProbePath;
                }

                if (this.ParameterSetName == SetAzureLoadBalancedEndpoint.TCPProbeParameterSet)
                {
                    endpoint.LoadBalancerProbe.Protocol = "tcp";
                    endpoint.LoadBalancerProbe.Path = null;
                }
            }
        }

        private bool ParameterSpecified(string parameterName)
        {
            return this.MyInvocation.BoundParameters.ContainsKey(parameterName);
        }
    }
}
