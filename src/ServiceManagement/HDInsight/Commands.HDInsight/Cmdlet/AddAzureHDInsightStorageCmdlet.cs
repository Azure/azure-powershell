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
    ///     Adds an AzureHDInsight Storage Account to the current configuration.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, AzureHdInsightPowerShellConstants.AzureHDInsightStorage)]
    [OutputType(typeof(AzureHDInsightConfig))]
    public class AddAzureHDInsightStorageCmdlet : AzureHDInsightCmdlet, IAddAzureHDInsightStorageBase
    {
        private readonly IAddAzureHDInsightStorageCommand command;

        /// <summary>
        ///     Initializes a new instance of the AddAzureHDInsightStorageCmdlet class.
        /// </summary>
        public AddAzureHDInsightStorageCmdlet()
        {
            this.command = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateAddStorage();
        }

        /// <summary>
        ///     Gets or sets the Azure HDInsight Configuration for the Azure HDInsight cluster being constructed.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster (created by New-AzureHDInsightConfig).",
            ValueFromPipeline = true, ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetAddStorageAccount)]
        public AzureHDInsightConfig Config
        {
            get { return this.command.Config; }
            set { this.command.Config.CopyFrom(value); }
        }

        /// <summary>
        ///     Gets or sets the Storage Account key for the storage account to be added to the cluster.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The storage account key for the storage account to be added to the new cluster.",
            ValueFromPipeline = false, ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetAddStorageAccount)]
        public string StorageAccountKey
        {
            get { return this.command.StorageAccountKey; }
            set { this.command.StorageAccountKey = value; }
        }

        /// <summary>
        ///     Gets or sets the Storage Account Name for the storage account to be added to the cluster.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The storage account name for the storage account to be added to the new cluster.",
            ValueFromPipeline = false, ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetAddStorageAccount)]
        public string StorageAccountName
        {
            get { return this.command.StorageAccountName; }
            set { this.command.StorageAccountName = value; }
        }

        /// <inheritdoc />
        protected override void EndProcessing()
        {
            try
            {
                this.WriteWarning(string.Format(AzureHdInsightPowerShellConstants.AsmWarning, "Add-AzureRmHDInsightStorage"));
                this.command.EndProcessing().Wait();
                foreach (AzureHDInsightConfig output in this.command.Output)
                {
                    this.WriteObject(output);
                }
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
