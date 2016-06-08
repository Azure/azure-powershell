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
    ///     Cmdlet that Revokes Rdp Services access to an HDInsight cluster.
    /// </summary>
    [Cmdlet(VerbsSecurity.Revoke, AzureHdInsightPowerShellConstants.AzureHdinsightRdpAccess)]
    [OutputType(typeof(AzureHDInsightCluster))]
    public class RevokeAzureHDInsightRdpAccessCmdlet : AzureHDInsightCmdlet, IManageAzureHDInsightRdpAccessBase
    {
        private readonly IManageAzureHDInsightRdpAccessCommand command;
        private bool enableRdpServices = false;

        /// <summary>
        ///     Initializes a new instance of the RevokeAzureHDInsightRdpServicesAccessCmdlet class.
        /// </summary>
        public RevokeAzureHDInsightRdpAccessCmdlet()
        {
            this.command = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateManageRdpAccess();
        }

        /// <inheritdoc />
        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The management certificate used to manage the Azure subscription.")]
        [Alias(AzureHdInsightPowerShellConstants.AliasCert)]
        public X509Certificate2 Certificate
        {
            get { return this.command.Certificate; }
            set { this.command.Certificate = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 5, Mandatory = false, HelpMessage = "The HostedService to use when managing the HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasCloudServiceName)]
        public string HostedService
        {
            get { return this.command.HostedService; }
            set { this.command.HostedService = value; }
        }

        /// <inheritdoc />
        public PSCredential RdpCredential
        {
            get { return this.command.RdpCredential; }
            set { this.command.RdpCredential = value; }
        }

        public DateTime RdpAccessExpiry
        {
            get { return this.command.RdpAccessExpiry; }
            set { this.command.RdpAccessExpiry = value; }
        }

        /// <inheritdoc />
        public bool Enable
        {
            get { return this.enableRdpServices; }
            set { this.enableRdpServices = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The Endpoint to use when connecting to Azure.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        public Uri Endpoint
        {
            get { return this.command.Endpoint; }
            set { this.command.Endpoint = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 5, Mandatory = false, HelpMessage = "Rule for SSL errors with HDInsight client.")]
        public bool IgnoreSslErrors
        {
            get { return this.command.IgnoreSslErrors; }
            set { this.command.IgnoreSslErrors = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The Location of the HDInsight cluster to Revoke rdp access to.")]
        public string Location
        {
            get { return this.command.Location; }
            set { this.command.Location = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the HDInsight cluster to Revoke rdp access to.",
            ValueFromPipeline = true)]
        [Alias(AzureHdInsightPowerShellConstants.AliasClusterName, AzureHdInsightPowerShellConstants.AliasDnsName)]
        public string Name
        {
            get { return this.command.Name; }
            set { this.command.Name = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The subscription id for the Azure subscription.")]
        [Alias(AzureHdInsightPowerShellConstants.AliasSub)]
        public string Subscription
        {
            get { return this.command.Subscription; }
            set { this.command.Subscription = value; }
        }

        /// <summary>
        ///     Finishes the execution of the cmdlet by listing the clusters.
        /// </summary>
        protected override void EndProcessing()
        {
            this.WriteWarning(string.Format(AzureHdInsightPowerShellConstants.AsmWarning, "Revoke-AzureRmHDInsightRdpServicesAccess"));
            this.command.Enable = false;
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
                foreach (AzureHDInsightCluster output in this.command.Output)
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
