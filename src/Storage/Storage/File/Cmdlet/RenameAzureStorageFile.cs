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
    [CmdletOutputBreakingChangeWithVersion(typeof(AzureStorageFile), "13.0.0", "8.0.0", ChangeDescription = "The child property CloudFile from deprecated v11 SDK will be removed. Use child property ShareFileClient instead.")]
    [Cmdlet("Rename", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageFile", SupportsShouldProcess = true, DefaultParameterSetName = ShareNameParameterSet)]
    [OutputType(typeof(AzureStorageFile))]
    public class RenameAzureStorageFile : StorageFileDataManagementCmdletBase
    {
        private const string ShareNameParameterSet = "ShareName";
        private const string FileObjectParameterSet = "FileObject";
        private const string DirectoryObjectParameterSet = "DirecotryObject";
        private const string ShareObjectParameterSet = "ShareObject";

        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = ShareNameParameterSet,
            HelpMessage = "Name of the file share where the file would be listed.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = FileObjectParameterSet,
            HelpMessage = "Source file instance")]
        [ValidateNotNull]
        public ShareFileClient ShareFileClient { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ShareObjectParameterSet,
            HelpMessage = "ShareClient indicated the share where the file would be listed.")]
        [ValidateNotNull]
        public ShareClient ShareClient { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = DirectoryObjectParameterSet,
            HelpMessage = "ShareDirectoryClient indicated the share where the file would be listed.")]
        [ValidateNotNull]
        public ShareDirectoryClient ShareDirectoryClient { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ShareNameParameterSet,
            HelpMessage = "Path to an existing file.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = ShareObjectParameterSet,
            HelpMessage = "Path to an existing file.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = DirectoryObjectParameterSet,
            HelpMessage = "Path to an existing file.")]
        [ValidateNotNullOrEmpty]
        public string SourcePath { get; set; }

        [Parameter(
            Position = 1,
            ParameterSetName = FileObjectParameterSet,
            HelpMessage = "The destination path to rename the file to.")]
        [Parameter(
            Position = 2,
            ParameterSetName = ShareNameParameterSet,
            HelpMessage = "The destination path to rename the file to.")]
        [Parameter(
            Position = 2,
            ParameterSetName = ShareObjectParameterSet,
            HelpMessage = "The destination path to rename the file to.")]
        [Parameter(
            Position = 2,
            ParameterSetName = DirectoryObjectParameterSet,
            HelpMessage = "The destination path to rename the file to.")]
        public string DestinationPath { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Optional. Specifies whether the ReadOnly attribute on a preexisting destination " +
            "file should be respected. If true, the rename will succeed, otherwise, a previous file at the destination with " +
            "the ReadOnly attribute set will cause the rename to fail.")]
        public SwitchParameter IgnoreReadonly;

        [Parameter(Mandatory = false,
            HelpMessage = "Sets the MIME content type of the file. The default type is 'application/octet-stream'.")]
        public string ContentType { get; set; }

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
            ShareFileClient srcFileClient;
            ShareFileClient srcFileClient2ForRename;
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

                    srcFileClient = Util.GetTrack2FileServiceClient((AzureStorageContext)this.Context, sourceClientOptions).GetShareClient(this.ShareName).GetRootDirectoryClient().GetFileClient(this.SourcePath);
                    // Need to set ClientOptions.AllowSourceTrailingDot, to allow/disallow  TrailingDot in Rename() 
                    srcFileClient2ForRename = Util.GetTrack2FileServiceClient((AzureStorageContext)this.Context, destClientOptions).GetShareClient(this.ShareName).GetRootDirectoryClient().GetFileClient(this.SourcePath);
                    destFileClient = Util.GetTrack2FileServiceClient((AzureStorageContext)this.Context, destClientOptions).GetShareClient(this.ShareName).GetRootDirectoryClient().GetFileClient(this.DestinationPath);
                    break;
                case FileObjectParameterSet:
                    srcFileClient = this.ShareFileClient;
                    srcFileClient2ForRename = srcFileClient;
                    destFileClient = srcFileClient.GetParentShareClient().GetRootDirectoryClient().GetFileClient(this.DestinationPath);
                    break;
                case ShareObjectParameterSet:
                    srcFileClient = this.ShareClient.GetRootDirectoryClient().GetFileClient(this.SourcePath);
                    srcFileClient2ForRename = srcFileClient;
                    destFileClient = this.ShareClient.GetRootDirectoryClient().GetFileClient(this.DestinationPath);
                    break;
                case DirectoryObjectParameterSet:
                    srcFileClient = this.ShareDirectoryClient.GetFileClient(this.SourcePath);
                    srcFileClient2ForRename = srcFileClient;
                    destFileClient = srcFileClient.GetParentShareClient().GetRootDirectoryClient().GetFileClient(this.DestinationPath);
                    break;
                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            if (ShouldProcess(srcFileClient.Name, VerbsCommon.Rename))
            {
                // Throw exception and quit directly if input path is not a file 
                srcFileClient.GetProperties(this.CmdletCancellationToken);

                bool destExist = destFileClient.Exists();
                if (!destExist || this.Force || ShouldContinue(string.Format(Resources.OverwriteConfirmation, destFileClient.Uri.ToString()), null))
                {
                    ShareFileRenameOptions options = new ShareFileRenameOptions
                    {
                        ReplaceIfExists = true,
                        IgnoreReadOnly = this.IgnoreReadonly,
                        ContentType = this.ContentType,
                        FilePermission = this.Permission,
                    };

                    destFileClient = srcFileClient2ForRename.Rename(this.DestinationPath, options, this.CmdletCancellationToken);

                    ShareFileProperties fileProperties = destFileClient.GetProperties(this.CmdletCancellationToken).Value;
                    WriteObject(new AzureStorageFile(destFileClient, (AzureStorageContext)this.Context, fileProperties, ClientOptions));
                }
            }
        }
    }
}
