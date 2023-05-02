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
    using global::Azure.Storage.Files.Shares;
    using global::Azure.Storage.Files.Shares.Models;
    using Microsoft.Azure.Storage.File;
    using Model.Contract;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Management.Automation;
    using System.Security.Permissions;

    /// <summary>
    /// create a new azure container
    /// </summary>
    [Cmdlet("Set", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageShareStoredAccessPolicy", SupportsShouldProcess = true), OutputType(typeof(String))]
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
            NamingUtil.ValidateShareName(this.ShareName, false);

            if (!NameUtil.IsValidStoredAccessPolicyName(this.Policy))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Resources.InvalidAccessPolicyName, this.Policy));
            }

            //Get share instance
            ShareClient share = Util.GetTrack2ShareReference(ShareName,
                 (AzureStorageContext)this.Context,
                 null,
                 ClientOptions);

            //Get existing permissions  
            IEnumerable<ShareSignedIdentifier> signedIdentifiers = share.GetAccessPolicy(cancellationToken: CmdletCancellationToken).Value;

            // find the policy to set
            ShareSignedIdentifier signedIdentifier = null;
            foreach (ShareSignedIdentifier identifier in signedIdentifiers)
            {
                if (identifier.Id == policyName)
                {
                    signedIdentifier = identifier;
                }
            }
            if (signedIdentifier == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName));
            }

            // Set the policy
            if (noStartTime)
            {
                signedIdentifier.AccessPolicy.PolicyStartsOn = DateTimeOffset.MinValue;
            }

            else if (startTime != null)
            {
                signedIdentifier.AccessPolicy.PolicyStartsOn = StartTime.Value.ToUniversalTime();
            }
            if (noExpiryTime)
            {
                signedIdentifier.AccessPolicy.PolicyExpiresOn = null;
            }
            else if (ExpiryTime != null)
            {
                signedIdentifier.AccessPolicy.PolicyExpiresOn = ExpiryTime.Value.ToUniversalTime();
            }

            if (this.Permission != null)
            {
                signedIdentifier.AccessPolicy.Permissions = this.Permission;
                signedIdentifier.AccessPolicy.Permissions = AccessPolicyHelper.OrderBlobPermission(this.Permission);
            }

            //Set permission back to share
            share.SetAccessPolicy(signedIdentifiers, cancellationToken: CmdletCancellationToken);
            WriteObject(AccessPolicyHelper.ConstructPolicyOutputPSObject<ShareSignedIdentifier>(signedIdentifier));
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
