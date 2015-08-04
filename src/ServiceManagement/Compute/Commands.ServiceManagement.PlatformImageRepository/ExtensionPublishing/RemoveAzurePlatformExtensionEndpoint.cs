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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.ExtensionPublishing
{
    /// <summary>
    /// Remove an Endpoint from the Config Set.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Remove,
        AzurePlatformExtensionEndpointCommandNoun,
        DefaultParameterSetName = InputEndpointParamSetStr),
    OutputType(
        typeof(ExtensionLocalResourceConfigSet))]
    public class RemoveAzurePlatformExtensionEndpointCommand : PSCmdlet
    {
        protected const string AzurePlatformExtensionEndpointCommandNoun = "AzurePlatformExtensionEndpoint";
        protected const string InputEndpointParamSetStr = "InputEndpoint";
        protected const string InternalEndpointParamSetStr = "InternalEndpoint";
        protected const string InstanceInputEndpointParamSetStr = "InstanceInputEndpoint";

        [Parameter(
            Mandatory = true,
            Position = 0,
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

        protected override void ProcessRecord()
        {
            if (this.EndpointConfig != null)
            {
                if (!string.IsNullOrEmpty(this.InputEndpointName))
                {
                    this.EndpointConfig.InputEndpoints.RemoveAll(
                        p => string.Equals(p.Name, this.InputEndpointName, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrEmpty(this.InternalEndpointName))
                {
                    this.EndpointConfig.InternalEndpoints.RemoveAll(
                        p => string.Equals(p.Name, this.InternalEndpointName, StringComparison.OrdinalIgnoreCase));
                }
            }

            WriteObject(this.EndpointConfig);
        }
    }
}
