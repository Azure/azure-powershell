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
    [Cmdlet(VerbsCommon.Set, "AzureEndpoint"), OutputType(typeof(IPersistentVM))]
    public class SetAzureEndpoint : VirtualMachineConfigurationCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "Endpoint name.")]
        [ValidateNotNullOrEmpty]
        public string Name 
        {
            get; 
            set; 
        }

        [Parameter(Position = 1, Mandatory = false, HelpMessage = "Endpoint protocol.")]
        [ValidateSet("tcp", "udp", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string Protocol
        { 
            get; 
            set; 
        }

        [Parameter(Position = 2, Mandatory = false, HelpMessage = "Local port.")]
        [ValidateNotNullOrEmpty]
        public int LocalPort
        { 
            get; 
            set; 
        }

        [Parameter(Mandatory = false, HelpMessage = "Public port.")]
        [ValidateNotNullOrEmpty]
        public int? PublicPort 
        { 
            get; 
            set;
        }


        [Parameter(Mandatory = false, HelpMessage = "Enable Direct Server Return")]
        [ValidateNotNull]
        public bool? DirectServerReturn
        {
            get; 
            set;
        }

        [Parameter(Mandatory = false, HelpMessage = "ACL Config for the endpoint.")]
        [ValidateNotNull]
        public NetworkAclObject ACL
        {
            get; 
            set; 
        }

        [Parameter(HelpMessage = "Internal Load Balancer Name.")]
        [ValidateNotNullOrEmpty]
        public string InternalLoadBalancerName
        {
            get;
            set;
        }

        [Parameter(Mandatory = false, HelpMessage = "Idle Timeout.")]
        public int IdleTimeoutInMinutes
        {
            get; 
            set;
        }

        [Parameter(HelpMessage = "LoadBalancerDistribution.")]
        [ValidateSet("sourceIP", "sourceIPProtocol", "none", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string LoadBalancerDistribution
        {
            get;
            set;
        }

        [Parameter(HelpMessage = "The Virtual IP Name of the Virtual IP on which the endpoint is to be added.")]
        [ValidateNotNullOrEmpty]
        public string VirtualIPName
        {
            get; 
            set;
        }

        internal void ExecuteCommand()
        {
            ValidateParameters();

            var endpoints = GetInputEndpoints();
            var endpoint = endpoints.SingleOrDefault(p => p.Name.Equals(Name, StringComparison.InvariantCultureIgnoreCase));

            if (endpoint == null)
            {
                ThrowTerminatingError(
                    new ErrorRecord(
                            new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, Resources.EndpointCanNotBeFoundInVMConfigurationInSetAzureEndpoint, this.Name)),
                            string.Empty,
                            ErrorCategory.InvalidData,
                            null));
            }
            
            if (this.ParameterSpecified("Protocol"))
            {
                endpoint.Protocol = this.Protocol;
            }
            
            if (this.ParameterSpecified("LocalPort"))
            {
                endpoint.LocalPort = this.LocalPort;
            }

            if (this.ParameterSpecified("PublicPort"))
            {
                endpoint.Port = this.PublicPort;
            }

            if (this.ParameterSpecified("DirectServerReturn"))
            {
                endpoint.EnableDirectServerReturn = this.DirectServerReturn;
            }

            if (this.ParameterSpecified("ACL"))
            {
                endpoint.EndpointAccessControlList = this.ACL;
            }

            if (!string.IsNullOrEmpty(this.InternalLoadBalancerName))
            {
                endpoint.LoadBalancerName = this.InternalLoadBalancerName;
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

            WriteObject(VM, true);
        }

        protected override void ProcessRecord()
        {
            try
            {
                base.ProcessRecord();
                ExecuteCommand();
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(ex, string.Empty, ErrorCategory.CloseError, null));
            }
        }

        protected Collection<InputEndpoint> GetInputEndpoints()
        {
            var role = VM.GetInstance(); 

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

            var inputEndpoints = networkConfiguration.InputEndpoints;
            return inputEndpoints;
        }

        private void ValidateParameters()
        {
            if (LocalPort < 0 || LocalPort > 65535)
            {
                throw new ArgumentException(Resources.PortsNotInRangeInSetAzureEndpoint);
            }

            if (PublicPort != null && (PublicPort < 0 || PublicPort > 65535))
            {
                throw new ArgumentException(Resources.PortsNotInRangeInSetAzureEndpoint);
            }
        }

        private bool ParameterSpecified(string parameterName)
        {
            return this.MyInvocation.BoundParameters.ContainsKey(parameterName);
        }
    }
}