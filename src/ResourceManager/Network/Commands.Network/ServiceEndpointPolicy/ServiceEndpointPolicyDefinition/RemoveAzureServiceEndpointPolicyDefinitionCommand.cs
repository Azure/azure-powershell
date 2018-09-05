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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceEndpointPolicyDefinition", DefaultParameterSetName = "RemoveByNameParameterSet", SupportsShouldProcess = true), OutputType(typeof(PSServiceEndpointPolicy))]
    public class RemoveAzureServiceEndpointPolicyDefinitionCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            ParameterSetName = "RemoveByNameParameterSet",
            HelpMessage = "The name of the service endpoint definition")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "DeleteByResourceIdParameterSet")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "DeleteByInputObjectParameterSet")]
        [ValidateNotNullOrEmpty]
        public PSServiceEndpointPolicyDefinition InputObject
        {
            get; set;
        }

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

                if (this.IsParameterBound(c => c.InputObject))
                {
                    this.Name = this.InputObject.Name;
                }

                if (this.IsParameterBound(c => c.ResourceId))
                {
                    var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                    this.Name = resourceIdentifier.ResourceName;
                }

                // Verify if the rule exists in the NetworkSecurityGroup
                var serviceEndpointPolicyDefinition = this.ServiceEndpointPolicy.ServiceEndpointPolicyDefinitions.SingleOrDefault(resource => string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

                if (serviceEndpointPolicyDefinition != null)
                {
                    this.ServiceEndpointPolicy.ServiceEndpointPolicyDefinitions.Remove(serviceEndpointPolicyDefinition);
                }

                WriteObject(this.ServiceEndpointPolicy);
            }
        }
    }
}
