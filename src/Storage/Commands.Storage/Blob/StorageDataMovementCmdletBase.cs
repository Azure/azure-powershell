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

using System.Security.Cryptography;

namespace Microsoft.WindowsAzure.Commands.Storage.Blob
{
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.WindowsAzure.Storage.DataMovement;
    using System;
    using System.Globalization;
    using System.Management.Automation;

    public class StorageDataMovementCmdletBase : StorageCloudBlobCmdletBase, IDisposable
    {
        /// <summary>
        /// Blob Transfer Manager
        /// </summary>
        protected ITransferManager TransferManager
        {
            get;
            private set;
        }

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
        protected bool ConfirmOverwrite(object source, object destination)
        {
            string overwriteMessage = string.Format(CultureInfo.CurrentCulture, Resources.OverwriteConfirmation, Util.ConvertToString(destination));
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
            OutputStream.ConfirmWriter = (s1, s2, s3) => ShouldContinue(s2, s3);

            this.TransferManager = TransferManagerFactory.CreateTransferManager(this.GetCmdletConcurrency());
        }

        protected SingleTransferContext GetTransferContext(DataMovementUserData userData)
        {
            SingleTransferContext transferContext = new SingleTransferContext();
            transferContext.ClientRequestId = CmdletOperationContext.ClientRequestId;
            transferContext.ShouldOverwriteCallback = ConfirmOverwrite;

            transferContext.ProgressHandler = new TransferProgressHandler((transferProgress) =>
                {
                    if (userData.Record != null)
                    {
                        // Size of the source file might be 0, when it is, directly treat the progress as 100 percent.
                        userData.Record.PercentComplete = 0 == userData.TotalSize ? 100 : (int)(transferProgress.BytesTransferred * 100 / userData.TotalSize);
                        userData.Record.StatusDescription = string.Format(CultureInfo.CurrentCulture, Resources.FileTransmitStatus, userData.Record.PercentComplete);
                        this.OutputStream.WriteProgress(userData.Record);
                    }
                });

            return transferContext;
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
                this.TransferManager = null;
            }
        }
    }
}
