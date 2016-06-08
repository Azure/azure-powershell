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
using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;
using Microsoft.WindowsAzure.Management.HDInsight.Logging;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.PSCmdlets
{
    /// <summary>
    ///     Cmdlet that creates a new HDInsight cluster.
    /// </summary>
    [Cmdlet(VerbsCommon.New, AzureHdInsightPowerShellConstants.AzureHDInsightCluster,
        DefaultParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
    [OutputType(typeof(AzureHDInsightCluster))]
    public class NewAzureHDInsightClusterCmdlet : AzureHDInsightCmdlet
    {
        private readonly INewAzureHDInsightClusterCommand command;

        /// <summary>
        ///     Initializes a new instance of the NewAzureHDInsightClusterCmdlet class.
        /// </summary>
        public NewAzureHDInsightClusterCmdlet()
        {
            this.command = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateCreate();
        }

        /*
         * Parameter Sets:
         * 
         * ParameterSetClusterByConfigWithSpecificSubscriptionCredentials
         *      Position 00: Name
         *      Position 01: Config
         *      Position 02: Subscription
         *      Position 03: Certificate
         *      Position 04: Location
         *      Position 05: Credential
         *      Position 06: ??? (Missed. To be fixed.)
         *      Position 07: Endpoint
         *      Position 08: HostedService
         *      Position 09: Version
         *      Position 10: OSType
         *      Position 11: SshCredential
         *      Position 12: SshPublicKey
         *      Position 13: RdpCredential
         *      Position 14: RdpAccessExpiry
         *      
         * ParameterSetClusterByNameWithSpecificSubscriptionCredentials
         *      Position 00: Name
         *      Position 01: Subscription
         *      Position 02: Certificate
         *      Position 03: Location
         *      Position 04: DefaultStorageAccountName
         *      Position 05: DefaultStorageAccountKey
         *      Position 06: DefaultStorageContainerName
         *      Position 07: Credential
         *      Position 08: ??? (Missed. To be fixed.)
         *      Position 09: ClusterSizeInNodes
         *      Position 10: Endpoint
         *      Position 11: HostedService
         *      Position 12: Version
         *      Position 13: HeadNodeVMSize
         *      Position 14: ClusterType
         *      Position 15: VirtualNetworkId
         *      Position 16: SubnetName
         *      Position 17: DataNodeVMSize
         *      Position 18: ZookeeperNodeVMSize
         *      Position 19: OSType
         *      Position 20: SshCredential
         *      Position 21: SshPublicKey
         *      Position 22: RdpCredential
         *      Position 23: RdpAccessExpiry
         */

        /// <inheritdoc />
        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The management certificate used to manage the Azure subscription.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Parameter(Position = 3, Mandatory = false, HelpMessage = "The management certificate used to manage the Azure subscription.",
            ValueFromPipeline = false,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasCert)]
        public X509Certificate2 Certificate
        {
            get { return this.command.Certificate; }
            set { this.command.Certificate = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 8, Mandatory = false, HelpMessage = "The Endpoint to use when connecting to Azure.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
        [Parameter(Position = 11, Mandatory = false, HelpMessage = "The Endpoint to use when connecting to Azure.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasCloudServiceName)]
        public string HostedService
        {
            get { return this.command.HostedService; }
            set { this.command.HostedService = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 9, Mandatory = true, HelpMessage = "The number of data nodes to use for the HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasNodes, AzureHdInsightPowerShellConstants.AliasSize)]
        public int ClusterSizeInNodes
        {
            get { return this.command.ClusterSizeInNodes; }
            set { this.command.ClusterSizeInNodes = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 1, Mandatory = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster (created by New-AzureHDInsightConfig).",
            ValueFromPipeline = true,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
        public AzureHDInsightConfig Config
        {
            get
            {
                var result = new AzureHDInsightConfig();
                result.ClusterSizeInNodes = this.command.ClusterSizeInNodes;
                result.HeadNodeVMSize = this.command.HeadNodeSize;
                result.DataNodeVMSize = this.command.DataNodeSize;
                result.ZookeeperNodeVMSize = this.command.ZookeeperNodeSize;
                result.ClusterType = this.command.ClusterType;
                result.VirtualNetworkId = this.command.VirtualNetworkId;
                result.SubnetName = this.command.SubnetName;
                result.DefaultStorageAccount.StorageAccountName = this.command.DefaultStorageAccountName;
                result.DefaultStorageAccount.StorageAccountKey = this.command.DefaultStorageAccountKey;
                result.DefaultStorageAccount.StorageContainerName = this.command.DefaultStorageContainerName;
                result.AdditionalStorageAccounts.AddRange(this.command.AdditionalStorageAccounts);
                result.ConfigActions.AddRange(this.command.ConfigActions);
                result.CoreConfiguration.AddRange(this.command.CoreConfiguration);
                result.YarnConfiguration.AddRange(this.command.YarnConfiguration);
                result.HdfsConfiguration.AddRange(this.command.HdfsConfiguration);
                result.OozieConfiguration.ConfigurationCollection.AddRange(this.command.OozieConfiguration.ConfigurationCollection);
                result.HiveConfiguration.AdditionalLibraries = this.command.HiveConfiguration.AdditionalLibraries;
                result.HiveConfiguration.ConfigurationCollection.AddRange(this.command.HiveConfiguration.ConfigurationCollection);
                result.MapReduceConfiguration.ConfigurationCollection.AddRange(this.command.MapReduceConfiguration.ConfigurationCollection);
                result.MapReduceConfiguration.CapacitySchedulerConfigurationCollection.AddRange(
                    this.command.MapReduceConfiguration.CapacitySchedulerConfigurationCollection);
                result.StormConfiguration.AddRange(this.command.StormConfiguration);
                result.SparkConfiguration.AddRange(this.command.SparkConfiguration);
                result.HBaseConfiguration.AdditionalLibraries = this.command.HBaseConfiguration.AdditionalLibraries;
                result.HBaseConfiguration.ConfigurationCollection.AddRange(this.command.HBaseConfiguration.ConfigurationCollection);

                return result;
            }

            set
            {
                if (value.IsNull())
                {
                    throw new ArgumentNullException("value", "The value for the configuration can not be null.");
                }
                this.command.ClusterSizeInNodes = value.ClusterSizeInNodes;
                this.command.ClusterType = value.ClusterType;
                this.command.VirtualNetworkId = value.VirtualNetworkId;
                this.command.SubnetName = value.SubnetName;
                this.command.HeadNodeSize = value.HeadNodeVMSize;
                this.command.DataNodeSize = value.DataNodeVMSize;
                this.command.ZookeeperNodeSize = value.ZookeeperNodeVMSize;
                this.command.DefaultStorageAccountName = value.DefaultStorageAccount.StorageAccountName;
                this.command.DefaultStorageAccountKey = value.DefaultStorageAccount.StorageAccountKey;
                this.command.DefaultStorageContainerName = value.DefaultStorageAccount.StorageContainerName;
                this.command.AdditionalStorageAccounts.AddRange(value.AdditionalStorageAccounts);
                this.command.ConfigActions.AddRange(value.ConfigActions);
                this.command.CoreConfiguration.AddRange(value.CoreConfiguration);
                this.command.YarnConfiguration.AddRange(value.YarnConfiguration);
                this.command.HdfsConfiguration.AddRange(value.HdfsConfiguration);
                this.command.MapReduceConfiguration.ConfigurationCollection.AddRange(value.MapReduceConfiguration.ConfigurationCollection);
                this.command.MapReduceConfiguration.CapacitySchedulerConfigurationCollection.AddRange(
                    value.MapReduceConfiguration.CapacitySchedulerConfigurationCollection);
                this.command.HiveConfiguration.AdditionalLibraries = value.HiveConfiguration.AdditionalLibraries;
                this.command.HiveConfiguration.ConfigurationCollection.AddRange(value.HiveConfiguration.ConfigurationCollection);
                this.command.OozieConfiguration.ConfigurationCollection.AddRange(value.OozieConfiguration.ConfigurationCollection);
                this.command.OozieConfiguration.AdditionalSharedLibraries = value.OozieConfiguration.AdditionalSharedLibraries;
                this.command.OozieConfiguration.AdditionalActionExecutorLibraries = value.OozieConfiguration.AdditionalActionExecutorLibraries;
                this.command.HiveMetastore = value.HiveMetastore;
                this.command.OozieMetastore = value.OozieMetastore;
                this.command.StormConfiguration.AddRange(value.StormConfiguration);
                this.command.SparkConfiguration.AddRange(value.SparkConfiguration);
                this.command.HBaseConfiguration.AdditionalLibraries = value.HBaseConfiguration.AdditionalLibraries;
                this.command.HBaseConfiguration.ConfigurationCollection.AddRange(value.HBaseConfiguration.ConfigurationCollection);
            }
        }

        /// <inheritdoc />
        [Parameter(Position = 7, Mandatory = true, HelpMessage = "The user credentials for the HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Parameter(Position = 5, Mandatory = true, HelpMessage = "The user credentials for the HDInsight cluster.", ValueFromPipeline = false,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasCredentials)]
        public PSCredential Credential
        {
            get { return this.command.Credential; }
            set { this.command.Credential = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 5, Mandatory = true, HelpMessage = "The key to use for the default storage account.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasStorageKey)]
        public string DefaultStorageAccountKey
        {
            get { return this.command.DefaultStorageAccountKey; }
            set { this.command.DefaultStorageAccountKey = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 4, Mandatory = true, HelpMessage = "The default storage account to use for the new cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasStorageAccount)]
        public string DefaultStorageAccountName
        {
            get { return this.command.DefaultStorageAccountName; }
            set { this.command.DefaultStorageAccountName = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 6, Mandatory = true, HelpMessage = "The container in the storage account to use for default HDInsight storage.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasStorageContainer)]
        public string DefaultStorageContainerName
        {
            get { return this.command.DefaultStorageContainerName; }
            set { this.command.DefaultStorageContainerName = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 7, Mandatory = false, HelpMessage = "The Endpoint to use when connecting to Azure.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
        [Parameter(Position = 10, Mandatory = false, HelpMessage = "The Endpoint to use when connecting to Azure.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        public Uri EndPoint
        {
            get { return this.command.Endpoint; }
            set { this.command.Endpoint = value; }
        }

        [Parameter(Position = 19, Mandatory = false, HelpMessage = "Rule for SSL errors with HDInsight client.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
        [Parameter(Position = 19, Mandatory = false, HelpMessage = "Rule for SSL errors with HDInsight client.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        public bool IgnoreSslErrors
        {
            get { return this.command.IgnoreSslErrors; }
            set { this.command.IgnoreSslErrors = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The azure location where the new cluster should be created.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Parameter(Position = 4, Mandatory = true, HelpMessage = "The azure location where the new cluster should be created.",
            ValueFromPipeline = false,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasLoc)]
        public string Location
        {
            get { return this.command.Location; }
            set { this.command.Location = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the HDInsight cluster to locate.", ValueFromPipeline = true,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the HDInsight cluster to locate.", ValueFromPipeline = false,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasClusterName, AzureHdInsightPowerShellConstants.AliasDnsName)]
        public string Name
        {
            get { return this.command.Name; }
            set { this.command.Name = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 1, Mandatory = false, HelpMessage = "The subscription id for the Azure subscription.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Parameter(Position = 2, Mandatory = false, HelpMessage = "The subscription id for the Azure subscription.", ValueFromPipeline = false,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasSub)]
        public string Subscription
        {
            get { return this.command.Subscription; }
            set { this.command.Subscription = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 12, Mandatory = false, HelpMessage = "The version of the HDInsight cluster to create.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Parameter(Position = 9, Mandatory = false, HelpMessage = "The version of the HDInsight cluster to create.", ValueFromPipeline = false,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
        [Alias(AzureHdInsightPowerShellConstants.AliasVersion)]
        public string Version
        {
            get { return this.command.Version; }
            set { this.command.Version = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 13, Mandatory = false, HelpMessage = "The size of the headnode VM.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        public string HeadNodeVMSize
        {
            get { return this.command.HeadNodeSize; }
            set { this.command.HeadNodeSize = value; }
        }

         /// <inheritdoc />
        [Parameter(Position = 14, Mandatory = false, HelpMessage = "The type HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        public ClusterType ClusterType
        {
            get { return this.command.ClusterType; }
            set { this.command.ClusterType = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 15, Mandatory = false, HelpMessage = "GUID of virtual network to deploy HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        public string VirtualNetworkId
        {
            get { return this.command.VirtualNetworkId; }
            set { this.command.VirtualNetworkId = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 16, Mandatory = false, HelpMessage = "Name of subnet to deploy HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        public string SubnetName
        {
            get { return this.command.SubnetName; }
            set { this.command.SubnetName = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 17, Mandatory = false, HelpMessage = "The size of the datanode VM.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        public string DataNodeVMSize
        {
            get { return this.command.DataNodeSize; }
            set { this.command.DataNodeSize = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 18, Mandatory = false, HelpMessage = "The size of the zookeeper VM.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        public string ZookeeperNodeVMSize
        {
            get { return this.command.ZookeeperNodeSize; }
            set { this.command.ZookeeperNodeSize = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 10, Mandatory = false, HelpMessage = "The type of operating system to install on cluster nodes.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
        [Parameter(Position = 19, Mandatory = false, HelpMessage = "The type of operating system to install on cluster nodes.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        public OSType OSType
        {
            get { return this.command.OSType; }
            set { this.command.OSType = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 11, Mandatory = false, HelpMessage = "The credentials for SSH access to the cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
        [Parameter(Position = 20, Mandatory = false, HelpMessage = "The credentials for SSH access to the cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        public PSCredential SshCredential
        {
            get { return this.command.SshCredential; }
            set { this.command.SshCredential = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 12, Mandatory = false, HelpMessage = "The public key to use to configure SSH access to the cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
        [Parameter(Position = 21, Mandatory = false, HelpMessage = "The public key to use to configure SSH access to the cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        public string SshPublicKey
        {
            get { return this.command.SshPublicKey; }
            set { this.command.SshPublicKey = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 22, Mandatory = false, HelpMessage = "The credentials for RDP access to the HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Parameter(Position = 13, Mandatory = false, HelpMessage = "The credentials for RDP access to the HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
        public PSCredential RdpCredential
        {
            get { return this.command.RdpCredential; }
            set { this.command.RdpCredential = value; }
        }

        /// <inheritdoc />
        [Parameter(Position = 23, Mandatory = false, HelpMessage = "The expiry for RDP access to the HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByNameWithSpecificSubscriptionCredentials)]
        [Parameter(Position = 14, Mandatory = false, HelpMessage = "The expiry for RDP access to the HDInsight cluster.",
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetClusterByConfigWithSpecificSubscriptionCredentials)]
        public DateTime? RdpAccessExpiry
        {
            get { return this.command.RdpAccessExpiry; }
            set { this.command.RdpAccessExpiry = value; }
        }

        /// <inheritdoc />
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        /// <inheritdoc />
        protected override void EndProcessing()
        {
            this.WriteWarning(string.Format(AzureHdInsightPowerShellConstants.AsmWarning, "New-AzureRmHDInsightCluster"));
            DateTime start = DateTime.Now;
            string msg = string.Format(CultureInfo.CurrentCulture, "Create Cluster Started : {0}", start.ToString(CultureInfo.CurrentCulture));
            this.Logger.Log(Severity.Informational, Verbosity.Detailed, msg);
            try
            {
                this.command.Logger = this.Logger;
                this.command.CurrentSubscription = this.GetCurrentSubscription(this.Subscription, this.Certificate);
                Task task = this.command.EndProcessing();
                CancellationToken token = this.command.CancellationToken;
                while (!task.IsCompleted)
                {
                    this.WriteDebugLog();
                    msg = string.Format(CultureInfo.CurrentCulture, "Creating Cluster: {0}", this.Name);
                    this.WriteProgress(new ProgressRecord(0, msg, this.command.State.ToString()));
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
            msg = string.Format(CultureInfo.CurrentCulture, "Create Cluster Stopped : {0}", DateTime.Now.ToString(CultureInfo.CurrentCulture));
            this.Logger.Log(Severity.Informational, Verbosity.Detailed, msg);
            msg = string.Format(
                CultureInfo.CurrentCulture,
                "Create Cluster Executed for {0} minutes",
                (DateTime.Now - start).TotalMinutes.ToString(CultureInfo.CurrentCulture));
            this.Logger.Log(Severity.Informational, Verbosity.Detailed, msg);
            this.WriteDebugLog();
        }

        /// <inheritdoc />
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
        }

        /// <inheritdoc />
        protected override void StopProcessing()
        {
            this.command.Cancel();
        }
    }
}
