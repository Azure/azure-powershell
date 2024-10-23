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

using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using Azure.Storage.Files.Shares.Specialized;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    [CmdletOutputBreakingChangeWithVersion(typeof(AzureStorageFileDirectory), "13.0.0", "8.0.0", ChangeDescription = "The child property CloudFileDirectory from deprecated v11 SDK will be removed. Use child property ShareDirectoryClient instead.")]
    [Cmdlet("Rename", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageDirectory", SupportsShouldProcess = true, DefaultParameterSetName = ShareNameParameterSet)]
    [OutputType(typeof(AzureStorageFileDirectory))]
    public class RenameAzureStorageDirectory : StorageFileDataManagementCmdletBase
    {
        private const string ShareNameParameterSet = "ShareName";
        private const string DirectoryObjectParameterSet = "DirecotryObject";
        private const string ShareObjectParameterSet = "ShareObject";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ShareNameParameterSet,
            HelpMessage = "Name of the file share where the directory would be listed.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ShareObjectParameterSet,
            HelpMessage = "ShareClienr indicated the share where the directory would be listed.")]
        [ValidateNotNull]
        public ShareClient ShareClient { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DirectoryObjectParameterSet,
            HelpMessage = "Source directory instance")]
        public ShareDirectoryClient ShareDirectoryClient { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ShareNameParameterSet,
            HelpMessage = "Path to an existing directory.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ShareObjectParameterSet,
            HelpMessage = "Path to an existing directory.")]
        [ValidateNotNullOrEmpty]
        public string SourcePath { get; set; }

        [Parameter(
            Position = 2,
            ParameterSetName = ShareNameParameterSet,
            HelpMessage = "The destination path to rename the directory to.")]
        [Parameter(
            Position = 2,
            ParameterSetName = ShareObjectParameterSet,
            HelpMessage = "The destination path to rename the directory to.")]
        [Parameter(
            Position = 2,
            ParameterSetName = DirectoryObjectParameterSet,
            HelpMessage = "The destination path to rename the directory to.")]
        public string DestinationPath { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Optional. Specifies whether the ReadOnly attribute on a preexisting destination " +
            "file should be respected. If true, the rename will succeed, otherwise, a previous file at the destination with " +
            "the ReadOnly attribute set will cause the rename to fail.")]
        public SwitchParameter IgnoreReadonly;

        [Parameter(Mandatory = false,
            HelpMessage = "If specified the permission (security descriptor) shall be set for the directory/file. " +
            "Default value: Inherit. If SDDL is specified as input, it must have owner, group and dacl.")]
        public string Permission { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Disallow trailing dot (.) to suffix source directory and source file names.", ParameterSetName = ShareNameParameterSet)]
        public virtual SwitchParameter DisAllowSourceTrailingDot { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Disallow trailing dot (.) to suffix destination directory and destination file names.", ParameterSetName = ShareNameParameterSet)]
        public virtual SwitchParameter DisAllowDestTrailingDot { get; set; }

        public override int? ClientTimeoutPerRequest { get; set; }
        public override int? ServerTimeoutPerRequest { get; set; }
        public override int? ConcurrentTaskCount { get; set; }
        public override SwitchParameter DisAllowTrailingDot { get; set; }

        public override void ExecuteCmdlet()
        {
            ShareDirectoryClient srcDirectoryClient;
            ShareDirectoryClient srcDirectoryClientForRename;
            ShareFileClient destFileClient;

            switch (ParameterSetName)
            {
                case ShareNameParameterSet:
                    ShareClientOptions sourceClientOptions = this.createClientOptions();
                    ShareClientOptions destClientOptions = this.ClientOptions;

                    if (this.DisAllowSourceTrailingDot)
                    {
                        sourceClientOptions.AllowTrailingDot = false;
                        destClientOptions.AllowSourceTrailingDot = false;
                    }
                    if (this.DisAllowDestTrailingDot)
                    {
                        destClientOptions.AllowTrailingDot = false;
                    }

                    srcDirectoryClient = Util.GetTrack2FileServiceClient((AzureStorageContext)this.Context, sourceClientOptions).GetShareClient(this.ShareName).GetDirectoryClient(this.SourcePath);
                    // Need to set ClientOptions.AllowSourceTrailingDot, to allow/disallow  TrailingDot in Rename() 
                    srcDirectoryClientForRename = Util.GetTrack2FileServiceClient((AzureStorageContext)this.Context, destClientOptions).GetShareClient(this.ShareName).GetDirectoryClient(this.SourcePath);
                    destFileClient = Util.GetTrack2FileServiceClient((AzureStorageContext)this.Context, destClientOptions).GetShareClient(this.ShareName).GetRootDirectoryClient().GetFileClient(this.DestinationPath);
                    break;
                case ShareObjectParameterSet:
                    srcDirectoryClient = this.ShareClient.GetDirectoryClient(this.SourcePath);
                    srcDirectoryClientForRename = srcDirectoryClient;
                    destFileClient = this.ShareClient.GetRootDirectoryClient().GetFileClient(this.DestinationPath);
                    break;
                case DirectoryObjectParameterSet:
                    srcDirectoryClient = this.ShareDirectoryClient;
                    srcDirectoryClientForRename = srcDirectoryClient;
                    destFileClient = srcDirectoryClient.GetParentShareClient().GetRootDirectoryClient().GetFileClient(this.DestinationPath);
                    break;
                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            if (ShouldProcess(srcDirectoryClient.Name, VerbsCommon.Rename))
            {
                // Throw exception and quit if input path is not a directory
                srcDirectoryClient.GetProperties();

                bool destFileExist = destFileClient.Exists();

                if (!destFileExist || this.Force || ShouldContinue(string.Format(Resources.OverwriteConfirmation, destFileClient.Uri.ToString()), null))
                {
                    ShareFileRenameOptions options = new ShareFileRenameOptions
                    {
                        ReplaceIfExists = true,
                        IgnoreReadOnly = this.IgnoreReadonly,
                        FilePermission = this.Permission,
                    };

                    ShareDirectoryClient destDirectoryClient = srcDirectoryClientForRename.Rename(this.DestinationPath, options, this.CmdletCancellationToken);

                    ShareDirectoryProperties dirProperties = destDirectoryClient.GetProperties(this.CmdletCancellationToken).Value;
                    WriteObject(new AzureStorageFileDirectory(destDirectoryClient, (AzureStorageContext)this.Context, dirProperties, ClientOptions));
                }
            }
        }
    }
}
