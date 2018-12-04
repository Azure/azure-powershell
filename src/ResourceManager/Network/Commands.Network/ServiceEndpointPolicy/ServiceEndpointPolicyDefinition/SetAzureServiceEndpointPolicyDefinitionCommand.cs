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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceEndpointPolicyDefinition", DefaultParameterSetName = "SetByResource", SupportsShouldProcess = true), OutputType(typeof(PSServiceEndpointPolicy))]
    public class SetAzureServiceEndpointPolicyDefinitionCommand : AzureServiceEndpointPolicyDefinitionBase
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the policy definition")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The ServiceEndpointPolicy")]
        public PSServiceEndpointPolicy ServiceEndpointPolicy { get; set; }

        public override void Execute()
        {
            if (this.ShouldProcess(Name, VerbsLifecycle.Restart))
            {
                base.Execute();

                // Verify if the subnet exists in the NetworkSecurityGroup
                var serviceEndpointPolicyDefinition = this.ServiceEndpointPolicy.ServiceEndpointPolicyDefinitions.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

                if (serviceEndpointPolicyDefinition == null)
                {
                    throw new ArgumentException("serviceEndpointPolicyDefinition with the specified name does not exist");
                }

                serviceEndpointPolicyDefinition.Description = this.Description;
                serviceEndpointPolicyDefinition.Service = this.Service;
                serviceEndpointPolicyDefinition.serviceResources = new List<string>();

                foreach (string resource in this.ServiceResource)
                {
                    serviceEndpointPolicyDefinition.serviceResources.Add(resource);
                }

                WriteObject(this.ServiceEndpointPolicy);
            }
        }
    }
}
