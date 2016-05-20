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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        /// <summary>
        /// Creates a new policy or updates an already existing policy
        /// </summary>
        /// <param name="policyName">Name of the policy</param>
        /// <param name="request">Policy create or update request</param>
        /// <returns>Policy created by this operation</returns>
        public ProtectionPolicyResponse CreateOrUpdateProtectionPolicy(
                string policyName,
                ProtectionPolicyRequest request)
        {           
            return BmsAdapter.Client.ProtectionPolicies.CreateOrUpdateAsync(
                                     BmsAdapter.GetResourceGroupName(),
                                     BmsAdapter.GetResourceName(), 
                                     policyName, 
                                     request,
                                     BmsAdapter.GetCustomRequestHeaders(),
                                     BmsAdapter.CmdletCancellationToken).Result;            
        }

        /// <summary>
        /// Gets a protection policy given the name
        /// </summary>
        /// <param name="policyName">Name of the policy</param>
        /// <returns>Policy response returned by the service</returns>
        public ProtectionPolicyResponse GetProtectionPolicy(string policyName)
        {
            return BmsAdapter.Client.ProtectionPolicies.GetAsync(
                                     BmsAdapter.GetResourceGroupName(),
                                     BmsAdapter.GetResourceName(),
                                     policyName,
                                     BmsAdapter.GetCustomRequestHeaders(),
                                     BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// Lists protection policies according to the input query filter
        /// </summary>
        /// <param name="queryFilter">Query filter</param>
        /// <returns>List of protection policies</returns>
        public ProtectionPolicyListResponse ListProtectionPolicy(
                                            ProtectionPolicyQueryParameters queryFilter)
        {           
            return BmsAdapter.Client.ProtectionPolicies.ListAsync(
                                     BmsAdapter.GetResourceGroupName(),
                                     BmsAdapter.GetResourceName(),
                                     queryFilter,
                                     BmsAdapter.GetCustomRequestHeaders(),
                                     BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// Gets protection policy operation status using the operation tracking URL
        /// </summary>
        /// <param name="url">Operation tracking URL</param>
        /// <returns>Operation status response returned by the service</returns>
        public BackUpOperationStatusResponse GetProtectionPolicyOperationStatusByURL(string url)
        {
            return BmsAdapter.Client.GetOperationStatusByURLAsync(
                              url,
                              BmsAdapter.GetCustomRequestHeaders(),
                              BmsAdapter.CmdletCancellationToken).Result;                              
        }

        /// <summary>
        /// Deletes protection policy from the vault specified by the name
        /// </summary>
        /// <param name="policyName">Name of the policy to be deleted</param>
        public AzureOperationResponse RemoveProtectionPolicy(
                string policyName)
        {
            return BmsAdapter.Client.ProtectionPolicies.DeleteAsync(
                                     BmsAdapter.GetResourceGroupName(),
                                     BmsAdapter.GetResourceName(),
                                     policyName,
                                     BmsAdapter.GetCustomRequestHeaders(),
                                     BmsAdapter.CmdletCancellationToken).Result;
        }
    }
}
