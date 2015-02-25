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
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.BaseCommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.PSCmdlets
{
    /// <summary>
    ///     Sets the Default Storage Container for the HDInsight cluster configuration.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, AzureHdInsightPowerShellConstants.AzureHDInsightDefaultStorage)]
    [OutputType(typeof(AzureHDInsightConfig))]
    public class SetAzureHDInsightDefaultStorageCmdlet : AzureHDInsightCmdlet, ISetAzureHDInsightDefaultStorageBase
    {
        private readonly ISetAzureHDInsightDefaultStorageCommand command;

        /// <summary>
        ///     Initializes a new instance of the SetAzureHDInsightDefaultStorageCmdlet class.
        /// </summary>
        public SetAzureHDInsightDefaultStorageCmdlet()
        {
            this.command = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateSetDefaultStorage();
        }

        /// <summary>
        ///     Gets or sets the Azure HDInsight Configuration for the Azure HDInsight cluster being constructed.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster (created by New-AzureHDInsightConfig).",
            ValueFromPipeline = true, ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetDefaultStorageAccount)]
        public AzureHDInsightConfig Config
        {
            get { return this.command.Config; }
            set
            {
                if (value.IsNull())
                {
                    throw new ArgumentNullException("value", "The value for the configuration can not be null.");
                }

                this.command.Config.ClusterSizeInNodes = value.ClusterSizeInNodes;
                this.command.Config.DefaultStorageAccount = value.DefaultStorageAccount;
                this.command.Config.AdditionalStorageAccounts.AddRange(value.AdditionalStorageAccounts);
                this.command.Config.ConfigActions.AddRange(value.ConfigActions);
                this.command.Config.HiveMetastore = value.HiveMetastore ?? this.command.Config.HiveMetastore;
                this.command.Config.OozieMetastore = value.OozieMetastore ?? this.command.Config.OozieMetastore;
                this.command.Config.CoreConfiguration.AddRange(value.CoreConfiguration);
                this.command.Config.YarnConfiguration.AddRange(value.YarnConfiguration);
                this.command.Config.HdfsConfiguration.AddRange(value.HdfsConfiguration);
                this.command.Config.MapReduceConfiguration.ConfigurationCollection.AddRange(value.MapReduceConfiguration.ConfigurationCollection);
                this.command.Config.MapReduceConfiguration.CapacitySchedulerConfigurationCollection.AddRange(
                    value.MapReduceConfiguration.CapacitySchedulerConfigurationCollection);
                this.command.Config.HiveConfiguration.ConfigurationCollection.AddRange(value.HiveConfiguration.ConfigurationCollection);
                this.command.Config.OozieConfiguration.ConfigurationCollection.AddRange(value.OozieConfiguration.ConfigurationCollection);
                this.command.Config.HeadNodeVMSize = value.HeadNodeVMSize;
                this.command.Config.ClusterType = value.ClusterType;
                this.command.Config.VirtualNetworkId = value.VirtualNetworkId;
                this.command.Config.SubnetName = value.SubnetName;
                this.command.Config.StormConfiguration.AddRange(value.StormConfiguration);
                this.command.Config.HBaseConfiguration.ConfigurationCollection.AddRange(value.HBaseConfiguration.ConfigurationCollection);
            }
        }

        /// <summary>
        ///     Gets or sets the Storage Account key for the Default Storage Account.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The key to use for the default storage account.", ValueFromPipeline = false,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetDefaultStorageAccount)]
        public string StorageAccountKey
        {
            get { return this.command.StorageAccountKey; }
            set { this.command.StorageAccountKey = value; }
        }

        /// <summary>
        ///     Gets or sets the Storage Account name for the Default Storage Account.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The default storage account to use for the new cluster.", ValueFromPipeline = false,
            ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetDefaultStorageAccount)]
        public string StorageAccountName
        {
            get { return this.command.StorageAccountName; }
            set { this.command.StorageAccountName = value; }
        }

        /// <summary>
        ///     Gets or sets the Storage Account container for the Default Storage Account.
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The container in the storage account to use for default HDInsight storage.",
            ValueFromPipeline = false, ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetDefaultStorageAccount)]
        public string StorageContainerName
        {
            get { return this.command.StorageContainerName; }
            set { this.command.StorageContainerName = value; }
        }

        /// <inheritdoc />
        protected override void EndProcessing()
        {
            this.command.EndProcessing().Wait();
            foreach (AzureHDInsightConfig output in this.command.Output)
            {
                this.WriteObject(output);
            }
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
