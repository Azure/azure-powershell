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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.File;
using System;
using System.Management.Automation;
using System.Security.Permissions;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Sas;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

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

        /// <summary>
        /// Sas permission with CloudFile instance parameter set name
        /// </summary>
        private const string CloudFileSasPermissionParameterSet = "FileSasPermission";

        /// <summary>
        /// Sas policy with CloudFile instance parameter set name
        /// </summary>
        private const string CloudFileSasPolicyParmeterSet = "FileSasPolicy";

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

        [CmdletParameterBreakingChangeWithVersion("File", "13.0.0", "8.0.0", ChangeDescription = "The parameter File (alias CloudFile) will be deprecated, and a new mandatory parameter ShareFileClient will be added.")]
        [Parameter(Mandatory = true,
            HelpMessage = "CloudFile instance to represent the file to get SAS token against.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CloudFileSasPermissionParameterSet)]
        [Parameter(Mandatory = true,
            HelpMessage = "CloudFile instance to represent the file to get SAS token against.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CloudFileSasPolicyParmeterSet)]
        [ValidateNotNull]
        [Alias("CloudFile")]
        public CloudFile File { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Policy Identifier", ParameterSetName = NameSasPolicyParmeterSet)]
        [Parameter(Mandatory = true, HelpMessage = "Policy Identifier", ParameterSetName = CloudFileSasPolicyParmeterSet)]
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
            ParameterSetName = CloudFileSasPermissionParameterSet)]
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
            HelpMessage = "Azure Storage Context Object",
            ParameterSetName = NameSasPermissionParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            HelpMessage = "Azure Storage Context Object",
            ParameterSetName = NameSasPolicyParmeterSet)]
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
            ShareClient shareClient;
            ShareFileClient fileClient;
            if (null != this.File)
            {
                // Build and set storage context for the output object when
                // 1. input track1 object and storage context is missing 2. the current context doesn't match the context of the input object 
                if (ShouldSetContext(this.Context, this.File.ServiceClient))
                {
                    this.Context = GetStorageContextFromTrack1FileServiceClient(this.File.ServiceClient, DefaultContext);
                }

                fileClient = AzureStorageFile.GetTrack2FileClient(this.File, this.ClientOptions);
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
                throw new InvalidOperationException("Create File service SAS only supported with SharedKey credentail.");
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
