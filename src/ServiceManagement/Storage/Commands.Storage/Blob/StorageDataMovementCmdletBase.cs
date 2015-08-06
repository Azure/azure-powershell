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

namespace Microsoft.WindowsAzure.Commands.Storage.Blob
{
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.DataMovement;

    public class StorageDataMovementCmdletBase : StorageCloudBlobCmdletBase, IDisposable
    {
        /// <summary>
        /// Blob Transfer Manager
        /// </summary>
        private ITransferJobRunner transferJobRunner;

        [Parameter(HelpMessage = "Force to overwrite the existing blob or file")]
        public SwitchParameter Force
        {
            get { return overwrite; }
            set { overwrite = value; }
        }

        protected bool overwrite;

        /// <summary>
        /// Confirm the overwrite operation
        /// </summary>
        /// <param name="msg">Confirmation message</param>
        /// <returns>True if the opeation is confirmed, otherwise return false</returns>
        protected bool ConfirmOverwrite(string sourcePath, string destinationPath)
        {
            string overwriteMessage = string.Format(CultureInfo.CurrentCulture, Resources.OverwriteConfirmation, destinationPath);
            return overwrite || OutputStream.ConfirmAsync(overwriteMessage).Result;
        }

        /// <summary>
        /// On Task run successfully
        /// </summary>
        /// <param name="data">User data</param>
        protected virtual void OnTaskSuccessful(DataMovementUserData data)
        { }


        /// <summary>
        /// Cmdlet begin processing
        /// </summary>
        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            this.transferJobRunner = TransferJobRunnerFactory.CreateRunner(this.GetCmdletConcurrency());
        }

        protected async Task RunTransferJob(TransferJob transferJob, DataMovementUserData userData)
        {
            this.SetRequestOptionsInTransferJob(transferJob);
            transferJob.OverwritePromptCallback = ConfirmOverwrite;

            try
            {
                await this.transferJobRunner.RunTransferJob(
                    transferJob,
                    (percent, speed) =>
                    {
                        if (userData.Record != null)
                        {
                            userData.Record.PercentComplete = (int)percent;
                            userData.Record.StatusDescription = string.Format(CultureInfo.CurrentCulture, Resources.FileTransmitStatus, (int)percent, Util.BytesToHumanReadableSize(speed));
                            this.OutputStream.WriteProgress(userData.Record);
                        }
                    },
                    this.CmdletCancellationToken);

                if (userData.Record != null)
                {
                    userData.Record.PercentComplete = 100;
                    userData.Record.StatusDescription = Resources.TransmitSuccessfully;
                    this.OutputStream.WriteProgress(userData.Record);
                }
            }
            catch (OperationCanceledException)
            {
                if (userData.Record != null)
                {
                    userData.Record.StatusDescription = Resources.TransmitCancelled;
                    this.OutputStream.WriteProgress(userData.Record);
                }
            }
            catch (Exception e)
            {
                if (userData.Record != null)
                {
                    userData.Record.StatusDescription = string.Format(CultureInfo.CurrentCulture, Resources.TransmitFailed, e.Message);
                    this.OutputStream.WriteProgress(userData.Record);
                }

                throw;
            }
        }

        protected void SetRequestOptionsInTransferJob(TransferJob transferJob)
        {
            BlobRequestOptions cmdletOptions = RequestOptions;

            if (cmdletOptions == null)
            {
                return;
            }

            if (null != transferJob.Source.Blob)
            {
                this.SetRequestOptions(transferJob.Source, cmdletOptions);
            }

            if (null != transferJob.Destination.Blob)
            {
                this.SetRequestOptions(transferJob.Destination, cmdletOptions);
            }
        }

        protected void SetRequestOptions(TransferLocation location, BlobRequestOptions cmdletOptions)
        {
            BlobRequestOptions requestOptions = location.RequestOptions as BlobRequestOptions;

            if (null == requestOptions)
            {
                requestOptions = new BlobRequestOptions();
            }

            if (cmdletOptions.MaximumExecutionTime != null)
            {
                requestOptions.MaximumExecutionTime = cmdletOptions.MaximumExecutionTime;
            }

            if (cmdletOptions.ServerTimeout != null)
            {
                requestOptions.ServerTimeout = cmdletOptions.ServerTimeout;
            }

            location.RequestOptions = requestOptions;
        }

        protected override void EndProcessing()
        {
            try
            {
                base.EndProcessing();
                WriteTaskSummary();
            }
            finally
            {
                this.transferJobRunner.Dispose();
                this.transferJobRunner = null;
            }
        }

        /// <summary>
        /// Dispose DataMovement cmdlet
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Dispose DataMovement cmdlet
        /// </summary>
        /// <param name="disposing">User disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.transferJobRunner != null)
                {
                    this.transferJobRunner.Dispose();
                    this.transferJobRunner = null;
                }
            }
        }
    }
}
