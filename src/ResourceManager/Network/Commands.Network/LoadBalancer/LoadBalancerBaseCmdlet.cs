
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
using Microsoft.Azure.Management.Network.Models;
using System.Net;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class LoadBalancerBaseCmdlet : NetworkBaseCmdlet
    {
        public ILoadBalancersOperations LoadBalancerClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.LoadBalancers;
            }
        }

        public bool IsLoadBalancerPresent(string resourceGroupName, string name)
        {
            try
            {
                GetLoadBalancer(resourceGroupName, name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    return false;
                }

                throw;
            }

            return true;
        }

        public PSLoadBalancer GetLoadBalancer(string resourceGroupName, string name, string expandResource = null)
        {
            var lb = this.LoadBalancerClient.Get(resourceGroupName, name, expandResource);

            var psLoadBalancer = Mapper.Map<PSLoadBalancer>(lb);
            psLoadBalancer.ResourceGroupName = resourceGroupName;
            psLoadBalancer.Tag =
                TagsConversionHelper.CreateTagHashtable(lb.Tags);

            return psLoadBalancer;
        }

        public PSLoadBalancer ToPsLoadBalancer(LoadBalancer lb)
        {
            var psLb = Mapper.Map<PSLoadBalancer>(lb);

            psLb.Tag = TagsConversionHelper.CreateTagHashtable(lb.Tags);

            return psLb;
        }
    }
}