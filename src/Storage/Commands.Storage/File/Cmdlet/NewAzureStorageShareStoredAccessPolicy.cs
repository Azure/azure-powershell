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
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Security.Permissions;

    /// <summary>
    /// create a new stored access policy to a specific azure share.
    /// </summary>
    [Cmdlet(VerbsCommon.New, StorageNouns.ShareStoredAccessPolicy, DefaultParameterSetName = Constants.ShareNameParameterSetName), OutputType(typeof(String))]
    public class NewAzureStorageShareStoredAccessPolicy : AzureStorageFileCmdletBase
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
            HelpMessage = "Policy Identifier. Need to be unique in the Share")]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        [Parameter(HelpMessage = "Permissions for a share. Permissions can be any subset of \"rwdl\".")]
        public string Permission { get; set; }

        [Parameter(HelpMessage = "Start Time")]
        public DateTime? StartTime { get; set; }

        [Parameter(HelpMessage = "Expiry Time")]
        public DateTime? ExpiryTime { get; set; }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(ShareName) || String.IsNullOrEmpty(Policy)) return;

            NamingUtil.ValidateShareName(this.ShareName, false);

            if (!NameUtil.IsValidStoredAccessPolicyName(this.Policy))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.InvalidAccessPolicyName, this.Policy));
            }

            //Get existing permissions
            CloudFileShare fileShare = this.Channel.GetShareReference(this.ShareName);

            FileSharePermissions fileSharePermissions = fileShare.GetPermissions();

            //Add new policy
            if (fileSharePermissions.SharedAccessPolicies.Keys.Contains(this.Policy))
            {
                throw new ResourceAlreadyExistException(String.Format(CultureInfo.CurrentCulture, Resources.PolicyAlreadyExists, this.Policy));
            }

            SharedAccessFilePolicy policy = new SharedAccessFilePolicy();
            AccessPolicyHelper.SetupAccessPolicy<SharedAccessFilePolicy>(policy, this.StartTime, this.ExpiryTime, this.Permission);
            fileSharePermissions.SharedAccessPolicies.Add(this.Policy, policy);

            //Set permissions back to container
            fileShare.SetPermissions(fileSharePermissions);
            WriteObject(Policy);
        }
    }
}
