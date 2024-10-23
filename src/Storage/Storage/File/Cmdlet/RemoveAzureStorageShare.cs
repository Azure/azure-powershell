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
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.File;
    using System.Globalization;
    using System.Management.Automation;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
    using global::Azure.Storage.Files.Shares;
    using global::Azure.Storage.Files.Shares.Models;
    using System;

    [CmdletOutputBreakingChangeWithVersion(typeof(AzureStorageFileShare), "13.0.0", "8.0.0", ChangeDescription = "The child property CloudFileShare from deprecated v11 SDK will be removed when -PassThru is specified. Use child property ShareClient instead.")]
    [Cmdlet("Remove", Azure.Commands.ResourceManager.Common.AzureRMConstants.AzurePrefix + "StorageShare",DefaultParameterSetName = Constants.ShareNameParameterSetName,SupportsShouldProcess = true), OutputType(typeof(AzureStorageFileShare))]
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

        [CmdletParameterBreakingChangeWithVersion("Share", "13.0.0", "8.0.0", ChangeDescription = "The parameter Share (alias CloudFileShare) will be deprecated, and ShareClient will be mandatory.")]
        [Parameter(
            Position = 0,
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "File share object to be removed.")]
        [ValidateNotNull]
        [Alias("CloudFileShare")]
        public CloudFileShare Share { get; set; }

        [Parameter(
            Position = 0,
            Mandatory = false,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = Constants.ShareParameterSetName,
            HelpMessage = "File share Client to be removed.")]
        [ValidateNotNull]
        public ShareClient ShareClient { get; set; }

        [Parameter(HelpMessage = "Remove File Share with all of its snapshots")]
        public SwitchParameter IncludeAllSnapshot { get; set; }

        [Parameter(
        Mandatory = false,
        ParameterSetName = Constants.ShareNameParameterSetName,
        ValueFromPipelineByPropertyName = true,
        HelpMessage = "SnapshotTime of the file share snapshot to be removed.")]
        public DateTimeOffset? SnapshotTime { get; set; }

        [Parameter(HelpMessage = "Force to remove the share with all its snapshots, and all content in them.")]
        public SwitchParameter Force
        {
            get { return force; }
            set { force = value; }
        }

        [Parameter(HelpMessage = "Returns an object representing the removed file share. By default, this cmdlet does not generate any output.")]
        public SwitchParameter PassThru { get; set; }

        private bool force;

        // Overwrite the useless parameter
        public override SwitchParameter DisAllowTrailingDot { get; set; }

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
            ShareClient share;
            switch (this.ParameterSetName)
            {
                case Constants.ShareParameterSetName:
                    if (this.ShareClient != null)
                    {
                        share = this.ShareClient;
                    }
                    else
                    {
                        share = AzureStorageFileShare.GetTrack2FileShareClient(this.Share, (AzureStorageContext)this.Context, this.ClientOptions);
                    }
                    this.SnapshotTime = this.Share.SnapshotTime == null ? null : this.Share.SnapshotTime;

                    // Build and set storage context for the output object when
                    // 1. input track1 object and storage context is missing 2. the current context doesn't match the context of the input object 
                    if (ShouldSetContext(this.Context, this.Share.ServiceClient))
                    {
                        this.Context = GetStorageContextFromTrack1FileServiceClient(this.Share.ServiceClient, DefaultContext);
                    }
                    break;

                case Constants.ShareNameParameterSetName:
                    NamingUtil.ValidateShareName(this.Name, false);
                    share = Util.GetTrack2ShareReference(this.Name,
                                (AzureStorageContext)this.Context,
                                this.SnapshotTime is null ? null : this.SnapshotTime.Value.ToUniversalTime().ToString("o").Replace("+00:00", "Z"),
                                ClientOptions);
                    break;

                default:
                    throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid parameter set name: {0}", this.ParameterSetName));
            }

            if (ShouldProcess(share.Name, "Remove share"))
            {
                this.RunTask(async taskId =>
                {                   
                    if (Util.GetSnapshotTimeFromUri(share.Uri) != null // this is share snapshot
                            && IncludeAllSnapshot.IsPresent)
                    {
                        throw new PSArgumentException(string.Format(CultureInfo.InvariantCulture, "'IncludeAllSnapshot' should only be specified to delete a base share, and should not be specified to delete a Share snapshot: {0}", share.Uri));
                    }

                    string promptMessage;
                    if (this.SnapshotTime != null)
                    {
                        promptMessage = string.Format("Remove share snapshot and all files in it: {0}, SnapshotTime: {1}", share.Name, this.SnapshotTime.Value.ToUniversalTime().ToString("o"));
                    }
                    else
                    {
                        promptMessage = string.Format("Remove share and all content in it: {0}", share.Name);
                    }

                    if (force || ShareIsEmpty(share) || ShouldContinue(promptMessage, ""))
                    {
                        bool includeSnapshots = false;
                        bool retryDeleteSnapshot = false;

                        //Force means will delete the share anyway, so use 'IncludeSnapshots' to delete the share even has snapshot, or delete will fail when share has snapshot
                        // To delete a Share shapshot, must use 'None' 
                        if (IncludeAllSnapshot.IsPresent)
                        {
                            includeSnapshots = true;
                        }
                        else
                        {
                            retryDeleteSnapshot = true;
                        }

                        try
                        {
                            share.Delete(includeSnapshots, this.CmdletCancellationToken);
                            retryDeleteSnapshot = false;
                        }
                        catch (global::Azure.RequestFailedException e)
                        {
                            //If x-ms-delete-snapshots is not specified on the request and the share has associated snapshots, the File service returns status code 409 (Conflict).
                            if (!(e.Status == 409 && retryDeleteSnapshot))
                            {
                                throw;
                            }
                        }

                        if (retryDeleteSnapshot)
                        {
                            if (force || await OutputStream.ConfirmAsync(string.Format("This share might have snapshots, remove the share and all snapshots?: {0}", share.Name)).ConfigureAwait(false))
                            {
                                includeSnapshots = true;
                                share.Delete(includeSnapshots, this.CmdletCancellationToken);
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
                        WriteObject(new AzureStorageFileShare(share, (AzureStorageContext)this.Context, shareProperties: null, ClientOptions));
                    }
                });
            }
        }
    }
}
