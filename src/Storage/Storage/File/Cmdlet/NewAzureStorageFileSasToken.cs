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

using Microsoft.WindowsAzure.Commands.Storage.Common;
using System;
using System.Management.Automation;
using System.Security.Permissions;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Sas;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    [Cmdlet("New", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageFileSASToken"), OutputType(typeof(String))]
    public class NewAzureStorageFileSasToken : AzureStorageFileCmdletBase
    {
        /// <summary>
        /// Sas permission with share name and path parameter set name
        /// </summary>
        private const string NameSasPermissionParameterSet = "NameSasPermission";

        /// <summary>
        /// Sas policy with share name and pathparemeter set name
        /// </summary>
        private const string NameSasPolicyParmeterSet = "NameSasPolicy";

        private const string FileClientSasPermissionParameterSet = "FileSasPermission";

        private const string FileClientSasPolicyParameterSet = "FileSasPolicy";


        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Share Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameSasPermissionParameterSet)]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Share Name",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameSasPolicyParmeterSet)]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Path to the cloud file to generate sas token against.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameSasPermissionParameterSet)]
        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Path to the cloud file to generate sas token against.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = NameSasPolicyParmeterSet)]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(Mandatory = true,
            HelpMessage = "ShareFlieClient instance to represent the file to get SAS token against.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = FileClientSasPermissionParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "ShareFileClient instance to represent the file to get SAS token against.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = FileClientSasPolicyParameterSet)]
        [ValidateNotNull]
        public ShareFileClient ShareFileClient { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Policy Identifier", ParameterSetName = NameSasPolicyParmeterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Policy Identifier", ParameterSetName = FileClientSasPolicyParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Policy
        {
            get { return accessPolicyIdentifier; }
            set { accessPolicyIdentifier = value; }
        }
        private string accessPolicyIdentifier;

        [Parameter(
            Mandatory = false,
            HelpMessage = "Permissions for a file. Permissions can be any subset of \"rwd\".",
            ParameterSetName = NameSasPermissionParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Permissions for a file. Permissions can be any subset of \"rwd\".",
            ParameterSetName = FileClientSasPermissionParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Permission { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Protocol can be used in the request with this SAS token.")]
        [ValidateSet("HttpsOnly", "HttpsOrHttp", IgnoreCase = true),]
        public string Protocol { get; set; }

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
            ShareClient shareClient;
            ShareFileClient fileClient;

            if (null != this.ShareFileClient)
            {
                CheckContextForObjectInput((AzureStorageContext)this.Context);
                fileClient = this.ShareFileClient;
                shareClient = Util.GetTrack2ShareReference(fileClient.ShareName,
                        (AzureStorageContext)this.Context,
                        snapshotTime: Util.GetSnapshotTimeStringFromUri(fileClient.Uri),
                        ClientOptions);
            }
            else
            {
                shareClient = Util.GetTrack2ShareReference(this.ShareName,
                        (AzureStorageContext)this.Context,
                        snapshotTime: null,
                        ClientOptions);
                fileClient = shareClient.GetRootDirectoryClient().GetFileClient(this.Path);
            }


            if (this.Context != null && this.Context is AzureStorageContext && ((AzureStorageContext)this.Context).StorageAccount != null && !((AzureStorageContext)this.Context).StorageAccount.Credentials.IsSharedKey)
            {
                throw new InvalidOperationException("Create File service SAS only supported with SharedKey credential.");
            }

            // Get share saved policy if any
            ShareSignedIdentifier identifier = null;
            if (!string.IsNullOrEmpty(this.Policy))
            {
                identifier = SasTokenHelper.GetShareSignedIdentifier(shareClient, this.Policy, CmdletCancellationToken);
            }

            //Create SAS builder
            ShareSasBuilder sasBuilder = SasTokenHelper.SetShareSasBuilder_FromFile(fileClient, identifier, this.Permission, this.StartTime, this.ExpiryTime, this.IPAddressOrRange, this.Protocol);

            //Create SAS and output it
            string sasToken = SasTokenHelper.GetFileSharedAccessSignature((AzureStorageContext)this.Context, sasBuilder, CmdletCancellationToken);

            // remove prefix "?" of SAS if any
            sasToken = Util.GetSASStringWithoutQuestionMark(sasToken);

            if (FullUri)
            {
                string fullUri = SasTokenHelper.GetFullUriWithSASToken(fileClient.Uri.AbsoluteUri.ToString(), sasToken);
                WriteObject(fullUri);
            }
            else
            {
                WriteObject(sasToken);
            }
        }
    }
}
