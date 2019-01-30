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
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Management.Network;
    using System.Linq;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ServiceEndpointPolicy", SupportsShouldProcess = true), OutputType(typeof(PSServiceEndpointPolicy))]
    public class NewAzureServiceEndpointPolicyCommand : ServiceEndpointPolicyBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The name of the subnet")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of service endpoint definitions")]
        [ValidateNotNullOrEmpty]
        public PSServiceEndpointPolicyDefinition[] ServiceEndpointPolicyDefinition { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "location.")]
        [ValidateNotNullOrEmpty]
        [LocationCompleter("Microsoft.Network/connections")]
        public virtual string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsServiceEndpointPolicyPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var serviceEndpointPolicy = CreateServiceEndpointPolicy();
                    WriteObject(serviceEndpointPolicy);
                },
                () => present);
        }

        public PSServiceEndpointPolicy CreateServiceEndpointPolicy()
        {
            PSServiceEndpointPolicy serviceEndpointPolicy = new PSServiceEndpointPolicy();
            serviceEndpointPolicy.Name = this.Name;
            serviceEndpointPolicy.ResourceGroupName = this.ResourceGroupName;
            serviceEndpointPolicy.Location = this.Location;

            if (ServiceEndpointPolicyDefinition != null)
            {
                serviceEndpointPolicy.ServiceEndpointPolicyDefinitions = this.ServiceEndpointPolicyDefinition?.ToList();
            }

            var  serviceEndpointPolicyModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ServiceEndpointPolicy>(serviceEndpointPolicy);

            this.ServiceEndpointPolicyClient.CreateOrUpdate(this.ResourceGroupName, this.Name, serviceEndpointPolicyModel);

            var getServiceEndpointPolicy = this.GetServiceEndpointPolicy(this.ResourceGroupName, this.Name);

            return getServiceEndpointPolicy;
        }
    }
}
