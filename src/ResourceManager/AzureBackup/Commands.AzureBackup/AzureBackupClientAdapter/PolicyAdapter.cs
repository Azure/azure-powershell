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

using Microsoft.Azure.Commands.AzureBackup.Properties;
using Microsoft.Azure.Management.BackupServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.AzureBackup.ClientAdapter
{
    public partial class AzureBackupClientAdapter
    {
        /// <summary>
        /// Gets protection policies of matching name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CSMProtectionPolicyResponse GetProtectionPolicyByName(string resourceGroupName, string resourceName, string name)
        {
            var policyList = ListProtectionPolicies(resourceGroupName, resourceName);
            var filteredList = policyList.Where(x => x.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase));
            return filteredList.FirstOrDefault();
        }

        /// <summary>
        /// Gets all policies in the vault
        /// </summary>
        /// <returns></returns>
        public IList<CSMProtectionPolicyResponse> ListProtectionPolicies(string resourceGroupName, string resourceName)
        {
            var listResponse = AzureBackupClient.CSMProtectionPolicy.ListAsync(resourceGroupName, resourceName, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return listResponse.CSMProtectionPolicyListResponse.Value;
        }

        /// <summary>
        /// Add protection policy
        /// </summary>
        /// <param name="policyName"></param>
        /// <param name="request"></param>
        public void AddProtectionPolicy(string resourceGroupName, string resourceName, string policyName, CSMAddProtectionPolicyRequest request)
        {
            AzureBackupClient.CSMProtectionPolicy.AddAsync(resourceGroupName, resourceName, policyName, request, GetCustomRequestHeaders(), CmdletCancellationToken).Wait();
        }

        /// <summary>
        /// Delete protection policy
        /// </summary>
        /// <param name="policyName"></param>
        public void DeleteProtectionPolicy(string resourceGroupName, string resourceName, string policyName)
        {
            AzureBackupClient.CSMProtectionPolicy.DeleteAsync(resourceGroupName, resourceName, policyName, GetCustomRequestHeaders(), CmdletCancellationToken).Wait();
        }

        /// <summary>
        /// Update specified protection policy
        /// </summary>
        /// <param name="policyName"></param>
        /// <param name="request"></param>
        public Guid UpdateProtectionPolicy(string resourceGroupName, string resourceName, string policyName, CSMUpdateProtectionPolicyRequest request)
        {
            var response = AzureBackupClient.CSMProtectionPolicy.UpdateAsync(resourceGroupName, resourceName, policyName, request, GetCustomRequestHeaders(), CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// Check protection policy name availability
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public void CheckProtectionPolicyNameAvailability(string resourceGroupName, string resourceName, string name)
        {
            var policy = GetProtectionPolicyByName(resourceGroupName, resourceName, name);
            if (policy != null)
            {
                var exception = new ArgumentException(Resources.PolicyAlreadyExist);
                throw exception;
            }
        }
    }
}