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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, "AzureRmLoadBalancer"), OutputType(typeof(PSLoadBalancer))]
    public class SetAzureLoadBalancerCommand : LoadBalancerBaseCmdlet
    {
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The loadBalancer")]
        public PSLoadBalancer LoadBalancer { get; set; }

        public override void Execute()
        {

            base.Execute();
            if (!this.IsLoadBalancerPresent(this.LoadBalancer.ResourceGroupName, this.LoadBalancer.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Normalize the IDs
            ChildResourceHelper.NormalizeChildResourcesId(this.LoadBalancer, this.NetworkClient.NetworkManagementClient.SubscriptionId);

            // Map to the sdk object
            var lbModel = Mapper.Map<MNM.LoadBalancer>(this.LoadBalancer);
            lbModel.Tags = TagsConversionHelper.CreateTagDictionary(this.LoadBalancer.Tag, validate: true);

            // Execute the Create VirtualNetwork call
            this.LoadBalancerClient.CreateOrUpdate(this.LoadBalancer.ResourceGroupName, this.LoadBalancer.Name, lbModel);

            var getLoadBalancer = this.GetLoadBalancer(this.LoadBalancer.ResourceGroupName, this.LoadBalancer.Name);
            WriteObject(getLoadBalancer);
        }
    }
}
