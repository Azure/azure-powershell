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
    using System.Threading.Tasks;

    /// <summary>
    /// create a new azure container
    /// </summary>
    [Cmdlet("Get", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageShareStoredAccessPolicy"), OutputType(typeof(SharedAccessFilePolicy))]
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
            //Get share instance
            ShareClient share = Util.GetTrack2ShareReference(shareName,
                 (AzureStorageContext)this.Context,
                 null,
                 ClientOptions);

            IEnumerable<ShareSignedIdentifier> signedIdentifiers = (await share.GetAccessPolicyAsync(cancellationToken: CmdletCancellationToken).ConfigureAwait(false)).Value;

            if (!String.IsNullOrEmpty(policyName))
            {
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
                else
                {
                    OutputStream.WriteObject(taskId, AccessPolicyHelper.ConstructPolicyOutputPSObject<ShareSignedIdentifier>(signedIdentifier));
                }
            }
            else
            {
                foreach (ShareSignedIdentifier identifier in signedIdentifiers)
                {
                    OutputStream.WriteObject(taskId, AccessPolicyHelper.ConstructPolicyOutputPSObject<ShareSignedIdentifier>(identifier));
                }
            }
        }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            NamingUtil.ValidateShareName(this.ShareName, false);
            Func<long, Task> taskGenerator = (taskId) => GetAzureShareStoredAccessPolicyAsync(taskId, Channel, ShareName, Policy);
            RunTask(taskGenerator);
        }
    }
}
