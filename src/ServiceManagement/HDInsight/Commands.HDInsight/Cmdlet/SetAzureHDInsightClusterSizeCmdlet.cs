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
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.PSCmdlets;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;
using Microsoft.WindowsAzure.Management.HDInsight.Logging;

namespace Microsoft.WindowsAzure.Commands.HDInsight.Cmdlet.PSCmdlets
{
    /// <summary>
    ///     Cmdlet that allows a user to change the size of a cluster.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "AzureHDInsightClusterSize")]
    [OutputType(typeof(AzureHDInsightCluster))]
    public class SetAzureHDInsightClusterSizeCmdlet : AzureHDInsightCmdlet
    {
        private readonly ISetAzureHDInsightClusterSizeCommand command;
        
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The new cluster size in nodes requested.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetResizingWithName)]
        [Parameter(Mandatory = true, HelpMessage = "The new cluster size in nodes requested.", ValueFromPipeline = true,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetResizingWithPiping)]
        public int ClusterSizeInNodes
        {
            get { return command.ClusterSizeInNodes; }
            set { command.ClusterSizeInNodes = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The management certificate used to manage the Azure subscription.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasCert)]
        public X509Certificate2 Certificate
        {
            get { return command.Certificate; }
            set { command.Certificate = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The subscription id for the Azure subscription.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasSub)]
        public string Subscription
        {
            get { return command.Subscription; }
            set { command.Subscription = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The Endpoint to use when connecting to Azure.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        public Uri Endpoint
        {
            get { return command.Endpoint; }
            set { command.Endpoint = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The name of the HDInsight cluster to set the size of.", ValueFromPipeline = false,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Parameter(Mandatory = true, HelpMessage = "The name of the HDInsight cluster to set the size of", ValueFromPipeline = false,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetResizingWithName)]
        [Alias(AzureHdInsightPowerShellConstants.AliasClusterName, AzureHdInsightPowerShellConstants.AliasDnsName)]
        public string Name
        {
            get { return command.Name; }
            set { command.Name = value; }
        }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetResizingWithName)]
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetResizingWithPiping)]
        public SwitchParameter Force
        {
            get { return command.Force; }
            set { command.Force = value; }
        }

        [Parameter(Mandatory=true, HelpMessage = "The HDInsight cluster to set the size of.", ValueFromPipeline = true,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetResizingWithPiping)]
        public AzureHDInsightCluster Cluster
        {
            get { return command.Cluster; }
            set { command.Cluster = value; }
        }

        public SetAzureHDInsightClusterSizeCmdlet()
        {
            command = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateSetClusterSize();
        }

        protected override void EndProcessing()
        {
            if (Cluster != null)
            {
                Name = Cluster.Name;
            }
            Name.ArgumentNotNull("Name");
            if (ClusterSizeInNodes < 1)
            {
                throw new ArgumentOutOfRangeException("ClusterSizeInNodes", "The requested ClusterSizeInNodes must be at least 1.");
            }
            try
            {
                command.Logger = Logger;
                var currentSubscription = GetCurrentSubscription(Subscription, Certificate);
                command.CurrentSubscription = currentSubscription;
                Func<Task> action = () => command.EndProcessing();
                var token = command.CancellationToken;

                //get cluster
                AzureHDInsightCluster cluster = Cluster;
                if (cluster == null)
                {
                    var getCommand = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateGet();
                    getCommand.CurrentSubscription = currentSubscription;
                    getCommand.Name = Name;
                    var getTask = getCommand.EndProcessing();
                    while (!getTask.IsCompleted)
                    {
                        WriteDebugLog();
                        getTask.Wait(1000, token);
                    }
                    if (getTask.IsFaulted)
                    {
                        throw new AggregateException(getTask.Exception);
                    }
                    if (getCommand.Output == null || getCommand.Output.Count == 0)
                    {
                        throw new InvalidOperationException(string.Format("Could not find cluster {0}", Name));
                    }
                    cluster = getCommand.Output.First();
                }

                //prep cluster resize operation
                command.Location = cluster.Location;
                if (ClusterSizeInNodes < cluster.ClusterSizeInNodes)
                {
                    var task = ConfirmSetAction(
                        "You are requesting a cluster size that is less than the current cluster size. We recommend not running jobs till the operation is complete as all running jobs will fail at end of resize operation and may impact the health of your cluster. Do you want to continue?",
                        "Continuing with set cluster operation.",
                        ClusterSizeInNodes.ToString(CultureInfo.InvariantCulture),
                        action);
                    if (task == null)
                    {
                        throw new OperationCanceledException("The change cluster size operation was aborted.");
                    }
                    while (!task.IsCompleted)
                    {
                        WriteDebugLog();
                        task.Wait(1000, token);
                    }
                    if (task.IsFaulted)
                    {
                        throw new AggregateException(task.Exception);
                    }
                }
                else
                {
                    var task = action();
                    while (!task.IsCompleted)
                    {
                        WriteDebugLog();
                        task.Wait(1000, token);
                    }
                    if (task.IsFaulted)
                    {
                        throw new AggregateException(task.Exception);
                    }
                }
                //print cluster details
                foreach (var output in command.Output)
                {
                    WriteObject(output);
                }
                WriteDebugLog();
            }
            catch (Exception ex)
            {
                var type = ex.GetType();
                Logger.Log(Severity.Error, Verbosity.Normal, FormatException(ex));
                WriteDebugLog();
                if (type == typeof (AggregateException) || type == typeof (TargetInvocationException) ||
                    type == typeof (TaskCanceledException))
                {
                    ex.Rethrow();
                }
                else
                {
                    throw;
                }
            }
            
            WriteDebugLog();
        }

        protected Task ConfirmSetAction(string actionMessage, string processMessage, string target,
            Func<Task> action)
        {
            if (Force.IsPresent || ShouldContinue(actionMessage, ""))
           {
                if (ShouldProcess(target, processMessage))
                {
                    return action();
                }
            }
            return null;
        }

        protected override void StopProcessing()
        {
            command.Cancel();
        }
    }
}
