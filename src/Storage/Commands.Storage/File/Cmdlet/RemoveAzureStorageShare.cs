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
    using System.Management.Automation;

    [Cmdlet(
        VerbsCommon.Remove,
        Constants.ShareCmdletName,
        DefaultParameterSetName = Constants.ShareNameParameterSetName,
        SupportsShouldProcess = true)]
    public class RemoveAzureStorageShare : AzureStorageFileCmdletBase
    {
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareNameParameterSetName,
            HelpMessage = "Name of the file share to be removed.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "File share object to be removed.")]
        [ValidateNotNull]
        public CloudFileShare Share { get; set; }

        [Parameter(HelpMessage = "Remove File Share with all of its snapshots")]
        public SwitchParameter IncludeAllSnapshot { get; set; }

        [Parameter(HelpMessage = "Force to remove the share with all its snapshots, and all content in them.")]
        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }

        [Parameter(HelpMessage = "Returns an object representing the removed file share. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        private bool force;

        /// <summary>
        /// Cmdlet begin processing
        /// </summary>
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            OutputStream.ConfirmWriter = (s1, s2, s3) => ShouldContinue(s2, s3);
        }

        public override void ExecuteCmdlet()
        {
            CloudFileShare share;
            switch (this.ParameterSetName)
            {
                case Constants.ShareParameterSetName:
                    share = this.Share;
                    break;

                case Constants.ShareNameParameterSetName:
                    share = this.BuildFileShareObjectFromName(this.Name);
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            if (ShouldProcess(share.Name, "Remove share"))
            {
                this.RunTask(async taskId =>
                {
                    if (share.IsSnapshot && IncludeAllSnapshot.IsPresent)
                    {
                        throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "'IncludeAllSnapshot' should only be specified to delete a base share, and should not be specified to delete a Share snapshot: {0}", share.SnapshotQualifiedUri));
                    }

                    if (force || ShareIsEmpty(share) || ShouldContinue(string.Format("Remove share and all content in it: {0}", share.Name), ""))
                    {
                        DeleteShareSnapshotsOption deleteShareSnapshotsOption = DeleteShareSnapshotsOption.None;
                        bool retryDeleteSnapshot = false;

                        //Force means will delete the share anyway, so use 'IncludeSnapshots' to delete the share even has snapshot, or delete will fail when share has snapshot
                        // To delete a Share shapshot, must use 'None' 
                        if (IncludeAllSnapshot.IsPresent)
                        {
                            deleteShareSnapshotsOption = DeleteShareSnapshotsOption.IncludeSnapshots;
                        }
                        else
                        {
                            retryDeleteSnapshot = true;
                        }

                        try
                        {
                            await this.Channel.DeleteShareAsync(share, deleteShareSnapshotsOption, null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken).ConfigureAwait(false);
                            retryDeleteSnapshot = false;
                        }
                        catch (StorageException e)
                        {
                            //If x-ms-delete-snapshots is not specified on the request and the share has associated snapshots, the File service returns status code 409 (Conflict).
                            if (!(e.IsConflictException() && retryDeleteSnapshot))
                            {
                                throw;
                            }
                        }

                        if (retryDeleteSnapshot)
                        {
                            if (force || await OutputStream.ConfirmAsync(string.Format("This share might have snapshots, remove the share and all snapshots?: {0}", share.Name)).ConfigureAwait(false))
                            {
                                deleteShareSnapshotsOption = DeleteShareSnapshotsOption.IncludeSnapshots;
                                await this.Channel.DeleteShareAsync(share, deleteShareSnapshotsOption, null, this.RequestOptions, this.OperationContext, this.CmdletCancellationToken).ConfigureAwait(false);
                            }
                            else
                            {
                                string result = string.Format("The remove operation of share '{0}' has been cancelled.", share.Name);
                                OutputStream.WriteVerbose(taskId, result);
                            }
                        }
                    }

                    if (this.PassThru)
                    {
                        this.OutputStream.WriteObject(taskId, share);
                    }
                });
            }
        }
    }
}
