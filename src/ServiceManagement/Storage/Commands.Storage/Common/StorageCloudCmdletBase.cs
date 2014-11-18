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
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Management.Automation;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Storage;
using Microsoft.WindowsAzure.Commands.Storage.File;
using Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    /// <summary>
    /// Base cmdlet for all storage cmdlet that works with cloud
    /// </summary>
    public class StorageCloudCmdletBase<T> : CloudBaseCmdlet<T>
        where T : class
    {
        [Parameter(HelpMessage = "Azure Storage Context Object",
            ValueFromPipelineByPropertyName = true)]
        public virtual AzureStorageContext Context { get; set; }

        [Parameter(HelpMessage = "The server time out for each request in seconds.")]
        public virtual int? ServerTimeoutPerRequest { get; set; }

        [Parameter(HelpMessage = "The client side maximum execution time for each request in seconds.")]
        public virtual int? ClientTimeoutPerRequest { get; set; }

        /// <summary>
        /// Amount of concurrent async tasks to run per available core.
        /// </summary>
        protected int concurrentTaskCount = 10;

        /// <summary>
        /// Amount of concurrent async tasks to run per available core.
        /// </summary>
        [Parameter(HelpMessage = "The total amount of concurrent async tasks. The default value is 10.")]
        [ValidateNotNull]
        [ValidateRange(1, 1000)]
        public virtual int? ConcurrentTaskCount
        {
            get { return concurrentTaskCount; }
            set
            {
                int count = value.Value;

                if (count > 0)
                {
                    concurrentTaskCount = count;
                }
            }
        }

        /// <summary>
        /// Cancellation Token Source
        /// </summary>
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        protected CancellationToken CmdletCancellationToken;

        /// <summary>
        /// whether stop processing
        /// </summary>
        protected bool ShouldForceQuit { get { return cancellationTokenSource.Token.IsCancellationRequested; } }

        /// <summary>
        /// Enable or disable multithread
        ///     If the storage cmdlet want to disable the multithread feature,
        ///     it can disable when construct and beginProcessing
        /// </summary>
        protected bool EnableMultiThread
        {
            get { return enableMultiThread; }
            set { enableMultiThread = value; }
        }
        private bool enableMultiThread = true;

        internal TaskOutputStream OutputStream;

        //CountDownEvent wait time out and output time interval.
        protected const int WaitTimeout = 1000;//ms

        /// <summary>
        /// Summary progress record on multithread task
        /// </summary>
        protected ProgressRecord summaryRecord;

        private LimitedConcurrencyTaskScheduler taskScheduler;

        /// <summary>
        /// Cmdlet operation context.
        /// </summary>
        protected OperationContext OperationContext
        {
            get
            {
                return CmdletOperationContext.GetStorageOperationContext(WriteDebugLog);
            }
        }

        /// <summary>
        /// Write log in debug mode
        /// </summary>
        /// <param name="msg">Debug log</param>
        internal void WriteDebugLog(string msg)
        {
            WriteDebugWithTimestamp(msg);
        }

        /// <summary>
        /// Get a request options
        /// </summary>
        /// <param name="type">Service type</param>
        /// <returns>Request options</returns>
        public IRequestOptions GetRequestOptions(StorageServiceType type)
        {
            IRequestOptions options;

            switch (type)
            {
                case StorageServiceType.Blob:
                    options = new BlobRequestOptions();
                    break;
                case StorageServiceType.Queue:
                    options = new QueueRequestOptions();
                    break;
                case StorageServiceType.Table:
                    options = new TableRequestOptions();
                    break;
                case StorageServiceType.File:
                    options = new FileRequestOptions();
                    break;
                default:
                    throw new ArgumentException(Resources.InvalidStorageServiceType, "type");
            }

            if (this.ServerTimeoutPerRequest.HasValue)
            {
                options.ServerTimeout = ConvertToTimeSpan(this.ServerTimeoutPerRequest.Value);
            }

            if (this.ClientTimeoutPerRequest.HasValue)
            {
                options.MaximumExecutionTime = ConvertToTimeSpan(this.ClientTimeoutPerRequest.Value);
            }

            return options;
        }

        /// <summary>
        /// Get cloud storage account 
        /// </summary>
        /// <returns>Storage account</returns>
        internal AzureStorageContext GetCmdletStorageContext()
        {
            if (Context != null)
            {
                WriteDebugLog(String.Format(Resources.UseStorageAccountFromContext, Context.StorageAccountName));
            }
            else
            {
                CloudStorageAccount account = null;
                bool shouldInitChannel = ShouldInitServiceChannel();

                try
                {
                    if (shouldInitChannel)
                    {
                        account = GetStorageAccountFromSubscription();
                    }
                    else
                    {
                        account = GetStorageAccountFromEnvironmentVariable();
                    }
                }
                catch (Exception e)
                {
                    //stop the pipeline if storage account is missed.
                    WriteTerminatingError(e);
                }

                //Set the storage context and use it in pipeline
                Context = new AzureStorageContext(account);
            }

            return Context;
        }

        /// <summary>
        /// Output azure storage object with storage context
        /// </summary>
        /// <param name="item">An AzureStorageBase object</param>
        internal void WriteObjectWithStorageContext(AzureStorageBase item)
        {
            item.Context = Context;

            WriteObject(item);
        }

        /// <summary>
        /// Init channel with or without subscription in storage cmdlet
        /// </summary>
        /// <param name="force">Force to create a new channel</param>
        protected override void InitChannelCurrentSubscription(bool force)
        {
            //Create storage management channel
            CreateChannel();
        }

        /// <summary>
        /// Whether should init the service channel or not
        /// </summary>
        /// <returns>True if it need to init the service channel, otherwise false</returns>
        internal virtual bool ShouldInitServiceChannel()
        {
            //Storage Context is empty and have already set the current storage account in subscription
            if (Context == null && HasCurrentSubscription && CurrentContext.Subscription != null &&
                !String.IsNullOrEmpty(CurrentContext.Subscription.GetProperty(AzureSubscription.Property.StorageAccount)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Output azure storage object with storage context
        /// </summary>
        /// <param name="itemList">An enumerable collection fo azurestorage object</param>
        internal void WriteObjectWithStorageContext(IEnumerable<AzureStorageBase> itemList)
        {
            if (null == itemList)
            {
                return;
            }

            foreach (AzureStorageBase item in itemList)
            {
                WriteObjectWithStorageContext(item);
            }
        }

        /// <summary>
        /// Convert the timeout in seconds into objects of TimeSpan. Notice
        /// that xSCL does not accept a TimeSpan whose TotalMilliseconds
        /// property exceeded int.MaxValue (2147483647) so if user specified a
        /// value beyond that, we will use Infinite instead.
        /// </summary>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        private static TimeSpan? ConvertToTimeSpan(int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var timeSpan = TimeSpan.FromSeconds(timeoutInSeconds);
                if ((long)timeSpan.TotalMilliseconds > int.MaxValue)
                {
                    return null;
                }
                else
                {
                    return timeSpan;
                }
            }
            else if (timeoutInSeconds == Timeout.Infinite)
            {
                return null;
            }
            else
            {
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, Resources.InvalidTimeoutValue, timeoutInSeconds));
            }
        }

        /// <summary>
        /// Get current storage account from azure subscription
        /// </summary>
        /// <returns>A storage account</returns>
        private CloudStorageAccount GetStorageAccountFromSubscription()
        {
            string CurrentStorageAccountName = CurrentContext.Subscription.GetProperty(AzureSubscription.Property.StorageAccount);

            if (string.IsNullOrEmpty(CurrentStorageAccountName))
            {
                throw new ArgumentException(Resources.DefaultStorageCredentialsNotFound);
            }
            else
            {
                WriteDebugLog(String.Format(Resources.UseCurrentStorageAccountFromSubscription, CurrentStorageAccountName, CurrentContext.Subscription.Name));

                try
                {
                    //The service channel initialized by subscription
                    return CurrentContext.Subscription.GetCloudStorageAccount();
                }
                catch (System.ServiceModel.CommunicationException e)
                {
                    WriteVerboseWithTimestamp(Resources.CannotGetSotrageAccountFromSubscription);

                    if (e.IsNotFoundException())
                    {
                        //Repack the 404 error
                        string errorMessage = String.Format(Resources.CurrentStorageAccountNotFoundOnAzure, CurrentStorageAccountName, CurrentContext.Subscription.Name);
                        System.ServiceModel.CommunicationException exception = new System.ServiceModel.CommunicationException(errorMessage, e);
                        throw exception;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Get storage account from environment variable "AZURE_STORAGE_CONNECTION_STRING"
        /// </summary>
        /// <returns>Cloud storage account</returns>
        private CloudStorageAccount GetStorageAccountFromEnvironmentVariable()
        {
            String connectionString = System.Environment.GetEnvironmentVariable(Resources.EnvConnectionString);

            if (String.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException(Resources.DefaultStorageCredentialsNotFound);
            }
            else
            {
                WriteDebugLog(Resources.GetStorageAccountFromEnvironmentVariable);

                try
                {
                    return CloudStorageAccount.Parse(connectionString);
                }
                catch
                {
                    WriteVerboseWithTimestamp(Resources.CannotGetStorageAccountFromEnvironmentVariable);
                    throw;
                }
            }
        }

        /// <summary>
        /// Write error with category and identifier
        /// </summary>
        /// <param name="e">an exception object</param>
        protected override void WriteExceptionError(Exception e)
        {
            Debug.Assert(e != null, Resources.ExceptionCannotEmpty);

            if (e is StorageException)
            {
                e = ((StorageException)e).RepackStorageException();
            }
            else if (e is AzureStorageFileException)
            {
                WriteError(((AzureStorageFileException)e).GetErrorRecord());
                return;
            }

            WriteError(new ErrorRecord(e, e.GetType().Name, GetExceptionErrorCategory(e), null));
        }

        /// <summary>
        /// Get the error category for specificed exception
        /// </summary>
        /// <param name="e">Exception object</param>
        /// <returns>Error category</returns>
        protected ErrorCategory GetExceptionErrorCategory(Exception e)
        {
            ErrorCategory errorCategory = ErrorCategory.CloseError; //default error category

            if (e is ArgumentException)
            {
                errorCategory = ErrorCategory.InvalidArgument;
            }
            else if (e is ResourceNotFoundException)
            {
                errorCategory = ErrorCategory.ObjectNotFound;
            }
            else if (e is ResourceAlreadyExistException)
            {
                errorCategory = ErrorCategory.ResourceExists;
            }

            return errorCategory;
        }

        /// <summary>
        /// write terminating error
        /// </summary>
        /// <param name="e">exception object</param>
        protected void WriteTerminatingError(Exception e)
        {
            Debug.Assert(e != null, Resources.ExceptionCannotEmpty);
            ThrowTerminatingError(new ErrorRecord(e, e.GetType().Name, GetExceptionErrorCategory(e), null));
        }

        /// <summary>
        /// Get the concurrency value
        /// </summary>
        /// <returns>The max number of concurrent task/rest call</returns>
        protected int GetCmdletConcurrency()
        {
            return concurrentTaskCount;
        }

        /// <summary>
        /// Configure Service Point
        /// </summary>
        private void ConfigureServicePointManager()
        {
            int maxConcurrency = 1000;
            int cmdletConcurrency = GetCmdletConcurrency();
            maxConcurrency = Math.Max(maxConcurrency, cmdletConcurrency);
            //Set the default connection limit to a very high value and control the concurrency with LimitedConcurrencyTaskScheduler.
            //If so, there is no need to set the ConnectionLimit for each ServicePoint.
            ServicePointManager.DefaultConnectionLimit = maxConcurrency;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.UseNagleAlgorithm = true;
        }

        private void TaskErrorHandler(object sender, TaskExceptionEventArgs args)
        {
            if (OutputStream != null)
            {
                OutputStream.WriteError(args.TaskId, args.Exception);
            }
        }

        /// <summary>
        /// Init the multithread run time resource
        /// </summary>
        internal void InitMutltiThreadResources()
        {
            taskScheduler = new LimitedConcurrencyTaskScheduler(GetCmdletConcurrency(), CmdletCancellationToken);
            OutputStream = new TaskOutputStream(CmdletCancellationToken);
            OutputStream.OutputWriter = WriteObject;
            OutputStream.ErrorWriter = WriteExceptionError;
            OutputStream.ProgressWriter = WriteProgress;
            OutputStream.VerboseWriter = WriteVerbose;
            OutputStream.DebugWriter = WriteDebugWithTimestamp;
            OutputStream.ConfirmWriter = ShouldProcess;
            OutputStream.TaskStatusQueryer = taskScheduler.IsTaskCompleted;
            taskScheduler.OnError += TaskErrorHandler;

            int summaryRecordId = 0;
            string summary = String.Format(Resources.TransmitActiveSummary, taskScheduler.TotalTaskCount,
                taskScheduler.FinishedTaskCount, taskScheduler.FailedTaskCount, taskScheduler.ActiveTaskCount);
            string activity = string.Format(Resources.TransmitActivity, this.MyInvocation.MyCommand);
            summaryRecord = new ProgressRecord(summaryRecordId, activity, summary);
            CmdletCancellationToken.Register(() => OutputStream.CancelConfirmRequest());
        }

        /// <summary>
        /// Set up MultiThread environment
        /// </summary>
        internal void SetUpMultiThreadEnvironment()
        {
            ConfigureServicePointManager();
            InitMutltiThreadResources();
        }

        /// <summary>
        /// End processing in multi thread environment
        /// </summary>
        internal void MultiThreadEndProcessing()
        {
            do
            {
                WriteTransmitSummaryStatus();
                //When task add to datamovement library, it will immediately start.
                //So, we'd better output status at first.
                OutputStream.Output();
            }
            while (!taskScheduler.WaitForComplete(WaitTimeout, CmdletCancellationToken));

            CloseSummaryProgressBar();
            OutputStream.Output();
        }

        protected void WriteTaskSummary()
        {
            WriteVerbose(String.Format(Resources.TransferSummary, taskScheduler.TotalTaskCount,
                taskScheduler.FinishedTaskCount, taskScheduler.FailedTaskCount, taskScheduler.ActiveTaskCount));
        }

        /// <summary>
        /// Close the summary progress bar, otherwise it'll cause a very bad performance on output.
        /// </summary>
        private void CloseSummaryProgressBar()
        {
            OutputStream.DisableProgressBar = true;
            summaryRecord.RecordType = ProgressRecordType.Completed;
            WriteProgress(summaryRecord);
        }

        internal void RunTask(Func<long, Task> taskGenerator)
        {
            taskScheduler.RunTask(taskGenerator);
        }

        /// <summary>
        /// Write transmit summary status
        /// </summary>
        protected virtual void WriteTransmitSummaryStatus()
        {
            string summary = String.Format(Resources.TransmitActiveSummary, taskScheduler.TotalTaskCount,
                taskScheduler.FinishedTaskCount, taskScheduler.FailedTaskCount, taskScheduler.ActiveTaskCount);
            summaryRecord.StatusDescription = summary;
            WriteProgress(summaryRecord);
        }

        /// <summary>
        /// Cmdlet begin process
        /// </summary>
        protected override void BeginProcessing()
        {
            CmdletOperationContext.Init();
            CmdletCancellationToken = cancellationTokenSource.Token;
            WriteDebugLog(String.Format(Resources.InitOperationContextLog, this.GetType().Name, CmdletOperationContext.ClientRequestId));

            if (enableMultiThread)
            {
                SetUpMultiThreadEnvironment();
            }

            base.BeginProcessing();
        }

        /// <summary>
        /// End processing
        /// </summary>
        protected override void EndProcessing()
        {
            if (enableMultiThread)
            {
                MultiThreadEndProcessing();
            }

            double timespan = CmdletOperationContext.GetRunningMilliseconds();
            string message = string.Format(Resources.EndProcessingLog,
                this.GetType().Name, CmdletOperationContext.StartedRemoteCallCounter, CmdletOperationContext.FinishedRemoteCallCounter, timespan, CmdletOperationContext.ClientRequestId);
            WriteDebugLog(message);
            base.EndProcessing();
        }

        /// <summary>
        /// stop processing
        /// time-consuming operation should work with ShouldForceQuit
        /// </summary>
        protected override void StopProcessing()
        {
            //ctrl + c and etc
            cancellationTokenSource.Cancel();
            base.StopProcessing();
        }
    }
}
