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

using System.Diagnostics.CodeAnalysis;
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
    ///     Represents the New-AzureHDInsightSqoopJobDefinition Power Shell Cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.New, AzureHdInsightPowerShellConstants.AzureHDInsightSqoopJobDefinition)]
    [OutputType(typeof(AzureHDInsightSqoopJobDefinition))]
    public class NewAzureHDInsightSqoopJobDefinitionCmdlet : AzureHDInsightCmdlet, INewAzureHDInsightSqoopJobDefinitionBase
    {
        private readonly INewAzureHDInsightSqoopJobDefinitionCommand command;

        /// <summary>
        ///     Initializes a new instance of the NewAzureHDInsightSqoopJobDefinitionCmdlet class.
        /// </summary>
        public NewAzureHDInsightSqoopJobDefinitionCmdlet()
        {
            this.command = ServiceLocator.Instance.Locate<IAzureHDInsightCommandFactory>().CreateNewSqoopDefinition();
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The command to run in the sqoop job.")]
        public string Command
        {
            get { return this.command.Command; }
            set { this.command.Command = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The query file to run in the sqoop job.")]
        [Alias(AzureHdInsightPowerShellConstants.AliasQueryFile)]
        public string File
        {
            get { return this.command.File; }
            set { this.command.File = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The files for the sqoop job.")]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Need collections for input parameters")]
        public string[] Files
        {
            get { return this.command.Files; }
            set { this.command.Files = value; }
        }

        /// <inheritdoc />
        [Parameter(Mandatory = false, HelpMessage = "The output location to use for the job.")]
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
            this.WriteWarning(string.Format(AzureHdInsightPowerShellConstants.AsmWarning, "New-AzureRmHDInsightSqoopJobDefinition"));
            if (this.File.IsNullOrEmpty() && this.Command.IsNullOrEmpty())
            {
                throw new PSArgumentException("Either File or Command should be specified for Sqoop jobs.");
            }

            this.command.EndProcessing().Wait();
            foreach (AzureHDInsightSqoopJobDefinition output in this.command.Output)
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
