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

using Microsoft.WindowsAzure.Storage.File;
using System.Globalization;
using System.IO;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Storage.DataMovement;
    using LocalConstants = Microsoft.WindowsAzure.Commands.Storage.File.Constants;
    using LocalDirectory = System.IO.Directory;
    using LocalPath = System.IO.Path;

    [Cmdlet(VerbsCommon.Get, LocalConstants.FileContentCmdletName, SupportsShouldProcess = true, DefaultParameterSetName = LocalConstants.ShareNameParameterSetName)]
    public class GetAzureStorageFileContent : StorageFileDataManagementCmdletBase
    {
        [Parameter(
           Position = 0,
           Mandatory = true,
           ParameterSetName = LocalConstants.ShareNameParameterSetName,
           HelpMessage = "Name of the file share where the file would be downloaded.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = LocalConstants.ShareParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share where the file would be downloaded.")]
        [ValidateNotNull]
        public CloudFileShare Share { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = LocalConstants.DirectoryParameterSetName,
            HelpMessage = "CloudFileDirectory object indicated the cloud directory where the file would be downloaded.")]
        [ValidateNotNull]
        public CloudFileDirectory Directory { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = LocalConstants.FileParameterSetName,
            HelpMessage = "CloudFile object indicated the cloud file to be downloaded.")]
        [ValidateNotNull]
        public CloudFile File { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = LocalConstants.ShareNameParameterSetName,
            HelpMessage = "Path to the cloud file to be downloaded.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = LocalConstants.ShareParameterSetName,
            HelpMessage = "Path to the cloud file to be downloaded.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = LocalConstants.DirectoryParameterSetName,
            HelpMessage = "Path to the cloud file to be downloaded.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(
            Position = 2,
            ParameterSetName = LocalConstants.ShareNameParameterSetName,
            HelpMessage = "Path to the local file or directory when the downloaded file would be put.")]
        [Parameter(
            Position = 2,
            ParameterSetName = LocalConstants.ShareParameterSetName,
            HelpMessage = "Path to the local file or directory when the downloaded file would be put.")]
        [Parameter(
            Position = 2,
            ParameterSetName = LocalConstants.DirectoryParameterSetName,
            HelpMessage = "Path to the local file or directory when the downloaded file would be put.")]
        [Parameter(
            Position = 1,
            ParameterSetName = LocalConstants.FileParameterSetName,
            HelpMessage = "Path to the local file or directory when the downloaded file would be put.")]
        [ValidateNotNullOrEmpty]
        public string Destination { get; set; }

        [Parameter(HelpMessage = "check the md5sum")]
        public SwitchParameter CheckMd5
        {
            get;
            set;
        }

        [Parameter(HelpMessage = "Returns an object representing the downloaded cloud file. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            CloudFile fileToBeDownloaded;
            string[] path = NamingUtil.ValidatePath(this.Path, true);
            switch (this.ParameterSetName)
            {
                case LocalConstants.FileParameterSetName:
                    fileToBeDownloaded = this.File;
                    break;

                case LocalConstants.ShareNameParameterSetName:
                    var share = this.BuildFileShareObjectFromName(this.ShareName);
                    fileToBeDownloaded = share.GetRootDirectoryReference().GetFileReferenceByPath(path);
                    break;

                case LocalConstants.ShareParameterSetName:
                    fileToBeDownloaded = this.Share.GetRootDirectoryReference().GetFileReferenceByPath(path);
                    break;

                case LocalConstants.DirectoryParameterSetName:
                    fileToBeDownloaded = this.Directory.GetFileReferenceByPath(path);
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            string resolvedDestination = this.GetUnresolvedProviderPathFromPSPath(
                string.IsNullOrWhiteSpace(this.Destination) ? "." : this.Destination);

            FileMode mode = this.Force ? FileMode.Create : FileMode.CreateNew;
            string targetFile;
            if (LocalDirectory.Exists(resolvedDestination))
            {
                // If the destination pointed to an existing directory, we
                // would download the file into the folder with the same name
                // on cloud.
                targetFile = LocalPath.Combine(resolvedDestination, fileToBeDownloaded.GetBaseName());
            }
            else
            {
                // Otherwise we treat the destination as a file no matter if
                // there's one existing or not. The overwrite behavior is configured
                // by FileMode.
                targetFile = resolvedDestination;
            }

            if (ShouldProcess(targetFile, "Download"))
            {
                this.RunTask(async taskId =>
                {
                    await
                        fileToBeDownloaded.FetchAttributesAsync(null, this.RequestOptions, OperationContext,
                            CmdletCancellationToken);

                    var progressRecord = new ProgressRecord(
                        this.OutputStream.GetProgressId(taskId),
                        string.Format(CultureInfo.CurrentCulture, Resources.ReceiveAzureFileActivity,
                            fileToBeDownloaded.GetFullPath(), targetFile),
                        Resources.PrepareDownloadingFile);

                    await DataMovementTransferHelper.DoTransfer(() =>
                    {
                        return this.TransferManager.DownloadAsync(
                            fileToBeDownloaded,
                            targetFile,
                            new DownloadOptions
                            {
                                DisableContentMD5Validation = !this.CheckMd5
                            },
                            this.GetTransferContext(progressRecord, fileToBeDownloaded.Properties.Length),
                            CmdletCancellationToken);
                    },
                        progressRecord,
                        this.OutputStream);

                    if (this.PassThru)
                    {
                        this.OutputStream.WriteObject(taskId, fileToBeDownloaded);
                    }
                });
            }
        }
    }
}
