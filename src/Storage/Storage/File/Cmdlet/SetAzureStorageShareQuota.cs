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
using Microsoft.Azure.Storage.File;
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    [CmdletOutputBreakingChangeWithVersion(typeof(AzureStorageFileShare), "13.0.0", "8.0.0", ChangeDescription = "The child property CloudFileShare from deprecated v11 SDK will be removed. Use child property ShareClient instead.")]
    [Cmdlet("Set", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageShareQuota", DefaultParameterSetName = Constants.ShareNameParameterSetName), OutputType(typeof(AzureStorageFileShare))]
    public class SetAzureStorageShareQuota : AzureStorageFileCmdletBase
    {
        [Alias("N", "Name")]
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "Share name",
            ParameterSetName = Constants.ShareNameParameterSetName,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [CmdletParameterBreakingChangeWithVersion("Share", "13.0.0", "8.0.0", ChangeDescription = "The parameter Share (alias CloudFileShare) will be deprecated, and a new mandatory parameter ShareClient will be added.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share whose quota to set.")]
        [ValidateNotNull]
        [Alias("CloudFileShare")]
        public CloudFileShare Share { get; set; }

        [Alias("QuotaGiB")]
        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "Share Quota")]
        public int Quota { get; set; }

        // Overwrite the useless parameter
        public override SwitchParameter DisAllowTrailingDot { get; set; }

        /// <summary>
        /// execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            ShareClient share;

            switch (this.ParameterSetName)
            {
                case Constants.ShareNameParameterSetName:
                    NamingUtil.ValidateShareName(this.ShareName, false);
                    share = Util.GetTrack2ShareReference(this.ShareName,
                                (AzureStorageContext)this.Context,
                                null,
                                ClientOptions);
                    break;

                case Constants.ShareParameterSetName:
                    share = AzureStorageFileShare.GetTrack2FileShareClient(this.Share, (AzureStorageContext)this.Context, this.ClientOptions);

                    // Build and set storage context for the output object when
                    // 1. input track1 object and storage context is missing 2. the current context doesn't match the context of the input object 
                    if (ShouldSetContext(this.Context, this.Share.ServiceClient))
                    {
                        this.Context = GetStorageContextFromTrack1FileServiceClient(this.Share.ServiceClient, DefaultContext);
                    }
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            ShareProperties shareProperties = share.GetProperties(this.CmdletCancellationToken).Value;

            if (shareProperties.QuotaInGB != this.Quota)
            {
                //fileShare.Properties.Quota = this.Quota;
                //this.Channel.SetShareProperties(fileShare, null, this.RequestOptions, this.OperationContext);
                share.SetQuota(this.Quota);
                shareProperties = share.GetProperties(this.CmdletCancellationToken).Value;
            }

            WriteObject( new AzureStorageFileShare(share, (AzureStorageContext)this.Context, shareProperties, ClientOptions));
        }
    }
}
