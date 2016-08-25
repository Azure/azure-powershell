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

using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Hadoop.Client;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.BaseCommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;
using Microsoft.WindowsAzure.Management.HDInsight.Logging;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters
{
    internal abstract class InvokeAzureHDInsightJobCommandBase : IInvokeAzureHDInsightJobCommand
    {
        private const string HiveQueryFileStoragePath = "http://{0}/{1}/user/{2}/{3}.hql";
        private const decimal Success = 0;

        private const double WaitAnHourInSeconds = 3600;

        private readonly object lockObject = new object();
        private bool canceled;
        private IAzureHDInsightCommandBase client;

        public InvokeAzureHDInsightJobCommandBase()
        {
            this.Output = new ObservableCollection<string>();
        }

        public CancellationToken CancellationToken
        {
            get { return this.client != null ? this.client.CancellationToken : new CancellationTokenSource().Token; }
        }

        public AzureSubscription CurrentSubscription { get; set; }

        public AzureHDInsightClusterConnection Connection { get; set; }

        public AzureHDInsightHiveJobDefinition JobDefinition { get; set; }

        public JobDetails JobDetailsStatus { get; private set; }

        public string JobId { get; private set; }

        public ILogWriter Logger { get; set; }

        public ObservableCollection<string> Output { get; private set; }

        public void Cancel()
        {
            lock (this.lockObject)
            {
                this.canceled = true;
                if (this.client.IsNotNull())
                {
                    this.client.Cancel();
                }
            }
        }

        public async Task EndProcessing()
        {
            this.Connection.ArgumentNotNull("Connection");
            this.JobDefinition.ArgumentNotNull("HiveJob");

            this.Output.Clear();
            AzureHDInsightClusterConnection currentConnection = this.Connection;

            this.WriteOutput("Submitting Hive query..");
            AzureHDInsightHiveJobDefinition hiveJobDefinition = this.JobDefinition;
            if (hiveJobDefinition.Query.IsNotNullOrEmpty() && hiveJobDefinition.File.IsNullOrEmpty())
            {
                hiveJobDefinition = this.UploadFileToStorage(this.JobDefinition, currentConnection);
            }

            var startedJob = await this.StartJob(hiveJobDefinition, currentConnection);
            this.JobId = startedJob.JobId;
            this.WriteOutput("Started Hive query with jobDetails Id : {0}", startedJob.JobId);

            var completedJob = await this.WaitForCompletion(startedJob, currentConnection);
            if (completedJob.ExitCode == Success)
            {
                await this.WriteJobSuccess(completedJob, currentConnection);
            }
            else
            {
                await this.WriteJobFailure(completedJob, currentConnection);
            }
        }

        public void SetClient(IAzureHDInsightCommandBase client)
        {
            lock (this.lockObject)
            {
                this.client = client;
            }
        }

        public void ValidateNotCanceled()
        {
            if (this.canceled)
            {
                throw new OperationCanceledException("The operation was canceled by the user.");
            }
        }

        protected virtual async Task<AzureHDInsightJob> StartJob(
            AzureHDInsightJobDefinition jobDefinition, AzureHDInsightClusterConnection currentConnection)
        {
            jobDefinition.ArgumentNotNull("jobDefinition");
            currentConnection.ArgumentNotNull("currentCluster");
            this.ValidateNotCanceled();
            var startJobCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateStartJob();
            this.SetClient(startJobCommand);
            startJobCommand.Cluster = currentConnection.Cluster.Name;
            startJobCommand.Logger = this.Logger;
            startJobCommand.CurrentSubscription = this.CurrentSubscription;
            startJobCommand.JobDefinition = jobDefinition;
            this.ValidateNotCanceled();
            await startJobCommand.EndProcessing();
            return startJobCommand.Output.Last();
        }

        protected virtual async Task<AzureHDInsightJob> WaitForCompletion(
            AzureHDInsightJob startedJob, AzureHDInsightClusterConnection currentConnection)
        {
            startedJob.ArgumentNotNull("startedJob");
            currentConnection.ArgumentNotNull("currentConnection");
            this.ValidateNotCanceled();
            var waitJobCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateWaitJobs();
            waitJobCommand.JobStatusEvent += this.ClientOnJobStatus;
            this.SetClient(waitJobCommand);
            waitJobCommand.Job = startedJob;
            waitJobCommand.Logger = this.Logger;
            waitJobCommand.WaitTimeoutInSeconds = WaitAnHourInSeconds;
            waitJobCommand.CurrentSubscription = this.CurrentSubscription;
            this.ValidateNotCanceled();
            await waitJobCommand.ProcessRecord();
            return waitJobCommand.Output.Last();
        }

        protected virtual async Task WriteJobFailure(AzureHDInsightJob completedJob, AzureHDInsightClusterConnection currentConnection)
        {
            completedJob.ArgumentNotNull("completedJob");
            currentConnection.ArgumentNotNull("currentConnection");
            this.WriteOutput("Hive query failed.");
            this.WriteOutput(Environment.NewLine);
            this.ValidateNotCanceled();
            var getJobOutputCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGetJobOutput();
            this.SetClient(getJobOutputCommand);
            getJobOutputCommand.JobId = completedJob.JobId;
            getJobOutputCommand.Logger = this.Logger;
            getJobOutputCommand.OutputType = JobOutputType.StandardError;
            getJobOutputCommand.CurrentSubscription = this.CurrentSubscription;
            getJobOutputCommand.Cluster = currentConnection.Cluster.Name;
            this.ValidateNotCanceled();
            await getJobOutputCommand.EndProcessing();
            var outputStream = getJobOutputCommand.Output.First();
            string content = new StreamReader(outputStream).ReadToEnd();
            this.WriteOutput(content);
        }

        protected virtual async Task WriteJobSuccess(AzureHDInsightJob completedJob, AzureHDInsightClusterConnection currentConnection)
        {
            completedJob.ArgumentNotNull("completedJob");
            currentConnection.ArgumentNotNull("currentConnection");
            this.WriteOutput("Hive query completed Successfully");
            this.WriteOutput(Environment.NewLine);
            this.ValidateNotCanceled();
            var getJobOutputCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGetJobOutput();
            this.SetClient(getJobOutputCommand);
            getJobOutputCommand.JobId = completedJob.JobId;
            getJobOutputCommand.Logger = this.Logger;
            getJobOutputCommand.CurrentSubscription = this.CurrentSubscription;
            getJobOutputCommand.Cluster = currentConnection.Cluster.Name;
            this.ValidateNotCanceled();
            await getJobOutputCommand.EndProcessing();
            var outputStream = getJobOutputCommand.Output.First();
            string content = new StreamReader(outputStream).ReadToEnd();
            this.WriteOutput(content);
        }

        protected virtual void WriteOutput(string content, params string[] args)
        {
            if (args.Any())
            {
                content = string.Format(CultureInfo.InvariantCulture, content, args);
            }

            this.Output.Add(content);
        }

        private void ClientOnJobStatus(object sender, WaitJobStatusEventArgs waitJobStatusEventArgs)
        {
            this.JobDetailsStatus = waitJobStatusEventArgs.JobDetails;
        }

        private Stream GetStreamForText(string textContents)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(textContents);
            var stream = new MemoryStream(bytes, 0, bytes.Length);
            return stream;
        }

        private AzureHDInsightHiveJobDefinition UploadFileToStorage(
            AzureHDInsightHiveJobDefinition jobDefinition, AzureHDInsightClusterConnection currentConnection)
        {
            currentConnection.Cluster.DefaultStorageAccount.ArgumentNotNull("DefaultStorageAccount");
            WabStorageAccountConfiguration storageAccount = currentConnection.Cluster.DefaultStorageAccount.ToWabStorageAccountConfiguration();
            var storageHandler = ServiceLocator.Instance.Locate<IAzureHDInsightStorageHandlerFactory>().Create(storageAccount);
            string hiveQueryFilePath = string.Format(
                CultureInfo.InvariantCulture,
                HiveQueryFileStoragePath,
                currentConnection.Cluster.DefaultStorageAccount.StorageAccountName,
                currentConnection.Cluster.DefaultStorageAccount.StorageContainerName,
                currentConnection.Cluster.HttpUserName,
                Guid.NewGuid().ToString("N"));
            using (Stream hiveQueryFileStream = this.GetStreamForText(jobDefinition.Query))
            {
                var hiveQueryFileUri = new Uri(hiveQueryFilePath, UriKind.RelativeOrAbsolute);
                storageHandler.UploadFile(hiveQueryFileUri, hiveQueryFileStream);
                jobDefinition.Query = string.Empty;
                jobDefinition.File = storageHandler.GetStoragePath(hiveQueryFileUri).OriginalString;
            }

            return jobDefinition;
        }
    }
}
