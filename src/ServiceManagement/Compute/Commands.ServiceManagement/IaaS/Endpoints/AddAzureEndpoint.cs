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
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Endpoints
{
    [Cmdlet(VerbsCommon.Add, "AzureEndpoint", DefaultParameterSetName = AddAzureEndpoint.NoLBParameterSet), OutputType(typeof(IPersistentVM))]
    public class AddAzureEndpoint : VirtualMachineConfigurationCmdletBase 
    {
        private const string NoLBParameterSet = "NoLB";
        private const string LBNoProbeParameterSet = "LBNoProbe";
        private const string LBDefaultProbeParameterSet = "LBDefaultProbe";
        private const string LBCustomProbeParameterSet = "LBCustomProbe";

        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Endpoint name")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "Endpoint protocol.")]
        [ValidateSet("tcp", "udp", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Protocol { get; set; }

        [Parameter(Position = 2, Mandatory = true, HelpMessage = "Local port.")]
        [ValidateNotNullOrEmpty]
        public int LocalPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Public port.")]
        [ValidateNotNullOrEmpty]
        public int? PublicPort { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Enable Direct Server Return")]
        public bool? DirectServerReturn { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "ACL Config for the endpoint.")]
        public NetworkAclObject ACL { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AddAzureEndpoint.LBNoProbeParameterSet, HelpMessage = "Load Balanced Endpoint Set Name")]
        [Parameter(Mandatory = true, ParameterSetName = AddAzureEndpoint.LBDefaultProbeParameterSet, HelpMessage = "Load Balanced Endpoint Set Name")]
        [Parameter(Mandatory = true, ParameterSetName = AddAzureEndpoint.LBCustomProbeParameterSet, HelpMessage = "Load Balanced Endpoint Set Name")]
        [Alias("LoadBalancedEndpointSetName")]
        [ValidateNotNullOrEmpty]
        public string LBSetName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AddAzureEndpoint.LBNoProbeParameterSet, HelpMessage = "Specifies that no load balancer probe is to be used.")]
        public SwitchParameter NoProbe { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AddAzureEndpoint.LBDefaultProbeParameterSet, HelpMessage = "Specifies that the default load balancer probe is to be used.")]
        public SwitchParameter DefaultProbe { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AddAzureEndpoint.LBCustomProbeParameterSet, HelpMessage = "Probe Port")]
        public int ProbePort { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = AddAzureEndpoint.LBCustomProbeParameterSet, HelpMessage = "Probe Protocol (http/tcp)")]
        [ValidateSet("tcp", "http", IgnoreCase = true)]
        public string ProbeProtocol { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AddAzureEndpoint.LBCustomProbeParameterSet, HelpMessage = "Probe Relative Path")]
        [ValidateNotNullOrEmpty]
        public string ProbePath { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AddAzureEndpoint.LBCustomProbeParameterSet, HelpMessage = "Probe Interval in Seconds.")]
        [ValidateNotNull]
        public int? ProbeIntervalInSeconds { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = AddAzureEndpoint.LBCustomProbeParameterSet, HelpMessage = "Probe Timeout in Seconds.")]
        [ValidateNotNull]
        public int? ProbeTimeoutInSeconds { get; set; }

        [Parameter(HelpMessage = "Internal Load Balancer Name.")]
        [ValidateNotNullOrEmpty]
        public string InternalLoadBalancerName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Idle Timeout.")]
        [ValidateNotNullOrEmpty]
        public int? IdleTimeoutInMinutes { get; set; }

        [Parameter(HelpMessage = "LoadBalancerDistribution.")]
        [ValidateSet("sourceIP", "sourceIPProtocol", "none", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string LoadBalancerDistribution { get; set; }

        [Parameter(HelpMessage = "The Virtual IP Name of the Virtual IP on which the endpoint is to be added.")]
        [ValidateNotNullOrEmpty]
        public string VirtualIPName { get; set;}

        internal void ExecuteCommand()
        {
            this.ValidateParameters();

            var endpoints = GetInputEndpoints();
            var endpoint = endpoints.SingleOrDefault(p => p.Name.Equals(this.Name, StringComparison.InvariantCultureIgnoreCase));

            if (endpoint != null)
            {
                ThrowTerminatingError(
                    new ErrorRecord(
                            new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.EndpointAlreadyDefinedForVM, this.Name)),
                            string.Empty,
                            ErrorCategory.InvalidData,
                            null));
            }

            endpoint = new InputEndpoint
            {
                Name = this.Name,
                Port = this.ParameterSpecified("PublicPort") ? this.PublicPort : null,
                LocalPort = this.LocalPort,
                Protocol = this.Protocol,
                EndpointAccessControlList = this.ACL,
                EnableDirectServerReturn = this.DirectServerReturn,
                LoadBalancerName = this.InternalLoadBalancerName,
                IdleTimeoutInMinutes = this.ParameterSpecified("IdleTimeoutInMinutes") ? this.IdleTimeoutInMinutes : null,
                LoadBalancerDistribution = this.ParameterSpecified("LoadBalancerDistribution") ? this.LoadBalancerDistribution : null,
                VirtualIPName = this.ParameterSpecified("VirtualIPName") ? this.VirtualIPName : null, 
            };

            if (this.ParameterSetName == AddAzureEndpoint.LBNoProbeParameterSet
                || this.ParameterSetName == AddAzureEndpoint.LBDefaultProbeParameterSet
                || this.ParameterSetName == AddAzureEndpoint.LBCustomProbeParameterSet)
            {
                endpoint.LoadBalancedEndpointSetName = this.LBSetName;

                if (this.ParameterSetName == AddAzureEndpoint.LBDefaultProbeParameterSet)
                {
                    endpoint.LoadBalancerProbe = new LoadBalancerProbe()
                    {
                        Protocol = "TCP",
                        Port = endpoint.LocalPort
                    };
                }
                else if (this.ParameterSetName == AddAzureEndpoint.LBCustomProbeParameterSet)
                {
                    endpoint.LoadBalancerProbe = new LoadBalancerProbe 
                    { 
                        Protocol = this.ProbeProtocol,
                        Port = this.ProbePort
                    };

                    if (endpoint.LoadBalancerProbe.Protocol.Equals("http", StringComparison.OrdinalIgnoreCase))
                    {
                        endpoint.LoadBalancerProbe.Path = this.ParameterSpecified("ProbePath") ? this.ProbePath : "/";
                    }

                    if (this.ParameterSpecified("ProbeIntervalInSeconds"))
                    {
                        endpoint.LoadBalancerProbe.IntervalInSeconds = this.ProbeIntervalInSeconds;
                    }

                    if (this.ParameterSpecified("ProbeTimeoutInSeconds"))
                    {
                        endpoint.LoadBalancerProbe.TimeoutInSeconds = this.ProbeTimeoutInSeconds;
                    }
                }
            }

            endpoints.Add(endpoint);

            this.WriteObject(VM, true);
        }

        protected override void ProcessRecord()
        {
            try
            {
                base.ProcessRecord();
                this.ExecuteCommand();
            }
            catch (Exception ex)
            {
                this.WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
            }
        }

        protected Collection<InputEndpoint> GetInputEndpoints()
        {
            var role = this.VM.GetInstance();

            var networkConfiguration = role.ConfigurationSets
                                        .OfType<NetworkConfigurationSet>()
                                        .SingleOrDefault();

            if (networkConfiguration == null)
            {
                networkConfiguration = new NetworkConfigurationSet();
                role.ConfigurationSets.Add(networkConfiguration);
            }

            if (networkConfiguration.InputEndpoints == null)
            {
                networkConfiguration.InputEndpoints = new Collection<InputEndpoint>();
            }

            return networkConfiguration.InputEndpoints;
        }

        private void ValidateParameters()
        {
            if (this.ParameterSetName == AddAzureEndpoint.LBCustomProbeParameterSet)
            {
                if (this.ProbeProtocol.Equals("tcp", StringComparison.OrdinalIgnoreCase))
                {
                    if (this.ParameterSpecified("ProbePath"))
                    {
                        throw new ArgumentException(Resources.ProbePathIsNotValidWithTcp);
                    }
                }

                if (this.ProbeProtocol.Equals("http", StringComparison.OrdinalIgnoreCase))
                {
                    if (!this.ParameterSpecified("ProbePath"))
                    {
                        throw new ArgumentException(Resources.ProbePathIsRequiredForHttp);
                    }
                }
            }

            if (this.LocalPort < 1 || this.LocalPort > 65535)
            {
                throw new ArgumentException(Resources.PortSpecifiedIsNotInRange);
            }

            if (this.ParameterSpecified("PublicPort")
                && (this.PublicPort < 1 || this.PublicPort > 65535))
            {
                throw new ArgumentException(Resources.PortSpecifiedIsNotInRange);
            }

            if (this.ParameterSetName == AddAzureEndpoint.LBCustomProbeParameterSet)
            {
                if (ProbePort < 1 || ProbePort > 65535)
                {
                    throw new ArgumentException(Resources.PortSpecifiedIsNotInRange);
                }
            }
        }

        private bool ParameterSpecified(string parameterName)
        {
            // Check for parameters by name so we can tell the difference between 
            // the user not specifying them, and the user specifying null/empty.
            return this.MyInvocation.BoundParameters.ContainsKey(parameterName);
        }
    }
}