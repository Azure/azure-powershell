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
    using global::Azure.Storage.Files.Shares;
    using Microsoft.Azure.Storage.File;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using System.Globalization;
    using System.Management.Automation;

    [CmdletOutputBreakingChangeWithVersion(typeof(AzureStorageFile), "13.0.0", "8.0.0", ChangeDescription = "The child property CloudFile from deprecated v11 SDK will be removed when -PassThru is specified. Use child property ShareFileClient instead.")]
    [Cmdlet("Remove", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageFile",SupportsShouldProcess = true,DefaultParameterSetName = Constants.ShareNameParameterSetName), OutputType(typeof(AzureStorageFile))]
    public class RemoveAzureStorageFile : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Name of the file share where the file would be removed.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [CmdletParameterBreakingChangeWithVersion("Share", "13.0.0", "8.0.0", ChangeDescription = "The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share where the file would be removed.")]
        [ValidateNotNull]
        [Alias("CloudFileShare")]
        public CloudFileShare Share { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "ShareClient object indicated the share where the file would be removed.")]
        [ValidateNotNull]
        public ShareClient ShareClient { get; set; }

        [CmdletParameterBreakingChangeWithVersion("Directory", "13.0.0", "8.0.0", ChangeDescription = "The parameter Directory (alias CloudFileDirectory) will be deprecated, and ShareDirectoryClient will be mandatory.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "CloudFileDirectory object indicated the cloud directory where the file would be removed.")]
        [ValidateNotNull]
        [Alias("CloudFileDirectory")]
        public CloudFileDirectory Directory { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "ShareDirectoryClient object indicated the base folder where the file would be removed.")]
        [ValidateNotNull]
        public ShareDirectoryClient ShareDirectoryClient { get; set; }

        [CmdletParameterBreakingChangeWithVersion("File", "13.0.0", "8.0.0", ChangeDescription = "The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.FileParameterSetName,
            HelpMessage = "CloudFile object indicated the file to be removed.")]
        [ValidateNotNull]
        [Alias("CloudFile")]
        public CloudFile File { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.FileParameterSetName,
            HelpMessage = "ShareFileClient object indicated the file would be removed.")]
        [ValidateNotNull]
        public ShareFileClient ShareFileClient { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Path of the file to be removed.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "Path of the file to be removed.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "Path of the file to be removed.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(HelpMessage = "Returns an object representing the removed file. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ShareFileClient fileToBeRemoved;
            switch (this.ParameterSetName)
            {
                case Constants.FileParameterSetName:
                    if (this.ShareFileClient != null)
                    {
                        fileToBeRemoved = this.ShareFileClient;
                    }
                    else
                    {
                        fileToBeRemoved = AzureStorageFile.GetTrack2FileClient(this.File, ClientOptions);

                        // Build and set storage context for the output object when
                        // 1. input track1 object and storage context is missing 2. the current context doesn't match the context of the input object 
                        if (ShouldSetContext(this.Context, this.File.ServiceClient))
                        {
                            this.Context = GetStorageContextFromTrack1FileServiceClient(this.File.ServiceClient, DefaultContext);
                        }
                    }
                    break;

                case Constants.ShareNameParameterSetName:
                    NamingUtil.ValidateShareName(this.ShareName, false);
                    ShareServiceClient fileserviceClient = Util.GetTrack2FileServiceClient((AzureStorageContext)this.Context, ClientOptions);
                    fileToBeRemoved = fileserviceClient.GetShareClient(this.ShareName).GetRootDirectoryClient().GetFileClient(this.Path);
                    break;

                case Constants.ShareParameterSetName:
                    if (this.ShareClient != null)
                    {
                        fileToBeRemoved = this.ShareClient.GetRootDirectoryClient().GetFileClient(this.Path);
                    }
                    else
                    {
                        fileToBeRemoved = AzureStorageFileDirectory.GetTrack2FileDirClient(this.Share.GetRootDirectoryReference(), ClientOptions).GetFileClient(this.Path);

                        // Build and set storage context for the output object when
                        // 1. input track1 object and storage context is missing 2. the current context doesn't match the context of the input object 
                        if (ShouldSetContext(this.Context, this.Share.ServiceClient))
                        {
                            this.Context = GetStorageContextFromTrack1FileServiceClient(this.Share.ServiceClient, DefaultContext);
                        }
                    }
                    break;

                case Constants.DirectoryParameterSetName:
                    if (this.ShareDirectoryClient != null)
                    {
                        fileToBeRemoved = this.ShareDirectoryClient.GetFileClient(this.Path);
                    }
                    else
                    {
                        fileToBeRemoved = AzureStorageFileDirectory.GetTrack2FileDirClient(this.Directory, ClientOptions).GetFileClient(this.Path);

                        // Build and set storage context for the output object when
                        // 1. input track1 object and storage context is missing 2. the current context doesn't match the context of the input object 
                        if (ShouldSetContext(this.Context, this.Directory.ServiceClient))
                        {
                            this.Context = GetStorageContextFromTrack1FileServiceClient(this.Directory.ServiceClient, DefaultContext);
                        }
                    }
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            this.RunTask(async taskId =>
            {
                if (this.ShouldProcess(Util.GetSnapshotQualifiedUri(fileToBeRemoved.Uri), "Remove file"))
                {
                    await fileToBeRemoved.DeleteAsync(cancellationToken: this.CmdletCancellationToken).ConfigureAwait(false);
                }

                if (this.PassThru)
                {
                    OutputStream.WriteObject(taskId, new AzureStorageFile(fileToBeRemoved, (AzureStorageContext)this.Context, clientOptions: ClientOptions));
                }
            });
        }
    }
}
