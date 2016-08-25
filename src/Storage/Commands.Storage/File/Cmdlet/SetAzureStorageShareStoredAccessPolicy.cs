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

    /// <summary>
    /// create a new azure container
    /// </summary>
    [Cmdlet(VerbsCommon.Set, StorageNouns.ShareStoredAccessPolicy, SupportsShouldProcess = true), OutputType(typeof(String))]
    public class SetAzureStorageShareStoredAccessPolicy : AzureStorageFileCmdletBase
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Share name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Policy Identifier")]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        [Parameter(HelpMessage = "Permissions for a share. Permissions can be any non-empty subset of \"rwdl\".")]
        public string Permission { get; set; }

        [Parameter(HelpMessage = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Parameter(HelpMessage = "Expiry Time")]
        public DateTime? ExpiryTime { get; set; }

        [Parameter(HelpMessage = "Set StartTime as null for the policy")]
        public SwitchParameter NoStartTime { get; set; }

        [Parameter(HelpMessage = "Set ExpiryTime as null for the policy")]
        public SwitchParameter NoExpiryTime { get; set; }

        internal string SetAzureShareStoredAccessPolicy(IStorageFileManagement localChannel, string shareName, string policyName, DateTime? startTime, DateTime? expiryTime, string permission, bool noStartTime, bool noExpiryTime)
        {
            //Get existing permissions
            CloudFileShare share = localChannel.GetShareReference(shareName);
            FileSharePermissions permissions = localChannel.GetSharePermissions(share);

            //Set the policy with new value
            if (!permissions.SharedAccessPolicies.Keys.Contains(policyName))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName));
            }

            SharedAccessFilePolicy policy = permissions.SharedAccessPolicies[policyName];
            AccessPolicyHelper.SetupAccessPolicy<SharedAccessFilePolicy>(policy, startTime, expiryTime, permission, noStartTime, noExpiryTime);
            permissions.SharedAccessPolicies[policyName] = policy;

            //Set permission back to share
            localChannel.SetSharePermissions(share, permissions);
            WriteObject(AccessPolicyHelper.ConstructPolicyOutputPSObject<SharedAccessFilePolicy>(permissions.SharedAccessPolicies, policyName));
            return policyName;
        }


        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (NoStartTime && StartTime != null)
            {
                throw new ArgumentException(Resources.StartTimeParameterConflict);
            }

            if (NoExpiryTime && ExpiryTime != null)
            {
                throw new ArgumentException(Resources.ExpiryTimeParameterConflict);
            }

            if (ShouldProcess(Policy, "Set"))
            {
                SetAzureShareStoredAccessPolicy(Channel, ShareName, Policy, StartTime, ExpiryTime, Permission, NoStartTime, NoExpiryTime);
            }
        }
    }
}

