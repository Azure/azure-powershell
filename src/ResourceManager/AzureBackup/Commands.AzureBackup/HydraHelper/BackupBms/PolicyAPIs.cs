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

namespace Microsoft.Azure.Commands.AzureBackup.Client
{
    public partial class HydraHelper
    {
        /// <summary>
        /// Gets protection policies of matching name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CSMProtectionPolicyResponse BackupGetProtectionPolicyByName(string resourceGroupName, string resourceName, string name)
        {
            var policyList = BackupListProtectionPolicies(resourceGroupName, resourceName);
            var filteredList = policyList.Where(x => x.Name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase));
            return filteredList.FirstOrDefault();
        }

        /// <summary>
        /// Gets all policies in the vault
        /// </summary>
        /// <returns></returns>
        public IList<CSMProtectionPolicyResponse> BackupListProtectionPolicies(string resourceGroupName, string resourceName)
        {
            var listResponse = BackupBmsAdapter.Client.CSMProtectionPolicy.ListAsync(
                resourceGroupName, resourceName,
                BackupBmsAdapter.GetCustomRequestHeaders(), BackupBmsAdapter.CmdletCancellationToken).Result;
            return listResponse.CSMProtectionPolicyListResponse.Value;
        }

        /// <summary>
        /// Add protection policy
        /// </summary>
        /// <param name="policyName"></param>
        /// <param name="request"></param>
        public void BackupAddProtectionPolicy(string resourceGroupName, string resourceName, string policyName, CSMAddProtectionPolicyRequest request)
        {
            BackupBmsAdapter.Client.CSMProtectionPolicy.AddAsync(
                resourceGroupName, resourceName, policyName, request,
                BackupBmsAdapter.GetCustomRequestHeaders(), BackupBmsAdapter.CmdletCancellationToken).Wait();
        }

        /// <summary>
        /// Delete protection policy
        /// </summary>
        /// <param name="policyName"></param>
        public void BackupDeleteProtectionPolicy(string resourceGroupName, string resourceName, string policyName)
        {
            BackupBmsAdapter.Client.CSMProtectionPolicy.DeleteAsync(
                resourceGroupName, resourceName, policyName,
                BackupBmsAdapter.GetCustomRequestHeaders(), BackupBmsAdapter.CmdletCancellationToken).Wait();
        }

        /// <summary>
        /// Update specified protection policy
        /// </summary>
        /// <param name="policyName"></param>
        /// <param name="request"></param>
        public Guid BackupUpdateProtectionPolicy(string resourceGroupName, string resourceName, string policyName, CSMUpdateProtectionPolicyRequest request)
        {
            var response = BackupBmsAdapter.Client.CSMProtectionPolicy.UpdateAsync(
                resourceGroupName, resourceName, policyName, request,
                BackupBmsAdapter.GetCustomRequestHeaders(), BackupBmsAdapter.CmdletCancellationToken).Result;
            return response.OperationId;
        }

        /// <summary>
        /// Check protection policy name availability
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public void BackupCheckProtectionPolicyNameAvailability(string resourceGroupName, string resourceName, string name)
        {
            var policy = BackupGetProtectionPolicyByName(resourceGroupName, resourceName, name);
            if (policy != null)
            {
                var exception = new ArgumentException(Resources.PolicyAlreadyExist);
                throw exception;
            }
        }
    }
}