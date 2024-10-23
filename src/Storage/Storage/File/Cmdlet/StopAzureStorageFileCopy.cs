using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.Azure.Storage.File;
using Microsoft.Azure.Storage.RetryPolicies;
using System;
using System.Management.Automation;
using System.Security.Permissions;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Azure.Storage.Files.Shares.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    [Cmdlet("Stop", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageFileCopy", SupportsShouldProcess = true), OutputType(typeof(void))]
    public class StopAzureStorageFileCopyCommand : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            HelpMessage = "Target share name",
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(
            Position = 1,
            HelpMessage = "Target file path",
            Mandatory = true,
            ParameterSetName = Constants.ShareNameParameterSetName)]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        [CmdletParameterBreakingChangeWithVersion("File", "13.0.0", "8.0.0", ChangeDescription = "The parameter File (alias CloudFile) will be deprecated, and ShareFileClient will be mandatory.")]
        [Parameter(
            Position = 0,
            HelpMessage = "Target file instance", Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.FileParameterSetName)]
        [ValidateNotNull]
        [Alias("CloudFile")]
        public CloudFile File { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.FileParameterSetName,
            HelpMessage = "ShareFileClient object indicated the file to Stop Copy.")]
        [ValidateNotNull]
        public ShareFileClient ShareFileClient { get; set; }

        [Parameter(HelpMessage = "Copy Id", Mandatory = false)]
        public string CopyId { get; set; }


        [Parameter(HelpMessage = "Whether to stop the copy when copy id is different with the one input.", Mandatory = false)]
        public SwitchParameter Force { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            OutputStream.ConfirmWriter = (target, query, caption) => ShouldContinue(query, caption);
        }

        /// <summary>
        /// Execute command
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public override void ExecuteCmdlet()
        {
            IStorageFileManagement localChannel = Channel;

            ShareFileClient file = null;

            //Set no retry to resolve the 409 conflict exception
            ShareClientOptions optionNoRetry = ClientOptions;
            optionNoRetry.Retry.MaxRetries = 0;

            if (this.ShareFileClient != null)
            {
                file = this.ShareFileClient;
            }
            else if (null != this.File)
            {
                file = AzureStorageFile.GetTrack2FileClient(this.File);
            }
            else
            {
                file = Util.GetTrack2ShareReference(this.ShareName,
                    (AzureStorageContext)this.Context,
                    snapshotTime: null,
                    ClientOptions).GetRootDirectoryClient().GetFileClient(this.FilePath);
            }

            if (ShouldProcess(file.Name, "Stop file copy task"))
            {
                Func<long, Task> taskGenerator = (taskId) => this.StopCopyFile(taskId, localChannel, file, CopyId);

                RunTask(taskGenerator);
            }
        }

        /// <summary>
        /// Stop copy operation by CloudBlob object
        /// </summary>
        /// <param name="taskId">Task id</param>
        /// <param name="localChannel">IStorageFileManagement channel object</param>
        /// <param name="file">CloudFile object</param>
        /// <param name="copyId">Copy id</param>
        private async Task StopCopyFile(long taskId, IStorageFileManagement localChannel, ShareFileClient file, string copyId)
        {
            string abortCopyId = string.Empty;

            if (string.IsNullOrEmpty(copyId) || Force)
            {
                //Make sure we use the correct copy id to abort
                //Use default retry policy for FetchBlobAttributes
                ShareFileProperties fileProperties = file.GetProperties(this.CmdletCancellationToken).Value;
                if (string.IsNullOrEmpty(fileProperties.CopyId))
                {
                    ArgumentException e = new ArgumentException(String.Format(Resources.FileCopyTaskNotFound, Util.GetSnapshotQualifiedUri(file.Uri)));
                    OutputStream.WriteError(taskId, e);
                }
                else
                {
                    abortCopyId = fileProperties.CopyId;
                }

                if (!Force)
                {
                    string confirmation = String.Format(Resources.ConfirmAbortFileCopyOperation, Util.GetSnapshotQualifiedUri(file.Uri), abortCopyId);
                    if (!await OutputStream.ConfirmAsync(confirmation).ConfigureAwait(false))
                    {
                        string cancelMessage = String.Format(Resources.StopCopyOperationCancelled, Util.GetSnapshotQualifiedUri(file.Uri));
                        OutputStream.WriteVerbose(taskId, cancelMessage);
                    }
                }
            }
            else
            {
                abortCopyId = copyId;
            }

            file.AbortCopy(abortCopyId, this.CmdletCancellationToken);
            string message = String.Format(Resources.StopCopyFileSuccessfully, Util.GetSnapshotQualifiedUri(file.Uri));
            OutputStream.WriteObject(taskId, message);
        }
    }
}
