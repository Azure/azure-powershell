using Microsoft.WindowsAzure.Commands.Storage.Model.Contract;
using Microsoft.WindowsAzure.Storage.File;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using System;
using System.Management.Automation;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Storage.File.Cmdlet
{
    [Cmdlet(VerbsLifecycle.Stop, Constants.FileCopyCmdletName, SupportsShouldProcess = true)]
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

        [Parameter(
            Position = 0,
            HelpMessage = "Target file instance", Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.FileParameterSetName)]
        [ValidateNotNull]
        public CloudFile File { get; set; }

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

            CloudFile file = null;

            if (null != this.File)
            {
                file = this.File;
            }
            else
            {
                string[] path = NamingUtil.ValidatePath(this.FilePath);
                file = this.BuildFileShareObjectFromName(this.ShareName).GetRootDirectoryReference().GetFileReferenceByPath(path);
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
        /// <param name="blob">CloudBlob object</param>
        /// <param name="copyId">Copy id</param>
        private async Task StopCopyFile(long taskId, IStorageFileManagement localChannel, CloudFile file, string copyId)
        {
            FileRequestOptions requestOptions = RequestOptions;

            //Set no retry to resolve the 409 conflict exception
            requestOptions.RetryPolicy = new NoRetry();

            string abortCopyId = string.Empty;

            if (string.IsNullOrEmpty(copyId) || Force)
            {
                //Make sure we use the correct copy id to abort
                //Use default retry policy for FetchBlobAttributes
                FileRequestOptions options = RequestOptions;
                await localChannel.FetchFileAttributesAsync(file, null, options, OperationContext, CmdletCancellationToken);

                if (file.CopyState == null || string.IsNullOrEmpty(file.CopyState.CopyId))
                {
                    ArgumentException e = new ArgumentException(String.Format(Resources.FileCopyTaskNotFound, file.Uri.ToString()));
                    OutputStream.WriteError(taskId, e);
                }
                else
                {
                    abortCopyId = file.CopyState.CopyId;
                }

                if (!Force)
                {
                    string confirmation = String.Format(Resources.ConfirmAbortFileCopyOperation, file.Uri.ToString(), abortCopyId);
                    if (!await OutputStream.ConfirmAsync(confirmation))
                    {
                        string cancelMessage = String.Format(Resources.StopCopyOperationCancelled, file.Uri.ToString());
                        OutputStream.WriteVerbose(taskId, cancelMessage);
                    }
                }
            }
            else
            {
                abortCopyId = copyId;
            }

            await localChannel.AbortCopyAsync(file, abortCopyId, null, requestOptions, OperationContext, CmdletCancellationToken);
            string message = String.Format(Resources.StopCopyFileSuccessfully, file.Uri.ToString());
            OutputStream.WriteObject(taskId, message);
        }
    }
}
