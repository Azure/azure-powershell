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

namespace Microsoft.Azure.Commands.Network
{
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceEndpointPolicy", SupportsShouldProcess = true, DefaultParameterSetName = "ListParameterSet"), OutputType(typeof(PSServiceEndpointPolicy))]
    public class GetAzureServiceEndpointPolicyCommand : ServiceEndpointPolicyBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            ParameterSetName = "ListParameterSet",
            HelpMessage = "The name of the service endpoint policy")]
        [ResourceNameCompleter("Microsoft.Network/serviceEndpointPolicies", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.",
           ParameterSetName = "ListParameterSet")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = "GetByResourceIdParameterSet")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        public override void Execute()
        {
            if (this.ShouldProcess(Name, VerbsLifecycle.Restart))
            {
                base.Execute();

                if (this.IsParameterBound(c => c.ResourceId))
                {
                    var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                    this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                    this.Name = resourceIdentifier.ResourceName;
                }

                if (ShouldGetByName(ResourceGroupName, Name))
                {
                    PSServiceEndpointPolicy serviceEndpointPolicy;
                    serviceEndpointPolicy = this.GetServiceEndpointPolicy(this.ResourceGroupName, this.Name);
                    WriteObject(serviceEndpointPolicy);
                }
                else
                {
                    IEnumerable<PSServiceEndpointPolicy> serviceEndpointPolicies = null;
                    if (ShouldListByResourceGroup(ResourceGroupName, Name))
                    {
                        serviceEndpointPolicies = ListServiceEndpointPolicies(this.ResourceGroupName);
                    }
                    else
                    {
                        serviceEndpointPolicies = ListServiceEndpointPolicies(string.Empty);
                    }

                    WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, serviceEndpointPolicies), true);
                }
            }
        }
    }
}
