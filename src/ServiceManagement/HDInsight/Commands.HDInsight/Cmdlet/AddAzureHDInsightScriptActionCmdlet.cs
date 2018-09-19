﻿﻿// ----------------------------------------------------------------------------------  
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
namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.PSCmdlets
{
    using Commands.BaseCommandInterfaces;
    using Commands.CommandInterfaces;
    using DataObjects;
    using GetAzureHDInsightClusters;
    using GetAzureHDInsightClusters.Extensions;
    using HDInsight.Logging;
    using Microsoft.WindowsAzure.Management.HDInsight.ClusterProvisioning.Data;
    using ServiceLocation;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Reflection;
    using System.Threading.Tasks;

    /// <summary>  
    ///     Adds an AzureHDInsight script action to the AzureHDInsight configuration.  
    /// </summary>  
    [Cmdlet(VerbsCommon.Add, AzureHdInsightPowerShellConstants.AzureHDInsightScriptAction)]
    [OutputType(typeof(AzureHDInsightConfig))]
    public class AddAzureHDInsightScriptActionCmdlet : AzureHDInsightCmdlet, IAddAzureHDInsightScriptActionBase
    {
        private readonly IAddAzureHDInsightScriptActionCommand command;

        /// <summary>  
        ///     Initializes a new instance of the AddAzureHDInsightMetastoreCmdlet class.  
        /// </summary>  
        public AddAzureHDInsightScriptActionCmdlet()
        {
            this.command = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateAddScriptAction();
        }

        /// <summary>  
        ///     Gets or sets the Azure HDInsight Configuration for the Azure HDInsight cluster being constructed.  
        /// </summary>  
        [Parameter(Position = 0, Mandatory = true,
            HelpMessage = "The HDInsight cluster configuration to use when creating the new cluster (created by New-AzureHDInsightConfig).",
            ValueFromPipeline = true, ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetAddScriptAction)]
        public AzureHDInsightConfig Config
        {
            get { return this.command.Config; }
            set { this.command.Config.CopyFrom(value); }
        }

        /// <summary>  
        ///     Gets or sets the name of the script action.  
        /// </summary>  
        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the script action.",
            ValueFromPipeline = false, ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetAddScriptAction)]
        public string Name
        {
            get { return this.command.Name; }
            set { this.command.Name = value; }
        }

        /// <summary>  
        ///     Gets or sets the affected cluster roles for this script action.  
        /// </summary>  
        [Parameter(Position = 2, Mandatory = true, HelpMessage = "The affected cluster roles for this script action.",
            ValueFromPipeline = false, ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetAddScriptAction)]
        public ClusterNodeType[] ClusterRoleCollection
        {
            get { return this.command.ClusterRoleCollection; }
            set { this.command.ClusterRoleCollection = value; }
        }

        /// <summary>  
        ///     Gets or sets the uri of the script action.  
        /// </summary>  
        [Parameter(Position = 3, Mandatory = true, HelpMessage = "The uri of the script action.",
            ValueFromPipeline = false, ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetAddScriptAction)]
        public Uri Uri
        {
            get { return this.command.Uri; }
            set { this.command.Uri = value; }
        }

        /// <summary>  
        ///     Gets or sets the name of the script action.  
        /// </summary>  
        [Parameter(Position = 4, Mandatory = false, HelpMessage = "The parameters of the script action.",
            ValueFromPipeline = false, ParameterSetName = AzureHdInsightPowerShellConstants.ParameterSetAddScriptAction)]
        public string Parameters
        {
            get { return this.command.Parameters; }
            set { this.command.Parameters = value; }
        }

        /// <inheritdoc />  
        protected override void EndProcessing()
        {
            try
            {
                this.WriteWarning(string.Format(AzureHdInsightPowerShellConstants.AsmWarning, "Add-AzureRmHDInsightScriptAction"));
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