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

using System;
using System.Globalization;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Storage.DataMovement.TransferJobs;

namespace Microsoft.WindowsAzure.Commands.Storage.File
{
    public abstract class StorageFileDataManagementCmdletBase : AzureStorageFileCmdletBase
    {
        /// <summary>
        /// Stores the default concurrent task count which is 10.
        /// </summary>
        private const int DefaultConcurrentTaskCount = 10;

        /// <summary>
        /// Stores the transfer job runner instance.
        /// </summary>
        private ITransferJobRunner transferJobRunner;

        /// <summary>
        /// Gets or sets whether to force overwrite the existing file.
        /// </summary>
        [Parameter(HelpMessage = "Force to overwrite the existing file.")]
        public SwitchParameter Force
        {
            get;
            set;
        }

        /// <summary>
        /// Confirm the overwrite operation
        /// </summary>
        /// <param name="sourcePath">Indicating the source path.</param>
        /// <param name="destinationPath">Indicating the destination path.</param>
        /// <returns>Returns a value indicating whether to overwrite.</returns>
        private bool ConfirmOverwrite(string sourcePath, string destinationPath)
        {
            return this.Force || this.OutputStream.ConfirmAsync(string.Format(CultureInfo.CurrentCulture, Resources.OverwriteConfirmation, destinationPath)).Result;
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            this.transferJobRunner = TransferJobRunnerFactory.CreateRunner(this.ConcurrentTaskCount ?? DefaultConcurrentTaskCount);
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            this.WriteTaskSummary();

            this.transferJobRunner.Dispose();
            this.transferJobRunner = null;
        }

        protected async Task RunTransferJob(FileTransferJob job, ProgressRecord record)
        {
            this.SetRequestOptionsInTransferJob(job);
            job.AccessCondition = this.AccessCondition;
            job.OverwritePromptCallback = this.ConfirmOverwrite;

            try
            {
                await this.transferJobRunner.RunTransferJob(job,
                        (percent, speed) =>
                        {
                            record.PercentComplete = (int)percent;
                            record.StatusDescription = string.Format(CultureInfo.CurrentCulture, Resources.FileTransmitStatus, (int)percent, Util.BytesToHumanReadableSize(speed));
                            this.OutputStream.WriteProgress(record);
                        },
                        this.CmdletCancellationToken);

                record.PercentComplete = 100;
                record.StatusDescription = Resources.TransmitSuccessfully;
                this.OutputStream.WriteProgress(record);
            }
            catch (OperationCanceledException)
            {
                record.StatusDescription = Resources.TransmitCancelled;
                this.OutputStream.WriteProgress(record);
            }
            catch (Exception e)
            {
                record.StatusDescription = string.Format(CultureInfo.CurrentCulture, Resources.TransmitFailed, e.Message);
                this.OutputStream.WriteProgress(record);
                throw;
            }
        }

        protected void SetRequestOptionsInTransferJob(FileTransferJob transferJob)
        {
            var cmdletOptions = this.RequestOptions;

            if (cmdletOptions == null)
            {
                return;
            }

            var requestOptions = transferJob.FileRequestOptions;

            if (cmdletOptions.MaximumExecutionTime != null)
            {
                requestOptions.MaximumExecutionTime = cmdletOptions.MaximumExecutionTime;
            }

            if (cmdletOptions.ServerTimeout != null)
            {
                requestOptions.ServerTimeout = cmdletOptions.ServerTimeout;
            }

            requestOptions.DisableContentMD5Validation = true;

            transferJob.FileRequestOptions = requestOptions;
        }
    }
}
