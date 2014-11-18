﻿// ----------------------------------------------------------------------------------
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

using System.Globalization;
using System.IO;
using System.Management.Automation;
using Microsoft.WindowsAzure.Storage.DataMovement.TransferJobs;
using Microsoft.WindowsAzure.Storage.File;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    using LocalDirectory = System.IO.Directory;
    using LocalPath = System.IO.Path;

    [Cmdlet(VerbsCommon.Get, Constants.FileContentCmdletName, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High, DefaultParameterSetName = Constants.ShareNameParameterSetName)]
    public class GetAzureStorageFileContent : StorageFileDataManagementCmdletBase
    {
        [Parameter(
           Position = 0,
           Mandatory = true,
           ParameterSetName = Constants.ShareNameParameterSetName,
           HelpMessage = "Name of the file share where the file would be downloaded.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share where the file would be downloaded.")]
        [ValidateNotNull]
        public CloudFileShare Share { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "CloudFileDirectory object indicated the cloud directory where the file would be downloaded.")]
        [ValidateNotNull]
        public CloudFileDirectory Directory { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.FileParameterSetName,
            HelpMessage = "CloudFile object indicated the cloud file to be downloaded.")]
        [ValidateNotNull]
        public CloudFile File { get; set; }

        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Path to the cloud file to be downloaded.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "Path to the cloud file to be downloaded.")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "Path to the cloud file to be downloaded.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(
            Position = 2,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Path to the local file or directory when the downloaded file would be put.")]
        [Parameter(
            Position = 2,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "Path to the local file or directory when the downloaded file would be put.")]
        [Parameter(
            Position = 2,
            ParameterSetName = Constants.DirectoryParameterSetName,
            HelpMessage = "Path to the local file or directory when the downloaded file would be put.")]
        [Parameter(
            Position = 1,
            ParameterSetName = Constants.FileParameterSetName,
            HelpMessage = "Path to the local file or directory when the downloaded file would be put.")]
        [ValidateNotNullOrEmpty]
        public string Destination { get; set; }

        [Parameter(HelpMessage = "Returns an object representing the downloaded cloud file. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            CloudFile fileToBeDownloaded;
            string[] path = NamingUtil.ValidatePath(this.Path, true);
            switch (this.ParameterSetName)
            {
                case Constants.FileParameterSetName:
                    fileToBeDownloaded = this.File;
                    break;

                case Constants.ShareNameParameterSetName:
                    var share = this.BuildFileShareObjectFromName(this.ShareName);
                    fileToBeDownloaded = share.GetRootDirectoryReference().GetFileReferenceByPath(path);
                    break;

                case Constants.ShareParameterSetName:
                    fileToBeDownloaded = this.Share.GetRootDirectoryReference().GetFileReferenceByPath(path);
                    break;

                case Constants.DirectoryParameterSetName:
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

            this.RunTask(async taskId =>
            {
                var downloadJob = new FileDownloadJob()
                {
                    SourceFile = fileToBeDownloaded,
                    DestPath = targetFile
                };

                var progressRecord = new ProgressRecord(
                    this.OutputStream.GetProgressId(taskId),
                    string.Format(CultureInfo.CurrentCulture, Resources.ReceiveAzureFileActivity, fileToBeDownloaded.GetFullPath(), targetFile),
                    Resources.PrepareDownloadingFile);

                await this.RunTransferJob(downloadJob, progressRecord);

                if (this.PassThru)
                {
                    this.OutputStream.WriteObject(taskId, fileToBeDownloaded);
                }
            });
        }
    }
}
