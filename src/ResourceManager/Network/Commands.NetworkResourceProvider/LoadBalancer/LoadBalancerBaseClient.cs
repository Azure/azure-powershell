
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
using System.Net;
using AutoMapper;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    public abstract class LoadBalancerBaseClient : NetworkResourceBaseClient
    {
        public ILoadBalancerOperations LoadBalancerClient
        {
            get
            {
                return NetworkClient.NetworkResourceProviderClient.LoadBalancers;
            }
        }

        public bool IsLoadBalancerPresent(string resourceGroupName, string name)
        {
            try
            {
                GetLoadBalancer(resourceGroupName, name);
            }
            catch (CloudException exception)
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

        public PSLoadBalancer GetLoadBalancer(string resourceGroupName, string name)
        {
            var getLoadBalancerResponse = this.LoadBalancerClient.Get(resourceGroupName, name);

            var loadBalancer = Mapper.Map<PSLoadBalancer>(getLoadBalancerResponse.LoadBalancer);
            loadBalancer.ResourceGroupName = resourceGroupName;
            loadBalancer.PropertiesText = JsonConvert.SerializeObject(loadBalancer.Properties, Formatting.Indented);
            return loadBalancer;
        }
    }
}