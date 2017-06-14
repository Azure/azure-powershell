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

using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Management.Automation;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.BaseCommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.DataObjects;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.PSCmdlets
{
    /// <summary>
    ///     Represents the New-AzureHDInsightConfig Power Shell Cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.New, AzureHdInsightPowerShellConstants.AzureHDInsightStreamingMapReduceJobDefinition)]
    [OutputType(typeof(AzureHDInsightStreamingMapReduceJobDefinition))]
    public class NewAzureHDInsightStreamingJobDefinitionCmdlet : AzureHDInsightCmdlet, INewAzureHDInsightStreamingJobDefinitionBase
    {
        private readonly INewAzureHDInsightStreamingJobDefinitionCommand command;

        /// <summary>
        ///     Initializes a new instance of the NewAzureHDInsightStreamingJobDefinitionCmdlet class.
        /// </summary>
        public NewAzureHDInsightStreamingJobDefinitionCmdlet()
        {
            this.command = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewStreamingMapReduceDefinition();
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The parameters for the jobDetails.")]
        [Alias(AzureHdInsightPowerShellConstants.AliasArguments)]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Need collections for input parameters")]
        public string[] Arguments
        {
            get { return this.command.Arguments; }
            set { this.command.Arguments = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The command line environment for the mappers or the reducers.")]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Need collections for input parameters")]
        public string[] CmdEnv
        {
            get { return this.command.CmdEnv; }
            set { this.command.CmdEnv = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The Combiner to use for the jobDetails.")]
        public string Combiner
        {
            get { return this.command.Combiner; }
            set { this.command.Combiner = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The parameters for the jobDetails.")]
        [Alias(AzureHdInsightPowerShellConstants.AliasParameters)]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Need collections for input parameters")]
        public Hashtable Defines
        {
            get { return this.command.Defines; }
            set { this.command.Defines = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The resources for the jobDetails.")]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Need collections for input parameters")]
        public string[] Files
        {
            get { return this.command.Files; }
            set { this.command.Files = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The input path to use for the jobDetails.")]
        [Alias(AzureHdInsightPowerShellConstants.AliasInput)]
        public string InputPath
        {
            get { return this.command.InputPath; }
            set { this.command.InputPath = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The name of the jobDetails.")]
        [Alias(AzureHdInsightPowerShellConstants.AliasJobName)]
        public string JobName
        {
            get { return this.command.JobName; }
            set { this.command.JobName = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The Mapper to use for the jobDetails.")]
        public string Mapper
        {
            get { return this.command.Mapper; }
            set { this.command.Mapper = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The output path to use for the jobDetails.")]
        [Alias(AzureHdInsightPowerShellConstants.AliasOutput)]
        public string OutputPath
        {
            get { return this.command.OutputPath; }
            set { this.command.OutputPath = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The Reducer to use for the jobDetails.")]
        public string Reducer
        {
            get { return this.command.Reducer; }
            set { this.command.Reducer = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The output location to use for the jobDetails.")]
        public string StatusFolder
        {
            get { return this.command.StatusFolder; }
            set { this.command.StatusFolder = value; }
        }

        /// <summary>
        ///     Finishes the execution of the cmdlet by writing out the config object.
        /// </summary>
        protected override void EndProcessing()
        {
            this.WriteWarning(string.Format(AzureHdInsightPowerShellConstants.AsmWarning, "New-AzureRmHDInsightStreamingMapReduceJobDefinition"));
            this.command.EndProcessing().Wait();
            foreach (AzureHDInsightStreamingMapReduceJobDefinition output in this.command.Output)
            {
                this.WriteObject(output);
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
