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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmApplicationGatewayBackendHealth"), OutputType(typeof(PSApplicationGatewayBackendHealth))]
    public class GetAzureApplicationGatewayBackendHealthCommand : ApplicationGatewayBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
             HelpMessage = "The resource reference to be expanded.",
             ParameterSetName = "Expand")]
        [ValidateNotNullOrEmpty]
        public string ExpandResource { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var backendHealth = this.ApplicationGatewayClient.BackendHealth(ResourceGroupName, Name, ExpandResource);
            var psBackendHealth = Mapper.Map<PSApplicationGatewayBackendHealth>(backendHealth);
            WriteObject(psBackendHealth);
        }
    }
}

