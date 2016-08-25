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

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    using Common;
    using Microsoft.WindowsAzure.Storage.File;
    using Model.Contract;
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Security.Permissions;
    using System.Threading.Tasks;

    /// <summary>
    /// create a new azure container
    /// </summary>
    [Cmdlet(VerbsCommon.Get, StorageNouns.ShareStoredAccessPolicy), OutputType(typeof(SharedAccessFilePolicy))]
    public class GetAzureStorageShareStoredAccessPolicy : AzureStorageFileCmdletBase
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Share name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(Position = 1,
            HelpMessage = "Policy Identifier",
            ValueFromPipelineByPropertyName = true)]
        public string Policy { get; set; }

        internal async Task GetAzureShareStoredAccessPolicyAsync(long taskId, IStorageFileManagement localChannel, string shareName, string policyName)
        {
            SharedAccessFilePolicies shareAccessPolicies = await GetPoliciesAsync(localChannel, shareName, policyName);

            if (!String.IsNullOrEmpty(policyName))
            {
                if (shareAccessPolicies.Keys.Contains(policyName))
                {
                    OutputStream.WriteObject(taskId, AccessPolicyHelper.ConstructPolicyOutputPSObject<SharedAccessFilePolicy>(shareAccessPolicies, policyName));
                }
                else
                {
                    throw new ResourceNotFoundException(String.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName));
                }
            }
            else
            {
                foreach (string key in shareAccessPolicies.Keys)
                {
                    OutputStream.WriteObject(taskId, AccessPolicyHelper.ConstructPolicyOutputPSObject<SharedAccessFilePolicy>(shareAccessPolicies, key));
                }
            }
        }

        internal async Task<SharedAccessFilePolicies> GetPoliciesAsync(IStorageFileManagement localChannel, string shareName, string policyName)
        {
            CloudFileShare share = localChannel.GetShareReference(shareName);
            FileSharePermissions permissions = await localChannel.GetSharePermissionsAsync(share, null, null, null, CmdletCancellationToken);
            return permissions.SharedAccessPolicies;
        }


        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            Func<long, Task> taskGenerator = (taskId) => GetAzureShareStoredAccessPolicyAsync(taskId, Channel, ShareName, Policy);
            RunTask(taskGenerator);
        }
    }
}


