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

namespace Microsoft.Azure.Commands.Network.VirtualNetwork.ServiceEndpointPolicies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using MNM = Microsoft.Azure.Management.Network.Models;

    [Cmdlet(VerbsCommon.New, "AzureRmPublicIpAddress", SupportsShouldProcess = true),
    OutputType(typeof(PSServiceEndpointPolicy))]
    class NewAzureServiceEndpointPolicyCommand : ServiceEndpointPolicyBaseCmdlet
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
        public List<PSServiceEndpointPolicyDefinition> ServiceEndpointDefinitions { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");
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

            if (ServiceEndpointDefinitions != null)
            {
                serviceEndpointPolicy.ServiceEndpointPolicyDefinitions = this.ServiceEndpointDefinitions;
            }

            var  serviceEndpointPolicyModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ServiceEndpointPolicy>(serviceEndpointPolicy);

            this.ServiceEndpointPolicyClient.CreateOrUpdateWithHttpMessagesAsync(this.ResourceGroupName, this.Name, serviceEndpointPolicyModel);

            var getServiceEndpointPolicy = this.GetServiceEndpointPolicy(this.ResourceGroupName, this.Name);

            return getServiceEndpointPolicy;
        }
    }
}