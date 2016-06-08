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
using System.Globalization;
using System.Management.Automation;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.BaseCommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;
using Microsoft.WindowsAzure.Management.HDInsight.Logging;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.PSCmdlets
{
    /// <summary>
    ///     Cmdlet that lists all the Jobs running on a HDInsight cluster.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, AzureHdInsightPowerShellConstants.AzureHDInsightJobs,
        DefaultParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetJobHistoryByName)]
    [OutputType(typeof(AzureHDInsightJob))]
    public class WaitAzureHDInsightJobCmdlet : AzureHDInsightCmdlet, IWaitAzureHDInsightJobBase
    {
        private readonly IWaitAzureHDInsightJobCommand command;

        /// <summary>
        ///     Initializes a new instance of the WaitAzureHDInsightJobCmdlet class.
        /// </summary>
        public WaitAzureHDInsightJobCmdlet()
        {
            this.command = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateWaitJobs();
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The management certificate used to manage the Azure subscription.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetJobHistoryByNameWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasCert)]
        public X509Certificate2 Certificate
        {
            get { return this.command.Certificate; }
            set { this.command.Certificate = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The HostedService to use when managing the HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetJobHistoryByNameWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasCloudServiceName)]
        public string HostedService
        {
            get { return this.command.HostedService; }
            set { this.command.HostedService = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = true, HelpMessage = "The name of the cluster the Job is running on", ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = true, ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetWaitJobById)]
        public string Cluster
        {
            get { return this.command.Cluster; }
            set { this.command.Cluster = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, Position = 1, HelpMessage = "The credentials to connect to Azure HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetJobHistoryByName)]
        [Parameter(Mandatory = false, HelpMessage = "The credentials to connect to Azure HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetWaitJobByJob)]
        [Parameter(Mandatory = false, HelpMessage = "The credentials to connect to Azure HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetWaitJobById)]
        [Alias(AzureHdInsightPowerShellConstants.AliasCredentials)]
        public PSCredential Credential
        {
            get { return this.command.Credential; }
            set { this.command.Credential = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The Endpoint to use when connecting to Azure.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetJobHistoryByNameWithSpecificSubscriptionCredentials)]
        public Uri Endpoint
        {
            get { return this.command.Endpoint; }
            set { this.command.Endpoint = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "Rule for SSL errors with HDInsight client.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetJobHistoryByNameWithSpecificSubscriptionCredentials)]
        public bool IgnoreSslErrors
        {
            get { return this.command.IgnoreSslErrors; }
            set { this.command.IgnoreSslErrors = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = true, HelpMessage = "The Jobs to wait for.", ValueFromPipeline = true,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetWaitJobByJob)]
        [Parameter(Mandatory = true, HelpMessage = "The Jobs to wait for.", ValueFromPipeline = true,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetJobHistoryByNameWithSpecificSubscriptionCredentials)]
        public AzureHDInsightJob Job
        {
            get { return this.command.Job; }
            set
            {
                this.command.Job = value;
                if (value.IsNotNull())
                {
                    this.command.JobId = this.command.Job.JobId;
                    this.command.Cluster = this.command.Job.Cluster;
                }
            }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = true, HelpMessage = "The Id of the Job to wait for.", ValueFromPipelineByPropertyName = true, ValueFromPipeline = true,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetWaitJobById)]
        public string JobId
        {
            get { return this.command.JobId; }
            set { this.command.JobId = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The subscription id for the Azure subscription.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetJobHistoryByNameWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasSub)]
        public string Subscription
        {
            get { return this.command.Subscription; }
            set { this.command.Subscription = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The number of seconds to wait for completion, before cancelling waiting.",
            ValueFromPipeline = true)]
        public double WaitTimeoutInSeconds
        {
            get { return this.command.WaitTimeoutInSeconds; }
            set { this.command.WaitTimeoutInSeconds = value; }
        }

        /// <inheritdoc />
        protected override void EndProcessing()
        {
            this.WriteWarning(string.Format(AzureHdInsightPowerShellConstants.AsmWarning, "Wait-AzureRmHDInsightJob"));
            try
            {
                this.command.Logger = this.Logger;
                this.command.CurrentSubscription = this.GetCurrentSubscription(this.Subscription, this.Certificate);
                Task task = this.command.EndProcessing();
                CancellationToken token = this.command.CancellationToken;
                while (!task.IsCompleted)
                {
                    this.WriteDebugLog();
                    task.Wait(1000, token);
                }
                if (task.IsFaulted)
                {
                    throw new AggregateException(task.Exception);
                }
                foreach (AzureHDInsightJob output in this.command.Output)
                {
                    this.WriteObject(output);
                }
                this.WriteDebugLog();
            }
            catch (AggregateException ex)
            {
                this.WriteObject(this.FormatException(ex));
                this.Logger.Log(Severity.Error, Verbosity.Normal, this.FormatException(ex));
                throw ex.InnerException;
            }
            this.WriteDebugLog();
        }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            DateTime start = DateTime.Now;
            string msg = string.Format(CultureInfo.CurrentCulture, "Waiting for jobDetails Started : {0}", start.ToString(CultureInfo.CurrentCulture));
            this.Logger.Log(Severity.Informational, Verbosity.Detailed, msg);
            try
            {
                this.command.Logger = this.Logger;
                this.command.CurrentSubscription = this.GetCurrentSubscription(this.Subscription, this.Certificate);
                Task task = this.command.ProcessRecord();
                CancellationToken token = this.command.CancellationToken;
                while (!task.IsCompleted)
                {
                    this.WriteDebugLog();
                    if (this.command.JobDetailsStatus.IsNotNull())
                    {
                        msg = string.Format(CultureInfo.CurrentCulture, "Waiting for jobDetails : {0}", this.JobId);
                        var record = new ProgressRecord(
                            0, msg, this.command.JobDetailsStatus.StatusCode.ToString() + " : " + this.command.JobDetailsStatus.PercentComplete);
                        this.WriteProgress(record);
                    }
                    task.Wait(1000, token);
                }
                this.WriteDebugLog();
            }
            catch (Exception ex)
            {
                Type type = ex.GetType();
                this.Logger.Log(Severity.Error, Verbosity.Normal, this.FormatException(ex));
                this.WriteDebugLog();
                if (type == typeof(AggregateException) || type == typeof(TargetInvocationException) || type == typeof(TaskCanceledException))
                {
                    ex.Rethrow();
                }
                else
                {
                    throw;
                }
            }
            msg = string.Format(CultureInfo.CurrentCulture, "Waiting for jobDetails Stopped : {0}", DateTime.Now.ToString(CultureInfo.CurrentCulture));
            this.Logger.Log(Severity.Informational, Verbosity.Detailed, msg);
            msg = string.Format(
                CultureInfo.CurrentCulture,
                "Waiting for jobDetails Executed for {0} minutes",
                (DateTime.Now - start).TotalMinutes.ToString(CultureInfo.CurrentCulture));
            this.Logger.Log(Severity.Informational, Verbosity.Detailed, msg);
            this.WriteDebugLog();
        }

        /// <inheritdoc />
        protected override void StopProcessing()
        {
            this.command.Cancel();
        }
    }
}
