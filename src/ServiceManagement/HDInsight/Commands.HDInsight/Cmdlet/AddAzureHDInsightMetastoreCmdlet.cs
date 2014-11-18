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
    ///     Adds an AzureHDInsight metastore to the AzureHDInsight configuration.
    /// </summary>
    [Cmdlet(VerbsCommon.Add, AzureHdInsightPowerShellConstants.AzureHDInsightMetastore)]
    [OutputType(typeof(AzureHDInsightConfig))]
    public class AddAzureHDInsightMetastoreCmdlet : AzureHDInsightCmdlet, IAddAzureHDInsightMetastoreBase
    {
        private readonly IAddAzureHDInsightMetastoreCommand command;

        /// <summary>
        ///     Initializes a new instance of the AddAzureHDInsightMetastoreCmdlet class.
        /// </summary>
        public AddAzureHDInsightMetastoreCmdlet()
        {
            this.command = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateAddMetastore();
        }

        /// <summary>
        ///     Gets or sets the Azure HDInsight Configuration for the Azure HDInsight cluster being constructed.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster (created by New-AzureHDInsightConfig).",
            ValueFromPipeline = true, ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetAddMetastore)]
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
                if (value.HiveMetastore.IsNotNull())
                {
                    this.command.Config.HiveMetastore = value.HiveMetastore;
                }
                if (value.OozieMetastore.IsNotNull())
                {
                    this.command.Config.OozieMetastore = value.OozieMetastore;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the user credentials to use for the Azure SQL Server database.
        /// </summary>
        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The user credentials to use for the Azure SQL Server database.",
            ValueFromPipeline = false, ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetAddMetastore)]
        public PSCredential Credential
        {
            get { return this.command.Credential; }
            set { this.command.Credential = value; }
        }

        /// <summary>
        ///     Gets or sets the Azure SQL Server database to use for this metastore.
        /// </summary>
        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The database on the Azure SQL Server instance to use for this metastore.",
            ValueFromPipeline = false, ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetAddMetastore)]
        public string DatabaseName
        {
            get { return this.command.DatabaseName; }
            set { this.command.DatabaseName = value; }
        }

        /// <summary>
        ///     Gets or sets the type of AzureHDInsight metastore represented by this object.
        /// </summary>
        [Parameter(Position = 5, Mandatory = true, HelpMessage = "The type of AzureHDInsight metastore represented by this metastore.",
            ValueFromPipeline = false, ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetAddMetastore)]
        public AzureHDInsightMetastoreType MetastoreType
        {
            get { return this.command.MetastoreType; }
            set { this.command.MetastoreType = value; }
        }

        /// <summary>
        ///     Gets or sets the Azure SQL Server to use for this metastore.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true,
                HelpMessage = "The Azure SQL Server instance to use for this metastore.",
                ValueFromPipeline = false,
                ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetAddMetastore)]
        public string SqlAzureServerName
        {
            get { return this.command.SqlAzureServerName; }
            set { this.command.SqlAzureServerName = value; }
        }

        /// <inheritdoc />
        protected override void EndProcessing()
        {
            try
            {
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
