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
    [Cmdlet(VerbsCommon.Get, AzureHdInsightPowerShellConstants.AzureHDInsightJobs,
        DefaultParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetJobHistoryByName)]
    [OutputType(typeof(AzureHDInsightJob))]
    public class GetAzureHDInsightJobCmdlet : AzureHDInsightCmdlet, IGetAzureHDInsightJobBase
    {
        private readonly IGetAzureHDInsightJobCommand command;

        /// <summary>
        ///     Initializes a new instance of the GetAzureHDInsightJobCmdlet class.
        /// </summary>
        public GetAzureHDInsightJobCmdlet()
        {
            this.command = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGetJobs();
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
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The endpoint to connect to the Azure HDInsight cluster.", ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [Alias(AzureHdInsightPowerShellConstants.AliasClusterName)]
        public string Cluster
        {
            get { return this.command.Cluster; }
            set { this.command.Cluster = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, Position = 1, HelpMessage = "The credentials to connect to Azure HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetJobHistoryByName)]
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
        [Parameter(Mandatory = false, HelpMessage = "Rule for SSL errors with HDInsight client.")]
        public bool IgnoreSslErrors
        {
            get { return this.command.IgnoreSslErrors; }
            set { this.command.IgnoreSslErrors = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The JobID of the jobDetails to get details for.", ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [Alias(AzureHdInsightPowerShellConstants.JobId)]
        public string JobId
        {
            get { return this.command.JobId; }
            set { this.command.JobId = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 1, Mandatory = false, HelpMessage = "The subscription id for the Azure subscription.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetJobHistoryByNameWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasSub)]
        public string Subscription
        {
            get { return this.command.Subscription; }
            set { this.command.Subscription = value; }
        }

        /// <inheritdoc />
        protected override void EndProcessing()
        {
            try
            {
                this.WriteWarning(string.Format(AzureHdInsightPowerShellConstants.AsmWarning, "Get-AzureRmHDInsightJob"));
                this.command.CurrentSubscription = this.GetCurrentSubscription(this.Subscription, this.Certificate);
                this.command.Logger = this.Logger;
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
            this.WriteDebugLog();
        }

        /// <inheritdoc />
        protected override void StopProcessing()
        {
            this.command.Cancel();
        }
    }
}
