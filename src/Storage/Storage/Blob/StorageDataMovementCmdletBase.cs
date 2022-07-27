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
    using Microsoft.WindowsAzure.Commands.Storage.Common;
    using Microsoft.Azure.Storage.DataMovement;
    using System;
    using System.Globalization;
    using System.Management.Automation;
    using System.Threading.Tasks;
    using OpContext = Microsoft.Azure.Storage.OperationContext;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    public class StorageDataMovementCmdletBase : StorageCloudBlobCmdletBase, IDisposable
    {
        protected const int size4MB = 4 * 1024 * 1024;

        protected const int size8MB = 8 * 1024 * 1024;

        /// <summary>
        /// block blob type
        /// </summary>
        protected const string BlockBlobType = "Block";

        /// <summary>
        /// page blob type
        /// </summary>
        protected const string PageBlobType = "Page";

        /// <summary>
        /// append blob type
        /// </summary>
        protected const string AppendBlobType = "Append";

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

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public virtual SwitchParameter AsJob { get; set; }

        public string ResolvedFileName { get; set; }

        /// <summary>
        /// Confirm the overwrite operation
        /// </summary>
        /// <param name="source">Indicating the source.</param>
        /// <param name="destination">Indicating the destination.</param>
        /// <returns>True if the opeation is confirmed, otherwise return false</returns>
        protected bool ConfirmOverwrite(object source, object destination)
        {
            string overwriteMessage = string.Format(CultureInfo.CurrentCulture, Resources.OverwriteConfirmation, Util.ConvertToString(destination));
            return overwrite || OutputStream.ConfirmAsync(overwriteMessage).Result;
        }

        /// <summary>
        /// Confirm the overwrite operation
        /// </summary>
        /// <param name="source">Indicating the source.</param>
        /// <param name="destination">Indicating the destination.</param>
        /// <returns>True if the opeation is confirmed, otherwise return false</returns>
        protected async Task<bool> ConfirmOverwriteAsync(object source, object destination)
        {
            string overwriteMessage = string.Format(CultureInfo.CurrentCulture, Resources.OverwriteConfirmation, Util.ConvertToString(destination));
            return overwrite || await OutputStream.ConfirmAsync(overwriteMessage);
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
            DoBeginProcessing();
        }

        protected virtual void DoBeginProcessing()
        {
            CmdletOperationContext.Init();
            CmdletCancellationToken = _cancellationTokenSource.Token;
            WriteDebugLog(String.Format(Resources.InitOperationContextLog, GetType().Name, CmdletOperationContext.ClientRequestId));

            if (_enableMultiThread)
            {
                SetUpMultiThreadEnvironment();
            }

            OpContext.GlobalSendingRequest +=
                (sender, args) =>
                {
                    //https://github.com/Azure/azure-storage-net/issues/658
                };

            OutputStream.ConfirmWriter = (s1, s2, s3) => ShouldContinue(s2, s3);

            this.TransferManager = TransferManagerFactory.CreateTransferManager(this.GetCmdletConcurrency());
        }
        
        protected SingleTransferContext GetTransferContext(DataMovementUserData userData)
        {
            SingleTransferContext transferContext = new SingleTransferContext();
            transferContext.ClientRequestId = CmdletOperationContext.ClientRequestId;
            if (overwrite)
            {
                transferContext.ShouldOverwriteCallbackAsync = TransferContext.ForceOverwrite;
            }
            else
            {
                transferContext.ShouldOverwriteCallbackAsync = ConfirmOverwriteAsync;
            }

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
            if (!AsJob.IsPresent)
            {
                DoEndProcessing();
            }
        }

        protected virtual void DoEndProcessing()
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

        /// <summary>
        /// Get the block size from block blob length
        /// </summary>
        public static long GetBlockLength(long contentLength)
        {
            if (contentLength <= size8MB)
            {
                return contentLength;
            }
            long blockLength = contentLength / 50000;
            if (blockLength % (size8MB) != 0)
            {
                blockLength = (blockLength / (size8MB) + 1) * (size8MB);
            }
            return blockLength > 0 ? blockLength : contentLength;
        }

        /// <summary>
        /// Get the block id arrary from block blob length, block size and blob name
        /// </summary>
        public static string[] GetBlockIDs(long contentLength, long blockLength, string blobname)
        {
            long blockCount = 0;
            if (blockLength != 0)
            {
                blockCount = contentLength / blockLength;
            }
            if (blockCount * blockLength != contentLength)
            {
                blockCount++;
            }
            List<string> blockIDs = new List<string>();
            string blockIdPrefix = Convert.ToBase64String(MD5.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(blobname)));
            for (int i = 0; i < (int)blockCount; i++)
            {
                string idNo = i.ToString();
                while (idNo.Length < 5)
                {
                    idNo = "0" + idNo;
                }
                string blockID = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(blockIdPrefix + idNo));
                blockIDs.Add(blockID);
            }
            return blockIDs.ToArray();
        }
    }
}
