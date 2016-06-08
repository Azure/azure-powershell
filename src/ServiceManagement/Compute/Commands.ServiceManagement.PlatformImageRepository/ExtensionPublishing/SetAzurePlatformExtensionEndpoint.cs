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

using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.ExtensionPublishing
{
    /// <summary>
    /// Add or Update an Endpoint in Config Set.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        AzurePlatformExtensionEndpointCommandNoun,
        DefaultParameterSetName = InputEndpointParamSetStr),
    OutputType(
        typeof(ExtensionEndpointConfigSet))]
    public class SetAzurePlatformExtensionEndpointCommand : PSCmdlet
    {
        protected const string AzurePlatformExtensionEndpointCommandNoun = "AzurePlatformExtensionEndpoint";
        protected const string InputEndpointParamSetStr = "InputEndpoint";
        protected const string InternalEndpointParamSetStr = "InternalEndpoint";
        protected const string InstanceInputEndpointParamSetStr = "InstanceInputEndpoint";

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Endpoint Config Object.")]
        public ExtensionEndpointConfigSet EndpointConfig { get; set; }

        [Parameter(
            ParameterSetName = InputEndpointParamSetStr,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Input Endpoint Name.")]
        public string InputEndpointName { get; set; }

        [Parameter(
            ParameterSetName = InternalEndpointParamSetStr,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Internal Endpoint Name.")]
        public string InternalEndpointName { get; set; }

        [Parameter(
            ParameterSetName = InstanceInputEndpointParamSetStr,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Instance Input Endpoint Name.")]
        public string InstanceInputEndpointName { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 2,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Protocol Name.")]
        [ValidateSet("tcp", "udp", "http", "https", IgnoreCase = true)]
        public string Protocol { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = InputEndpointParamSetStr,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Port for External Endpoint.")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = InternalEndpointParamSetStr,
            Position = 3,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Port for External Endpoint.")]
        [ValidateRange(1, 65535)]
        public int Port { get; set; }

        [Parameter(
            ParameterSetName = InputEndpointParamSetStr,
            Mandatory = true,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Local Port for Input Endpoint.")]
        [Parameter(
            ParameterSetName = InstanceInputEndpointParamSetStr,
            Mandatory = true,
            Position = 4,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Local Port for Instanc Endpoint.")]
        public string LocalPort { get; set; }

        [Parameter(
            ParameterSetName = InstanceInputEndpointParamSetStr,
            Mandatory = true,
            Position = 5,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Min Port Value for Instance Input Endpoint Port Range.")]
        [ValidateRange(1, 65535)]
        public int FixedPortMin { get; set; }

        [Parameter(
            ParameterSetName = InstanceInputEndpointParamSetStr,
            Mandatory = true,
            Position = 6,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Max Port Value for Instance Input Endpoint Port Range.")]
        [ValidateRange(1, 65535)]
        public int FixedPortMax { get; set; }

        protected override void ProcessRecord()
        {
            if (this.EndpointConfig == null)
            {
                this.EndpointConfig = new ExtensionEndpointConfigSet();
            }

            if (!string.IsNullOrEmpty(this.InternalEndpointName))
            {
                if (this.EndpointConfig.InternalEndpoints == null)
                {
                    this.EndpointConfig.InternalEndpoints = new List<ExtensionInternalEndpoint>();
                }

                this.EndpointConfig.InternalEndpoints.Add(new ExtensionInternalEndpoint
                {
                    Name = this.InternalEndpointName,
                    Port = this.Port,
                    Protocol = this.Protocol
                });
            }

            if (!string.IsNullOrEmpty(this.InputEndpointName))
            {
                if (this.EndpointConfig.InputEndpoints == null)
                {
                    this.EndpointConfig.InputEndpoints = new List<ExtensionInputEndpoint>();
                }

                this.EndpointConfig.InputEndpoints.Add(new ExtensionInputEndpoint
                {
                    Name = this.InputEndpointName,
                    Port = this.Port,
                    Protocol = this.Protocol,
                    LocalPort = this.LocalPort
                });
            }

            if (!string.IsNullOrEmpty(this.InstanceInputEndpointName))
            {
                if (this.EndpointConfig.InstanceInputEndpoints == null)
                {
                    this.EndpointConfig.InstanceInputEndpoints = new List<ExtensionInstanceInputEndpoint>();
                }

                this.EndpointConfig.InstanceInputEndpoints.Add(new ExtensionInstanceInputEndpoint
                {
                    Name = this.InstanceInputEndpointName,
                    Protocol = this.Protocol,
                    LocalPort = this.LocalPort,
                    FixedPortMax =  this.FixedPortMax,
                    FixedPortMin = this.FixedPortMin
                });
            }

            WriteObject(this.EndpointConfig);
        }
    }
}
