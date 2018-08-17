﻿
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
    using System.Net;
    using Microsoft.Azure.Management.Network;
    using Microsoft.Azure.Management.Network.Models;
    using System.Collections.Generic;
    using Microsoft.Rest.Azure;

    public abstract class ServiceEndpointPolicyBaseCmdlet : NetworkBaseCmdlet
    {
        public IServiceEndpointPoliciesOperations ServiceEndpointPolicyClient
        {
            get
            {
                return NetworkClient.NetworkManagementClient.ServiceEndpointPolicies;
            }
        }

        public bool IsServiceEndpointPolicyPresent(string resourceGroupName, string name)
        {
            try
            {
                GetServiceEndpointPolicy(resourceGroupName, name);
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

        public PSServiceEndpointPolicy GetServiceEndpointPolicy(string resourceGroupName, string name, string expandResource = null)
        {
            var serviceEndpointPolicy = this.ServiceEndpointPolicyClient.Get(resourceGroupName, name, expandResource);

            var pSServiceEndpointPolicy = ToServiceEndpointPolicy(serviceEndpointPolicy);
            pSServiceEndpointPolicy.ResourceGroupName = resourceGroupName;

            return pSServiceEndpointPolicy;
        }

        public IEnumerable<PSServiceEndpointPolicy> ListServiceEndpointPolicies(string resourceGroupName)
        {
            var serviceEndpointPolicies = this.ServiceEndpointPolicyClient.ListByResourceGroup(resourceGroupName);

            List<PSServiceEndpointPolicy> psserviceEndpointPolicies = new List<PSServiceEndpointPolicy>();
            foreach (var policy in serviceEndpointPolicies)
            {
                var pSServiceEndpointPolicy = ToServiceEndpointPolicy(policy);
                pSServiceEndpointPolicy.ResourceGroupName = resourceGroupName;
                psserviceEndpointPolicies.Add(pSServiceEndpointPolicy);
            }
            
            return psserviceEndpointPolicies;
        }

        public PSServiceEndpointPolicy ToServiceEndpointPolicy(ServiceEndpointPolicy serviceEndpointPolicy)
        {
            var pSServiceEndpointPolicy = NetworkResourceManagerProfile.Mapper.Map<PSServiceEndpointPolicy>(serviceEndpointPolicy);
            return pSServiceEndpointPolicy;
        }
    }
}