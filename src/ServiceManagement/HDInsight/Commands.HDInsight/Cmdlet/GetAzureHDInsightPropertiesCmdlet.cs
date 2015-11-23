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
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.BaseInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;
using Microsoft.WindowsAzure.Management.HDInsight.Logging;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.PSCmdlets
{
    /// <summary>
    ///     Cmdlet that lists all the properties of a subscription registered with the HDInsight service.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, AzureHdInsightPowerShellConstants.AzureHDInsightProperties)]
    [OutputType(typeof(AzureHDInsightCapabilities))]
    public class GetAzureHDInsightPropertiesCmdlet : AzureHDInsightCmdlet, IAzureHDInsightCommonCommandBase
    {
        private readonly IGetAzureHDInsightPropertiesCommand command;

        /// <summary>
        ///     Initializes a new instance of the GetAzureHDInsightPropertiesCmdlet class.
        /// </summary>
        public GetAzureHDInsightPropertiesCmdlet()
        {
            this.command = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGetProperties();
        }

        /// <inheritdoc />
        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The management certificate used to manage the Azure subscription.")]
        [Alias(AzureHdInsightPowerShellConstants.AliasCert)]
        public X509Certificate2 Certificate
        {
            get { return this.command.Certificate; }
            set { this.command.Certificate = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The HostedService to use when managing the HDInsight cluster.")]
        [Alias(AzureHdInsightPowerShellConstants.AliasCloudServiceName)]
        public string HostedService
        {
            get { return this.command.HostedService; }
            set { this.command.HostedService = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The Endpoint to use when connecting to Azure.")]
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

        /// <summary>
        ///     Gets or sets a flag to only show Azure regions available to the subscription.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Flag to only show Azure regions available to the subscription.")]
        public SwitchParameter Locations { get; set; }

        /// <inheritdoc />
        [Parameter(Position = 1, Mandatory = false, HelpMessage = "The subscription id for the Azure subscription.")]
        [Alias(AzureHdInsightPowerShellConstants.AliasSub)]
        public string Subscription
        {
            get { return this.command.Subscription; }
            set { this.command.Subscription = value; }
        }

        /// <summary>
        ///     Gets or sets a flag to only show HDInsight versions available to the subscription.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Flag to only show HDInsight versions available to the subscription")]
        public SwitchParameter Versions { get; set; }

        /// <summary>
        ///     Finishes the execution of the cmdlet by listing the clusters.
        /// </summary>
        protected override void EndProcessing()
        {
            this.WriteWarning(string.Format(AzureHdInsightPowerShellConstants.AsmWarning, "Get-AzureRmHDInsightProperties"));
            this.command.Logger = this.Logger;
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
                if (this.MyInvocation.BoundParameters.ContainsKey("Debug"))
                {
                    this.WriteObject(this.command.Output.SelectMany(output => output.Capabilities));
                }
                else
                {
                    if (this.Versions.IsPresent)
                    {
                        foreach (AzureHDInsightCapabilities output in this.command.Output)
                        {
                            this.WriteObject(output.Versions);
                        }
                    }
                    else if (this.Locations.IsPresent)
                    {
                        foreach (AzureHDInsightCapabilities output in this.command.Output)
                        {
                            this.WriteObject(output.Locations);
                        }
                    }
                    else
                    {
                        foreach (AzureHDInsightCapabilities output in this.command.Output)
                        {
                            this.WriteObject(output);
                        }
                    }
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
