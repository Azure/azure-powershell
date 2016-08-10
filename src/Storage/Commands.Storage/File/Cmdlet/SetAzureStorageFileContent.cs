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
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.File;
    using System.Globalization;
    using System.IO;
    using System.Management.Automation;
    using System.Net;
    using System.Threading.Tasks;
    using LocalConstants = Microsoft.WindowsAzure.Commands.Storage.File.Constants;

    [Cmdlet(VerbsCommon.Set, LocalConstants.FileContentCmdletName, SupportsShouldProcess = true, DefaultParameterSetName = LocalConstants.ShareNameParameterSetName)]
    public class SetAzureStorageFileContent : StorageFileDataManagementCmdletBase
    {
        [Parameter(
           Position = 0,
           Mandatory = true,
           ParameterSetName = LocalConstants.ShareNameParameterSetName,
           HelpMessage = "Name of the file share where the file would be uploaded to.")]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = LocalConstants.ShareParameterSetName,
            HelpMessage = "CloudFileShare object indicated the share where the file would be uploaded to.")]
        [ValidateNotNull]
        public CloudFileShare Share { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = LocalConstants.DirectoryParameterSetName,
            HelpMessage = "CloudFileDirectory object indicated the cloud directory where the file would be uploaded.")]
        [ValidateNotNull]
        public CloudFileDirectory Directory { get; set; }

        [Alias("FullName")]
        [Parameter(
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Path to the local file to be uploaded.")]
        [ValidateNotNullOrEmpty]
        public string Source { get; set; }

        [Parameter(
            Position = 2,
            HelpMessage = "Path to the cloud file which would be uploaded to.")]
        [ValidateNotNullOrEmpty]
        public string Path { get; set; }

        [Parameter(HelpMessage = "Returns an object representing the downloaded cloud file. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            // Step 1: Validate source file.
            FileInfo localFile = new FileInfo(this.GetUnresolvedProviderPathFromPSPath(this.Source));
            if (!localFile.Exists)
            {
                throw new FileNotFoundException(string.Format(CultureInfo.CurrentCulture, Resources.SourceFileNotFound, this.Source));
            }

            bool isDirectory;
            string[] path = NamingUtil.ValidatePath(this.Path, out isDirectory);
            var cloudFileToBeUploaded =
                BuildCloudFileInstanceFromPathAsync(localFile.Name, path, isDirectory).ConfigureAwait(false).GetAwaiter().GetResult();
            if (ShouldProcess(cloudFileToBeUploaded.Name, "Set file content"))
            {
                // Step 2: Build the CloudFile object which pointed to the
                // destination cloud file.
                this.RunTask(async taskId =>
                {
                    var progressRecord = new ProgressRecord(
                        this.OutputStream.GetProgressId(taskId),
                        string.Format(CultureInfo.CurrentCulture, Resources.SendAzureFileActivity, localFile.Name,
                            cloudFileToBeUploaded.GetFullPath(), cloudFileToBeUploaded.Share.Name),
                        Resources.PrepareUploadingFile);

                    await DataMovementTransferHelper.DoTransfer(() =>
                    this.TransferManager.UploadAsync(
                            localFile.FullName,
                            cloudFileToBeUploaded,
                            null,
                            this.GetTransferContext(progressRecord, localFile.Length),
                            this.CmdletCancellationToken),
                        progressRecord,
                        this.OutputStream);


                    if (this.PassThru)
                    {
                        this.OutputStream.WriteObject(taskId, cloudFileToBeUploaded);
                    }
                });
            }
        }

        private async Task<CloudFile> BuildCloudFileInstanceFromPathAsync(string defaultFileName, string[] path, bool pathIsDirectory)
        {
            CloudFileDirectory baseDirectory = null;
            bool isPathEmpty = path.Length == 0;
            switch (this.ParameterSetName)
            {
                case LocalConstants.DirectoryParameterSetName:
                    baseDirectory = this.Directory;
                    break;

                case LocalConstants.ShareNameParameterSetName:
                    NamingUtil.ValidateShareName(this.ShareName, false);
                    baseDirectory = this.BuildFileShareObjectFromName(this.ShareName).GetRootDirectoryReference();
                    break;

                case LocalConstants.ShareParameterSetName:
                    baseDirectory = this.Share.GetRootDirectoryReference();
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            if (isPathEmpty)
            {
                return baseDirectory.GetFileReference(defaultFileName);
            }

            var directory = baseDirectory.GetDirectoryReferenceByPath(path);
            if (pathIsDirectory)
            {
                return directory.GetFileReference(defaultFileName);
            }

            bool directoryExists;

            try
            {
                directoryExists = await this.Channel.DirectoryExistsAsync(directory, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken);
            }
            catch (StorageException e)
            {
                if (e.RequestInformation != null &&
                    e.RequestInformation.HttpStatusCode == (int)HttpStatusCode.BadRequest &&
                    e.RequestInformation.ExtendedErrorInformation == null)
                {
                    throw new AzureStorageFileException(ErrorCategory.InvalidArgument, ErrorIdConstants.InvalidResource, Resources.InvalidResource, this);
                }

                throw;
            }

            if (directoryExists)
            {
                // If the directory exist on the cloud, we treat the path as
                // to a directory. So we append the default file name after
                // it and build an instance of CloudFile class.
                return directory.GetFileReference(defaultFileName);
            }
            else
            {
                // If the directory does not exist, we treat the path as to a
                // file. So we use the path of the directory to build out a
                // new instance of CloudFile class.
                return baseDirectory.GetFileReferenceByPath(path);
            }
        }
    }
}
