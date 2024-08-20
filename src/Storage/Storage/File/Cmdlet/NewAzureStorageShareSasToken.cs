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
    using Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.WindowsAzure.Commands.Common.Storage;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.File;
    using System;
    using System.Management.Automation;
    using System.Security.Permissions;
    using global::Azure.Storage.Files.Shares;
    using global::Azure.Storage.Sas;
    using global::Azure.Storage.Files.Shares.Models;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using global::Azure.Storage;

    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageShareSASToken"), OutputType(typeof(String))]
    public class NewAzureStorageShareSasToken : AzureStorageFileCmdletBase
    {
        /// <summary>
        /// Sas permission parameter set name
        /// </summary>
        private const string SasPermissionParameterSet = "SasPermission";

        /// <summary>
        /// Sas policy paremeter set name
        /// </summary>
        private const string SasPolicyParmeterSet = "SasPolicy";

        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Share Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Policy Identifier", ParameterSetName = SasPolicyParmeterSet)]
        [ValidateNotNullOrEmpty]
        public string Policy
        {
            get { return accessPolicyIdentifier; }
            set { accessPolicyIdentifier = value; }
        }
        private string accessPolicyIdentifier;

        [Parameter(Mandatory = false, HelpMessage = "Permissions for a share. Permissions can be any subset of \"rwdl\".",
            ParameterSetName = SasPermissionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Permission { get; set; }

        [CmdletParameterBreakingChangeWithVersion("Protocol", "13.0.0", "8.0.0", ChangeDescription = "The type of parameter Protocol will be changed from SharedAccessProtocol to string.")]
        [Parameter(Mandatory = false, HelpMessage = "Protocol can be used in the request with this SAS token.")]
        [ValidateNotNull]
        public SharedAccessProtocol? Protocol { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "IP, or IP range ACL (access control list) that the request would be accepted by Azure Storage.")]
        [ValidateNotNullOrEmpty]
        public string IPAddressOrRange { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Start Time")]
        [ValidateNotNull]
        public DateTime? StartTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Expiry Time")]
        [ValidateNotNull]
        public DateTime? ExpiryTime { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Display full uri with sas token")]
        public SwitchParameter FullUri { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Azure Storage Context Object")]
        [ValidateNotNull]
        public override IStorageContext Context { get; set; }

        // Overwrite the useless parameter
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }
        public override SwitchParameter DisAllowTrailingDot { get; set; }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            if (String.IsNullOrEmpty(ShareName)) return;

            if (Channel.StorageContext != null && Channel.StorageContext.StorageAccount != null && !Channel.StorageContext.StorageAccount.Credentials.IsSharedKey)
            {
                throw new InvalidOperationException("Create File service SAS only supported with SharedKey credentail.");
            }

            ShareClient share = Util.GetTrack2ShareReference(this.ShareName,
                        (AzureStorageContext)this.Context,
                        snapshotTime: null, 
                        ClientOptions);

            // Get share saved policy if any
            ShareSignedIdentifier identifier = null;
            if (ParameterSetName == SasPolicyParmeterSet)
            {
                identifier = SasTokenHelper.GetShareSignedIdentifier(share, this.Policy, CmdletCancellationToken);
            }

            //Create SAS builder
            ShareSasBuilder sasBuilder = SasTokenHelper.SetShareSasBuilder_FromShare(share, identifier, this.Permission, this.StartTime, this.ExpiryTime, this.IPAddressOrRange, this.Protocol);

            //Create SAS and output it
            string sasToken = SasTokenHelper.GetFileSharedAccessSignature(Channel.StorageContext, sasBuilder, CmdletCancellationToken);

            // remove prefix "?" of SAS if any
            sasToken = Util.GetSASStringWithoutQuestionMark(sasToken);

            if (FullUri)
            {
                string fullUri = SasTokenHelper.GetFullUriWithSASToken(share.Uri.AbsoluteUri.ToString(), sasToken);
                WriteObject(fullUri);
            }
            else
            {
                WriteObject(sasToken);
            }
        }
    }
}
