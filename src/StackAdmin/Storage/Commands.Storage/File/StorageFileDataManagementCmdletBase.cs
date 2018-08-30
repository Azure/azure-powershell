﻿﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.WindowsAzure.Commands.Storage.File
{
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Commands.Storage.Blob;
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.DataMovement;
    using Microsoft.WindowsAzure.Storage.File;

    public abstract class StorageFileDataManagementCmdletBase : AzureStorageFileCmdletBase
    {
        /// <summary>
        /// Stores the default concurrent task count which is 10.
        /// </summary>
        private const int DefaultConcurrentTaskCount = 10;

        /// <summary>
        /// Stores the transfer manager instance.
        /// </summary>
        protected ITransferManager TransferManager
        {
            get;
            private set;
        }

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
        protected bool ConfirmOverwrite(string sourcePath, string destinationPath)
        {
            return this.Force || this.OutputStream.ConfirmAsync(string.Format(CultureInfo.CurrentCulture, Resources.OverwriteConfirmation, destinationPath)).Result;
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            this.TransferManager = TransferManagerFactory.CreateTransferManager(this.GetCmdletConcurrency());
        }

        protected override void EndProcessing()
        {
            try
            {
                base.EndProcessing();
                this.WriteTaskSummary();
            }
            finally
            {
                this.TransferManager = null;
            }
        }

        protected TransferContext GetTransferContext(ProgressRecord record, long totalTransferLength)
        {
            TransferContext transferContext = new TransferContext();
            transferContext.ClientRequestId = CmdletOperationContext.ClientRequestId;
            transferContext.OverwriteCallback = ConfirmOverwrite;

            transferContext.ProgressHandler = new TransferProgressHandler((transferProgress) =>
            {
                if (record != null)
                {
                    record.PercentComplete = (int)(transferProgress.BytesTransferred * 100 / totalTransferLength);
                    record.StatusDescription = string.Format(CultureInfo.CurrentCulture, Resources.FileTransmitStatus, record.PercentComplete);
                    this.OutputStream.WriteProgress(record);
                }
            });

            return transferContext;
        }
    }
}
