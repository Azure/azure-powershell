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
using System.Collections.Generic;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Helpers;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Properties;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using RestAzureNS = Microsoft.Rest.Azure;
using RestAzureODataNS = Microsoft.Rest.Azure.OData;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS
{
    public partial class ServiceClientAdapter
    {
        /// <summary>
        /// Creates a new policy or updates an already existing policy
        /// </summary>
        /// <param name="policyName">Name of the policy</param>
        /// <param name="request">Policy create or update request</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="auxiliaryAccessToken"></param>
        /// <param name="isMUAProtected"></param>
        /// <returns>Policy created by this operation</returns>
        public RestAzureNS.AzureOperationResponse<ProtectionPolicyResource>
            CreateOrUpdateProtectionPolicy(
                string policyName,
                ProtectionPolicyResource request,
                string vaultName = null,
                string resourceGroupName = null, 
                string auxiliaryAccessToken = "", 
                bool isMUAProtected = false)
        {
            Dictionary<string, List<string>> customHeaders = new Dictionary<string, List<string>>();
            string operationRequest = null;

            if (isMUAProtected)
            {
                List<ResourceGuardProxyBaseResource> resourceGuardMapping = ListResourceGuardMapping(vaultName, resourceGroupName);                

                if (resourceGuardMapping != null && resourceGuardMapping.Count != 0)
                {
                    foreach (ResourceGuardOperationDetail operationDetail in resourceGuardMapping[0].Properties.ResourceGuardOperationDetails)
                    {
                        if (operationDetail.VaultCriticalOperation == "Microsoft.RecoveryServices/vaults/backupPolicies/write") operationRequest = operationDetail.DefaultResourceRequest;
                    }

                    if (operationRequest != null)
                    {
                        request.Properties.ResourceGuardOperationRequests = new List<string>();
                        request.Properties.ResourceGuardOperationRequests.Add(operationRequest);
                    }
                }
            }

            if (auxiliaryAccessToken != null && auxiliaryAccessToken != "")
            {
                if (operationRequest != null)
                {
                    customHeaders.Add("x-ms-authorization-auxiliary", new List<string> { "Bearer " + auxiliaryAccessToken });
                }
                else if (!isMUAProtected)
                {
                    throw new ArgumentException(String.Format(Resources.PolicyUpdateNotCritical));
                }
                else
                {   
                    throw new ArgumentException(String.Format(Resources.UnexpectedParameterToken, "ModifyPolicy"));
                }
            }

            return BmsAdapter.Client.ProtectionPolicies.CreateOrUpdateWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                policyName,
                request,
                customHeaders,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
        }

        /// <summary>
        /// Gets a protection policy given the name
        /// </summary>
        /// <param name="policyName">Name of the policy</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>Policy response returned by the service</returns>
        public ProtectionPolicyResource GetProtectionPolicy(
            string policyName,
            string vaultName = null,
            string resourceGroupName = null)
        {
            return BmsAdapter.Client.ProtectionPolicies.GetWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                policyName,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;
        }

        /// <summary>
        /// Lists protection policies according to the input query filter
        /// </summary>
        /// <param name="queryFilter">Query filter</param>
        /// <param name="skipToken">Skip token for pagination</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>List of protection policies</returns>
        public List<ProtectionPolicyResource> ListProtectionPolicy(
            RestAzureODataNS.ODataQuery<ProtectionPolicyQueryObject> queryFilter,
            string skipToken = default(string),
            string vaultName = null,
            string resourceGroupName = null)
        {
            Func<RestAzureNS.IPage<ProtectionPolicyResource>> listAsync =
                () => BmsAdapter.Client.BackupPolicies.ListWithHttpMessagesAsync(
                    vaultName ?? BmsAdapter.GetResourceName(),
                    resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                    queryFilter,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;

            Func<string, RestAzureNS.IPage<ProtectionPolicyResource>> listNextAsync =
                nextLink => BmsAdapter.Client.BackupPolicies.ListNextWithHttpMessagesAsync(
                    nextLink,
                    cancellationToken: BmsAdapter.CmdletCancellationToken).Result.Body;            

            return HelperUtils.GetPagedList(listAsync, listNextAsync);
        }

        /// <summary>
        /// Deletes protection policy from the vault specified by the name
        /// </summary>
        /// <param name="policyName">Name of the policy to be deleted</param>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns>Default azure operation response</returns>
        public RestAzureNS.AzureOperationResponse RemoveProtectionPolicy(
                string policyName,
                string vaultName = null,
                string resourceGroupName = null)
        {
            return BmsAdapter.Client.ProtectionPolicies.DeleteWithHttpMessagesAsync(
                vaultName ?? BmsAdapter.GetResourceName(),
                resourceGroupName ?? BmsAdapter.GetResourceGroupName(),
                policyName,
                cancellationToken: BmsAdapter.CmdletCancellationToken).Result;
        }
    }
}