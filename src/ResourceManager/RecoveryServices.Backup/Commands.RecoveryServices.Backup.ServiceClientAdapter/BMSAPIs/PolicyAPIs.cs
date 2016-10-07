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
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;

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
        public Microsoft.Rest.Azure.AzureOperationResponse<ProtectionPolicyResource> CreateOrUpdateProtectionPolicy(
                string policyName,
                ProtectionPolicyResource request)
        {           
            return BmsAdapter.Client.ProtectionPolicies.CreateOrUpdateWithHttpMessagesAsync(
                                     BmsAdapter.GetResourceName(),
                                     BmsAdapter.GetResourceGroupName(),
                                     policyName, 
                                     request,
                                     cancellationToken: BmsAdapter.CmdletCancellationToken).Result;            
        }

        /// <summary>
        /// Gets a protection policy given the name
        /// </summary>
        /// <param name="policyName">Name of the policy</param>
        /// <returns>Policy response returned by the service</returns>
        public ProtectionPolicyResource GetProtectionPolicy(string policyName)
        {
            return BmsAdapter.Client.ProtectionPolicies.GetWithHttpMessagesAsync(
                                     BmsAdapter.GetResourceName(),
                                     BmsAdapter.GetResourceGroupName(),
                                     policyName,
                                     cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;
        }

        /// <summary>
        /// Lists protection policies according to the input query filter
        /// </summary>
        /// <param name="queryFilter">Query filter</param>
        /// <returns>List of protection policies</returns>
        public List<ProtectionPolicyResource> ListProtectionPolicy(
                                            Microsoft.Rest.Azure.OData.ODataQuery<ProtectionPolicyQueryObject> queryFilter,
                                            string skipToken = default(string))
        {
            Func<Microsoft.Rest.Azure.IPage<ProtectionPolicyResource>> listAsync =
                () => BmsAdapter.Client.ProtectionPolicies.ListWithHttpMessagesAsync(
                                     BmsAdapter.GetResourceName(),
                                     BmsAdapter.GetResourceGroupName(),
                                     queryFilter,
                                     cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            Func<string, Microsoft.Rest.Azure.IPage<ProtectionPolicyResource>> listNextAsync =
                nextLink => BmsAdapter.Client.ProtectionPolicies.ListNextWithHttpMessagesAsync(
                                     nextLink,
                                     cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            return HelperUtils.GetPagedList<ProtectionPolicyResource>(listAsync, listNextAsync);
        }        

        /// <summary>
        /// Deletes protection policy from the vault specified by the name
        /// </summary>
        /// <param name="policyName">Name of the policy to be deleted</param>
        public Microsoft.Rest.Azure.AzureOperationResponse RemoveProtectionPolicy(
                string policyName)
        {
            return BmsAdapter.Client.ProtectionPolicies.DeleteWithHttpMessagesAsync(
                                     BmsAdapter.GetResourceName(),
                                     BmsAdapter.GetResourceGroupName(),
                                     policyName,
                                     cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
        }
    }
}