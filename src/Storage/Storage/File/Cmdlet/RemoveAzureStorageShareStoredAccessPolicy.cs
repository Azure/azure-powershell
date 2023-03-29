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
    [Cmdlet("Remove", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageShareStoredAccessPolicy", SupportsShouldProcess = true), OutputType(typeof(Boolean))]
    public class RemoveAzureStorageShareStoredAccessPolicy : AzureStorageFileCmdletBase
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Share name",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Policy Identifier",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Policy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return whether the specified policy is successfully removed")]
        public SwitchParameter PassThru { get; set; }

        internal bool RemoveAzureShareStoredAccessPolicy(IStorageFileManagement localChannel, string shareName, string policyName)
        {
            bool success = false;
            string result = string.Empty;

            //Get share instance
            ShareClient share = Util.GetTrack2ShareReference(shareName,
                 (AzureStorageContext)this.Context,
                 null,
                 ClientOptions);

            IEnumerable<ShareSignedIdentifier> signedIdentifiers = share.GetAccessPolicy(cancellationToken: CmdletCancellationToken).Value;

            //remove the specified policy
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
                throw new ResourceNotFoundException(String.Format(CultureInfo.CurrentCulture, Resources.PolicyNotFound, policyName));
            }

            if (ShouldProcess(policyName, "Remove policy"))
            {
                List<ShareSignedIdentifier> newsignedIdentifiers = new List<ShareSignedIdentifier>(signedIdentifiers);
                newsignedIdentifiers.Remove(signedIdentifier);

                share.SetAccessPolicy(newsignedIdentifiers, cancellationToken: CmdletCancellationToken);
                success = true;
            }

            return success;
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            bool success = RemoveAzureShareStoredAccessPolicy(Channel, ShareName, Policy);
            string result = string.Empty;

            if (success)
            {
                result = String.Format(CultureInfo.CurrentCulture, Resources.RemovePolicySuccessfully, Policy);
            }
            else
            {
                result = String.Format(CultureInfo.CurrentCulture, Resources.RemovePolicyCancelled, Policy);
            }

            WriteVerbose(result);

            if (PassThru)
            {
                WriteObject(success);
            }
        }
    }
}
