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
    ///     Cmdlet that lists submits a jobDetails to a running HDInsight cluster.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, AzureHdInsightPowerShellConstants.AzureHDInsightJobs,
        DefaultParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetStartJobByName)]
    [OutputType(typeof(AzureHDInsightJob))]
    public class StartAzureHDInsightJobCmdlet : AzureHDInsightCmdlet, IStartAzureHDInsightJobBase
    {
        private readonly IStartAzureHDInsightJobCommand command;

        /// <summary>
        ///     Initializes a new instance of the StartAzureHDInsightJobCmdlet class.
        /// </summary>
        public StartAzureHDInsightJobCmdlet()
        {
            this.command = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateStartJob();
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The management certificate used to manage the Azure subscription.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetStartJobByNameWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasCert)]
        public X509Certificate2 Certificate
        {
            get { return this.command.Certificate; }
            set { this.command.Certificate = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The HostedService to use when connecting to the HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetStartJobByNameWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasCloudServiceName)]
        public string HostedService
        {
            get { return this.command.HostedService; }
            set { this.command.HostedService = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "the Azure HDInsight cluster to start the jobDetails on.", ValueFromPipeline = true)]
        [Alias(AzureHdInsightPowerShellConstants.AliasClusterName)]
        public string Cluster
        {
            get { return this.command.Cluster; }
            set { this.command.Cluster = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, Position = 1, HelpMessage = "The credentials to connect to Azure HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetStartJobByName)]
        [Alias(AzureHdInsightPowerShellConstants.AliasCredentials)]
        public PSCredential Credential
        {
            get { return this.command.Credential; }
            set { this.command.Credential = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The Endpoint to use when connecting to Azure.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetStartJobByNameWithSpecificSubscriptionCredentials)]
        public Uri Endpoint
        {
            get { return this.command.Endpoint; }
            set { this.command.Endpoint = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "Rule for SSL errors with HDInsight client.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetStartJobByNameWithSpecificSubscriptionCredentials)]
        public bool IgnoreSslErrors
        {
            get { return this.command.IgnoreSslErrors; }
            set { this.command.IgnoreSslErrors = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = true, Position = 2, HelpMessage = "The jobDetails definition to start on the Azure HDInsight cluster.",
            ValueFromPipeline = true)]
        [Alias(AzureHdInsightPowerShellConstants.JobDefinition)]
        public AzureHDInsightJobDefinition JobDefinition
        {
            get { return this.command.JobDefinition; }
            set { this.command.JobDefinition = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 1, Mandatory = false, HelpMessage = "The subscription id for the Azure subscription.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetStartJobByNameWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasSub)]
        public string Subscription
        {
            get { return this.command.Subscription; }
            set { this.command.Subscription = value; }
        }

        /// <inheritdoc />
        protected override void EndProcessing()
        {
            this.WriteWarning(string.Format(AzureHdInsightPowerShellConstants.AsmWarning, "Start-AzureRmHDInsightJob"));
            try
            {
                this.command.Logger = this.Logger;
                this.command.CurrentSubscription = this.GetCurrentSubscription(this.Subscription, this.Certificate);
                AzureHDInsightHiveJobDefinition jobDef = this.command.JobDefinition as AzureHDInsightHiveJobDefinition;
                //If the credential is null then they are connected to the subscription.
                if(jobDef.IsNotNull() && jobDef.Query.IsNotNullOrEmpty() && !jobDef.RunAsFileJob && this.Credential.IsNull())
                {
                    this.WriteWarning("When submitting a query use the -RunAsFile switch to prevent errors with query lengths or special characters");
                }
                else if(jobDef.IsNotNull() && jobDef.Query.IsNotNullOrEmpty() && this.Credential.IsNotNull())
                {
                    //If they are only connected to the cluster, then they should submit via file.
                    this.WriteWarning("Running queries is deprecated due to inability to process special characters and multiple lines. Please upload the query to a file in storage and re-submit the job using the -File parameter");
                }
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
